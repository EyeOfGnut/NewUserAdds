using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace NewUserAdds
{
    /// <summary>
    /// Form for editing a pending user, prior to processing.
    /// </summary>
    public partial class editPendingUser : Form
    {
        /// <summary>
        /// Person object to be edited
        /// </summary>
        public Person person;
        //int row;

        /// <summary>
        /// Initialize the Form (One overload)
        /// </summary>
        public editPendingUser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize the Form
        /// </summary>
        /// <param name="p">Person object to be edited</param>
        public editPendingUser(Person p): this()
        {
            person = p;
        }

        private void editPendingUser_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'degreesDataSet.Degrees' table. You can move, or remove it, as needed.
            this.degreesTableAdapter.Fill(this.degreesDataSet.Degrees);
            // TODO: This line of code loads data into the 'specialtiesDataSet.Specialties' table. You can move, or remove it, as needed.
            this.specialtiesTableAdapter.Fill(this.specialtiesDataSet.Specialties);
            this.clinicsTableAdapter.Fill(this.clinicsDataSet.Clinics);
            editClinicToolTip.SetToolTip(this.editClinicCB, "This will only update the clinic data for this individual user.\nIt won't update the data in the clinic database");
            loadFields();
            
        }

        /// <summary>
        /// Load the initial data into the appropriate fields for editing.
        /// </summary>
        private void loadFields()
        {
            //Set plain text entry fields common to all                
            clncMgrText.Text = person.Manager;
            fltPwText.Text = person.Password;
            taskTxt.Text = person.Task;
            starIdTxt.Text = person.LocalId;
            upinTxt.Text = person.Upin;
            npiText.Text = person.Npi;

            firstName.Text = person.FirstName;
            middleInitial.Text = person.MiddleInitial;
            lastName.Text = person.LastName;
            if (person.Fax)
                userNameText.Text = person.ShortName.Substring(3);
            else if (person.Float)
                userNameText.Text = person.ShortName.Substring(person.ClinicAbbr.Length - 1);
            else
                userNameText.Text = person.ShortName;

            ssnText.Text = person.SSN;

            ioChkBx.Checked = person.Ordering;
            epiChkBx.Checked = person.EditPatientIndex;
            repChkBx.Checked = person.Repository;
            rxChkBx.Checked = person.PrescriptionWriter;

            if (person.UserType == "Fax")
            {
                clinicDetailGroup.Visible = true;
                clinicDDGrp.Visible = false;
                editClinicCB.Visible = false;
                
                clinicNameText.Text = person.CompanyName;
                addressText.Text = person.StreetAddress;
                cityText.Text = person.City;
                stateText.Text = person.State;
                zipText.Text = person.Zip;
                phoneText.Text = person.PhoneNumber;
                faxText.Text = person.FaxNumber;
                countryText.Text = person.Country;

                ecdText.Visible = false;
                ecdLabel.Visible = false;
                abbrLabel.Visible = false;
                abbrText.Visible = false;
            }
            else
            {
                if (!String.IsNullOrEmpty(person.ARForm))
                {
                    arfLabel.Text = Path.GetFileName(person.ARForm);
                    arfLabel.Links.Add(0, arfLabel.Text.ToString().Length, person.ARForm);
                    arfLabel.Visible = true;
                    arfButton.Text = "Change Link";
                }
                else
                {
                    arfLabel.Links.Clear();
                }

                if (person.Internal)
                    fmgRB.Checked = true;
                else
                {
                    commRB.Checked = true;
                    emailLabel.Visible = emailText.Visible = true;
                    emailText.Text = person.Email;
                }

                floatCheckBox.Checked = person.Float;
                clinicDetailGroup.Visible = false;
                clinicDDGrp.Visible = true;

                setDDLabels(person.ClinicId);
                clinicDropDown.SelectedIndex = clinicDropDown.FindString(person.CompanyName);
                string selValue = clinicDropDown.SelectedValue.ToString();
                int selIndex = clinicDropDown.SelectedIndex;
                int i = 0;
                while (selValue.ToString() != person.ClinicId && selIndex > 0 && i++ < clinicDropDown.Items.Count)
                {
                    selIndex = clinicDropDown.FindString(person.CompanyName, clinicDropDown.SelectedIndex);
                    if (selIndex > 0)
                    {
                        clinicDropDown.SelectedIndex = selIndex;
                        selValue = clinicDropDown.SelectedValue.ToString();
                    }              
                }

                if (!string.IsNullOrEmpty(person.Specialty))
                {
                    specialtyDropDown.SelectedIndex = specialtyDropDown.FindString(person.Specialty);
                    selValue = specialtyDropDown.SelectedValue.ToString();
                    selIndex = specialtyDropDown.SelectedIndex;
                    i = 0;
                    while (selValue.ToString() != person.SpecialtyId && selIndex > 0 && i++ < specialtyDropDown.Items.Count)
                    {
                        selIndex = specialtyDropDown.FindString(person.Specialty, specialtyDropDown.SelectedIndex);
                        if (selIndex > 0)
                        {
                            specialtyDropDown.SelectedIndex = selIndex;
                            selValue = specialtyDropDown.SelectedValue.ToString();
                        }
                    }
                }
                else specialtyDropDown.SelectedIndex = 0;
            }
            
            //Set Combo Boxes
            userTypeDropDown.SelectedIndex = userTypeDropDown.FindString(Utils.fixUserType(person.UserType));
            jobCategoryDropDown.SelectedIndex = jobCategoryDropDown.FindString(person.JobCategory);
            transCB.SelectedIndex = transCB.FindString(person.Credential6);
            //If the job category is LHP or MD...
            if (jobCategoryDropDown.SelectedIndex != jobCategoryDropDown.FindString("Staff-I"))
            {
                degreeDropDown.Visible = degreeDropDown.Enabled = true;
                if (jobCategoryDropDown.SelectedIndex == jobCategoryDropDown.FindString("Licensed Health Professional"))
                {
                    degreeDropDown.DataSource = this.degreesTableAdapter.GetLHP();
                }
                else
                {
                    npiText.Visible = npiText.Enabled = npiLabel.Visible = npiLabel.Enabled = true;
                    npiText.Text = person.Upin;

                    deaText.Visible = deaText.Enabled = deaLabel.Visible = deaLabel.Enabled = true;
                    deaText.Text = person.Dea;

                    specialtyDropDown.SelectedIndex = specialtyDropDown.FindString(person.Specialty);

                    degreeDropDown.DataSource = this.degreesTableAdapter.GetMD();
                }
                degreeDropDown.SelectedIndex = degreeDropDown.FindString(Utils.getDegreeInfo(person.Degree)[0]);
            }
            
        }

        /// <summary>
        /// Set the text fields for non-editable information
        /// such as clinic info for a workstation user.
        /// </summary>
        /// <param name="clinicID">ID number of the user's Clinic</param>
        private void setDDLabels(string clinicID)
        {
            string[] clinicInfo = Utils.getClinicInfo(clinicID);
            ddAbbrLabel.Text = "Abbr: " + clinicInfo[10];
            ddEcdLabel.Text = "ECD: " + clinicInfo[9];
            ddCountryLabel.Text = "Country: " + clinicInfo[8];
            ddZipLabel.Text = "Zip: " + clinicInfo[7];
            ddStateLabel.Text = "State: " + clinicInfo[6];
            ddCityLabel.Text = "City: " + clinicInfo[5];
            ddAddyLabel.Text = "Address: " + clinicInfo[4];
            ddFaxLabel.Text = "Fax: " + clinicInfo[3];
            ddPhoneLabel.Text = "Phone: " + clinicInfo[2];

            clinicNameText.Text = clinicInfo[1];
            phoneText.Text = clinicInfo[2];
            faxText.Text = clinicInfo[3];
            addressText.Text = clinicInfo[4];
            cityText.Text = clinicInfo[5];
            stateText.Text = clinicInfo[6];
            zipText.Text = clinicInfo[7];
            countryText.Text = clinicInfo[8];
            ecdText.Text = clinicInfo[9];
            abbrText.Text = clinicInfo[10];           
        }

        /// <summary>
        /// Cancel the edit
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*private void editClinicCB_CheckedChanged(object sender, EventArgs e)
        {
            int faxIndex = userTypeDropDown.FindString("Fax");
            if (editClinicCB.Checked || userTypeDropDown.SelectedIndex == faxIndex)
            {
                clinicDetailGroup.Visible = true;
                clinicDDGrp.Visible = false;

                if (userTypeDropDown.SelectedIndex != faxIndex)
                {
                    clinicNameText.Text = person.CompanyName;
                    addressText.Text = person.StreetAddress;
                    cityText.Text = person.City;
                    stateText.Text = person.State;
                    zipText.Text = person.Zip;
                    phoneText.Text = person.PhoneNumber;
                    faxText.Text = person.FaxNumber;
                    countryText.Text = person.Country;
                }
            }
            else
            {
                clinicDetailGroup.Visible = false;
                clinicDDGrp.Visible = true;
            }
        }*/

        private void clinicDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (floatCheckBox.Checked)
            {
                userNameText.Text = userNameText.Text.Substring(abbrText.Text.Trim().Length, userNameText.Text.Length - abbrText.Text.Trim().Length);
                setDDLabels(clinicDropDown.SelectedValue.ToString());
                userNameText.Text = abbrText.Text.ToLower().Trim() + userNameText.Text;
            }
            else
            {
                setDDLabels(clinicDropDown.SelectedValue.ToString());
            }            
        }

        private void confButton_Click(object sender, EventArgs e)
        {
            person.FirstName = firstName.Text;
            person.MiddleInitial = middleInitial.Text;
            person.LastName = lastName.Text;
            person.Title = "";

            if (jobCategoryDropDown.SelectedIndex != jobCategoryDropDown.FindString("Staff-I"))
            {
                person.Degree = degreeDropDown.SelectedValue.ToString();
                if (jobCategoryDropDown.SelectedIndex == jobCategoryDropDown.FindString("Medical Doctor"))
                {
                    string[] specInfo = Utils.getSpecialtyInfo(specialtyDropDown.SelectedValue.ToString());
                    person.Specialty = specInfo[1];
                    person.SpecialtyId = specInfo[0];

                    person.Dea = deaText.Text;
                    person.RxLicenseNumber = "NA";
                    person.Npi = npiText.Text;
                    person.Upin = upinTxt.Text;
                }
                else
                {
                    person.Specialty = string.Empty;
                    person.SpecialtyId = string.Empty;
                    person.RxLicenseNumber = string.Empty;
                    person.Npi = string.Empty;
                    person.Dea = string.Empty;
                }
            }
            else
            {
                person.Degree = string.Empty;
                person.Specialty = string.Empty;
                person.SpecialtyId = string.Empty;
                person.Npi = string.Empty;
                person.RxLicenseNumber = string.Empty;
                person.Dea = string.Empty;
            }

            person.Float = floatCheckBox.Checked;

            person.ShortName = userNameText.Text;
            person.Password = fltPwText.Text;
            if (userTypeDropDown.SelectedIndex != userTypeDropDown.FindString("Fax") || !editClinicCB.Checked)
            {
                // Pull the ClinicID out of the selected item in the Combo Box. "SelectedItem" is an Object type, so 
                // cast it as a DataRowView and save it to a variable, so we can access the complete data pulled
                // from the SQL server, which is stored in ItemArray
                DataRowView selItem = clinicDropDown.SelectedItem as DataRowView;
                person.setClinicInfo(selItem.Row.ItemArray[0].ToString());
            }
            else
            {
                person.CompanyName = clinicNameText.Text;
                person.PhoneNumber = phoneText.Text;
                person.FaxNumber = faxText.Text;
                person.StreetAddress = addressText.Text;
                person.City = cityText.Text;
                person.State = stateText.Text;
                person.Zip = zipText.Text;
                person.Country = countryText.Text;
            }
            person.SSN = ssnText.Text;
            person.Ecd = ecdText.Text;
            person.LocalId = starIdTxt.Text;
            if (!string.IsNullOrEmpty(starIdTxt.Text))
                person.IdQualifier = "FHS";

            if(transCB.SelectedItem != null)
                person.Credential6 = transCB.SelectedItem.ToString();

            person.UserType = userTypeDropDown.SelectedItem.ToString();
            person.JobCategory = jobCategoryDropDown.SelectedItem.ToString();

            person.Email = emailText.Text;
            person.Manager = clncMgrText.Text;
            person.Task = taskTxt.Text;
            person.SpecialtyId = specialtyDropDown.SelectedIndex.ToString();
            person.Internal = fmgRB.Checked;
            if (arfLabel.Links.LinksAdded)
                person.ARForm = arfLabel.Links[0].LinkData.ToString();

            Close();
        }

        private void jobCategoryDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (jobCategoryDropDown.SelectedIndex != jobCategoryDropDown.FindString("Staff-I"))
            {
                degreeDropDown.Visible= degreeLabel.Visible = true;

                if (jobCategoryDropDown.SelectedIndex == jobCategoryDropDown.FindString("Medical Doctor"))
                {
                    degreeDropDown.DataSource = this.degreesTableAdapter.GetMD();
                    degreeDropDown.SelectedIndex = 0;
                    providerGrpBx.Visible = true;
                }
                else
                {
                    degreeDropDown.DataSource = this.degreesTableAdapter.GetLHP();
                    degreeDropDown.SelectedIndex = 0;
                    providerGrpBx.Visible = false;
                }
            }
            else
            {
                degreeDropDown.Visible = degreeLabel.Visible = false;
                providerGrpBx.Visible = false;
            }
        }

        private void userTypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userTypeDropDown.SelectedIndex == userTypeDropDown.FindString("Fax"))
            {
                clinicDDGrp.Visible = false;
                clinicDetailGroup.Visible = true;
                editClinicCB.Visible = false;
                addOnGroupBox.Visible = false;
            }
            else
            {
                if (!editClinicCB.Checked)
                {
                    clinicDDGrp.Visible = true;
                    clinicDetailGroup.Visible = false;
                }
                editClinicCB.Visible = true;
                addOnGroupBox.Visible = true;
            }
        }

        private void commRB_CheckedChanged(object sender, EventArgs e)
        {
            if (commRB.Checked)
            {
                emailLabel.Visible = emailText.Visible = true;
                fltPwLabel.Visible = fltPwText.Visible = false;
                floatCheckBox.Visible = floatCheckBox.Checked = false;
            }
            else
            {
                emailText.Visible = emailLabel.Visible = false;
                fltPwLabel.Visible = fltPwText.Visible = true;
                floatCheckBox.Visible = true;
            }
        }

        private void floatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            string[] info = Utils.getClinicInfo(clinicDropDown.SelectedValue.ToString());
            if (floatCheckBox.Checked)
            {
                fltPwText.Visible = fltPwLabel.Visible = true;
                userNameText.Text = info[10].ToLower().Trim() + userNameText.Text;
            }
            else
            {
                fltPwText.Visible = fltPwLabel.Visible = false;
                int abbLen = info[10].Trim().Length;
                userNameText.Text = userNameText.Text.Substring(abbLen);
            }
        }

        private void arfButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor; //switch to the hourglass cursor
            OpenFileDialog arf = new OpenFileDialog();
            arfLabel.Links.Clear();
            arf.Title = "Access Request Form";

            //start in the network drive where the forms are saved
            arf.InitialDirectory = @"\\nwtac1mss07\sjmcshared\FMG IT\HIE\AccessRequestForms";
            arf.Filter = "Request Files (*.doc, *.docx, *.pdf)|*.doc;*.docx;*.pdf|All Files (*.*)|*.*"; //set the file types
            arf.FilterIndex = 1; // Start with the first entry in the Filetype Dropdown
            arf.RestoreDirectory = true;

            //If the user selects a file and clicks Ok\Open
            if (arf.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.Default; //reset to the normal cursor
                //strip out the path and show just the filename as the link, but the link itself is the full path to the file.
                try
                {
                    arfLabel.Text = System.IO.Path.GetFileName(arf.FileName);
                    //arfLabel.Text = arf.FileName.Substring(arf.FileName.LastIndexOf('\\') + 1);
                    //arfLabel.Text = file[file.Length - 1];
                    arfLabel.Links.Add(0, arfLabel.Text.ToString().Length, arf.FileName);
                    arfLabel.Visible = true;
                    arfButton.Text = "Change Link";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Open File Dialog Error: " + ex.Message);
                }
            }
        }

        private void arfLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening file: " + ex.Message);
            }
        }
    }
}
