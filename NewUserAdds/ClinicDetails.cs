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
    /// Form for viewing/editing Clinic information
    /// </summary>
    public partial class ClinicDetails : Form
    {
        System.Data.SqlClient.SqlConnection con;

        string rowId;
        bool readOnly;

        /// <summary>
        /// Initialize the form
        /// </summary>
        public ClinicDetails()
        {
            InitializeComponent();
            con = new System.Data.SqlClient.SqlConnection(Properties.Settings.Default.UserAddDBConnectionString);
        }

        /// <summary>
        /// Load the information for the selected clinic
        /// </summary>
        /// <param name="id">Clinic ID</param>
        /// <param name="rO">Read-Only Boolean (true is read-only)</param>
        public void LoadClinicValues(string id, Boolean rO)
        {
            rowId = id;
            readOnly = rO;


            clinicNameText.Name = "Company";
            phoneText.Name = "Phone";
            faxText.Name = "Fax";
            addressText.Name = "Address";
            cityText.Name = "City";
            stateText.Name = "State";
            zipText.Name = "Zip";
            countryText.Name = "Country";
            ecdText.Name = "ECD";
            abbrText.Name = "Abbr";
            epicChkBx.Name = "Epic";
            countryText.Name = "Country";

            if (id != null)
            {
                string[] info = Utils.getClinicInfo(id);

                idLabel.Text = info[(int)Utils.ClinicTable.ID].Trim();

                clinicNameText.Tag = clinicNameText.Text = info[(int)Utils.ClinicTable.Company].Trim();

                phoneText.Tag = phoneText.Text = info[(int)Utils.ClinicTable.Phone].Trim();

                faxText.Tag = faxText.Text = info[(int)Utils.ClinicTable.Fax].Trim() as String;

                addressText.Tag = addressText.Text = info[(int)Utils.ClinicTable.Address].Trim();

                cityText.Tag = cityText.Text = info[(int)Utils.ClinicTable.City].Trim();

                stateText.Tag = stateText.Text = info[(int)Utils.ClinicTable.State].Trim();

                zipText.Tag = zipText.Text = info[(int)Utils.ClinicTable.Zip].Trim();

                countryText.Tag = countryText.Text = info[(int)Utils.ClinicTable.Country].Trim();

                ecdText.Tag = ecdText.Text = info[(int)Utils.ClinicTable.ECD].Trim();

                abbrText.Tag = abbrText.Text = info[(int)Utils.ClinicTable.Abbr].Trim();

                epicChkBx.Checked = (Int32.Parse(info[(int)Utils.ClinicTable.Epic].Trim()) == 1);

                countryText.Tag = countryText.Text = info[(int)Utils.ClinicTable.Country].Trim();


                if(readOnly)
                {
                    clinicNameText.ReadOnly = true;
                    phoneText.ReadOnly = true;
                    faxText.ReadOnly = true;
                    addressText.ReadOnly = true;
                    cityText.ReadOnly = true;
                    stateText.ReadOnly = true;
                    zipText.ReadOnly = true;
                    countryText.ReadOnly = true;
                    ecdText.ReadOnly = true;
                    abbrText.ReadOnly = true;
                    updateBtn.Visible = false;
                    epicChkBx.Enabled = false;
                }
            }
            else
            {
                updateBtn.Text = "Submit";
            }

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            con.Close();
            Close();
        }

        // Remove SQL injection attacks
        private string fixUserString(string userString)
        {
            string str = userString;
            while (str.Contains('\''))
                str = str.Remove(str.IndexOf('\''), 1);

            while (str.Contains('\"'))
                str = str.Remove(str.IndexOf('\"'), 1);

            return str;
        }

        private string genNewClinic()
        {
            string sql = "INSERT INTO Clinics (";
            string vals = "VALUES (";

            foreach (Control Obj in this.Controls)
            {
                if (Obj.GetType() == typeof(CheckBox))
                {
                    sql += Obj.Name + ", ";
                    vals += ((((CheckBox)Obj).Checked) ? 1 : 0) + ", ";
                }
                else if (Obj.GetType() == typeof(TextBox))
                {
                    sql += Obj.Name + ", ";
                    vals += "'" + fixUserString(Obj.Text) + "', ";
                }
                else 
                {
                    //Skip the control
                }

            }

            sql = sql.Remove(sql.Length - 2);
            sql = sql + ") ";
            vals = vals.Remove(vals.Length - 2);
            vals = vals + ")";
            sql = sql + vals;

            return sql;
        }

        private string genUpdateClinic()
        {
            string sql = "UPDATE Clinics SET ";

            foreach (Control Obj in this.Controls)
            {
                if (Obj.GetType() == typeof(CheckBox))
                {
                    sql += Obj.Name + " = " + ((((CheckBox)Obj).Checked) ? 1 : 0) + ", ";
                }
                else if (Obj.GetType() == typeof(TextBox))
                {
                    if (!Obj.Tag.Equals(Obj.Text))
                    {
                        sql += Obj.Name + " = '" + fixUserString(Obj.Text) + "', ";
                    }
                } else { /*skip*/ }

            }

            sql = sql.Remove(sql.Length - 2);
            sql = sql + " WHERE id = " + rowId;

            return sql;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            string sql;

            if (rowId == null)
                sql = genNewClinic();
            else
                sql = genUpdateClinic();

            try
            {
                SqlCommand command = new SqlCommand(sql, con);
                command.Connection.Open();
                MessageBox.Show("Successfully updated " + command.ExecuteNonQuery() + " rows");
                command.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Running Command: " + ex.ToString());
            }
            finally
            {
                con.Close();
                Close();
            }
        }        

        private void ClinicDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void ecdText_Enter(object sender, EventArgs e)
        {
            if(!readOnly) MessageBox.Show("Be careful, a typo will make a new ECD!");
        }

        private void deleteClinicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Verify Delete " + clinicNameText.Text + "?"
                            + "\n\nYou cannot undo this!", "Delete Clinic", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (result == DialogResult.OK)
            {
                try
                {
                    string sql = "DELETE FROM Clinics WHERE id = " + idLabel.Text;
                    SqlCommand command = new SqlCommand(sql, con);
                    command.Connection.Open();
                    MessageBox.Show("Successfully removed " + command.ExecuteNonQuery() + " rows");
                    command.Connection.Close();
                    con.Close();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Running Command: " + ex.ToString());
                    con.Close();
                }
            }
        }     
    }
}
