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
    /// Allow users to specify an SSN offset
    /// </summary>
    public partial class ssnOffset : Form
    {
        /// <summary>
        /// The offset to use
        /// </summary>
        public int offset;
        private int original;
        private int key = 0;

        /// <summary>
        /// Initialize the form (Two overloads)
        /// </summary>
        public ssnOffset()
        {
            InitializeComponent();
            ssnOffsetText.Text = Utils.genSSN(offset, key).ToString();
        }

        /// <summary>
        /// Initialize the Form
        /// </summary>
        /// <param name="os">Offset</param>
        public ssnOffset(int os) : this()
        {
            offset = original = os;
        }

        /// <summary>
        /// Initialize the Form
        /// </summary>
        /// <param name="os">Offset</param>
        /// <param name="adminKey">SSN Key for the admin user</param>
        public ssnOffset(int os, int adminKey) : this(os)
        {
            key = adminKey;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            ssnOffsetText.Text = Utils.genSSN(++offset, key).ToString();
        }

        private void subBtn_Click(object sender, EventArgs e)
        {
            if (offset > 0)
                ssnOffsetText.Text = Utils.genSSN(--offset, key).ToString();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            offset = original;
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
