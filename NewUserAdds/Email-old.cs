using System;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;


namespace NewUserAdds
{
    class Email
    {
        /// <summary>
        /// Send an email notificaiton
        /// Overload for Community Users
        /// </summary>
        /// <param name="md">Does the new user need "Dr." appended to their name?</param>
        /// <param name="userFName">User's First Name</param>
        /// <param name="userLName">User's Last Name</param>
        /// <param name="commUserEmail">Users email address</param>// 
        /// <param name="show">Display the finished email, or just send it</param>
        public static bool sendNotificationEmail(bool md, string userFName, string userLName, string commUserEmail, bool show)
        {
            Outlook.Application olApp = null;
            Outlook.MailItem email = null;
            Outlook.NameSpace oNS = null;

            try
            {
                olApp = new Outlook.Application();
                email = (Outlook.MailItem)olApp.CreateItem(Outlook.OlItemType.olMailItem);
                oNS = olApp.GetNamespace("MAPI");

                if (md)
                {
                    email.Subject = "Dr. " + userFName + " " + userLName + "'s Elysium Account";
                    email.HTMLBody = old_buildCommMsgBody("Dr. " + userLName);
                }
                else
                {
                    email.HTMLBody = old_buildCommMsgBody(userFName);
                    email.Subject = userFName + " " + userLName + "'s Elysium Account";
                }

                Outlook.Recipient newUser = email.Recipients.Add(commUserEmail);
                newUser.Type = (int)Outlook.OlMailRecipientType.olTo;

                Outlook.Recipient FHIE = email.Recipients.Add("Franciscan HIE");
                FHIE.Type = (int)Outlook.OlMailRecipientType.olBCC;

                old_resolveRecipients(email.Recipients, oNS);

                if(!show)
                    ((Outlook._MailItem)email).Send();
                else
                    ((Outlook._MailItem)email).Display(true);

                Marshal.ReleaseComObject(newUser);
                Marshal.ReleaseComObject(FHIE);

                if (email.Sent)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending email: " + ex.Message);
                return false;
            }
            finally
            {
                if (email != null) Marshal.ReleaseComObject(email);
                if (olApp != null) Marshal.ReleaseComObject(olApp);
                if (oNS != null) Marshal.ReleaseComObject(oNS);
            }
        }

        /// <summary>
        /// Send an email notification to Internal Franciscan users, and their manager.
        /// </summary>
        /// <param name="md">Does the user need "Dr." appended?</param>
        /// <param name="userFName">User's First name</param>
        /// <param name="userLName">User's Last name</param>
        /// <param name="loginName">User's Elysium login name</param>
        /// <param name="manager">Manager's FULL name</param>
        /// <param name="show">Display the finished email, or just send it</param>
        public static bool sendNotificationEmail(bool md, string userFName, string userLName, string loginName, string manager, string fltClinic, bool show)
        {
            Outlook.Application olApp = null;
            Outlook.MailItem email = null;
            Outlook.NameSpace oNS = null;

            try
            {
                olApp = new Outlook.Application();
                email = (Outlook.MailItem)olApp.CreateItem(Outlook.OlItemType.olMailItem);
                oNS = olApp.GetNamespace("MAPI");

                if (md)
                {
                    if (string.IsNullOrEmpty(fltClinic))
                    {
                        email.HTMLBody = old_buildMsgBody("Dr. " + userLName, loginName);
                        email.Subject = "Dr. " + userFName + " " + userLName + "'s Elysium Account";
                    }
                    else
                    {
                        email.HTMLBody = old_buildFltMsgBody("Dr. " + userLName, loginName, fltClinic);
                        email.Subject = "Dr. " + userFName + " " + userLName + "'s Elysium Float Account";
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(fltClinic))
                    {
                        email.HTMLBody = old_buildMsgBody(userFName, loginName);
                        email.Subject = userFName + " " + userLName + "'s Elysium Account";
                    }
                    else
                    {
                        email.HTMLBody = old_buildFltMsgBody(userFName, loginName, fltClinic);
                        email.Subject = userFName + " " + userLName + "'s Elysium Float Account";
                    }
                }

                Outlook.Recipient newUser = email.Recipients.Add(userLName + ", " + userFName);
                newUser.Type = (int)Outlook.OlMailRecipientType.olTo;

                
                Outlook.Recipient usrMgr = null;
                if (!string.IsNullOrEmpty(manager))
                {
                    usrMgr = email.Recipients.Add(manager);
                    usrMgr.Type = (int)Outlook.OlMailRecipientType.olCC;
                }

                Outlook.Recipient FHIE = email.Recipients.Add("Franciscan HIE");
                FHIE.Type = (int)Outlook.OlMailRecipientType.olBCC;

                old_resolveRecipients(email.Recipients, oNS);
               
                if(!show)
                    ((Outlook._MailItem)email).Send();
                else
                    ((Outlook._MailItem)email).Display(true);

                // Cleanup
                if (newUser != null) Marshal.ReleaseComObject(newUser);
                if (usrMgr != null) Marshal.ReleaseComObject(usrMgr);
                if (FHIE != null) Marshal.ReleaseComObject(FHIE);
                

                if (email.Sent)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sending Email Error: " + ex.Message);
                return false;
            }
            finally
            {
                if (email != null) Marshal.ReleaseComObject(email);
                if (olApp != null) Marshal.ReleaseComObject(olApp);
                if (oNS != null) Marshal.ReleaseComObject(oNS);
            }
        }

        private static void old_resolveRecipients(Outlook.Recipients recipients, Outlook.NameSpace nameSpace){
            if (recipients == null)
                throw new ArgumentNullException();

            if (recipients.ResolveAll())
                return;
            else
            {
                for (int i = 1; i <= recipients.Count; i++)
                {
                    if (!recipients[i].Resolve())
                    {
                        Outlook.SelectNamesDialog snd = nameSpace.GetSelectNamesDialog();
                        snd.Recipients.Add(recipients[i].Name);
                        snd.Caption = recipients[i].Name;
                        snd.NumberOfRecipientSelectors = Outlook.OlRecipientSelectors.olShowToCc;
                        snd.ForceResolution = true;
                        snd.AllowMultipleSelection = false;
                        snd.Display();

                        if (!snd.Recipients.ResolveAll())
                            recipients.Remove(i);
                        else
                        {
                            recipients.Remove(i);
                            recipients.Add(snd.Recipients[1].Address);
                        }
                        snd = null;
                    }
                }
            }
        }

        private static string old_buildFltMsgBody(string userFName, string loginName, string clinic)
        {
            StringBuilder msgBody = new StringBuilder();
            msgBody.Append(userFName);
            msgBody.Append(",<br><br>Your Elysium Float account for ");
            msgBody.Append(clinic);
            msgBody.Append(" has been created with username <strong>");
            msgBody.Append(loginName);
            msgBody.Append("</strong>, but your password is the same as your main account.<br>Please contact our support line at 253-428-8350 (152-8350) if you have any questions or issues.<br><br>Thanks,<br>");
            msgBody.Append(old_getSignature("Int"));
            return msgBody.ToString();
        }

        private static string old_buildMsgBody(string userFName, string loginName)
        {
            StringBuilder msgBody = new StringBuilder();
            msgBody.Append(userFName);
            msgBody.Append(",<br><br>Your Elysium account has been created with username <strong>");
            msgBody.Append(loginName);
            msgBody.Append("</strong>.<br>Please contact our support line at 253-428-8350 (152-8350) to establish your temporary password, or if you have any questions or issues.<br><br>Thanks,<br>");
            msgBody.Append(old_getSignature("Int"));
            return msgBody.ToString();
        }

        private static string old_buildCommMsgBody(string userFName)
        {
            StringBuilder msgBody = new StringBuilder();
            msgBody.Append(userFName);
            msgBody.Append(",<br>Your Elysium account has been created. Please contact our support line at 253-779-6120 to receive your credentials.<br><br>Thanks,<br>");
            msgBody.Append(old_getSignature("Ext"));
            return msgBody.ToString();
        }

        private static string old_getSignature(string intExt)
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
