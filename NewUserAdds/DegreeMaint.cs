using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NewUserAdds
{
    /// <summary>
    /// Add/Update/Delete Degree information in the SQL Database
    /// </summary>
    public partial class DegreeMaint : Form
    {
        private string query = null;

        /// <summary>
        /// Initialize the Form
        /// </summary>
        public DegreeMaint()
        {
            InitializeComponent();
        }

        private void DegreeMaint_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'degreesDataSet.Degrees' table. You can move, or remove it, as needed.
            this.degreesTableAdapter.Fill(this.degreesDataSet.Degrees);

        }

        private void mdFilter_Click(object sender, EventArgs e)
        {
            degCB.DataSource = this.degreesTableAdapter.GetMD();
        }

        private void lhpFilter_Click(object sender, EventArgs e)
        {
            degCB.DataSource = this.degreesTableAdapter.GetLHP();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            editBox.Text = "Edit Degree";
            addBtn.Text = "Apply";
            cancelBtn.Visible = true;
            query = "UPDATE Degrees SET Degree = " + degreeTxt.Text.Trim().ToUpper() + ", JobCategory = ";
            if (mdRB.Checked) query += "160";
            else query += "150";
            query += "WHERE ID = " + degCB.SelectedValue.ToString();
            degreeTxt.Text = degCB.Text.ToString();
            if (Utils.getDegreeInfo(degCB.SelectedValue.ToString())[1] == "160")
                mdRB.Checked = true;
            else
                lhpRB.Checked = true;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {

            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Properties.Settings.Default.UserAddDBConnectionString);

            if (string.IsNullOrEmpty(query))
            {
                query = "INSERT INTO Degrees VALUES('" + degreeTxt.Text.Trim().ToUpper() + "',";
                if (mdRB.Checked) query += "160";
                else query += "150";
                query += ")";
            }

            try
            {
                SqlCommand command = new SqlCommand(query, con);
                command.Connection.Open();
                MessageBox.Show("Successfully updated " + command.ExecuteNonQuery() + " rows");
                command.Connection.Close();
                con.Close();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Running Command: " + ex.ToString());
                con.Close();
            }

            cancelBtn_Click(null, null);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            editBox.Text = "Add New Degree";
            addBtn.Text = "Add";
            degreeTxt.Text = "";
            cancelBtn.Visible = false;
        }
    }
}
