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
    /// Generate and send new account notifications
    /// </summary>
    public partial class SendNotificationEmails : Form
    {
        private static List<Person> pList = null;
        Button[] editBtn;
        Label[] fName;
        Label[] lName;
        Label[] userName;
        Button[] sendBtn;

        /// <summary>
        /// Initialize the form (One overload)
        /// </summary>
        public SendNotificationEmails()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize the form
        /// </summary>
        /// <param name="list">List of Person objects representing the people with new accounts</param>
        public SendNotificationEmails(List<Person> list) : this()
        {
            pList = list;
            LoadTable();
        }

        /// <summary>
        /// Dynamically create the buttons text labels in the Panel for sending individual emails.
        /// </summary>
        private void LoadTable()
        {
            Person dr;
            int count = pList.Count;
            int y;
            int j = 0; //Keep a separate counter so there aren't gaps when a Fax account is skipped

            editBtn = new Button[count];
            fName = new Label[count];
            lName = new Label[count];
            userName = new Label[count];
            sendBtn = new Button[count];
            

            for (int i=0; i< count; i++)
            {
                //Skip sending Fax account emails
                if (!pList[i].UserType.Equals("Fax"))
                {
                    dr = pList[i];

                    // y position
                    y = (j + 1) * 28;
                    
                    editBtn[j] = new Button();
                    editBtn[j].Text = "Edit Username";
                    editBtn[j].Location = new Point(4, y);
                    editBtn[j].AutoSize = true;
                    editBtn[j].Click += new EventHandler(editBtn_Click);
                    panel.Controls.Add(editBtn[j]);

                    fName[j] = new Label();
                    fName[j].Text = dr.FirstName; // Set the First Name Label
                    fName[j].Location = new Point(editBtn[j].Location.X + editBtn[j].Size.Width + 10, y + 5);
                    fName[j].AutoSize = true;
                    panel.Controls.Add(fName[j]);

                    lName[j] = new Label();
                    lName[j].Text = dr.LastName; // Set the Last Name Label
                    lName[j].Location = new Point(fName[j].Location.X + fName[j].Size.Width + 2, y + 5);
                    lName[j].AutoSize = true;
                    panel.Controls.Add(lName[j]);

                    userName[j] = new Label();
                    userName[j].Text = dr.ShortName; // Set the Username Label
                    userName[j].Location = new Point(300, y + 5);
                    userName[j].AutoSize = true;
                    panel.Controls.Add(userName[j]);

                    sendBtn[j] = new Button();
                    sendBtn[j].Text = "Send Email";
                    sendBtn[j].Location = new Point(400, y);
                    sendBtn[j].AutoSize = true;
                    sendBtn[j].Click += new EventHandler(sendBtn_Click);
                    panel.Controls.Add(sendBtn[j]);

                    j++;
                }
            }
            if (j == 0)
            {
                MessageBox.Show("No remaining notifications to be sent");
                Close();
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            int i;
            for (i = 0; i < (panel.Controls.Count/6)-1; i++)
            {
                if (sendBtn[i].Equals(btn))
                    break;
            }

            Email email = new Email(pList[i]);
            
            try
            {
                if(email.Send(true))
                {
                    pList.RemoveAt(i);
                    panel.Controls.Clear();
                    LoadTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending email: " + ex.Message);
            }
        }

        private string normalizeManager(string managerName)
        {
            string normalized = managerName;

            if (managerName.IndexOf(',') < 0 && !string.IsNullOrEmpty(managerName))
            {
                string[] name = managerName.Split(' ');
                normalized = name[name.Length - 1].Trim() + ", " + name[0].Trim();
            }

            return normalized;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int i;
            for(i=0; i < pList.Count(); i++)
            {
                if (editBtn[i].Equals(btn))
                    break;
            }

            Person person = pList.ElementAt(i);
            string newUName;
            editUsername edit = new editUsername(person.ShortName);
            edit.ShowDialog();
            newUName = edit.UsrName;
            if (!string.IsNullOrEmpty(newUName) && !newUName.Equals(person.ShortName))
            {
                person.ShortName = newUName;
                panel.Controls.Remove(userName[i]);
                userName[i].Text = person.ShortName;
                userName[i].ForeColor = Color.Red;
                panel.Controls.Add(userName[i]);
            }
        }

        /// <summary>
        /// Send all the notification emails in one blast
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Person> list = new List<Person>(pList); // Make a copy of the person list

            int count = 0;
            progressBar.Step = 100/list.Count();
            progressBar.Value = 0;
            progressBar.Visible = true;

            //Itereate through each person in the copied list, and if the Email is sent successfully, 
            // remove that person from the original list. This way the user can watch as the to-be-sent list
            // shrinks as emails are sent. If we do this without the copy, we'll get an error and the function
            // will stop as soon as a person is removed, because of the "foreach" statement - the criteria it's
            // using changed while the loop was using it, confusing the program.
            foreach(Person person in list)
            {
                if (!person.UserType.Equals("Fax"))
                {
                    Email email = new Email(person);

                    try
                    {
                        if (email.Send())
                        {
                            pList.Remove(person);
                            panel.Controls.Clear();
                            LoadTable();
                            count++;
                            progressBar.PerformStep();
                        }
                        else MessageBox.Show("Didn't send email for " + person.FirstName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error sending email: " + ex.Message);
                    }
                }
                else
                {
                    progressBar.PerformStep();
                }
            }

            MessageBox.Show("Sent " + count + " emails");
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
