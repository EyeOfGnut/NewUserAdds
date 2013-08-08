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
    public partial class editUsername : Form
    {
        /// <summary>
        /// Username to be updated
        /// </summary>
        public string UsrName = string.Empty;

        /// <summary>
        /// Initialize the Form (One overload)
        /// </summary>
        public editUsername()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize the form
        /// </summary>
        /// <param name="userName">Username to be edited</param>
        public editUsername(string userName) : this()
        {
            userNameTxt.Text = UsrName = userName;
        }

        private void doneBtn_Click(object sender, EventArgs e)
        {
            UsrName = userNameTxt.Text;
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
