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
    /// Add a fax number
    /// </summary>
    public partial class AddFaxNumber : Form
    {
        /// <summary>
        /// The fax number
        /// </summary>
        public string faxNumber = string.Empty;

        /// <summary>
        /// Initialize the form (One overload)
        /// </summary>
        public AddFaxNumber()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize the form (One overload)
        /// </summary>
        /// <param name="userName">Name of the user getting the fax number</param>
        public AddFaxNumber(String userName)
            : this()
        {
            nameLabel.Text = userName;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(numberTextBox.Text))
            {
                MessageBox.Show("Please enter a Fax number");
            }
            else
            {
                faxNumber = numberTextBox.Text;
                Close();
            }
        }
    }
}
