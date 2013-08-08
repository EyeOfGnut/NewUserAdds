using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NewUserAdds
{
    /// <summary>
    /// Add/Update/Delete Clinic information in the SQL database
    /// </summary>
    public partial class ClinicMaint : Form
    {
        
        /// <summary>
        /// Initialize the Form
        /// </summary>
        public ClinicMaint()
        {
            InitializeComponent();
        }


        private void ClinicMaint_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'clinicsDataSet.Clinics' table. You can move, or remove it, as needed.
            this.clinicsTableAdapter.Fill(this.clinicsDataSet.Clinics);
            
        }

        private void addNewBtn_Click(object sender, EventArgs e)
        {
            clinicDetails(null, false);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            clinicDetails(clinicDropDown.SelectedValue.ToString(), !editChkBx.Checked);
        }

        private void clinicDetails(string id, Boolean readOnly)
        {
            ClinicDetails cdForm = new ClinicDetails();
            cdForm.LoadClinicValues(id, readOnly);
            cdForm.ShowDialog();

            this.clinicsTableAdapter.Fill(this.clinicsDataSet.Clinics);
            clinicsBindingSource1.ResetBindings(false);
            clinicDropDown.Invalidate();
            clinicDropDown.Refresh();
        }
    }
}
