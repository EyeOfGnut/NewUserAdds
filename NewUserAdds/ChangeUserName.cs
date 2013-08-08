using System;
using System.Text;
using System.Windows.Forms;

namespace NewUserAdds
{
    /// <summary>
    /// Update a username in the event that the auto-generated name is already in use.
    /// </summary>
    public partial class ChangeUserName : Form
    {
        /// <summary>
        /// The user's generated name
        /// </summary>
        public string uName;
        private string exUser;

        /// <summary>
        /// Initialize the form (2 Overloads)
        /// </summary>
        public ChangeUserName()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize the form
        /// </summary>
        /// <param name="username">Username to be changed</param>
        public ChangeUserName(string username)
            : this()
        {
            uName = username;
        }

        /// <summary>
        /// Initialize the form
        /// </summary>
        /// <param name="username">Username to be changed</param>
        /// <param name="existingUser">Existing user that is already assigned the username</param>
        public ChangeUserName(string username, string existingUser)
            : this(username)
        {
            exUser = existingUser;
        }

        private void ChangeUserName_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder("Shortname \"");
            if (!string.IsNullOrEmpty(uName)) sb.Append(uName + "\" ");
            sb.Append("is in use");
            if (!string.IsNullOrEmpty(exUser)) sb.Append(" by " + exUser);
            errorLabel.Text = sb.ToString();
            unameText.Text = uName;
        }

        private void textBtn_Click(object sender, EventArgs e)
        {
            uName = unameText.Text;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
