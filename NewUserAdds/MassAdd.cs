using System;
using System.Collections.Specialized;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using NewUserAdds.Data_Sets;

namespace NewUserAdds
{
    public partial class MassAdd : Form
    {
        private List<Person> pList;
        private int ssn;

        private int count = 0;

        /// <summary>
        /// Returns the number of users added via Mass Add
        /// </summary>
        public int UserCount
        {
            get { return this.count; }
        }

        /// <summary>
        /// Form to allow adding bulk users to a single ECD
        /// </summary>
        public MassAdd()
        {
            InitializeComponent();
        } 
        
        /// <summary>
        /// Form to allow adding bulk users to a single ECD
        /// </summary>
        /// <param name="list">Person list for processing the new users</param>
        /// <param name="ssnEnd">Next SSN suffix to use</param>
        public MassAdd(List<Person> list, int ssnEnd)
            : this()
        {
            pList = list;
            ssn = ssnEnd;
        }

        private void MassAdd_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'clinicsDataSet.Clinics' table. You can move, or remove it, as needed.
            if (DesignMode) return;
            //massAddList = new ListViewEx();
            this.clinicsTableAdapter.Fill(this.clinicsDataSet.Clinics);
            clinicComboBox.DataSource = clinicsTableAdapter.GetFMG();
            fmgBtn.Checked = true;
            wkstnBtn.Checked = true;

            #region ListViewEx Loading

            massAddList.AddSubItem = true;
            massAddList.HideComboAfterSelChange = true;
            massAddList.HideCheckAfterChange = true;

            massAddList.AddEditableCell(-1, 0);
            massAddList.AddEditableCell(-1, 1);
            massAddList.AddEditableCell(-1, 2);

            StringCollection jobs = new StringCollection();
            jobs.AddRange(new string[] { "Staff-I", "LHP"});
            massAddList.AddComboBoxCell(-1, 3, jobs);

            //Add all the Degrees in the SQL server
            DegreesDataSet degreesDataSet = new DegreesDataSet();
            NewUserAdds.Data_Sets.DegreesDataSetTableAdapters.DegreesTableAdapter degrees = new NewUserAdds.Data_Sets.DegreesDataSetTableAdapters.DegreesTableAdapter();
            degrees.Fill(degreesDataSet.Degrees);
            massAddList.AddComboBoxCell(-1, 4, degrees.GetLHP());

            massAddList.AddCheckBoxGroup(-1, 5);

            #endregion
        }

        private void fillFMGToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.clinicsTableAdapter.FillFMG(this.clinicsDataSet.Clinics);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillFMGToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.clinicsTableAdapter.FillFMG(this.clinicsDataSet.Clinics);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fmgBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (fmgBtn.Checked)
            {
                if (vhrBtn.Checked) clinicComboBox.DataSource = this.clinicsTableAdapter.GetFMG();
                else clinicComboBox.DataSource = this.clinicsTableAdapter.GetFMGEW();
            }
            else
            {
                if (vhrBtn.Checked) clinicComboBox.DataSource = this.clinicsTableAdapter.GetComm();
                else clinicComboBox.DataSource = this.clinicsTableAdapter.GetCommEW();

                MessageBox.Show("Warning: Cannot automaticlly send emails");
            }
            clinicComboBox.Refresh();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            progressBar.Step = 100 / massAddList.Items.Count;
            progressBar.Visible = true;

            foreach (ListViewItem item in massAddList.Items)
            {
                if (!String.IsNullOrEmpty(item.SubItems[0].Text))
                {
                    Person person = new Person();
                    person.LastName = item.SubItems[0].Text;
                    person.FirstName = item.SubItems[1].Text;
                    person.MiddleInitial = item.SubItems[2].Text;
                    person.JobCategory = fixJobCategory(item.SubItems[3].Text);
                    if(item.SubItems[4].Tag != null)
                        person.Degree = item.SubItems[4].Tag.ToString();

                    person.Password = Utils.RandomString(10);
                    person.Float = false;
                    person.Specialty = person.SpecialtyId = string.Empty;
                    person.Title = string.Empty;
                    person.Npi = string.Empty;
                    person.Email = string.Empty;
                    person.SSN = Utils.genSSN(ssn++, Utils.getAdminNumberKey());

                    person.UserType = setUserType();
                    setAddOns(person, item.SubItems[5].Tag.ToString());

                    person.Manager = clncMgrText.Text;
                    person.setClinicInfo(clinicComboBox.SelectedValue.ToString());
                    person.genShortName();
                    person.Internal = fmgBtn.Checked;
                    person.NotesConnection = newUserMain.notesConnection;

                    pList.Add(person);
                    progressBar.PerformStep();
                    count++;
                }

            }
            this.Close();
        }

        private string fixJobCategory(string category)
        {
            if (category == "LHP") return "Licensed Health Professional";
            else return "Staff-I";
        }

        private string setUserType()
        {
            if (wkstnBtn.Checked) return "EW";
            else return "ERep";
        }

        private void setAddOns(Person person, string addOns)
        {
            int value = Convert.ToInt32(addOns);
            if (value >= 8) { person.EditPatientIndex = true; value -= 8; }
            if (value >= 4) { person.Repository = true; value -= 4; }
            if (value >= 2) { person.Ordering = true; value -= 2; }
            if (value >= 1) { person.PrescriptionWriter = true; }
        }

        private void vhrBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (vhrBtn.Checked)
            {
                if (commBtn.Checked) clinicComboBox.DataSource = this.clinicsTableAdapter.GetComm();
                else clinicComboBox.DataSource = this.clinicsTableAdapter.GetFMG();
            }
            else
            {
                if (commBtn.Checked)  clinicComboBox.DataSource = this.clinicsTableAdapter.GetCommEW();
                else clinicComboBox.DataSource = this.clinicsTableAdapter.GetFMGEW();
            }
            clinicComboBox.Refresh();
        }
    }
}
