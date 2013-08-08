using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Extensions;
using System.Runtime.InteropServices;

namespace NewUserAdds
{
    enum ImportTypes : int
    {
        PROV,
        REQ, 
        FILE
    };

    public partial class Import : Form
    {
        private List<Person> pList;
        private int adminKey;

        /// <summary> The last SSN to be used.</summary>
        public int ssnEnd;
        private int type;

        private string[] cmbItems = {"SKIP","First Name","Middle Initial","Last Name","Degree","Company Name"
            ,"Phone","Fax","Location", "Address","City","State","Zip","Country","Specialty","DEA", "NPI", "STAR ID"};

        /// <summary>
        /// Initialize the Form (1 Overload)
        /// </summary>
        public Import()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize the Form
        /// </summary>
        /// <param name="list">Person list</param>
        /// <param name="ssn">Starting SSN</param>
        /// <param name="aKey">SSN Key for the person adding the Fax account</param>
        /// <param name="Type">Type of import, refereced off of FILE, PROV, and REQ constants</param>
        public Import(List<Person> list, int ssn, int aKey, int Type) : this()
        {
            this.ssnEnd = ssn;
            this.adminKey = aKey;
            this.pList = list;
            this.type = Type;
        }

        private void Import_Load(object sender, EventArgs e)
        {
            switch(type){
                case (int)ImportTypes.FILE:
                    selectCsvFile();
                    break;
                case (int)ImportTypes.PROV:
                    providerInfo();
                    break;
                case (int)ImportTypes.REQ:
                    refRequest();
                    break;
                default:
                    selectCsvFile();
                    break;
        }
            dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            //dataGridView.ColumnHeadersVisible = false;

            System.Data.DataTable dt = new System.Data.DataTable();
            for(int i=0; i < dataGridView.Columns.Count; i++)
            {
                dt.Columns.Add(new DataColumn(i.ToString(), typeof(String)));
            }

            dt.Rows.Add(dt.NewRow());
            dataGridHeaders.DataSource = dt;

            for(int i=0; i<dataGridHeaders.Columns.Count; i++)
            {
                DataGridViewComboBoxCell cb = new DataGridViewComboBoxCell();
                cb.Items.AddRange(cmbItems);
                cb.AutoComplete = true;
                dataGridHeaders.Rows[0].Cells[i] = cb;
                dataGridHeaders.Columns[i].Width = dataGridView.Columns[i].Width;

                switch (dataGridView.Columns[i].HeaderText)
                {
                    case "Last Name":
                        dataGridHeaders.Rows[0].Cells[i].Value = "Last Name";
                        break;
                    case "First Name":
                        dataGridHeaders.Rows[0].Cells[i].Value = "First Name";
                        break;
                    case "Middle Name or Initial":
                    case "Middle Initial":
                        dataGridHeaders.Rows[0].Cells[i].Value = "Middle Initial";
                        break;
                    case "Title/Degree":
                    case "Degree":
                        dataGridHeaders.Rows[0].Cells[i].Value = "Degree";
                        break;
                    case "Specialty":
                        dataGridHeaders.Rows[0].Cells[i].Value = "Specialty";
                        break;
                    case "STAR ID#":
                        dataGridHeaders.Rows[0].Cells[i].Value = "STAR ID";
                        break;
                    case "NPI #":
                        dataGridHeaders.Rows[0].Cells[i].Value = "NPI";
                        break;
                    case "Office Name":
                    case "Office Name \"Other\"":
                    case "Company":
                        dataGridHeaders.Rows[0].Cells[i].Value = "Company Name";
                        break;
                    case "Office Address Line 1":
                    case "Office Address Line 2":
                    case "Address":
                        dataGridHeaders.Rows[0].Cells[i].Value = "Address";
                        break;
                    case "Office City":
                    case "City":
                        dataGridHeaders.Rows[0].Cells[i].Value = "City";
                        break;
                    case "Office State":
                    case "State":
                        dataGridHeaders.Rows[0].Cells[i].Value = "State";
                        break;
                    case "Office Zip Code":
                    case "Zip code":
                        dataGridHeaders.Rows[0].Cells[i].Value = "Zip";
                        break;
                    case "Office Phone":
                    case "Phone":
                        dataGridHeaders.Rows[0].Cells[i].Value = "Phone";
                        break;
                    case "Office FAX":
                    case "Fax":
                        dataGridHeaders.Rows[0].Cells[i].Value = "Fax";
                        break;
                }
                
            }
            if (dataGridView.ScrollBars == System.Windows.Forms.ScrollBars.Vertical || dataGridView.ScrollBars == System.Windows.Forms.ScrollBars.Both)
                dataGridHeaders.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            else
                dataGridHeaders.ScrollBars = System.Windows.Forms.ScrollBars.None;

            dataGridHeaders.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        /// <summary>
        /// Open the dialog to select the file to import
        /// </summary>
        private void selectCsvFile()
        {
            Cursor.Current = Cursors.WaitCursor; //switch to the hourglass cursor
            OpenFileDialog csv = new OpenFileDialog();
            csv.Title = "CSV Fax Information Files";
            csv.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            csv.Filter = "Request Files (*.csv, *.xlsx, *.xls)|*.csv; *.xlsx; *.xls"; //set the file types
            csv.FilterIndex = 1; // Start with the first entry in the Filetype Dropdown
            csv.RestoreDirectory = true;

            //If the user selects a file and clicks Ok\Open
            if (csv.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.Default; //reset to the normal cursor
                //strip out the path and show just the filename as the link, but the link itself is the full path to the file.
                try
                {
                    loadCsv(csv.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Open File Dialog Error: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Load the CSV, XLS, or XLSX file into the Form's DataGridView
        /// </summary>
        /// <param name="path">Full path to the file</param>
        private void loadCsv(string path)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show(this, "File does not exist: \r\n" + path, "File not found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                StringBuilder conStr = new StringBuilder();
                System.Data.DataTable dt = new System.Data.DataTable();

                switch (Path.GetExtension(path))
                {

                    case ".xls":
                        conStr.Append("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=");
                        conStr.Append(Path.GetFullPath(path));
                        conStr.Append(";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";");
                        using(OleDbConnection oleConn = new OleDbConnection(conStr.ToString()))
                        {
                            oleConn.Open();
                            string worksheet = getWorksheetName(oleConn);
                            if (string.IsNullOrEmpty(worksheet))
                                worksheet = "Sheet1$";
                            OleDbDataAdapter oleDa = new OleDbDataAdapter("SELECT * FROM [" + worksheet + "]", oleConn);
                            oleDa.Fill(dt);
                            oleDa.Dispose();
                            oleConn.Close();
                        }
                        break;
                    case ".xlsx":
                        conStr.Append("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=");
                        conStr.Append(Path.GetFullPath(path));
                        conStr.Append(";Extended Properties=\"Excel 12.0 Xml;HDR=YES\"");
                        using(OleDbConnection oleConn = new OleDbConnection(conStr.ToString()))
                        {
                            oleConn.Open();
                            string worksheet = getWorksheetName(oleConn);
                            if (string.IsNullOrEmpty(worksheet))
                                worksheet = "Sheet1$";
                            OleDbDataAdapter oleDa = new OleDbDataAdapter("SELECT * FROM [" + worksheet + "]", oleConn);
                            oleDa.Fill(dt);                                
                            oleDa.Dispose();
                            oleConn.Close();
                        }
                        break;
                    case ".csv":
                        conStr.Append(@"Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=");
                        conStr.Append(Path.GetDirectoryName(Path.GetFullPath(path)));
                        conStr.Append(";Extensions=csv");
                        using(OdbcConnection OdbcConn = new OdbcConnection(conStr.ToString()))
                        {
                            OdbcDataAdapter odbcDa = new OdbcDataAdapter("Select * from [" + Path.GetFileName(path) + "]", OdbcConn);
                            odbcDa.Fill(dt);
                            odbcDa.Dispose();
                            OdbcConn.Close();
                        }
                        break;
                    default:
                        MessageBox.Show("Invalid File Type");
                        return;
                }
                
                dataGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "There was an error loading the data file: \r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void refRequest()
        {
            getFromSharpoint("refreq.iqy", "p10");
        }

        private void providerInfo()
        {
            getFromSharpoint("owssvr.iqy", "s10");
        }

        private void getFromSharpoint(string finderFile, string leftRange)
        {
            DataTable dt = new DataTable();
            //Following the rule to never use two .'s with COM objects (i.e. don't use "app.Workbooks.Add()");
            Excel.Application app = new Excel.Application();
            Excel.Workbooks workbooks = app.Workbooks;
            Excel.Workbook workBook = workbooks.Add();
            Excel.Worksheet workSheet = workBook.ActiveSheet;
            Excel.Range range = workSheet.Range["a1", leftRange];
            Excel.QueryTables tables = workSheet.QueryTables;
            Excel.QueryTable queryTable = tables.Add("FINDER;" + Path.Combine(Application.StartupPath, finderFile), range, Type.Missing);

            queryTable.RefreshStyle = Excel.XlCellInsertionMode.xlInsertEntireRows;
            queryTable.Refresh(false);
            workSheet.Fill(range, dt);// Extension method to emulate ODBC.Fill method. Look in Extensions.cs for definition.
                

            try
            {
                dataGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "There was an error loading the data file: \r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            finally // Release the Excel process
            {
                workBook.Saved = true; // Fool Excel into thinking the workbook is saved, so it won't prompt when closing.
                //workBook.Close(false, false, false);
                app.Quit();
                Marshal.ReleaseComObject(queryTable);
                Marshal.ReleaseComObject(tables);
                Marshal.ReleaseComObject(range);
                Marshal.ReleaseComObject(workSheet);
                Marshal.ReleaseComObject(workBook);
                Marshal.ReleaseComObject(workbooks);
                Marshal.ReleaseComObject(app);
            }
        }

        private string getWorksheetName(OleDbConnection conn)
        {
            if (conn != null)
            {
                System.Data.DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null)
                    return string.Empty;

                //String[] sheets = new String[dt.Rows.Count];
                List<String> sheets = new List<String> { };
                int i = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (!row["TABLE_NAME"].ToString().Contains('_') && !string.IsNullOrEmpty(row["TABLE_NAME"].ToString())) // Don't display hidden table info as a sheet
                        sheets.Add(row["TABLE_NAME"].ToString());
                }

                dt.Dispose();

                //MessageBox.Show("Found " + i.ToString() + " Worksheets");
                if (i <= 1)
                    return sheets[0];
                else
                {
                    SelectSheet sheet = new SelectSheet(sheets);
                    sheet.ShowDialog();
                    return sheet.worksheet;
                }
            }
            return string.Empty;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if(row.Cells[0] == null || row.Cells[0].Value == null || String.IsNullOrEmpty(row.Cells[0].Value.ToString()))
                    break;

                Person person = new Person();
                Boolean setLastName = false;

                person.UserType = "Fax";
                person.JobCategory = "Medical Doctor";
                person.SSN = Utils.genSSN(ssnEnd++, adminKey);

                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    if (!String.IsNullOrEmpty(dataGridHeaders.Rows[0].Cells[i].Value.ToString()))
                    {
                        switch (dataGridHeaders.Rows[0].Cells[i].Value.ToString())
                        {
                            case "SKIP":
                                break;
                            case "":
                                break;
                            case "Company Name":
                                if (String.IsNullOrEmpty(person.CompanyName))
                                    if (row.Cells[i].Value.ToString() == "Select one...")
                                        person.CompanyName = string.Empty;
                                    else
                                    {
                                        person.CompanyName = row.Cells[i].Value.ToString().Trim();
                                        if (setLastName)
                                            person.LastName = person.CompanyName;
                                    }
                                break;
                            case "First Name":
                                if (row.Cells[i].Value.ToString().Trim().Equals("*") || string.IsNullOrEmpty(row.Cells[i].Value.ToString().Trim()))
                                    person.FirstName = "Referral";
                                else
                                    person.FirstName = row.Cells[i].Value.ToString().Trim();
                                break;
                            case "Middle Initial":
                                if(!string.IsNullOrEmpty(row.Cells[i].Value.ToString()))
                                    person.MiddleInitial = row.Cells[i].Value.ToString().Substring(0, 1).ToUpper();
                                break;
                            case "Last Name":
                                if (row.Cells[i].Value.ToString().Trim().Equals("*") || string.IsNullOrEmpty(row.Cells[i].Value.ToString().Trim()))
                                {
                                    if (!string.IsNullOrEmpty(person.CompanyName))
                                        person.LastName = person.CompanyName;
                                    else
                                        setLastName = true;
                                }
                                else
                                {
                                    person.LastName = row.Cells[i].Value.ToString().Trim();
                                }
                                break;
                            case "Phone":
                                person.PhoneNumber = row.Cells[i].Value.ToString();
                                break;
                            case "Fax":
                                if(!string.IsNullOrEmpty(row.Cells[i].Value.ToString()))
                                    person.FaxNumber = row.Cells[i].Value.ToString();
                                break;
                            case "Specialty":
                                string[] specInfo = Utils.matchSpecialty(row.Cells[i].Value.ToString().Trim());
                                person.Specialty = specInfo[1];
                                person.SpecialtyId = specInfo[0];
                                break;
                            case "Degree":
                                person.Degree = Utils.matchDegree(row.Cells[i].Value.ToString().Trim());
                                break;
                            case "Address":
                                if (string.IsNullOrEmpty(person.StreetAddress))
                                    person.StreetAddress = row.Cells[i].Value.ToString();
                                else
                                    person.StreetAddress += " " + row.Cells[i].Value.ToString();
                                break;
                            case "Location":
                                person.Location = row.Cells[i].Value.ToString();
                                break;
                            case "City":
                                person.City = row.Cells[i].Value.ToString();
                                break;
                            case "State":
                                person.State = row.Cells[i].Value.ToString();
                                break;
                            case "Zip":
                                person.Zip = row.Cells[i].Value.ToString();
                                break;
                            case "Country":
                                person.Country = row.Cells[i].Value.ToString();
                                break;
                            case "DEA":
                                person.Dea = row.Cells[i].Value.ToString();
                                break;
                            case "NPI":
                                person.Npi = row.Cells[i].Value.ToString();
                                break;
                            case "STAR ID":
                                person.LocalId = row.Cells[i].Value.ToString();
                                person.IdQualifier = "FHS";
                                break;
                            default:
                                //newRow[dataGridHeaders.Rows[0].Cells[i].Value.ToString()] = row.Cells[i].Value.ToString().Trim();
                                break;
                        }
                    }
                }

                /*if(person.LastName.Length > 7)
                    person.ShortName = "fax" + person.FirstName.Substring(0, 1).ToLower() + person.LastName.Substring(0, 7).ToLower();
                else
                    person.ShortName = "fax" + person.FirstName.Substring(0, 1).ToLower() + person.LastName.Substring(0, person.LastName.Length).ToLower();
                */

                if (person.FaxNumber != null)
                {
                    pList.Add(person);
                    count++;
                }
                else
                {
                    AddFaxNumber missingFax = new AddFaxNumber(person.FirstName + " " + person.LastName);
                    missingFax.ShowDialog();
                    if (string.IsNullOrEmpty(missingFax.faxNumber))
                    {
                        MessageBox.Show(this, "Skipping " + person.FirstName + " " + person.LastName, 
                            "Skip Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        person = null;
                    }
                    else
                    {
                        person.FaxNumber = missingFax.faxNumber;
                        pList.Add(person);
                        count++;
                    }
                }
            }

            MessageBox.Show("Imported " + count + " records");
            Close();
        }

        private void dataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                dataGridHeaders.HorizontalScrollingOffset = e.NewValue;                
        }
    }
}
