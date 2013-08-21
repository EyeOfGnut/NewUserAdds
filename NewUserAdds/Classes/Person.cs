using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NewUserAdds
{
    /// <summary>
    /// Class for a new user's account information and methods specific to a single user.
    /// </summary>
    public class Person
    {
        // Ordering
        /// <summary>
        /// Suppliers for Elysium Ordering
        /// </summary>
        public const string SupplierName = "FHS - DI;FHS - Lab"; // FHS - DI, FHD - Lab
        //public const string ServerName = "FHS3/CHIW;FHS3/CHIW"; // FHS3/CHIW
        private static string ServerName = Properties.Settings.Default.orderingServer + ";" + Properties.Settings.Default.orderingServer;

        /// <summary>
        /// File path for ordering directory on Notes Server
        /// </summary>
        public const string SupplierPath = @"ea\ordering\radcat.nsf;ea\ordering\radcat.nsf"; // ea\ordering\radcat.nsf

        // Add Ons
        /// <summary>Boolean storing wether or not to add Ordering</summary>
        public bool Ordering;
        /// <summary>Boolean storing wether or not to add Patient Index Editing</summary>
        public bool EditPatientIndex;
        /// <summary>Boolean storing wether or not to add Repository access</summary>
        public bool Repository;
        /// <summary>Boolean storing wether or not to add Prescription Writer</summary>
        public bool PrescriptionWriter;

        // Notes Connection
        private LotusNotesConnection _notesConnection = null;
        /// <summary>Get or Set the Notes Connection string</summary>
        public LotusNotesConnection NotesConnection
        {
            get { return _notesConnection; }
            set { _notesConnection = value; }
        }


        // User Demographics
        private string _firstName;
        /// <summary>Get or Set the new user's First Name</summary>
        public string FirstName // "Accessor"
        {
            get { return _firstName; }
            set { _firstName = NormalizeName(value); }
        }

        private string _middleInitial;
        /// <summary>Get or Set the new user's Middle Initial</summary>
        public string MiddleInitial
        {
            get { return _middleInitial; }
            set {
                if (value.Length > 0)
                    _middleInitial = value.Substring(0, 1);
                else
                    _middleInitial = "";
            }
        }

        private string _lastName;
        /// <summary>Get or Set the new user's Last Name</summary>
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (UserType != "Fax")
                    _lastName = NormalizeName(value);
                else
                    if (value == CompanyName)
                    {
                        _lastName = value;
                    }
                    else
                    {
                        _lastName = NormalizeName(value);
                    }
            }
        }

        public string FullName
        {
            get {
                if(String.IsNullOrEmpty(_middleInitial))
                    return _firstName + ' ' + _lastName;
                else
                    return _firstName + ' ' + _middleInitial + ' ' + _lastName;
            }
        }


        /// <summary>Dr, Prof, Mr, Mrs, Ms, etc</summary>
        public string Title; // Dr., Prof, Mr, Mrs, Ms, etc
        /// <summary>The User's degree abbreviation (MD, DO, MA, etc)</summary>
        public string Degree; // aka Degree
        private string _shortname; // aka User Name
        /// <summary>Get or Set the new user's Short Name (aka login name, user name)</summary>
        public string ShortName
        {
            get
            {
                if (string.IsNullOrEmpty(_shortname))
                    genShortName();
                return _shortname;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    genShortName();
                else
                    _shortname = value;
            }
        }

        /// <summary>User's initial, random password</summary>
        public string Password;
        /// <summary>Unique identifier containing date and creator stamps</summary>
        public string SSN;
        /// <summary>User's email (Only used for community users)</summary>
        public string Email;

        // Account Details
        private string _userType; // EW, ERep, Fax
        /// <summary>Get or Set the User's type (Fax, VHR, EMR)</summary>
        public string UserType
        {
            get { return _userType; }
            set
            {
                _userType = fixUserType(value);
                if (_userType == "Fax") Fax = true;
            }
        }

        private string _specialty;
        /// <summary>Get or Set the new user's Specialty</summary>
        public string Specialty
        {
            get { return _specialty; }
            set { _specialty = value.Trim(); }
        }

        /// <summary>Users DEA number</summary>
        public string Dea;
        /// <summary>Users RX License number. This is "N/A" and only used for provider accounts</summary>
        public string RxLicenseNumber;
        /// <summary>Users Job Category</summary>
        public string JobCategory; // LHP, Staff-I, Medical Doctor
        /// <summary>Users Medicare number (unused)</summary>
        public string Upin; // Medicare Number
        /// <summary>Tag for Float Accounts</summary>
        public string Credential2; // Second Account
        /// <summary>Specialty abbreviation</summary>
        public string Credential5; // Specialty

        private string _credential6;
        /// <summary>Get or Set the Transcription company abbreviation</summary>
        public string Credential6
        {
            get { return _credential6; }
            set
            {
                _credential6 = value;
                if(_credential6.Equals("TNI"))
                {
                    IdQualifier += ";Export";
                }
            }
        }// Transcription Svc

        private string _ssoID;
        /// <summary>
        /// The SSO ID
        /// </summary>
        public string SSOID
        {
            get { return _ssoID; }
            set { _ssoID = value; }
        }

        /// <summary>National Provider Index</summary>
        public string Npi;

        // Company Info
        /// <summary>Clinic SQL ID Number</summary>
        public string ClinicId;
        private string _clinicAbbr;
        /// <summary>Get or Set the Clinic Abbreviation</summary>
        public string ClinicAbbr
        {
            get { return _clinicAbbr; }
            set { _clinicAbbr = value.Trim(); }
        }

        // Fix Fax account imports where the user didn't know how the Caps Lock key works.
        private string _companyName;
        /// <summary>Get or Set the Company Name</summary>
        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                value = value.ToLower();
                if (!value.Equals("fmg") && !value.Equals("fhs"))
                {
                    _companyName = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
                }
                else
                {
                    _companyName = value.ToUpper();
                }
            }
        }

        private string _phoneNumber;
        /// <summary>Get or Set the clinic phone number</summary>
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = validatePhone(value); }
        }

        private string _faxNumber = null;
        /// <summary>Get or Set the clinic fax number</summary>
        public string FaxNumber
        {
            get { return _faxNumber; }
            set { _faxNumber = validatePhone(value); }
        }

        /// <summary>Clinic location, in the event of a chain of clinics under a company (i.e. FMG St Joseph Medical Center)</summary>
        public string Location;
        /// <summary>Clinic Street and number</summary>
        public string StreetAddress;
        /// <summary>Clinic City</summary>
        public string City;
        /// <summary>Clinic State</summary>
        public string State;
        /// <summary>Clinic Zip</summary>
        public string Zip;
        /// <summary>Clinic Country (Def: USA)</summary>
        public string Country = "USA";
        /// <summary>Clinic's Database</summary>
        public string Ecd;

        // These three are for the "External Organization ID Information,
        // which is the information for routing, setting up TNI, etc.
        /// <summary>Last 5 digits of provider's state license</summary>
        public string LocalId; // STAR ID 
        /// <summary>Constant</summary>
        public const string OrgName = "CHIW";
        /// <summary>Constant</summary>
        public string IdQualifier = "FHS"; // "FHS", "Export", etc.

        /// <summary>Users Manager, for notification dissemination</summary>
        public string Manager;
        /// <summary>Remedy Task number</summary>
        public string Task;
        /// <summary>SQL ID of the provider's specialty</summary>
        public string SpecialtyId;
        /// <summary>Link to the Access Request Form</summary>
        public string ARForm;

        //Account Type switches
        /// <summary>
        /// Get or Set the Internal Account switch.
        /// </summary>
        private bool _internal;
        /// <summary>Get or Set if the new user is internal or community</summary>
        public bool Internal
        {
            get { return _internal; }
            set { _internal = value; }
        }

        /// <summary>
        /// Get or Set the Float switch. Setting this to True will set Fax to false.
        /// </summary>
        private bool _float;
        /// <summary>Get or Set if the new account is a Float (secondary) account</summary>
        public bool Float
        {
            get { return _float; }
            set
            {
                _float = value;
                if (_float)
                {
                    Fax = false;
                    Credential2 = "Second Account";
                }
            }
        }

        /// <summary>
        /// Get or Set the Fax switch. Setting this to True will set Float to false.
        /// </summary>
        private bool _fax;
        /// <summary>Get or Set if the account is a Fax only account</summary>
        public bool Fax
        {
            get { return _fax; }
            set
            {
                _fax = value;
                if (_fax)
                    Float = false;
            }
        }

        /// <summary>Create and configure a new Person object with default values</summary>
        public Person()
        {
            Ordering = EditPatientIndex = Repository = PrescriptionWriter = false;
            _internal = true;
            _float = false;
            _fax = false;
        }

        /// <summary>
        /// Generates the 'Short Name' (aka username) for the user, based on if the new account is a 
        /// float or fax account, or a normal account
        /// </summary>
        /// <returns>Username, formatted as abbr + first initial + 7 letters of last name</returns>
        public bool genShortName()
        {
            if (!string.IsNullOrEmpty(_firstName) && !string.IsNullOrEmpty(_lastName))
            {
                string shortName;
                if (_lastName.Length > 7)
                    shortName = _firstName.Substring(0, 1) + _lastName.Substring(0, 7);
                else
                    shortName = _firstName.Substring(0, 1) + _lastName;

                shortName = NormalizeName(shortName); //Ensure that referral accounts don't have bad characters

                if (_float) shortName = ClinicAbbr.ToLower().Trim() + shortName;
                if (_fax) shortName = "fax" + shortName;

                _shortname = shortName.ToLower().Trim();
                checkUserName();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Trim out invalid characters from Names (i.e. hyphens)
        /// </summary>
        /// <param name="name">Name to normalize. First OR Last. Sending both with a space will
        /// return both mashed together without the space</param>
        /// <returns>Normalized Name in a string</returns>
        private string NormalizeName(string name)
        {
            char[] invalid = { '-', '\'', ' ' };
            foreach (char item in invalid)
            {

                while (name.Contains(item))
                    name = name.Remove(name.IndexOf(item), 1);
            }

            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());
        }

        /// <summary>
        /// The Elysium backend user type designation isn't user friendly,
        /// so this flip-flops between the actual designation and the understandable version.
        /// </summary>
        /// <param name="type">String of user type</param>
        /// <returns>The alternate verison of the user type (i.e. EW to Workstation and back)</returns>
        private static string fixUserType(string type)
        {
            switch (type)
            {
                case "Workstation":
                    return "EW";
                case "Repository":
                    return "ERep";
                case "Fax":
                    return "Fax";
                case "EW":
                    return "EW";
                case "ERep":
                    return "ERep";
                default:
                    MessageBox.Show("Invalid User Type");
                    return "";
            }
        }

        /// <summary>
        /// Validates and fixes phone numbers, removing anything but integers
        /// </summary>
        /// <param name="phoneNumber">Phone number as a string</param>
        /// <returns>Validated and fixed phone number, as a string</returns>
        private string validatePhone(string phoneNumber)
        {
            char[] invalid = { '-', '(', ')', ' ', '.' };

            foreach (char item in invalid)
            {

                while (phoneNumber.Contains(item))
                    phoneNumber = phoneNumber.Remove(phoneNumber.IndexOf(item), 1);
            }
            return phoneNumber;
        }
        
        /// <summary>
        /// Checks the generated short name against the Database of existing users to ensure it's unique.
        /// </summary>
        public void checkUserName()
        {
            string usedName = usedShortName(ShortName);
            System.Windows.Forms.DialogResult dr = new System.Windows.Forms.DialogResult();
            if (!string.IsNullOrEmpty(usedName))
            {
                ChangeUserName newName = new ChangeUserName(ShortName, usedName);
                dr = newName.ShowDialog();
                ShortName = newName.uName;
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    checkUserName();
                }
                else
                {
                    MessageBox.Show(ShortName + " is used.\nYou will need to change it to add this new user."
                        , "Username is in use"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Warning
                        , MessageBoxDefaultButton.Button1);
                }
            }
        }


        private string usedShortName(string username)
        {
            if (_notesConnection != null)
            {
#if DEBUG
                MessageBox.Show("Searching Notes Connection");
#endif
                return _notesConnection.SearchUsername(username);
            }
            else
            {
                
                string[] tmpInfo = new string[11];
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Properties.Settings.Default.RawDataDBConnectionString);
                System.Data.DataSet dSet = new System.Data.DataSet();
                string sql = "Select RTRIM(FirstName + ' ' + LastName) as Name from AddrBk_Person where ShortName = '" + username + "' And Deleted = 0";

                System.Data.SqlClient.SqlDataAdapter dAdapter = new System.Data.SqlClient.SqlDataAdapter(sql, con);
                dAdapter.Fill(dSet, "shortnames");

                if (dSet.Tables["shortnames"].Rows.Count > 0)
                    return dSet.Tables["shortnames"].Rows[0].ItemArray.GetValue(0).ToString();
                else
                    return string.Empty;
            }
        }

        /// <summary>
        /// Sets the Clinic's information from the SQL Database
        /// </summary>
        /// <param name="id">SQL ID of the Clinic</param>
        public void setClinicInfo(string id)
        {           
            string[] tmpInfo = new string[11];
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Properties.Settings.Default.UserAddDBConnectionString);
            System.Data.DataSet dSet = new System.Data.DataSet();
            string sql = "SELECT * From Clinics Where id = " + id;

            System.Data.SqlClient.SqlDataAdapter dAdapter = new System.Data.SqlClient.SqlDataAdapter(sql, con);
            dAdapter.Fill(dSet, "Clinics");
            System.Data.DataRow dRow = dSet.Tables["Clinics"].Rows[0];
            for (int i = 0; i < 11; i++)
                tmpInfo[i] = dRow.ItemArray.GetValue(i).ToString();

            ClinicAbbr = tmpInfo[10]; // Clinic Abbreviation
            if (tmpInfo[1].Contains("FMG") || tmpInfo[1].Contains("FHS"))
            {
                CompanyName = tmpInfo[1].Substring(0, 3).Trim();
                int idx = tmpInfo[1].IndexOf("-");
                Location = tmpInfo[1].Substring(idx+2, tmpInfo[1].Length - (idx+2)).Trim();
            }
            else
            {
                CompanyName = tmpInfo[1]; //Clinic Name
                Location = string.Empty;
            }
            PhoneNumber = tmpInfo[2].Trim(); // Phone
            FaxNumber = tmpInfo[3].Trim(); // Fax
            StreetAddress = tmpInfo[4].Trim(); // Address
            City = tmpInfo[5].Trim(); // City
            State = tmpInfo[6].Trim(); // State
            Zip = tmpInfo[7].Trim(); // Zip
            Country = tmpInfo[8].Trim(); // Country
            Ecd = tmpInfo[9].Trim(); // ECD
            ClinicId = tmpInfo[0].Trim(); // ID*/


            dAdapter.Dispose();
            con.Close();
        }

        /// <summary>
        /// If the person is a provider, and the STAR ID is left blank, 
        /// this will attempt to look it up via  the ProviderInfo intranet page.
        /// </summary>
        private void CheckLUID()
        {
            if(String.IsNullOrEmpty(LocalId) && JobCategory.Contains("Medical"))
            {
                string id = Utils.GetStarID(LastName + "," + FirstName);
                if (!id.Contains("Not Found"))
                    LocalId = id;
            }
        }

        /// <summary>Generate the comma-deliminated entry for this user, to be used in the CSV export (One Overload)</summary>
        public string GetExportCSV() { return GetExportCSV(false); }
        /// <summary>Generate the comma-deliminated entry for this user, to be used in the CSV export or Log</summary>
        /// <param name="log">Boolean - True = Generate CSV for Log, False = Generate CSV for Notes Export</param>
        public string GetExportCSV(bool log)
        {
            CheckLUID();
            StringBuilder csvLine = new StringBuilder("\"");
            
            csvLine.Append(_firstName);
            if (_float) csvLine.Append(ClinicAbbr.ToUpper());
            if (UserType == "ERep" && !log) csvLine.Append("VHR");
            csvLine.Append("\",");

            csvLine.Append("\"" + _middleInitial + "\",");
            csvLine.Append("\"" + _lastName + "\",");
            csvLine.Append("\"" + Title + "\",");

            if (Fax)
            {
                csvLine.Append("\"" + Degree + "\",");
            }
            else
            {
                csvLine.Append("\"" + Utils.getDegreeInfo(Degree)[0] + "\",");
            }

            csvLine.Append("\"" + ShortName + "\",");

            if (log)
                csvLine.Append("||");
            else
                csvLine.Append("\"" + Password + "\",");

            csvLine.Append("\"" + CompanyName + "\",");
            csvLine.Append("\"" + PhoneNumber + "\",");
            csvLine.Append("\"" + FaxNumber + "\",");
            csvLine.Append("\"" + Location + "\",");
            csvLine.Append("\"" + buildAddOns() + "\",");
            csvLine.Append("\"" + StreetAddress + "\",");
            csvLine.Append("\"" + City + "\",");
            csvLine.Append("\"" + State + "\",");
            csvLine.Append("\"" + Zip + "\",");
            csvLine.Append("\"" + Country + "\",");
            csvLine.Append("\"" + SSN + "\",");

            if (UserType == "ERep")
                csvLine.Append("\"Elysium Repository Only Workgroup\",");
            else
                csvLine.Append("\"" + Ecd + "\",");

            csvLine.Append(buildExtIds());            

            csvLine.Append("\"" + UserType + "\",");
            csvLine.Append("\"" + Specialty + "\",");
            csvLine.Append("\"" + Dea + "\",");

            if (PrescriptionWriter)
                csvLine.Append("\"NA\",");
            else
                csvLine.Append("\"\",");

            csvLine.Append("\"" + JobCategory + "\",");
            csvLine.Append("\"" + Upin + "\",");
            csvLine.Append("\"" + Credential2 + "\",");
            csvLine.Append("\"" + Credential5 + "\",");
            csvLine.Append("\"" + Npi + "\",");

            if (Ordering)
            {
                csvLine.Append("\"" + SupplierName + "\",");
                csvLine.Append("\"" + ServerName + "\",");
                csvLine.Append("\"" + SupplierPath + "\",");
            }
            else
                csvLine.Append("\"\",\"\",\"\",");

            csvLine.Append("\"" + Email + "\",");
            csvLine.Append("\"" + Credential6 + "\"");

            return csvLine.ToString();
        }

        private string buildExtIds()
        {
            StringBuilder extIds = new StringBuilder();
            StringBuilder qIds = new StringBuilder();
            StringBuilder org = new StringBuilder();

            if (!string.IsNullOrEmpty(LocalId))
            {
                extIds.Append(LocalId);
                qIds.Append("FHS");
                org.Append(OrgName);
            }

            if(!string.IsNullOrEmpty(Credential6) && Credential6.Contains("TNI"))
            {
                if (extIds.Length > 0) { extIds.Append(';'); qIds.Append(';'); org.Append(';'); }
                extIds.Append(LocalId);
                qIds.Append("Export");
                org.Append(OrgName);
            }

            if (!string.IsNullOrEmpty(SSOID))
            {
                if (extIds.Length > 0) { extIds.Append(';'); qIds.Append(';'); org.Append(';'); }
                extIds.Append(SSOID);
                qIds.Append("SSO");
                org.Append(OrgName);
                Credential2 = "Epic";
            }

            return "\"" + extIds.ToString() + "\",\"" + org.ToString() + "\",\"" + qIds.ToString() + "\",";
        }

        /// <summary>
        /// Additional entries for Log information, that are not required for the Export CSV
        /// </summary>
        /// <returns>String with extra info formatted for the Log</returns>
        public string GetLogCSV()
        {
            StringBuilder csvLine = new StringBuilder(GetExportCSV(true).Replace("\",\"", "|"));
            csvLine.Append("|" + Manager);
            csvLine.Append("|" + Task);
            csvLine.Append("|" + ClinicId);
            csvLine.Append("|" + SpecialtyId);
            csvLine.Append("|" + ARForm);
            csvLine.Append("|" + Internal.ToString());
            csvLine.Append("|" + Float.ToString());
            csvLine.Append("|" + Fax.ToString());
            csvLine.Append("|" + Utils.getFullName(Environment.UserName));

            return csvLine.ToString().Replace("\"", "").Replace(",|", "|");
        }

        /// <summary>
        /// Restore previous Pending Users from the log
        /// </summary>
        /// <param name="values">DataTable Array of the values to be restored</param>
        /// <returns>Success</returns>
        public bool RestoreFromCSV(string[] values)
        {
            if (values.Count() == 45)
            {
                FirstName = values[0];
                MiddleInitial = values[1];
                LastName = values[2];
                Title = values[3];
                Degree = values[4];
                ShortName = values[5];
                Password = values[6];
                CompanyName = values[7];
                PhoneNumber = values[8];
                FaxNumber = values[9];
                Location = values[10];
                setAddOns(values[11]);
                StreetAddress = values[12];
                City = values[13];
                State = values[14];
                Zip = values[15];
                Country = values[16];
                SSN = values[17];
                Ecd = values[18];
                LocalId = values[19];
                //OrgName = values[20];
                IdQualifier = values[21];
                UserType = values[22];
                Specialty = values[23];
                Dea = values[24];
                RxLicenseNumber = values[25];
                JobCategory = values[26];
                Upin = values[27];
                Credential2 = values[28];
                Credential5 = values[29];
                Npi = values[30];
                //SupplierName = values[31];
                //ServerName = values[32];
                //SupplierPath = values[33];
                Email = values[34];
                Credential6 = values[35];
                Manager = values[36];
                Task = values[37];
                ClinicId = values[38];
                SpecialtyId = values[39];
                ARForm = values[40];
                Internal = true.ToString().Equals(values[41]);
                Float = true.ToString().Equals(values[42]);
                Fax = true.ToString().Equals(values[43]);

                if (Float)
                {
                    FirstName = FirstName.Substring(0, FirstName.Length - ClinicAbbr.Length);
                    setClinicInfo(ClinicId);
                }

                return true;
            }
            else return false;
        }

        private string buildAddOns()
        {
            StringBuilder addOns = new StringBuilder();

            if (Ordering) addOns.Append("32768^0^0^0;");
            if (Repository) addOns.Append("2048^0^0^0;");
            if (PrescriptionWriter) addOns.Append("524288^0^0^0;");
            if (EditPatientIndex) addOns.Append("0^4^0^0;");

            return addOns.ToString().TrimEnd(';');
        }

        private void setAddOns(string addOnsStr)
        {
            if(string.IsNullOrEmpty(addOnsStr)) return;

            string[] addOns = addOnsStr.Split(';');
            foreach (string addOn in addOns)
            {
                switch (addOn)
                {
                    case "32768^0^0^0":
                        Ordering = true;
                        break;
                    case "2048^0^0^0":
                        Repository = true;
                        break;
                    case "524288^0^0^0":
                        PrescriptionWriter = true;
                        break;
                    case "0^4^0^0":
                        EditPatientIndex = true;
                        break;
                    default:
                        System.Windows.Forms.MessageBox.Show("Error restoring Add-Ons: " + addOn + " unrecognized");
                        break;
                }
            }
        }
    }
}
