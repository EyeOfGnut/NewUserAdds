using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewUserAdds
{
    /// <summary>
    /// Add new users to Elysium.
    /// </summary>
    public partial class newUserMain : Form
    {
        PendingUsers puForm = null;        
        //private DataTable pendingTbl;
        private List<Person> pList = new List<Person> { };
        private bool autoRep = false;

        /// <summary>
        /// Last-used SSN number
        /// </summary>
        private static int ssnEnd = 0; //SSN offset, the last two digits of the SSN

        /// <summary>
        /// Returns the last-used SSN
        /// </summary>
        public static int SSNEnd
        {
            get { return ssnEnd; }
        }

        private int adminKey = 0; //The admin user's SSN tag, the third-to-last digit. Shows who made the user account.

        /// <summary>
        /// Connection to Notes server
        /// </summary>
        public static LotusNotesConnection notesConnection;
        
        // Readonly can be initialized at declaration, OR in the constructor. Other than that, it's a Constant.
        private readonly int mdIndex; 
        private readonly int lhpIndex;
        private readonly int ewIndex;
        private readonly int repIndex;
        private readonly int faxIndex;

        private HelpProvider help = new HelpProvider();

        /// <summary>
        /// Initialize the Data Table for user data, and set the initial dropdown and SSN values
        /// </summary>
        public newUserMain()
        {
            InitializeComponent();

            mdIndex = jobCategoryDropDown.FindStringExact("Medical Doctor");
            lhpIndex = jobCategoryDropDown.FindStringExact("Licensed Health Professional");
            ewIndex = userTypeDropDown.FindString("Workstation");
            repIndex = userTypeDropDown.FindString("Repository");
            faxIndex = userTypeDropDown.FindString("Fax");

#if DEBUG
            help.HelpNamespace = System.IO.Path.GetFullPath(@"C:\Users\smountjo\Documents\Visual Studio 2010\Projects\NewUserAdds\New_Users_Help.chm");
#else
            help.HelpNamespace = System.IO.Path.Combine(Application.StartupPath, "New_Users_Help.chm");
#endif

            adminKey = Utils.getAdminNumberKey(); //Gets the appropriate Admin User SSN tag from the xml settings file
            
            userTypeDropDown.SelectedIndex = 0;
            jobCategoryDropDown.SelectedIndex = 0;
            fNameTT.SetToolTip(this.firstName, "User's First Name");

            // Set the Combo Box style to keep users from typing their own values into the field. Allowing it causes null ref.
            // errors, as hand-entered values are unknown to other methods and classes.
            userTypeDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            jobCategoryDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            clinicDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            specialtyDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            transCB.DropDownStyle = ComboBoxStyle.DropDownList;
            degreeDropDown.DropDownStyle = ComboBoxStyle.DropDownList;

            specialtyDropDown.SelectedIndex = -1;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'degreesDataSet.Degrees' table. You can move, or remove it, as needed.
            this.degreesTableAdapter.Fill(this.degreesDataSet.Degrees);
            this.specialtiesTableAdapter1.Fill(this.specialtiesDataSet.Specialties);
            this.clinicsTableAdapter1.FillFMG(this.clinicsDataSet.Clinics);
            clinicDropDown.DataSource = clinicsTableAdapter1.GetFMG();

            arfLabel.Links.Clear();
            clinicDropDown_SelectedIndexChanged(null, null);
            localUser();

            //Generate an SSN for the current day and admin user. If the date matches (YYMMdd), then
            // use the stored SSN for the current SSN offset
            // I.E. create 3 users, leaving the program with 120202504 as the next ssn.
            //      Start the program again on the same day, and 120202504 will automatically be set as the next SSN.
            //      Start on the next day, and 120203500 will be the next SSN.
            string tmp = Utils.genSSN(ssnEnd, adminKey);
            if (Properties.Settings.Default.LastSSN.Length > 7)
            {
                if (tmp.Substring(0, 7) == Properties.Settings.Default.LastSSN.Substring(0, 7))
                {
                    ssnEnd = Convert.ToInt16(Properties.Settings.Default.LastSSN.Substring(7, 2));
                }
            }

            updateSSNToolStrip(0);
            
            // Connect to Notes
            notesConnection = new LotusNotesConnection();

            if (!notesConnection.StartSession())
            {
                #if !DEBUG // Don't force Notes login if in DEBUG mode.
                    Application.Exit();
                    Close();
                #endif
            }
        }

        /// <summary>
        /// Populate the Degree dropdown based on MD or LHP job category.
        /// Also show the Specialty, DEA, and NPI boxes for MD
        /// </summary>
       private void jobCategoryDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (jobCategoryDropDown.SelectedIndex == mdIndex)
            {
                degreeDropDown.Visible = degreeLabel.Visible = true;
                this.Height = 444;
                if (userTypeDropDown.SelectedIndex != userTypeDropDown.FindString("Repository"))
                    providerGrpBx.Visible = true;
                else
                    providerGrpBx.Visible = false;

                specialtyDropDown.SelectedIndex = -1;

                degreeDropDown.DataSource = degreesTableAdapter.GetMD();
                degreeDropDown.SelectedIndex = 0;
            }
            else if (jobCategoryDropDown.SelectedIndex == lhpIndex)
            {
                degreeDropDown.Visible = degreeLabel.Visible = true;
                providerGrpBx.Visible = false;
                this.Height = 370;

                degreeDropDown.DataSource = degreesTableAdapter.GetLHP();
                degreeDropDown.SelectedIndex = 0;
            }
            else
            {
                degreeDropDown.Visible = degreeLabel.Visible = false;
                providerGrpBx.Visible = false;
                this.Height = 370;
            }
        }

        /// <summary>
        /// Show or hide the appropriate Clinic Data fields based on the user type
        /// </summary>
        private void userTypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userTypeDropDown.SelectedIndex == userTypeDropDown.FindString("Fax"))
            {
                loginClncGrp.Visible = false;
                floatCheckBox.Checked = false;
                floatCheckBox.Visible = false;
                addOnGroupBox.Visible = false;
                repChkBx.Checked = false;
                epiChkBx.Checked = false;
                rxChkBx.Checked = false;
                ioChkBx.Checked = false;
                this.Width = 778;

                fNameTT.SetToolTip(this.firstName, "Set to \"Referral\" if not for a specific provider");
                if(string.IsNullOrEmpty(firstName.Text))
                    firstName.Text = "Referral";


                fNameTT.Show("Set to \"Referral\" if not for a specific provider", firstName, 1500);
                faxClncGrp.Visible = true;
                
            }
            else
            {
                loginClncGrp.Visible = true;
                floatCheckBox.Visible = true;
                repChkBx.Checked = true;
                if (userTypeDropDown.SelectedIndex == userTypeDropDown.FindString("Repository"))
                {
                    addOnGroupBox.Visible = false;
                    floatCheckBox.Checked = false;
                    floatCheckBox.Visible = false;
                    this.Width = 778;
                    ecdLabel.Visible = false;
                    if (jobCategoryDropDown.SelectedIndex == jobCategoryDropDown.FindString("Medical Doctor"))
                        providerGrpBx.Visible = false;
                }
                else
                {
                    if (fmgRB.Checked)
                        floatCheckBox.Visible = true;
                    else
                        floatCheckBox.Visible = false;

                    addOnGroupBox.Visible = true;
                    this.Width = 880;
                    ecdLabel.Visible = true;
                    if (jobCategoryDropDown.SelectedIndex == jobCategoryDropDown.FindString("Medical Doctor"))
                        providerGrpBx.Visible = true;
                }

                faxClncGrp.Visible = false;


                fNameTT.SetToolTip(this.firstName, "User's First Name");
                if (firstName.Text == "Referral")
                    firstName.Text = string.Empty;
            }

        }

        /// <summary>
        /// Show the email address field if this is a Community account
        /// </summary>
        private void commRB_CheckedChanged(object sender, EventArgs e)
        {
            if (commRB.Checked == true)
            {
                if (userTypeDropDown.SelectedIndex == userTypeDropDown.FindString("Fax"))
                    emailText.Visible = emailText.Enabled = emailLabel.Visible = emailLabel.Enabled = false;
                else
                    emailText.Visible = emailText.Enabled = emailLabel.Visible = emailLabel.Enabled = true;

                floatCheckBox.Visible = floatCheckBox.Checked = false;

                ssoIdLbl.Visible = ssoIdTxtBx.Visible = false;
                ssoIdTxtBx.Text = string.Empty;

                clinicDropDown.DataSource = this.clinicsTableAdapter1.GetComm();
            }
            else
            {
                emailText.Visible = emailText.Enabled = emailLabel.Visible = emailLabel.Enabled = false;
                if (userTypeDropDown.SelectedIndex == userTypeDropDown.FindString("Workstation"))
                    floatCheckBox.Visible = true;
                else
                    floatCheckBox.Visible = false;

                clinicDropDown.DataSource = this.clinicsTableAdapter1.GetFMG();
                ssoIdLbl.Visible = ssoIdTxtBx.Visible = true;
            }
        }

        /// <summary>
        /// Show the list of Pending Users
        /// </summary>
        private void pendingBtn_Click(object sender, EventArgs e)
        {
            //Check if the Pending Users Form has been created, or previously disposed of
            if (puForm == null || puForm.IsDisposed)
            {
                puForm = new PendingUsers(pList, notesConnection);
                puForm.Show();
            }
            else //If the Pending Users Form is already open, bring it to the front
            {
                puForm.Focus();
            }

        }
       
        /// <summary>
        /// Adds the pending user information to the user data table
        /// </summary>
        private void addUserBtn_Click(object sender, EventArgs e)
        {
            //DataRow newRow = pendingTbl.NewRow();
            Person newUser = new Person();

            //Validating entered Data.
            if (validateData(userTypeDropDown.SelectedIndex, jobCategoryDropDown.SelectedIndex))
            {
                if (adminAccountsBlastToolStripMenuItem.Checked)
                {
                    blastAdminAccounts();
                }
                else
                {
                    newUser.FirstName = firstName.Text.Trim();
                    newUser.LastName = lastName.Text.Trim();

                    /*
                     * Check if the account is a Fax account or not. If it IS a fax account,
                     * show the Clinic address/phone/fax fields for unique entry. Otherwise,
                     * Fax accounts will be dependant on clinic information that is in the SQL DB.
                     * Since Fax accounts are 99% NOT for clinics in the SQL DB, clinic info needs to be 
                     * entered by hand.
                     */
                    if (userTypeDropDown.SelectedIndex != faxIndex)
                    {
                        // Get the selected clinic's information from the SQL DB, and 
                        // put it into a string array
                        newUser.setClinicInfo(clinicDropDown.SelectedValue.ToString());

                        if (floatCheckBox.Checked)
                        {
                            newUser.Float = true;
                            if (string.IsNullOrEmpty(fltPwText.Text))
                                newUser.Password = Utils.RandomString(10);
                            else
                                newUser.Password = fltPwText.Text;
                        }
                        else
                        {
                            newUser.Float = false;
                            newUser.Password = Utils.RandomString(10); // Generate a random 10-character password
                        }
                    }
                    else
                    {
                        newUser.Fax = true;
                        newUser.CompanyName = clinicText.Text;
                        newUser.PhoneNumber = phoneText.Text;
                        newUser.FaxNumber = faxText.Text;
                        newUser.StreetAddress = addressText.Text;
                        newUser.City = cityText.Text;
                        newUser.State = stateText.Text;
                        newUser.Zip = zipText.Text;
                        newUser.Country = "USA";
                        newUser.Ecd = string.Empty;
                        newUser.ClinicId = string.Empty;
                    }



                    if (jobCategoryDropDown.SelectedIndex == mdIndex)
                    {
                        newUser.Degree = degreeDropDown.SelectedValue.ToString();

                        if (specialtyDropDown.SelectedIndex != -1)
                        {
                            string[] specInfo = Utils.getSpecialtyInfo(specialtyDropDown.SelectedValue.ToString().Trim());
                            newUser.Specialty = specInfo[1];
                            newUser.SpecialtyId = specInfo[0];
                            newUser.Credential5 = specInfo[2];
                        }
                        if (transCB.SelectedItem != null)
                            newUser.Credential6 = transCB.SelectedItem.ToString();
                        newUser.LocalId = starIdTxt.Text;
                        newUser.Upin = upinTxt.Text;

                    }
                    else if (jobCategoryDropDown.SelectedIndex == lhpIndex)
                    {
                        newUser.Degree = degreeDropDown.SelectedValue.ToString();
                        newUser.Specialty = newUser.SpecialtyId = string.Empty;
                    }
                    else
                    {
                        newUser.Specialty = newUser.SpecialtyId = newUser.Degree = string.Empty;
                    }

                    newUser.EditPatientIndex = epiChkBx.Checked;
                    newUser.Ordering = ioChkBx.Checked;
                    newUser.Repository = repChkBx.Checked;
                    newUser.PrescriptionWriter = rxChkBx.Checked;

                    newUser.MiddleInitial = middleInitial.Text;
                    newUser.Title = string.Empty; //Can put in Jr, Sr, etc later

                    // If we're at a new day from the last time we added a user, reset the counter to 0
                    if (Convert.ToInt32(DateTime.Now.ToString("yyMMdd")) != Convert.ToInt32(sSNToolStripMenuItem.Text.Substring(5, 6)))
                        ssnEnd = 0;

                    newUser.SSN = Utils.genSSN(ssnEnd, adminKey);

                    newUser.UserType = userTypeDropDown.SelectedItem.ToString();
                    newUser.Dea = deaText.Text;

                    newUser.JobCategory = jobCategoryDropDown.SelectedItem.ToString();
                    newUser.Npi = npiText.Text;
                    newUser.Email = emailText.Text;
                    newUser.Manager = clncMgrTxt.Text;
                    newUser.Task = taskTxt.Text;
                    if (arfLabel.Links.Count != 0)
                        newUser.ARForm = arfLabel.Links[0].LinkData.ToString();

                    newUser.Internal = fmgRB.Checked; // Internal or External account?
                    newUser.NotesConnection = notesConnection;

                    newUser.genShortName(); // Gen the short-name first, so any changes will be reflected in the backup

                    newUser.SSOID = ssoIdTxtBx.Text;
                    pList.Add(newUser);

                    backUpPending();


                    if (floatCheckBox.Checked)
                    {
                        DialogResult result = MessageBox.Show(this, "Added a float account for " + lastName.Text + ", "
                                + firstName.Text + "\nAdd another float account?",
                               "Added Pending Float User", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result != DialogResult.Yes)
                        {
                            clearTextBoxes();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Added " + lastName.Text + ", " + firstName.Text);
                        clearTextBoxes();
                    }
                    updateSSNToolStrip(1);
                }
                //Refresh the pending users list to add the new user
                if (puForm != null)
                    puForm.LoadTable();
            }
        }

        /// <summary>
        /// Update the SSN Tool Strip, and incriment the SSN End
        /// </summary>
        /// <param name="count">Number of users added</param>
        public void updateSSNToolStrip(int count)
        {
            sSNToolStripMenuItem.Text = "SSN: " + Utils.genSSN((ssnEnd += count), adminKey);
        }

        /// <summary>
        /// Clears all the text entry fields, resets combo boxes
        /// </summary>
        private void clearTextBoxes()
        {
            userTypeDropDown.SelectedIndex = 0;
            emailText.Text = string.Empty;
            npiText.Text = string.Empty;
            deaText.Text = string.Empty;
            starIdTxt.Text = string.Empty;
            specialtyDropDown.SelectedIndex = 0;
            floatCheckBox.Checked = false;
            jobCategoryDropDown.SelectedIndex = 0;
            lastName.Text = string.Empty;
            middleInitial.Text = string.Empty;
            firstName.Text = string.Empty;
            clinicDropDown.SelectedIndex = 0;
            clinicText.Text = string.Empty;
            phoneText.Text = string.Empty;
            faxText.Text = string.Empty;
            addressText.Text = string.Empty;
            cityText.Text = string.Empty;
            zipText.Text = string.Empty;
            stateText.Text = "WA";
            fltPwText.Text = string.Empty;
            clncMgrTxt.Text = string.Empty;
            arfLabel.Links.Clear();
            arfLabel.Visible = false;
            arfButton.Text = "Link to Request Form";
            taskTxt.Text = string.Empty;
            fmgRB.Select();
            repChkBx.Checked = false;
            epiChkBx.Checked = false;
            rxChkBx.Checked = false;
            ioChkBx.Checked = false;
            ssoIdTxtBx.Text = string.Empty;

            clinicDropDown.DataSource = clinicsTableAdapter1.GetFMG();
        }

        /// <summary>
        /// Actions to take when the status of the Float Checkbox changed
        /// Checked: show the float password box
        /// Unchecked: hide the float password box
        /// </summary>
        private void floatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (floatCheckBox.Checked)
                fltPwText.Visible = fltPwLabel.Visible = true;
            else
                fltPwText.Visible = fltPwLabel.Visible = false;
        }

        /// <summary>
        /// Updates labels etc. when a clinic is selected from the drop down.
        /// </summary>
        private void clinicDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clinicDropDown.SelectedValue != null)
            {
                bool wsAcct = (userTypeDropDown.SelectedIndex == userTypeDropDown.FindString("Workstation"));

                string[] clinicInfo = Utils.getClinicInfo(clinicDropDown.SelectedValue.ToString());

                // Set the SSO Label color if this is an Epic clinic.
                ssoIdLbl.ForeColor = (Int32.Parse(clinicInfo[(int)Utils.ClinicTable.Epic].Trim()) == 1)? Color.Red : Color.Black;

                // Set the account type to Respository if there is no ECD
                if (clinicInfo[(int)Utils.ClinicTable.ECD].Trim().Length > 1)
                {
                    if (wsAcct || autoRep)
                    {
                        ecdLabel.Text = "ECD: " + clinicInfo[9];
                        ecdLabel.Visible = true;
                        if (autoRep)
                        {
                            autoRep = false;
                            userTypeDropDown.SelectedIndex = userTypeDropDown.FindString("Workstation");
                        }
                    }
                }
                else
                {
                    if (wsAcct)
                    {
                        autoRep = true;
                        userTypeDropDown.SelectedIndex = userTypeDropDown.FindString("Repository");
                    }

                    ecdLabel.Visible = false;
                }
            }
        }

        /// <summary>
        /// Open the form for SSN Offsetting
        /// </summary>
        private void ssnOffsetMnu_Click(object sender, EventArgs e)
        {
            ssnOffset ssnForm = new ssnOffset(ssnEnd, adminKey);
            ssnForm.ShowDialog();
            int tmpOffset = ssnForm.offset;
            ssnEnd = ssnForm.offset;
            sSNToolStripMenuItem.Text = "SSN: " + Utils.genSSN(ssnEnd, adminKey);
        }

        /// <summary>
        /// Saves the current pending list to a temp. CSV file, in case the program crashes.
        /// </summary>
        /// <returns>Count of the rows backed up (eventually)</returns>
        private int backUpPending()
        {
            string tempDir = System.IO.Path.GetTempPath();
            tempDir += @"\newuseraddPendingBackup.csv";
            Utils.writeCSV(pList, tempDir, true);
            return 0;
        }

        /// <summary>
        /// Reads the pending list data from the back-up CSV into the pending user data table
        /// </summary>
        private void restorePendingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int restored = Utils.restorePending(pList);

            if (restored > 0)
            {
                int ssn = Convert.ToInt32(pList[pList.Count-1].SSN.ToString());
                ssnEnd = (ssn % 100);
                sSNToolStripMenuItem.Text = "SSN: " + Utils.genSSN(++ssnEnd, adminKey);
                MessageBox.Show("Restored " + restored.ToString() + " pending users");
            }
            else
                MessageBox.Show("No Backup file found");
        }

        /// <summary>
        /// Open the linked Access Request Form when the link is clicked.
        /// </summary>
        private void arfLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(e.Link.LinkData.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening file: " + ex.Message);
            }
        }

        /// <summary>
        /// Open a file explorer window to select the Access Request Form for this pending user
        /// </summary>
        private void arfButton_Click(object sender, EventArgs e)
        {
            Boolean fileFound = false;
            Cursor.Current = Cursors.WaitCursor; //switch to the hourglass cursor
            OpenFileDialog arf = new OpenFileDialog();
            arfLabel.Links.Clear();
            arf.Title = "Access Request Form";

            //start in the network drive where the forms are saved
            arf.InitialDirectory = @"\\nwtac1mss07\sjmcshared\FMG IT\HIE\AccessRequestForms"; 
            arf.Filter = "Request Files (*.doc, *.docx, *.pdf)|*.doc;*.docx;*.pdf|All Files (*.*)|*.*"; //set the file types
            arf.FilterIndex = 1; // Start with the first entry in the Filetype Dropdown
            arf.RestoreDirectory = true;
            arf.Multiselect = false;

            // Attempt to find the Access Request Form based on IF the First and Last names are already entered, and the button
            // doesn't say "Change Link", which would mean that there is already a link. Must check the button because if we don't, 
            // and it finds the file automatically, then we'll never be able to change it should it find the WRONG file automatically.
            if (!string.IsNullOrEmpty(lastName.Text) && !string.IsNullOrEmpty(firstName.Text) && arfButton.Text != "Change Link")
            {
                StringBuilder filename = new StringBuilder(lastName.Text);
                filename.Append(", ");
                filename.Append(firstName.Text);
                if (!string.IsNullOrEmpty(middleInitial.Text)) filename.Append(" " + middleInitial.Text);
                arf.Title += " for " + filename.ToString();

                if (commRB.Checked)
                {
                    filename.Append(".pdf");
                    if (System.IO.File.Exists(arf.InitialDirectory + @"\" + filename.ToString()))
                    {
                        fileFound = true;
                        arf.FileName = arf.InitialDirectory + @"\" + filename.ToString();
                        arfLink(arf.FileName);
                    }
                }
                else
                {
                    filename.Append(".doc");
                    if (System.IO.File.Exists(arf.InitialDirectory + @"\" + filename.ToString()))
                    {
                        fileFound = true;
                        arf.FileName = arf.InitialDirectory + @"\" + filename.ToString();
                        arfLink(arf.FileName);
                    }
                    else
                    {
                        filename.Append('x');
                        if (System.IO.File.Exists(arf.InitialDirectory + @"\" + filename.ToString()))
                        {
                            fileFound = true;
                            arf.FileName = arf.InitialDirectory + @"\" + filename.ToString();
                            arfLink(arf.FileName);
                        }
                    }
                }
                
                
            }

            //If the user selects a file and clicks Ok\Open
            if (!fileFound && arf.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.Default; //reset to the normal cursor
                //strip out the path and show just the filename as the link, but the link itself is the full path to the file.
                arfLink(arf.FileName);
            }
        }

        private void arfLink(string FileName) 
        {
            try
            {
                arfLabel.Text = System.IO.Path.GetFileName(FileName);
                //arfLabel.Text = arf.FileName.Substring(arf.FileName.LastIndexOf('\\') + 1);
                //arfLabel.Text = file[file.Length - 1];
                arfLabel.Links.Add(0, arfLabel.Text.ToString().Length, FileName);
                arfLabel.Visible = true;
                arfButton.Text = "Change Link";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Open File Dialog Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Opens the form to manage Clinic entries in the DB
        /// </summary>
        private void manageClinicsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ClinicMaint cMForm = new ClinicMaint();
            cMForm.ShowDialog();

            this.clinicsTableAdapter1.Fill(this.clinicsDataSet.Clinics);
            clinicsBindingSource.ResetBindings(false);
            clinicDropDown.Invalidate();
            clinicDropDown.Refresh();
        }

        /// <summary>
        /// Opens the form to manage Specialty entries in the DB
        /// </summary>
        private void manageSpecialtiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpecMaint sMForm = new SpecMaint();
            sMForm.ShowDialog();

            this.specialtiesTableAdapter1.Fill(this.specialtiesDataSet.Specialties);
            specialtiesBindingSource.ResetBindings(false);
            specialtyDropDown.Invalidate();
            specialtyDropDown.Refresh();
        }

        /// <summary>
        /// Open the Audit Log form
        /// </summary>
        private void newUserLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogView logView = new LogView();
            logView.ShowDialog();
            logView = null;
        }

        /// <summary>
        /// If the User Type is Fax, the First Name field is automatically populated with "Referral".
        /// This will automatically highlight the entire field when a user clicks in the First Name field,
        /// so they don't have to specifically delete the "Referral" that's there.
        /// </summary>
        private void firstName_Enter(object sender, EventArgs e)
        {
            if (userTypeDropDown.SelectedIndex == userTypeDropDown.FindString("Fax") && firstName.Text == "Referral")
            {
                firstName.SelectAll();
            }
        }

        /// <summary>
        /// Short over to the FirstName Enter, which occurs when the user Tabs to the field.
        /// This is for when the user mouse-clicks in the field, and since they do the exact same thing,
        /// reuse the code.
        /// </summary>
        private void firstName_Click(object sender, EventArgs e)
        {
            firstName_Enter(null, null);
        }

        /// <summary>
        /// Determine who the Admin user is (the person running the program) by who is logged into the computer,
        /// and set the titlebar accordingly.
        /// </summary>
        private void localUser()
        {
#if DEBUG
            this.Text += ", Debugging Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
#else
            this.Text += ", Version: " + Application.ProductVersion;
#endif

            this.Text += "\t -- User: " + Utils.getFullName(Environment.UserName);
        }

        /// <summary>
        /// Save the last used SSN when the form closes. If the user needs to add more entries in the same day, 
        /// they won't need to increment the SSN offset by hand.
        /// </summary>
        private void newUserMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.LastSSN = Utils.genSSN(ssnEnd, adminKey);
            Properties.Settings.Default.Save();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserSettings usrSettings = new UserSettings();
            usrSettings.ShowDialog();
        }

        private void adminAccountsBlastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (adminAccountsBlastToolStripMenuItem.Checked)
            {
                commRB.Enabled = false;
                fmgRB.Checked = true;
                faxClncGrp.Visible = false;
                loginClncGrp.Visible = false;
                providerGrpBx.Visible = false;
                floatCheckBox.Visible = floatCheckBox.Checked = false;
                arfButton.Visible = false;
                arfLabel.Visible = false;

                fltPwLabel.Visible = fltPwText.Visible = true;
                addOnGroupBox.Location = new Point(12, 170);
                fltPwText.Location = new Point(196, 188);
                fltPwLabel.Location = new Point(196, 170);
                fltPwLabel.Text = "Password";
                this.Width = 450;
            }
            else
            {
                faxClncGrp.Visible = true;
                loginClncGrp.Visible = true;
                floatCheckBox.Visible = true;
                arfButton.Visible = true;
                arfLabel.Visible = true;
                commRB.Enabled = true;

                fltPwLabel.Visible = fltPwText.Visible = false;
                addOnGroupBox.Location = new Point(662, 170);
                fltPwText.Location = new Point(533, 45);
                fltPwLabel.Location = new Point(530, 27);
                fltPwLabel.Text = "Original Password";
                this.Width = 880;
            }
        } 

        void blastAdminAccounts()
        {
            string sqlConnectionString = "Data Source=NWTACVFHIE01;Initial Catalog=UserAddDb;Integrated Security=True";
            HashSet<string> ecds = new HashSet<string>();

            string[] tmpInfo = new string[11];
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(sqlConnectionString);
            System.Data.DataSet dSet = new System.Data.DataSet();
            string sql = "SELECT id From Clinics";

            System.Data.SqlClient.SqlDataAdapter dAdapter = new System.Data.SqlClient.SqlDataAdapter(sql, con);
            dAdapter.Fill(dSet, "Clinics");

            foreach (System.Data.DataRow row in dSet.Tables["Clinics"].Rows)
            {
                Person newUser = new Person();
                newUser.setClinicInfo(row.ItemArray.GetValue(0).ToString());

                if (newUser.Ecd != string.Empty)
                {
                    if (!ecds.Contains(newUser.Ecd))
                    {
                        ecds.Add(newUser.Ecd);
                        newUser.FirstName = firstName.Text;
                        newUser.MiddleInitial = middleInitial.Text;
                        newUser.LastName = lastName.Text;
                        newUser.Password = fltPwText.Text;

                        newUser.UserType = "Workstation";
                        newUser.JobCategory = "Licensed Health Professional";
                        newUser.Credential2 = "ADMIN";
                        newUser.Float = true;
                        newUser.Internal = true;

                        newUser.EditPatientIndex = epiChkBx.Checked;
                        newUser.Ordering = ioChkBx.Checked;
                        newUser.Repository = repChkBx.Checked;
                        newUser.PrescriptionWriter = rxChkBx.Checked;

                        if (ssnEnd / 100 > 0)
                            newUser.SSN = Utils.genSSN(ssnEnd % 100, ssnEnd / 100);
                        else
                            newUser.SSN = Utils.genSSN(ssnEnd, adminKey);

                        pList.Add(newUser);
                        ssnEnd++;
                    }
                }
                else
                {
                    newUser = null;
                }
            }
            sSNToolStripMenuItem.Text = "SSN: " + Utils.genSSN(ssnEnd, adminKey);
        }

        private void fillMDToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.degreesTableAdapter.FillMD(this.degreesDataSet.Degrees);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillLHPToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.degreesTableAdapter.FillLHP(this.degreesDataSet.Degrees);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void manageDegreesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DegreeMaint dm = new DegreeMaint();
            dm.ShowDialog();
        }

        private void providerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Import import = new Import(pList, ssnEnd, adminKey, (int)ImportTypes.PROV);
            import.ShowDialog();
            ssnEnd = import.ssnEnd;
            sSNToolStripMenuItem.Text = "SSN: " + Utils.genSSN(++ssnEnd, adminKey);
        }

        private void faxRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Import import = new Import(pList, ssnEnd, adminKey, (int)ImportTypes.REQ);
            import.ShowDialog();
            ssnEnd = import.ssnEnd;
            sSNToolStripMenuItem.Text = "SSN: " + Utils.genSSN(++ssnEnd, adminKey);
        }

        private void fromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Import import = new Import(pList, ssnEnd, adminKey, (int)ImportTypes.FILE);
            import.ShowDialog();
            ssnEnd = import.ssnEnd;
            sSNToolStripMenuItem.Text = "SSN: " + Utils.genSSN(++ssnEnd, adminKey);
        }

        private void resetLabels()
        {
            fNameLabel.ForeColor = lastNameLabel.ForeColor = Color.Black;
            deaLabel.ForeColor = rxChkBx.ForeColor = Color.Black;
            npiLabel.ForeColor = ioChkBx.ForeColor = Color.Black;
            faxLabel.ForeColor = Color.Black;
        }

        private bool validateData(int acctType, int degree)
        {
            bool retVal = true;
            StringBuilder errorList = new StringBuilder();

            resetLabels();

            // Check first for First and Last names
            if (string.IsNullOrEmpty(firstName.Text))
            {
                errorList.Append("Please enter the user's First name.\n");
                fNameLabel.ForeColor = Color.Red;
                retVal = false;
            }
            
            if (string.IsNullOrEmpty(lastName.Text))
            {
                errorList.Append("Please enter the user's Last name.\n");
                lastNameLabel.ForeColor = Color.Red;
                retVal = false;
            }

            if (ssoIdLbl.ForeColor == Color.Red && ssoIdTxtBx.Text.Length < 1)
            {
                errorList.Append("Error: user at Epic clinics MUST have an SSO ID.\n");
                retVal = false;
            }

            // Fields specific to Providers
            if (degree == mdIndex)
            {
                if (rxChkBx.Checked)
                {
                    if (string.IsNullOrEmpty(deaText.Text))
                    {
                        errorList.Append("Error: Providers must have a DEA to have Prescription Writer.\n");
                        deaLabel.ForeColor = Color.Red;
                        rxChkBx.ForeColor = Color.Red;
                        retVal = false;
                    }

                    if (string.IsNullOrEmpty(npiText.Text))
                    {
                        errorList.Append("Error: Providers must have an NPI entered to have Prescription Writer.\n");
                        npiLabel.ForeColor = Color.Red;
                        ioChkBx.ForeColor = Color.Red;
                        retVal = false;
                    }
                }

                if (ioChkBx.Checked)
                {
                    if (string.IsNullOrEmpty(npiText.Text))
                    {
                        errorList.Append("Error: Providers must have an NPI entered to have Ordering.\n");
                        npiLabel.ForeColor = Color.Red;
                        ioChkBx.ForeColor = Color.Red;
                        retVal = false;
                    }
                }
            }

            // Fields specific to LHP
            if (degree == lhpIndex)
            {
                // Nothing requried for LHP yet
            }

            // Fields specific to Fax Users
            if (acctType == faxIndex)
            {
                if (string.IsNullOrEmpty(faxText.ToString()))
                {
                    errorList.Append("Error: Fax accounts require a fax number.\n");
                    faxLabel.ForeColor = Color.Red;
                    retVal = false;
                }
            }

            // Fields specific to Workstation Users
            if (acctType == ewIndex)
            {
                // Can't assign a Workstation User a clinic without an ECD
                // Ex. St. Joseph Medical Center
                if (ecdLabel.Visible == false)
                {
                    MessageBox.Show("Error: No ECD. Changing to Repository account.");
                    userTypeDropDown.SelectedIndex = repIndex;
                }
            }

            // Fields specific to Repository Users
            if (acctType == repIndex)
            {
                // None so far
            }

            // Show any accumulated error messages
            if (!retVal) MessageBox.Show(errorList.ToString());

            return retVal;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, help.HelpNamespace);
        }

        private void massAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MassAdd massAdd = new MassAdd(pList, SSNEnd);
            massAdd.ShowDialog();
            updateSSNToolStrip(massAdd.UserCount);
        }

        //Won't connect. Need to find the port.
       /* private void testLoadBMC()
        {
            BMC.ARSystem.Server server = new BMC.ARSystem.Server();
            server.Login("remedy.catholichealth.net", "tacoma-wa_smountjo", "password");
            BMC.ARSystem.FieldIdList fieldIdList = new BMC.ARSystem.FieldIdList();
            BMC.ARSystem.Field field = server.GetField("HPD:HelpDesk", 8);
            MessageBox.Show("Field ID 1000000161 is: " + field.ToString());
            /*server.GetEntry("HPD:HelpDesk", "INC000003575059", fieldIdList);
            foreach (int id in fieldIdList)
            {
                MessageBox.Show("Field ID " + id);
            }
        } */
    }
}
