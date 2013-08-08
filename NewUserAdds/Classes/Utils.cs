using Domino;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace NewUserAdds
{
    class Utils
    {
        // SQL Data columns in the 'Clinics' Table.
        public enum ClinicTable : int
        {
            ID = 0,
            Company = 1,
            Phone = 2,
            Fax = 3,
            Address = 4,
            City = 5,
            State = 6,
            Zip = 7,
            Country = 8,
            ECD = 9,
            Abbr = 10,
            Epic = 11
        }

        // SQL Server connection string. Uses Windows AD login to authenticate.
        
        public static string[] getSpecialtyInfo(string id)
        {
            string[] tmpInfo = new string[3];
            SqlConnection con = new System.Data.SqlClient.SqlConnection(Properties.Settings.Default.UserAddDBConnectionString);
            DataSet dSet = new DataSet();
            string sql = "SELECT * From Specialties Where id = " + id;

            SqlDataAdapter dAdapter = new SqlDataAdapter(sql, con);
            dAdapter.Fill(dSet, "Specialties");
            DataRow dRow = dSet.Tables["Specialties"].Rows[0];
            for (int i = 0; i < 3; i++)
                tmpInfo[i] = dRow.ItemArray.GetValue(i).ToString().Trim();
            dAdapter.Dispose();
            con.Close();

            return tmpInfo;
        }
                
        public static bool setExtID(string idName, string idValue, NotesDocument doc)
        {
            IList<Object> ids = (doc.GetItemValue(idName) as Object[]).ToList();
            ids.Add(idValue);
            doc.ReplaceItemValue(idName, ids.ToArray());
            return doc.Save(false, false, false);
        }

        public static string GetStarID(string name)
        {
            WebClient client = new WebClient();
            name = name.Replace(",", "%2C").Replace(" ", String.Empty);
            String result = client.DownloadString("http://providerinfo/StarDocQueryM1.asp?DocName=" + name + "&bSubmit=Search+Name");
            if (result.Contains("I was unable")) return "Not Found";

            String substring = result.Substring(result.IndexOf("Physician ID:"), 100); // Get lots, just in case
            substring = substring.Substring(substring.IndexOf("data\">") + 6, 5); //Get the 5 characters after the '>'
            if (substring.Contains("<")) return substring.Substring(0, substring.IndexOf("<")); // If the ID is less than 5 characters, trim the extra
            else return substring;
        }

        public static string[] getDegreeInfo(string id)
        {
            string[] tmpInfo = new string[3];
            if (string.IsNullOrEmpty(id))
            {
                for (int j = 0; j < 3; j++)
                    tmpInfo[j] = "";
            }
            else
            {
                SqlConnection con = new System.Data.SqlClient.SqlConnection(Properties.Settings.Default.UserAddDBConnectionString);
                DataSet dSet = new DataSet();
                string sql = "SELECT * From Degrees Where id = " + id;

                SqlDataAdapter dAdapter = new SqlDataAdapter(sql, con);
                dAdapter.Fill(dSet, "Degrees");
                DataRow dRow = dSet.Tables["Degrees"].Rows[0];
                for (int i = 0; i < 3; i++)
                    tmpInfo[i] = dRow.ItemArray.GetValue(i).ToString().Trim();
                dAdapter.Dispose();
                con.Close();
            }

            return tmpInfo;
        }

        /// <summary>
        /// The Elysium backend user type designation isn't user friendly,
        /// so this flip-flops between the actual designation and the understandable version.
        /// </summary>
        /// <param name="type">String of user type</param>
        /// <returns>The alternate verison of the user type (i.e. EW to Workstation and back)</returns>
        public static string fixUserType(string type)
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
                    return "Workstation";
                case "ERep":
                    return "Repository";
                default:
                    return "ERep";
            }
        }

        /// <summary>
        /// Generate the 'SSN' for a new user: YYMMDD5##
        /// </summary>
        /// <param name="ssnEnd">Current new account's number for the day (00-99)</param>
        /// <param name="key">Administrative User key</param>
        /// <returns>The completed SSN</returns>
        public static string genSSN(int ssnEnd, int key)
        {
            StringBuilder ssnStr = new StringBuilder(DateTime.Now.ToString("yyMMdd"));
            ssnStr.Append(key);
            ssnStr.Append(ssnEnd.ToString("00"));
            ssnEnd++;
            return ssnStr.ToString();
        }

        public static int getAdminNumberKey()
        {
            string userName = Environment.UserName;
            int key = 0;

            try
            {
                XmlReader reader = XmlReader.Create(@"\\nwtac1mss07\sjmcshared\FMG IT\HIE\AccessRequestForms\Audit Logs\AdminSSNKeys.xml");
                reader.MoveToContent();
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name == "key" && reader.GetAttribute("value") == userName)
                            {
                                try { key = Convert.ToInt16(reader.GetAttribute("id")); return key; }
                                catch (Exception ex) { MessageBox.Show("XML Error: " + ex.Message); }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (XmlException ex)
            {
                MessageBox.Show("XML Exception: " + ex.ToString());
            }
           
            return key;
        }

        /// <summary>
        /// Generate a CSV file from the supplied data table into the supplied file location
        /// </summary>
        /// <param name="list">List&lt;Person&gt; containing User data</param>
        /// <param name="file">Complete path to file, including filename</param>
        /// <param name="log">Boolean to include extra log data</param>
        /// <returns>Number of Data Rows written to the file</returns>
        public static int writeCSV(List<Person> list, string file, bool log)
        {
            int count = 0;
            if (File.Exists(file))
                File.Delete(file);

            StreamWriter sWriter = new StreamWriter(file);
            foreach(Person person in list){
                if (log)
                    sWriter.WriteLine(person.GetLogCSV());
                else
                    sWriter.WriteLine(person.GetExportCSV());
                    count++;                
            }
            sWriter.Close();
            return count;
        }


        public static int addAuditInfo(List<Person> pList)
        {
            string auditFile = @"\\nwtac1mss07\sjmcshared\FMG IT\HIE\AccessRequestForms\Audit Logs\NewUserAudit";
            int count = 0;

            using (StreamWriter log = File.AppendText(auditFile))
            {
                DateTime now = DateTime.Now;

                log.WriteLine("Audit log for " + now.ToString(@"MM/dd/yy hh:mm"));
                foreach (Person person in pList)
                {
                    log.WriteLine(person.GetLogCSV());
                    count++;
                }
                log.Flush();
                log.Close();
            }
            return count;
        }

        public static int readAuditInfo(DataTable dataTable)
        {
            string auditFile = @"\\nwtac1mss07\sjmcshared\FMG IT\HIE\AccessRequestForms\Audit Logs\NewUserAudit";
            int count = 0;

            if (File.Exists(auditFile))
            {
                string[] lines = File.ReadAllLines(auditFile);
                string date = string.Empty;

                foreach (string line in lines)
                {
                    if (line.Contains("Audit"))
                    {
                        string[] dateLine = line.Split(' ');
                        date = dateLine[dateLine.Length - 2].Trim();
                    }
                    else
                    {
                        string[] items = line.Split('|');
                        DataRow dRow = dataTable.NewRow();
                        for (int i = 0; i < items.Length; i++)
                        {
                            dRow[i] = items[i];
                        }
                        dRow[dataTable.Columns.Count - 1] = date;
                        dataTable.Rows.Add(dRow);
                        count++;
                    }
                }
            }
            else
            {
                return 0;
            }
            return count;
        }

        public static int restorePending(List<Person> pList)
        {
            string tempDir = System.IO.Path.GetTempPath();
            string file = "newuseraddPendingBackup.csv";
            int count = 0;

            if(File.Exists(tempDir + "\\" + file))
            {
                string[] lines = File.ReadAllLines(tempDir + "\\" + file);
                char[] quote = { '"' };

                foreach (string line in lines)
                {
                    //string[] items = line.Split(','); //this will split addresses with commas
                    string[] items = line.Split('|');
                    Person person = new Person();
                    person.RestoreFromCSV(items);
                    pList.Add(person);
                    count++;
                }
            }
            else
            {                
                return 0;
            }
            return count;
        }
        
        /// <summary>
        /// Setup the menagerie of columns for our standard data table
        /// </summary>
        /// <returns>Array of Data Columns for use in the DataTable.AddRange(DataColumn[]) method</returns>
        public static DataColumn[] setDataColumns()
        {
            DataColumn[] pendingCols = new DataColumn[44];
            pendingCols[0] = new DataColumn("First Name");
            pendingCols[1] = new DataColumn("Middle Initial");
            pendingCols[2] = new DataColumn("Last Name");
            pendingCols[3] = new DataColumn("Title");
            pendingCols[4] = new DataColumn("Degree");
            pendingCols[5] = new DataColumn("Short Name");
            pendingCols[6] = new DataColumn("Password");
            pendingCols[7] = new DataColumn("Company Name");
            pendingCols[8] = new DataColumn("PhoneNumber");
            pendingCols[9] = new DataColumn("FaxNumber");
            pendingCols[10] = new DataColumn("Location");
            pendingCols[11] = new DataColumn("Add Ons");
            pendingCols[12] = new DataColumn("Address");
            pendingCols[13] = new DataColumn("City");
            pendingCols[14] = new DataColumn("State");
            pendingCols[15] = new DataColumn("Zip");
            pendingCols[16] = new DataColumn("Country");
            pendingCols[17] = new DataColumn("SSN");
            pendingCols[18] = new DataColumn("ECD");
            pendingCols[19] = new DataColumn("Local User ID");
            pendingCols[20] = new DataColumn("Organization");
            pendingCols[21] = new DataColumn("ID Qualifier");
            pendingCols[22] = new DataColumn("User Type");
            pendingCols[23] = new DataColumn("Specialty");
            pendingCols[24] = new DataColumn("DEA");
            pendingCols[25] = new DataColumn("Prescription License #");
            pendingCols[26] = new DataColumn("Job Category");
            pendingCols[27] = new DataColumn("UPIN");
            pendingCols[28] = new DataColumn("Cred2");
            pendingCols[29] = new DataColumn("Cred5");
            pendingCols[30] = new DataColumn("NPI");
            pendingCols[31] = new DataColumn("Ordering Supplier");
            pendingCols[32] = new DataColumn("Ordering Server");
            pendingCols[33] = new DataColumn("RadCat");
            pendingCols[34] = new DataColumn("Email");
            pendingCols[35] = new DataColumn("Cred6");

            // Extra columns for storing data in this program. Don't export to Lotus Notes!
            pendingCols[36] = new DataColumn("Manager");
            pendingCols[37] = new DataColumn("Task");
            pendingCols[38] = new DataColumn("Clinic ID");
            pendingCols[39] = new DataColumn("Spec ID");
            pendingCols[40] = new DataColumn("Form");
            pendingCols[41] = new DataColumn("Internal");
            pendingCols[42] = new DataColumn("Float");
            pendingCols[43] = new DataColumn("Fax");
            return pendingCols;
        }

        public static string getFullName(string username)
        {
            string str = string.Empty;
            string domain;
            string name;

            int index = username.IndexOf('\\');
            if (index == -1)
                index = username.IndexOf('@');

            if (index != -1)
            {
                domain = username.Substring(0, index);
                name = username.Substring(index + 1);
            }
            else
            {
                domain = Environment.MachineName;
                name = username;
            }

            DirectoryEntry obDirEntry = null;
            try
            {
                obDirEntry = new DirectoryEntry("WinNT://tacoma-wa/" + name);
                System.DirectoryServices.PropertyCollection collection = obDirEntry.Properties;
                object obVal = collection["FullName"].Value;
                str = obVal.ToString();
            }
            catch (Exception ex)
            {
                str = ex.Message;
            }

            return str;
        }

        /// <summary>
        /// Match a hand-entered Degree, and return an "Official" match
        /// </summary>
        /// <param name="degree">the Hand-Entered value</param>
        /// <returns>the "Official" degree</returns>
        public static string matchDegree(string degree)
        {
            // Connect to the SQL server
            SqlConnection con = new System.Data.SqlClient.SqlConnection(Properties.Settings.Default.UserAddDBConnectionString);
            DataSet dSet = new DataSet();
            string sql = "SELECT * From Degrees";

            // Fill a dataset with available degrees
            SqlDataAdapter dAdapter = new SqlDataAdapter(sql, con);
            dAdapter.Fill(dSet, "Degrees");
            dAdapter.Dispose();
            con.Close();

            // Match the hand-entered degree against the database values
            foreach(DataRow row in dSet.Tables[0].Rows)
            {
                string deg = row.ItemArray[0].ToString().Trim();
                Regex rex = new Regex(@"\s*" + deg + @"\s*-\s*\w*\d*", RegexOptions.IgnoreCase);
                if (rex.IsMatch(degree))
                    return deg;
            }
            return "MD";
        }

        /// <summary>
        /// Match a hand-entered specialty against the database
        /// </summary>
        /// <param name="specialty">Hand-Entered specialty</param>
        /// <returns>DB Key and Text of the matched specialty</returns>
        public static string[] matchSpecialty(string specialty)
        {   
            // Open the SQL connection
            SqlConnection con = new System.Data.SqlClient.SqlConnection(Properties.Settings.Default.UserAddDBConnectionString);
            DataSet dSet = new DataSet();
            string sql = "SELECT * From Specialties";
            string[] spec = { "22", "Family Practice" }; //Sets default Specialty info, if there are no matches

            // Fill a data table with the specialty information
            SqlDataAdapter dAdapter = new SqlDataAdapter(sql, con);
            dAdapter.Fill(dSet, "Specialties");
            dAdapter.Dispose();
            con.Close();

            foreach (DataRow row in dSet.Tables[0].Rows)
            {
                if (Regex.Matches(specialty, @"[a-z]*\s*-\s" + row.ItemArray[2].ToString().Trim() + @"\s*", RegexOptions.IgnoreCase).Count != 0 ||
                    Regex.Matches(row.ItemArray[1].ToString(), @"\s*" + specialty + @"\d*\s*\w*", RegexOptions.IgnoreCase).Count != 0)
                {
                    spec[0] = row.ItemArray[0].ToString();
                    spec[1] = row.ItemArray[1].ToString();
                    return spec;
                }
            }

 /*           // Compare any number of hand-entered specialty options agains the best-fit entry in the DB
            for (int i = 0; i < dSet.Tables[0].Rows.Count; i++)
            {
                DataRow row = dSet.Tables[0].Rows[i];

                // Match abbreviated specialties, like "GYN" or "GP"
                Regex rex = new Regex(@"[a-z]*\s*-\s" + row.ItemArray[2].ToString().Trim() + @"\s*", RegexOptions.IgnoreCase);
                if (rex.IsMatch(specialty))
                {
                    spec[0] = row.ItemArray[0].ToString();
                    spec[1] = row.ItemArray[1].ToString();
                    return spec;
                }
                
                // Match full specialties, like "Hematology" or "Family Practice"
                rex = new Regex(@"\s*" + specialty + @"\d*\s*\w*", RegexOptions.IgnoreCase);
                if(rex.IsMatch(row.ItemArray[1].ToString().Trim()))
                {
                    spec[0] = row.ItemArray[0].ToString();
                    spec[1] = row.ItemArray[1].ToString();
                    return spec;
                }
            }
 */
            return spec;
        }

        public static string[] getClinicInfo(string id)
        {
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Properties.Settings.Default.UserAddDBConnectionString);
            System.Data.DataSet dSet = new System.Data.DataSet();
            string sql = "SELECT * From Clinics Where id = " + id;

            System.Data.SqlClient.SqlDataAdapter dAdapter = new System.Data.SqlClient.SqlDataAdapter(sql, con);
            dAdapter.Fill(dSet, "Clinics");
            System.Data.DataRow dRow = dSet.Tables["Clinics"].Rows[0];
            string[] tmpInfo = new string[dRow.ItemArray.Length];
            for(int i = 0; i < dRow.ItemArray.Length; i++)
                tmpInfo[i] = dRow.ItemArray.GetValue(i).ToString();

            dAdapter.Dispose();
            con.Close();

            return tmpInfo;
        }

        /// <summary>
        /// Generate a random string for a temporary password. 
        /// Really only necessary because Notes requires a password for new accounts.
        /// </summary>
        /// <param name="size">Length of random string to generate</param>
        /// <returns>The random string</returns>
        public static string RandomString(int size)
        {            
            Random random = new Random((int)DateTime.Now.Ticks);
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }
    }
}
