using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace NewUserAdds
{
    enum Categories : int
    {
        Fax, Ordering, CPI_Exception, Prescribing, Float, Unauthorized
    }

    /// <summary>
    /// Display a window of actions that need to be performed on the new accounts, that cannot be done from this program
    /// </summary>
    public partial class AfterActions : Form
    {        
        /// <summary>
        /// Override the Form.CreateParams method to remove flickering on Draw
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= NewUserAdds.Classes.ExtendedWindowStyles.WS_EX_TOPMOST;
                return cp;
            }
        }


        private class ToDo
        {
            public string Category { get { return category.ToString(); } }
            public Categories CatEnum { get { return category; } }

            private string username;
            public string UserName { get { return username; } }

            private string clinicName;
            public string ClinicName { get { return clinicName; } }

            public bool Status = false;
            Categories category;

            public ToDo(Categories cat, string name)
            {
                category = cat;
                username = name;
            }

            public ToDo(Categories cat, string name, string clinic) : this(cat, name)
            {
                clinicName = clinic;
            }

            
        }

        private List<ToDo> toDoList = new List<ToDo>();


        /// <summary>
        /// Display a To-Do list for final processing that must be done by hand
        /// </summary>
        /// <param name="list">The list of accounts added</param>
        public AfterActions(List<Person> list)
        {
            InitializeComponent();

            this.toDoListView.CellToolTip.Font = new Font("Tahoma", 10);
            this.toDoListView.CellToolTipShowing += new EventHandler<ToolTipShowingEventArgs>(toDoListView_CellToolTipShowing);

            this.toDoListView.BooleanCheckStateGetter = delegate(object rowObject)
            {
                return ((ToDo)rowObject).Status;
            };

            this.toDoListView.BooleanCheckStatePutter = delegate(object rowObject, Boolean value)
            {
                ((ToDo)rowObject).Status = value;
                if (value == true)
                {
                    toDoList.Remove((ToDo)rowObject);
                    toDoListView.BuildList(true);
                    if (toDoListView.GetItemCount() < 1)
                    {
                        this.Close();
                    }
                }
                return value;
            };

            foreach (Person p in list)
            {
                if (p.Fax) { toDoList.Add(new ToDo(Categories.Fax, _GenDisplayName(p), (String.IsNullOrEmpty(p.Location)? p.CompanyName : p.Location))); }
                else
                {
                    // Community users don't get anything that requires after-add actions.
                    if (p.Internal)
                    {
                        // CPI Exception for LHP and Provider
                        if (!p.JobCategory.Equals("Staff-I"))
                        {
                            toDoList.Add(new ToDo(Categories.CPI_Exception, _GenDisplayName(p), (String.IsNullOrEmpty(p.Location) ? p.CompanyName : p.Location)));
                        }

                        // Add to Ordering Catalog
                        if (p.Ordering)
                        {
                            toDoList.Add(new ToDo(Categories.Ordering, _GenDisplayName(p), (String.IsNullOrEmpty(p.Location) ? p.CompanyName : p.Location)));
                        }

                        // Contact Axolotl for SureScripts setup
                        if (p.JobCategory.Equals("Medical Doctor"))
                        {
                            if(p.UserType == "EW")
                                toDoList.Add(new ToDo(Categories.Unauthorized, _GenDisplayName(p), (String.IsNullOrEmpty(p.Location) ? p.CompanyName : p.Location)));

                            if(p.PrescriptionWriter)
                                toDoList.Add(new ToDo(Categories.Prescribing, _GenDisplayName(p), (String.IsNullOrEmpty(p.Location) ? p.CompanyName : p.Location)));
                        }

                        // Float accounts need their password expiration set
                        if (p.Float) { toDoList.Add(new ToDo(Categories.Float, _GenDisplayName(p), (String.IsNullOrEmpty(p.Location) ? p.CompanyName : p.Location))); }
                    }
                }
            }
        }

        private string _GenDisplayName(Person p)
        {
            return (p.LastName + ", " + p.FirstName + " " + p.MiddleInitial).Trim();
        }

        private void AfterActions_Load(object sender, EventArgs e)
        {
            this.toDoListView.SetObjects(toDoList);
            this.toDoListView.BuildGroups(this.category, SortOrder.Descending);
        }

        private void toDoListView_CellToolTipShowing(object sender, ToolTipShowingEventArgs e)
        {
            ToDo td = (ToDo)e.Item.RowObject;

            switch (td.CatEnum)
            {
                case Categories.CPI_Exception:
                    e.Text = "Add user to the CPI Exception policy in ea\\administration.nsf\n";
                    e.IsBalloon = true;
                    e.StandardIcon = ToolTipControl.StandardIcons.Info;
                    e.Title = "'Break the Glass' Excpetion";
                    break;
                case Categories.Fax:
                    e.Text = "Run the 'Set Fax' agent on the account.\nThere is a button for this on the Elysium Users view, or" +
                        " use 'Actions->Other', then select 'Set Fax Address LD'\n\n";
                    e.IsBalloon = true;
                    e.StandardIcon = ToolTipControl.StandardIcons.Info;
                    e.Title = "Set Fax Address";
                    break;
                case Categories.Float:
                    e.Text = "Set the new float account's password expiration date to\nthe same as the main account in the (WSP) view\n\n";
                    e.IsBalloon = true;
                    e.StandardIcon = ToolTipControl.StandardIcons.Info;
                    e.Title = "Set Password Expiration Date";
                    break;
                case Categories.Ordering:
                    e.Text = "Add user to the Ordering Catalog under the appropriate clinic.\nThe catalog is ea\\radcat\\ordering.nsf\n\n";
                    e.IsBalloon = true;
                    e.StandardIcon = ToolTipControl.StandardIcons.Info;
                    e.Title = "Add to Order Placers";
                    break;
                case Categories.Prescribing:
                    e.Text = "Clone an 'Add eRx' case in Axolotl's ticketing system to\nadd SureScripts et. al. to the provider's account\n\n";
                    e.IsBalloon = true;
                    e.StandardIcon = ToolTipControl.StandardIcons.Info;
                    e.Title = "Create 'Add eRx' Axolotl Case";
                    break;
                case Categories.Unauthorized:
                    e.Text = "Check the Unauthorized Provider list for the new user's name.\nFHSAdmin/CHIW, ES\\ECroute.nsf\n\n";
                    e.IsBalloon = true;
                    e.StandardIcon = ToolTipControl.StandardIcons.Info;
                    e.Title = "Check Unauthorized list";
                    break;
                default:
                    e.Text = "Unknown To-Do Category";
                    e.IsBalloon = true;
                    e.StandardIcon = ToolTipControl.StandardIcons.Warning;
                    e.Title = "Error";
                    e.ForeColor = Color.Red;
                    break;
            }
        }
    }
}
