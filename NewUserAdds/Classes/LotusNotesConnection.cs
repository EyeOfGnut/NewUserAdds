using System;
using System.Text;
using System.Windows.Forms;
using Domino;
using System.Collections.Generic;



namespace NewUserAdds
{
    /// <summary>
    /// Connect the the Notes servers via the locally installed Notes Client. The Client MUST be installed before
    /// this program can be used.
    /// The last user to log into the Notes Client is the one that will be used, by restriction from the Notes API.
    /// To change users, log into the Notes client first, then try to add new users with this program.
    /// </summary>
    public sealed class LotusNotesConnection
    {
        //private static string _NotesServer = "FHS5/CHIW";
        private static string _NotesServer = Properties.Settings.Default.addsServer;

        private NotesSession _notesSession = null;
        private NotesDatabase _dataBase = null;
        private NotesAgent _importAgent = null;

        private string _lotusClientPassword = null;

        /// <summary>Get or Set the Notes Client password</summary>
        public string LotusClientPassword {
            get { return _lotusClientPassword; }
            set { _lotusClientPassword = value; }
        }

        private string _lotusNotesServer = null;
        /// <summary>Get or Set the Notes Server string</summary>
        public string LotusNotesServer
        {
            get { return _lotusNotesServer; }
            set { _lotusNotesServer = value; }
        }

        private bool _isFetchServerData = false;

        #region Constructors

        /// <summary>
        /// Set up a new Notes Connection (One Overload)
        /// </summary>
        public LotusNotesConnection()
        {
            SetNotesDirectory();
        }

        /// <summary>
        /// Set up a new Notes Connection
        /// </summary>
        /// <param name="Password">Notes ID File password</param>
        /// <param name="ServerName">Notes Server</param>
        /// <param name="isFetchServerData">Boolean - Fetch server data</param>
        public LotusNotesConnection(string Password, string ServerName, bool isFetchServerData) : this()
        {
            _lotusClientPassword = Password;
            _lotusNotesServer = ServerName;
            _isFetchServerData = isFetchServerData;
        }

        #endregion

        #region Private Methods

        // Make sure that the Notes program directory is in the environment variable PATH.
        // Otherwise, the import agent will fail to run, as it won't know where to look for it's own requirements
        private void SetNotesDirectory()
        {
            Microsoft.Win32.RegistryKey notesDir = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(@".nsf\shell\open\command");

            StringBuilder list = new StringBuilder("Registry Value Names:\n");
            string value = notesDir.GetValue("") as string;
            value = value.Substring(1, value.LastIndexOf('\\') - 1);

            string path = Environment.GetEnvironmentVariable("PATH");

            if (!path.Contains(value))
                Environment.SetEnvironmentVariable("PATH", path + ";" + value, EnvironmentVariableTarget.Process);

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Opens a connection to the local Notes client
        /// </summary>
        /// <returns>Success or failure</returns>
        public bool StartSession()
        {
            try
            {
                _notesSession = new NotesSession();
                _notesSession.Initialize();
                             
            }
            catch(Exception ex)
            {
                if(!ex.Message.Equals("Notes error: The prompt for password was aborted by user"))
                    MessageBox.Show("StartSession() Caught Exception Message: " + ex.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Search the Notes database for a username
        /// </summary>
        /// <param name="username">Username to search for</param>
        /// <returns>Returns the full name belonging to the Username</returns>
        public String SearchUsername(string username)
        {
            NotesView peopleView;

            if (_notesSession == null)
                StartSession();

            try
            {
                if(_dataBase == null)
                    _dataBase = _notesSession.GetDatabase(_NotesServer, "names.nsf", false);


                //Object[] views = _dataBase.Views as Object[];
                //NotesViewList viewList = new NotesViewList(views);
                //viewList.ShowDialog();

                peopleView = _dataBase.GetView("_People");
                if (peopleView.FTSearch(username, 0) > 0)
                {
                    NotesDocument document = peopleView.GetFirstDocument();
                    StringBuilder itemList = new StringBuilder();
                    while (document != null)
                    {
                        Object[] items = document.Items as Object[];
                        String fName = string.Empty;
                        String lName = string.Empty;
                        String sName = string.Empty;
                        foreach (NotesItem item in items)
                        {
                            switch (item.Name)
                            {
                                case "ShortName":
                                    sName = item.Text;
                                    break;
                                case "FirstName":
                                    fName = item.Text;
                                    break;
                                case "LastName":
                                    lName = item.Text;
                                    break;
                                default:
                                    break;
                            }
                        }

                        if (username.Equals(sName))
                        {
                            return fName + " " + lName;
                        }
   
                        document = peopleView.GetNextDocument(document);
                    }
                }

                peopleView.Clear();
                Application.UseWaitCursor = false;
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("SearchUserName caught Excpetion: " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Triggers the import agent on the Notes server, but runs it locally. 
        /// This needs the local Notes Client directory to be included in the PATH Environment Variable
        /// </summary>
        /// <returns>Success or Failure</returns>
        public bool ImportCSV()
        {
            if (_notesSession == null)
                StartSession();

            try
            {
                if(_dataBase == null)
                    _dataBase = _notesSession.GetDatabase(_NotesServer, "names.nsf", false);

                _importAgent = _dataBase.GetAgent("(FHS_Import)");
                _importAgent.Run(); // Need to set in PATH to Notes directory in Windows environment variables
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ImportCSV() Caught Exception Message: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Refresh the Elysium Users view
        /// </summary>
        /// <returns>Success</returns>
        public bool RefreshUsers()
        {
            if (_notesSession == null)
                StartSession();

            try
            {
                if (_dataBase == null)
                {
                    _dataBase = _notesSession.GetDatabase(_NotesServer, "names.nsf", false);
                }

                NotesView usersView = _dataBase.GetView(@"Elysium Users");
                usersView.Refresh();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("RefreshPending() Caught Exception Message: " + ex.Message);
                return false;
            }
        }
        
        /// <summary>
        /// Attempt to trigger the Set_LD Fax agent. This will always fail
        /// </summary>
        /// <param name="ssn">SSN of the account to set</param>
        /// <returns>Success</returns>
        public bool SetFax(String ssn)
        {
            if (_notesSession == null)
                StartSession();

            try
            {
                NotesDatabase tmpDataBase = _notesSession.GetDatabase(_NotesServer, "names.nsf", false);

                NotesDocumentCollection faxUsers = tmpDataBase.FTSearch("\"" + ssn.Trim() + "\"", 0);
                if (faxUsers.Count > 0)
                {
                    if (faxUsers.Count > 1)
                    {
                        MessageBox.Show("More than one match for " + ssn);
                        return false;
                    }
                    else
                    {
                        NotesDocument document = faxUsers.GetFirstDocument();
                        while (document != null)
                        {
                            NotesAgent _faxAgent = tmpDataBase.GetAgent("set fax address LD");
                            _faxAgent.Run(document.NoteID);
                            document = faxUsers.GetNextDocument(document);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No matching documents for " + ssn + ".");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SetFax caught Exception Message: " + ex.Message);
                return false;
            }

            return true;
        }

        // This doesn't really work as intended. Still need to refresh the client view manually, but 
        // keeping it just in case we need it for future use/reference.
        /// <summary>
        /// Refresh the Pending view. Doesn't work.
        /// </summary>
        /// <returns>Success</returns>
        public bool RefreshPending()
        {
            if (_notesSession == null)
                StartSession();

            try
            {
                if (_dataBase == null)
                {
                    _dataBase = _notesSession.GetDatabase(_NotesServer, "names.nsf", false);
                }
                
                NotesView pendingView = _dataBase.GetView(@"Elysium Users\Pending");
                pendingView.Refresh();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("RefreshPending() Caught Exception Message: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Process every document in the Pending view. Careful, this will process those that were there already, as well.
        /// </summary>
        /// <returns>Success or Failure</returns>
        public bool ProcessAllPending()
        {
            if (_notesSession == null)
                StartSession();

            try
            {
                if (_dataBase == null)
                {
                    _dataBase = _notesSession.GetDatabase(_NotesServer, "names.nsf", false);
                }

                _importAgent = _dataBase.GetAgent("UMT_ProcessAll");
                _importAgent.RunOnServer();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ProcessAllPending() Caught Exception Message: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Attempt to process specific Pending documents in Notes. Doesn't work.
        /// </summary>
        /// <param name="ssnList">List of SSN strings for accounts to process</param>
        /// <returns>Success</returns>
        public bool ProcessPending(List<String> ssnList)
        {
            if (_notesSession == null)
                StartSession();

            try
            {
                if (_dataBase == null)
                {
                    _dataBase = _notesSession.GetDatabase(_NotesServer, "names.nsf", false);
                }

                NotesView pendingView = _dataBase.GetView(@"Elysium Users\Pending");
                NotesAgent processingAgent = _dataBase.GetAgent("UMT_Process");
                NotesDocument pendingUser = null;
                pendingUser = pendingView.GetFirstDocument();
                Object[] items = null;
                List<String> noteIdList = new List<String>();

                while (pendingUser != null)
                {
                    items = pendingUser.Items as Object[];
                    foreach (NotesItem item in items)
                    {
                        if (item.Name == "SSN")
                        {
                            if (ssnList.Contains(item.Text))
                                noteIdList.Add(pendingUser.NoteID);

                            break;
                        }
                    }                    
                }

                foreach(string noteId in noteIdList)
                    processingAgent.RunOnServer(noteId);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ProcessAllPending() Caught Exception Message: " + ex.Message);
                return false;
            }
        }

        
        /// <summary>
        /// Add the user names to the Break-the-Glass policy
        /// </summary>
        /// <param name="cpiList">List of Person objects, representing the users to add to the CPI policy</param>
        public void cpiExceptions(List<Person> cpiList)
        {
            NotesDatabase cpiDB = _notesSession.GetDatabase("fhs7.axolotl.com", "ea/administration.nsf");
            NotesView byTemplate = cpiDB.GetView("Active Policies\\By Template");

            foreach (Person p in cpiList)
            {
                NotesDocument document = byTemplate.GetDocumentByKey("EA CPI");
                Char lastInit = p.LastName[0];
                while (null != document && (document.ColumnValues as Object[])[0].ToString().Equals("EA CPI"))
                {
                    if (typeof(Object[]) == (document.ColumnValues as Object[])[1].GetType())
                    {
                        String[] colName = ((document.ColumnValues as Object[])[1] as Object[])[0].ToString().Split(' ');
                        if (lastInit == colName[colName.Length - 1][0]) break;
                    }

                    document = byTemplate.GetNextDocument(document);
                }

                if (null != document && (document.ColumnValues as Object[])[0].ToString().Equals("EA CPI"))
                {
                    Object[] cpiNames = document.GetItemValue("UserName") as Object[];
                    Array.Resize(ref cpiNames, cpiNames.Length + 1);
                    cpiNames[cpiNames.Length - 1] = p.FullName;
                    document.ReplaceItemValue("UserName", cpiNames);
                    document.Save(false, false);
                }
                else
                {
                    MessageBox.Show("Error adding " + p.FullName + " to CPI Exception List");
                }
            }
        }

        #endregion
    }
}
