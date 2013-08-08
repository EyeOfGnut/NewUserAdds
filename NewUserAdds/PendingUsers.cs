using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;

namespace NewUserAdds
{
    /// <summary>
    /// Displays a list of pending users, and hosts the interface for deleteing, updating, and processing them.
    /// </summary>
    public partial class PendingUsers : Form
    {
        private static System.Collections.Generic.List<Person> pList = null;
        private static LotusNotesConnection notesConnection;
        private BackgroundWorker bgWorker;

        /// <summary>
        /// Override the Form.CreateParams method to remove flickering on Draw
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                // Windows Extended Styles
                //http://msdn.microsoft.com/en-us/library/windows/desktop/ff700543%28v=vs.85%29.aspx
                //
                //cp.ExStyle |= 0x02000000; //WS_EX_COMPOSITIED - double-buffers and paints bottom object to top, so top-layer objects are overdrawn.
                cp.ExStyle |= NewUserAdds.Classes.ExtendedWindowStyles.WS_EX_COMPOSITED;
                return cp;
            }
        }


        /// <summary>
        /// Default constructor. DO NOT USE.
        /// Pending Users List needs to be initialized with data.
        /// Use PendingUsers(DataTable) instead.
        /// </summary>
        public PendingUsers()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            bgWorker = new BackgroundWorker();
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.DoWork += bgWorker_DoWork;
            bgWorker.RunWorkerCompleted += bgWorker_RunWorkerCompleted;

            progressBar.Font_Style = FontStyle.Bold;
        }

        /// <summary>
        /// Constructer for the Pending User List
        /// </summary>
        /// <param name="list">List&lt;Person&gt; containing the list of pending users</param>
        public PendingUsers(System.Collections.Generic.List<Person> list) : this()
        {
            pList = list;
            LoadTable();

#if DEBUG
            sndEmailsBtn.Visible = true;
            toDo.Visible = toDo.Enabled = true;
#endif
        }

        /// <summary>
        /// Constructor for the Pending User List
        /// </summary>
        /// <param name="list">List of Person objects</param>
        /// <param name="nConn">Lotus Notes connection object</param>
        public PendingUsers(System.Collections.Generic.List<Person> list, LotusNotesConnection nConn)
            : this(list)
        {
            notesConnection = nConn;
        }

        #region BG Worker Methods
        void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Visible = false;
        }

        void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int expCount = 0;
            Boolean aa = false;
            progressBar.Invoke(new Action(() =>
            {
                progressBar.Message = "Setting CSV File Path";
                progressBar.Visible = true;
                progressBar.Value = 0;
                progressBar.Maximum = 8;
                progressBar.Step = 1;

                progressBar.PerformStep();
            }));

            string csvFile = @"C:\axolotl\users\PendingElysiumUsers.csv";

            if (!Directory.Exists(Path.GetDirectoryName(csvFile)))
            {
                progressBar.Invoke(new Action(() =>
                {
                    progressBar.Maximum++;
                    progressBar.Message = "Creating CSV Folder and file";
                    progressBar.PerformStep();
                }));
                Directory.CreateDirectory(Path.GetDirectoryName(csvFile));
            }

            this.Invoke(new Action(() => updatePB("Writing to Log")));

            Utils.addAuditInfo(pList);
            this.Invoke(new Action(() => updatePB("Writing CSV file")));
            expCount = Utils.writeCSV(pList, csvFile, false);

            this.Invoke(new Action(() => updatePB("Importing CSV into Notes")));

            this.Invoke(new Action(() =>
                {
                    notesConnection.ImportCSV();
                    updatePB("Processing all new users into Address Book in Notes");
                    notesConnection.ProcessAllPending();
                    notesConnection.RefreshUsers();
                    this.Cursor = Cursors.Default; 
                    updatePB("Done Exporting");
                }));

            // Check and see if there are any non-Fax accounts. If so, show the Emails button.
            // Otherwise, all the new accounts are Fax only, and there's nobody to send an email to
            this.Invoke(new Action(() => updatePB("Checking for VHR/EW accounts")));

            foreach (Person person in pList)
            {
                if (!person.Fax)
                {
                    if (person.Internal && (!person.JobCategory.Equals("Staff-I") || person.Ordering))
                        aa = true;

                    if (!sndEmailsBtn.Visible)
                        sndEmailsBtn.Invoke(new Action(() => sndEmailsBtn.Visible = true));
                }
                else aa = true;

                if (sndEmailsBtn.Visible && aa) break;
            }

            this.Invoke(new Action(() => updatePB("Exported " + expCount.ToString() + " users to Lotus Notes.")));

            if (aa) this.Invoke((MethodInvoker)(()=>startAfterActions()));
        }

        private void updatePB(String message)
        {
            progressBar.Invoke(new Action(() =>
                {
                    progressBar.Message = message;
                    progressBar.PerformStep();
                }));
        }
        #endregion

        /// <summary>
        /// Loads the List Control with the pending list data.
        /// Checks to be sure that the pending list has been initialized through the constructor.
        /// </summary>
        public void LoadTable()
        {
            if (pList == null)
                MessageBox.Show("Error, Pending List uninitialized.");
            else
            {
                pendingList.Items.Clear();
                int i = 0;
                foreach (Person person in pList)
                {
                    string[] del = { "DELETE" };
                    ListViewItem lvi = new ListViewItem(del, "",  Color.Red, Color.FromArgb(0xD1EEEE), new Font(DefaultFont, FontStyle.Bold));
                    lvi.UseItemStyleForSubItems = false;
                      
                    if (i % 2 == 0)
                        lvi.BackColor = Color.FromArgb(0xD1EEEE);
                    else
                        lvi.BackColor = Color.Honeydew;

                    string fName = person.FirstName;
                    if(person.Float)
                        fName += person.ClinicAbbr.ToUpper();

                    string fullName = person.LastName + ", " + fName + " " + person.MiddleInitial;
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, fullName.Trim(), Color.Black, lvi.BackColor, new Font(DefaultFont, FontStyle.Regular)));
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, Utils.fixUserType(person.UserType), Color.Black, lvi.BackColor, new Font(DefaultFont, FontStyle.Regular)));
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, person.CompanyName, Color.Black, lvi.BackColor, new Font(DefaultFont, FontStyle.Regular)));
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, person.JobCategory, Color.Black, lvi.BackColor, new Font(DefaultFont, FontStyle.Regular)));
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, Path.GetFileName(person.ARForm), Color.Blue, lvi.BackColor, new Font(DefaultFont, FontStyle.Regular)));
                    lvi.SubItems.Add(person.ARForm);
                    lvi.SubItems.Add(i.ToString());
                    lvi.SubItems.Add(pList.IndexOf(person).ToString()); // Row index
                    
                    pendingList.Items.Add(lvi); // Add the item to the List Control
                    i++;
                }
            }

        }
        
        /// <summary>
        /// Determines which cell was click, and reacts accordingly.
        /// </summary>
        private void pendingList_MouseDown(object sender, MouseEventArgs e)
        {
            var info = pendingList.HitTest(e.Location);
            DialogResult result;
            if (info.SubItem != null)
            {
                if (info.Item.SubItems[0] == info.SubItem) //Delete was clicked
                {
                    {
                        result = MessageBox.Show(this, "Delete " + info.Item.SubItems[1].Text + " " + info.Item.SubItems[3].Text + "?",
                                "Delete Pending User", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                        if (result == DialogResult.Yes)
                        {
                            pList.RemoveAt(Convert.ToInt16(info.Item.SubItems[8].Text));
                            pendingList.Items.RemoveAt(Convert.ToInt16(info.Item.SubItems[7].Text));
                            LoadTable();
                        }
                    }
                }
                else if (info.Item.SubItems[5] == info.SubItem) //ARF link was clicked
                {
                    try
                    {
                        System.Diagnostics.Process.Start(info.Item.SubItems[info.Item.SubItems.Count - 3].Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error opening file " + info.Item.SubItems[info.Item.SubItems.Count - 3].Text + ": " + ex.Message);
                    }
                }
                else //Open Edit dialog
                {
                    result = MessageBox.Show(this, "Edit " + info.Item.SubItems[1].Text + "?",
                        "Edit Pending User", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        int rowIndex = Convert.ToInt16(info.Item.SubItems[info.Item.SubItems.Count - 1].Text);
                        editPendingUser editForm = new editPendingUser(pList[rowIndex]);
                        //editPendingUser editForm = new editPendingUser(pList, Convert.ToInt16(rowIndex));
                        editForm.ShowDialog();
                        pList.RemoveAt(rowIndex);
                        pList.Add(editForm.person);
                        LoadTable();
                        editForm = null;
                    }
                }
            }
        }

        /// <summary>
        /// Export the user list to a CSV file, for re-import into Notes
        /// </summary>
        private void expUsers_Click(object sender, EventArgs e)
        {
            bgWorker.RunWorkerAsync();
        }

        private void startAfterActions()
        {
            AfterActions actions = new AfterActions(pList);
            actions.Show();
            Application.OpenForms["AfterActions"].BringToFront();
        }

        /// <summary>
        /// Starts the Email form for account notification
        /// </summary>
        private void sndEmailsBtn_Click(object sender, EventArgs e)
        {
            if (pList.Count > 0)
            {
                SendNotificationEmails emails = new SendNotificationEmails(pList);
                emails.ShowDialog();
                LoadTable();
            }
            else { MessageBox.Show(this, "No Emails to send", "No users added", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        ListViewItem.ListViewSubItem mHovered;
        private void pendingList_MouseMove(object sender, MouseEventArgs e)
        {
            var info = pendingList.HitTest(e.Location);
            if (info.SubItem == mHovered) return;
            mHovered = null;
            pendingList.Cursor = Cursors.Default;
            if (info.SubItem != null)
            {
                if (info.Item.SubItems[5] == info.SubItem && !string.IsNullOrEmpty(info.SubItem.Text))
                {
                    pendingList.Cursor = Cursors.Hand;
                    mHovered = info.SubItem;
                }
                else if (info.Item.SubItems[0] == info.SubItem)
                {
                    pendingList.Cursor = Cursors.Hand;
                    mHovered = info.SubItem;
                }
            }
        }

        private void clrPendingBtn_Click(object sender, EventArgs e)
        {
            pList.Clear();
            LoadTable();
            progressBar.Value = 0;
            progressBar.Visible = false;
        }

        private void toDo_Click(object sender, EventArgs e)
        {
            startAfterActions();
        }    
    }
}
