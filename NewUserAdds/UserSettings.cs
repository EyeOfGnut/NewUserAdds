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
    /// User Settings Form
    /// </summary>
    public partial class UserSettings : Form
    {
        private string extSig = Properties.Settings.Default.extSigFile;
        private string intSig = Properties.Settings.Default.intSigFile;

        /// <summary>
        /// Initialize the Form
        /// </summary>
        public UserSettings()
        {
            InitializeComponent();
        }

        private void UserSettings_Load(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(Properties.Settings.Default.intSigFile))
                intEmailSigDisp.Navigate(Properties.Settings.Default.intSigFile);

            if (!String.IsNullOrEmpty(Properties.Settings.Default.extSigFile))
                extEmailSigDisp.Navigate(Properties.Settings.Default.extSigFile);

            mainSrvTxt.Text = Properties.Settings.Default.addsServer;
            ordSrvTxt.Text = Properties.Settings.Default.orderingServer;
        }

        private void intEmailSigBtn_Click(object sender, EventArgs e)
        {
            string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Signatures";

            Cursor.Current = Cursors.WaitCursor; //switch to the hourglass cursor
            OpenFileDialog sigOFD = new OpenFileDialog();
            sigOFD.Title = "Access Request Form";

            sigOFD.InitialDirectory = appDataDir;
            sigOFD.Filter = "Outlook Signature Files (*.htm, *.html, *.txt)|*.htm;*.html;*.txt|All Files (*.*)|*.*"; //set the file types
            sigOFD.FilterIndex = 1; // Start with the first entry in the Filetype Dropdown
            sigOFD.RestoreDirectory = true;

            if (sigOFD.ShowDialog() == DialogResult.OK)
            {
                intSig = sigOFD.FileName;
                Cursor.Current = Cursors.Default; //reset to the normal cursor
                //strip out the path and show just the filename as the link, but the link itself is the full path to the file.
                try
                {
                    intEmailSigDisp.Navigate(sigOFD.FileName);
                    Properties.Settings.Default.intSigFile = sigOFD.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Open File Dialog Error: " + ex.Message);
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            applyBtn_Click(sender, e);
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.extSigFile = extSig;
            Properties.Settings.Default.intSigFile = intSig;
            Properties.Settings.Default.addsServer = mainSrvTxt.ToString();
            Properties.Settings.Default.orderingServer = ordSrvTxt.ToString();
            Properties.Settings.Default.Save();
        }

        private void extEmailSigBtn_Click(object sender, EventArgs e)
        {
            string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Signatures";

            Cursor.Current = Cursors.WaitCursor; //switch to the hourglass cursor
            OpenFileDialog sigOFD = new OpenFileDialog();
            sigOFD.Title = "Access Request Form";

            sigOFD.InitialDirectory = appDataDir;
            sigOFD.Filter = "Outlook Signature Files (*.htm, *.html, *.txt)|*.htm;*.html;*.txt|All Files (*.*)|*.*"; //set the file types
            sigOFD.FilterIndex = 1; // Start with the first entry in the Filetype Dropdown
            sigOFD.RestoreDirectory = true;

            if (sigOFD.ShowDialog() == DialogResult.OK)
            {
                extSig = sigOFD.FileName;
                Cursor.Current = Cursors.Default; //reset to the normal cursor
                //strip out the path and show just the filename as the link, but the link itself is the full path to the file.
                try
                {
                    extEmailSigDisp.Navigate(sigOFD.FileName);
                    Properties.Settings.Default.extSigFile = sigOFD.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Open File Dialog Error: " + ex.Message);
                }
            }
        }
    }
}
