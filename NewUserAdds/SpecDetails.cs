using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;

namespace NewUserAdds
{
    /// <summary>
    /// Form for adding/editing Specialties.
    /// </summary>
    public partial class SpecDetails : Form
    {
        System.Data.SqlClient.SqlConnection con;
        Hashtable changedItems = new Hashtable();
        private static string id = null;

        /// <summary>
        /// Initialize the form (one overload)
        /// </summary>
        public SpecDetails()
        {
            InitializeComponent();
            loadValues();
        }

        /// <summary>
        /// Initialize the form
        /// </summary>
        /// <param name="specID">ID of the specialty to be edited</param>
        public SpecDetails(string specID)
        {
            InitializeComponent();
            id = specID;
            loadValues();
        }

        private void loadValues()
        {
            if (id != null)
            {
                string[] info = Utils.getSpecialtyInfo(id);

                idLabel.Text = "ID: " + info[0];
                specText.Text = info[1];
                abbText.Text = info[2];
            }
            else
            {
                updateBtn.Text = "Submit";
            }

            con = new System.Data.SqlClient.SqlConnection(Properties.Settings.Default.UserAddDBConnectionString);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            con.Close();
            Close();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            string sql;

            if (id == null)
            {
                sql = "INSERT INTO Specialties (Specialty, Abbr) VALUES (" + specText.Text + ", " + abbText.Text + ")";
            }
            else
            {
                sql = "UPDATE Specialties SET ";
                foreach (DictionaryEntry col in changedItems)
                {
                    TextBox tb = (TextBox)col.Value;
                    String colName = (String)col.Key;
                    sql = sql + colName + " = '" + tb.Text + "', ";
                }
                sql = sql.Remove(sql.Length - 2);
                sql = sql + " WHERE id = " + id;
            }

            try
            {
                SqlCommand command = new SqlCommand(sql, con);
                command.Connection.Open();
                MessageBox.Show("Successfully updated " + command.ExecuteNonQuery() + " rows");
                command.Connection.Close();
                con.Close();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Running Command: " + ex.ToString());
            }
        }

        private void specText_TextChanged(object sender, EventArgs e)
        {
            if (!changedItems.ContainsKey("Specialty"))
                changedItems.Add("Specialty", specText);
        }

        private void abbText_TextChanged(object sender, EventArgs e)
        {
            if (!changedItems.ContainsKey("Abbr"))
                changedItems.Add("Abbr", abbText);
        }
    }
}
