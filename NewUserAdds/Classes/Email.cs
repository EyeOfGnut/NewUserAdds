using System;
using System.IO;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace NewUserAdds
{
    enum ShowWindowCommands : int
    {
        /// <summary>
        /// Hides the window and activates another window.
        /// </summary>
        Hide = 0,
        /// <summary>
        /// Activates and displays a window. If the window is minimized or
        /// maximized, the system restores it to its original size and position.
        /// An application should specify this flag when displaying the window
        /// for the first time.
        /// </summary>
        Normal = 1,
        /// <summary>
        /// Activates the window and displays it as a minimized window.
        /// </summary>
        ShowMinimized = 2,
        /// <summary>
        /// Maximizes the specified window.
        /// </summary>
        Maximize = 3, // is this the right value?
        /// <summary>
        /// Activates the window and displays it as a maximized window.
        /// </summary>      
        ShowMaximized = 3,
        /// <summary>
        /// Displays a window in its most recent size and position. This value
        /// is similar to Normal, except
        /// the window is not activated.
        /// </summary>
        ShowNoActivate = 4,
        /// <summary>
        /// Activates the window and displays it in its current size and position.
        /// </summary>
        Show = 5,
        /// <summary>
        /// Minimizes the specified window and activates the next top-level
        /// window in the Z order.
        /// </summary>
        Minimize = 6,
        /// <summary>
        /// Displays the window as a minimized window. This value is similar to
        /// ShowMinimized, except the
        /// window is not activated.
        /// </summary>
        ShowMinNoActive = 7,
        /// <summary>
        /// Displays the window in its current size and position. This value is
        /// similar to Show, except the
        /// window is not activated.
        /// </summary>
        ShowNA = 8,
        /// <summary>
        /// Activates and displays the window. If the window is minimized or
        /// maximized, the system restores it to its original size and position.
        /// An application should specify this flag when restoring a minimized window.
        /// </summary>
        Restore = 9,
        /// <summary>
        /// Sets the show state based on the SW_* value specified in the
        /// STARTUPINFO structure passed to the CreateProcess function by the
        /// program that started the application.
        /// </summary>
        ShowDefault = 10,
        /// <summary>
        ///  <b>Windows 2000/XP:</b> Minimizes a window, even if the thread
        /// that owns the window is not responding. This flag should only be
        /// used when minimizing windows from a different thread.
        /// </summary>
        ForceMinimize = 11
    }

    class Email
    {
        private Outlook.MailItem _mailItem = null;
        private Outlook.NameSpace _nameSpace = null;
        private Boolean _sent = false;
        private Boolean _isMd = false;

        private Person _person;
        public Person EmailPerson 
        {
            get{ return _person; }
            set{ _person = value; }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommands nCmdShow);

        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(IntPtr ZeroOnly, string lpWindowName);

        /// <summary>
        /// Destructor
        /// </summary>
        ~Email()
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(_mailItem);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(_nameSpace);
            _person = null;
        }

        public Email()
        {
            _mailItem = new Outlook.Application().CreateItem(Outlook.OlItemType.olMailItem) as Outlook.MailItem;

            // Tap into the Mail Item's Send and Close events
            // since the mail item is closed when sent or cancelled, and we need to know the difference.
            ((Outlook.ItemEvents_10_Event)_mailItem).Send += new Outlook.ItemEvents_10_SendEventHandler(mailItem_Send);

            _nameSpace = new Outlook.Application().GetNamespace("MAPI");
        }

        // Cascaded constructors
        // : this() executes the constructor that fits the pattern, then 
        // executes the code in this method.
        public Email(Person p) : this()
        {
            EmailPerson = p;
            _isMd = _person.JobCategory.Contains("Medical") && Utils.getDegreeInfo(_person.Degree)[0].Contains("D");
        }

        // Method to use with caught mailItem Send events (caught in the constructor)
        void mailItem_Send(ref bool Cancel)
        {
            if (!Cancel)
                _sent = true;
        }

        /// <summary>
        /// Send the email without showing it
        /// </summary>
        /// <returns>Sent status of email</returns>
        public Boolean Send()
        {
            return Send(false);
        }

        /// <summary>
        /// Send the email
        /// </summary>
        /// <param name="showDialog">Show the dialog before sending. Defaults to False</param>
        /// <returns>Sent status of email</returns>
        public Boolean Send(Boolean showDialog)
        {
            string body = string.Empty;
            string fName = _person.FirstName;
            string recipient = _person.Email; // Grab the email address for External users. Internal users will be an empty string

            if (string.IsNullOrEmpty(_person.FirstName))
                throw new ArgumentOutOfRangeException("firstName", "User First Name cannot be blank or null");
            if (string.IsNullOrEmpty(_person.LastName))
                throw new ArgumentOutOfRangeException("lastName", "User Last Name cannot be blank or null");
            if (!_person.Internal && string.IsNullOrEmpty(_person.Email))
                throw new ArgumentOutOfRangeException("emailAddress", "External users must have an email address set");
            if (_person.Internal && string.IsNullOrEmpty(_person.ShortName))
                throw new ArgumentOutOfRangeException("userName", "Internal users must have a username set");

            Outlook.Recipient usrMgr = null;

            // If the user is internal, overwrite the email address from _person.Email with the First and Last name, for lookup
            // in the Outlook Global Address Book. If they're internal, _person.Email should be empty anyway.
            if (_person.Internal)
            {
                recipient = _person.LastName + ", " + _person.FirstName; // Change from email address to Outlook Address List format
                
                if (!string.IsNullOrEmpty(_person.Manager))
                {
                    usrMgr = _mailItem.Recipients.Add(normalizeManager(_person.Manager));
                    usrMgr.Type = (int)Outlook.OlMailRecipientType.olCC;
                }
            }

            Outlook.Recipient newUser = _mailItem.Recipients.Add(recipient);
            newUser.Type = (int)Outlook.OlMailRecipientType.olTo;

            Outlook.Recipient FHIE = _mailItem.Recipients.Add("Franciscan HIE");
            FHIE.Type = (int)Outlook.OlMailRecipientType.olBCC;

            if (!_person.Internal)
            {
                Outlook.Recipient Nicole = _mailItem.Recipients.Add(Properties.Settings.Default.ExternalCoordinator);
                Nicole.Type = (int)Outlook.OlMailRecipientType.olBCC;
            }
            
            if(_person.Task != string.Empty)
            {
                // For some reason the GAL isn't resolving ITS Remedy anymore. Trying the actual email address.

                //Outlook.Recipient Remedy = _mailItem.Recipients.Add("ITS Remedy");
                Outlook.Recipient Remedy = _mailItem.Recipients.Add("itsremedy@catholichealth.net");
                Remedy.Type = (int)Outlook.OlMailRecipientType.olBCC;
            }

            // Generate the message body
            if (_isMd)
                fName = "Dr. " + _person.LastName;

            if (_person.Internal)
                if (!_person.Float)
                    body = buildMsgBody(fName, _person.ShortName);
                else
                    body = buildFltMsgBody(fName, _person.ShortName, _person.Location);
            else
                body = buildCommMsgBody(fName);

            resolveRecipients(_mailItem.Recipients, _nameSpace);

            // Set the message body and subject
            _mailItem.HTMLBody = body;
            _mailItem.Subject = buildSubject();

            if (!showDialog)
                ((Outlook._MailItem)_mailItem).Send();
            else
                ((Outlook._MailItem)_mailItem).Display(true);

            return _sent;
        }

        private void resolveRecipients(Outlook.Recipients recipients, Outlook.NameSpace nameSpace)
        {
            if (recipients == null)
                throw new ArgumentNullException();

            if (recipients.ResolveAll())
                return;
            else
            {
                for (int i = recipients.Count; i > 0; i--)
                {
                    if (!recipients[i].Resolve())
                    {
                        Outlook.SelectNamesDialog snd = nameSpace.GetSelectNamesDialog();
                        //snd.Recipients.Add(recipients[i].Name);
                        snd.Caption = recipients[i].Name;
                        snd.NumberOfRecipientSelectors = Outlook.OlRecipientSelectors.olShowToCc;
                        snd.ForceResolution = true;
                        snd.AllowMultipleSelection = false;
                        snd.Display();

                        if (!snd.Recipients.ResolveAll())
                            recipients.Remove(i);
                        else // Remove the unresolved name from the Recipients, and replace it with the resolved one.
                        {
                            recipients.Remove(i);

                            // If the recipient's name can't be resolved from the GAL, 
                            // and/or the user cancels the selection, DON'T try to add
                            // a resolved recipient - it doesn't exist and will throw an 
                            // Out Of Bounds error
                            if (snd.Recipients.Count > 0)
                            {
                                recipients.Add(snd.Recipients[1].Address);
                            }
                        }
                        snd = null;
                    }
                }
            }
        }


        private string buildSubject()
        {
            string subject = "Elysium ";
            if(_person.Float) subject += "Float ";
            subject += "Account for ";
            if (_isMd) subject += "Dr. ";
            subject = subject + _person.FirstName + " " + _person.LastName;

            if (_person.Task != string.Empty)
                subject = subject + " | " + _person.Task;
            return subject;

        }

        /// <summary>
        /// Fix the Manager name for resolving in the Outlook Address List
        /// </summary>
        /// <param name="managerName">Manager name</param>
        /// <returns> Manager name as {Last, First}</returns>
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

        private string buildFltMsgBody(string userFName, string loginName, string clinic)
        {
            StringBuilder msgBody = new StringBuilder();
            msgBody.Append(userFName);
            msgBody.Append(",<br><br>Your Elysium Float account for ");
            msgBody.Append(clinic);
            msgBody.Append(" has been created with username <strong>");
            msgBody.Append(loginName);
            msgBody.Append("</strong>, but your password is the same as your main account.<br>Please contact our support line at " 
                + Properties.Settings.Default.ExtContactNumber 
                + ' ' 
                + Properties.Settings.Default.IntContactNumber 
                + " if you have any questions or issues.<br><br>Thanks,<br>");
            msgBody.Append(getSignature("Int"));
            return msgBody.ToString();
        }

        private string buildMsgBody(string userFName, string loginName)
        {
            StringBuilder msgBody = new StringBuilder();
            msgBody.Append(userFName);
            msgBody.Append(",<br><br>Your Elysium account has been created with username <strong>");
            msgBody.Append(loginName);
            msgBody.Append("</strong>.<br>Please contact our support line at "
                + Properties.Settings.Default.ExtContactNumber
                + ' '
                + Properties.Settings.Default.IntContactNumber
                + " between 8am and 5pm to establish your temporary password, or if you have any questions or issues.<br>");
            msgBody.Append("If you only work night shift, please call our on-call cell phone at 253-341-9633<br><br>Thanks,<br>");
            msgBody.Append(getSignature("Int"));
            return msgBody.ToString();
        }

        private string buildCommMsgBody(string userFName)
        {
            StringBuilder msgBody = new StringBuilder();
            msgBody.Append(userFName);
            msgBody.Append(",<br>Your Elysium account has been created. Please contact our support line at "
                + Properties.Settings.Default.ExtContactNumber
                + " to receive your credentials.<br><br>Thanks,<br>");
            msgBody.Append(getSignature("Ext"));
            return msgBody.ToString();
        }

        private string getSignature(string intExt)
        {
            string appDataDir;
            string signature = string.Empty;
            string sigFile = "default.htm";
            if (intExt.Equals("Int"))
            {
                if (String.IsNullOrEmpty(Properties.Settings.Default.intSigFile))
                    appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Signatures";
                else
                {
                    appDataDir = Path.GetDirectoryName(Properties.Settings.Default.intSigFile);
                    sigFile = Path.GetFileName(Properties.Settings.Default.intSigFile);
                }
            }
            else
            {
                if (String.IsNullOrEmpty(Properties.Settings.Default.intSigFile))
                    appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Signatures";
                else
                {
                    appDataDir = Path.GetDirectoryName(Properties.Settings.Default.extSigFile);
                    sigFile = Path.GetFileName(Properties.Settings.Default.extSigFile);
                }
            }


            DirectoryInfo dInfo = new DirectoryInfo(appDataDir);

            if (dInfo.Exists)
            {

                FileInfo[] defSig = dInfo.GetFiles(sigFile);
                Array.Sort(defSig);

                if (defSig.Length > 0)
                {
                    StreamReader sr = new StreamReader(defSig[0].FullName, Encoding.Default);
                    signature = sr.ReadToEnd();

                    if (!string.IsNullOrEmpty(signature))
                    {
                        string fileName = defSig[0].Name.Replace(defSig[0].Extension, string.Empty);
                        signature = signature.Replace(fileName + "_files/", appDataDir + "/" + fileName + "_files/");
                    }
                }
            }

            return signature;
        }
    }
}
