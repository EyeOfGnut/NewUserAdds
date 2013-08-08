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
    /// Maintanance for the Specialties Database Table (Add/Update/Delete Specialties)
    /// </summary>
    public partial class SpecMaint : Form
    {
        /// <summary>
        /// Initialize the Form
        /// </summary>
        public SpecMaint()
        {
            InitializeComponent();
        }

        private void SpecMaint_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'specialtiesDataSet.Specialties' table. You can move, or remove it, as needed.
            this.specialtiesTableAdapter.Fill(this.specialtiesDataSet.Specialties);

        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            SpecDetails sdForm = new SpecDetails(specDropDown.SelectedValue.ToString());
            sdForm.ShowDialog();

            this.specialtiesTableAdapter.Fill(this.specialtiesDataSet.Specialties);
            specialtiesBindingSource.ResetBindings(false);
            specDropDown.Invalidate();
            specDropDown.Refresh();

        }

        private void addNewBtn_Click(object sender, EventArgs e)
        {
            SpecDetails sdForm = new SpecDetails();
            sdForm.ShowDialog();

            this.specialtiesTableAdapter.Fill(this.specialtiesDataSet.Specialties);
            specialtiesBindingSource.ResetBindings(false);
            specDropDown.Invalidate();
            specDropDown.Refresh();
        }
    }
}
