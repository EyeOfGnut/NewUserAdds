using System;
using System.Collections.Generic;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace Extensions
{

    /// <summary>
    /// Extensions for the List class
    /// </summary>
    public static class ListExtension
    {
        /// <summary>
        /// Extension for the List class to force generation of the Person.ShortName when it's added to the list
        /// </summary>
        /// <param name="list">List object being extended</param>
        /// <param name="person">Person object being added to the list</param>
        public static void AddPerson(this List<NewUserAdds.Person> list, NewUserAdds.Person person)
        {
            if (!person.genShortName()) System.Windows.Forms.MessageBox.Show("Unable to generate a unique shortname");
            list.Add(person);
        }
    }


    /// <summary>
    /// Extension for the Microsoft.Office.Interop.Excel.Worksheet class, to 
    /// add a Fill(Datatable) method.
    /// </summary>
    public static class WorksheetExtension
    {
        /// <summary>Fill a data table with information from a Sharepoint list - emulates ODBC.Fill(DataTable)</summary>
        public static void Fill(this Excel.Worksheet worksheet, Excel.Range range, DataTable dataTable)
        {            
            int rows = range.Rows.Count;
            int cols = range.Columns.Count;
            if (range.get_Item(2, 1).Value2 == null)
            {
                dataTable.Columns.Add("No Fax Requests to Import", typeof(string));
            }
            else
            {
                for (int i = 1; i <= rows; i++)
                {
                    DataRow row = dataTable.NewRow();
                    for (int j = 1; j <= cols; j++)
                    {
                        try
                        {
                            if (i == 1) dataTable.Columns.Add(range.get_Item(i, j).Value2.ToString(), typeof(string));
                            else row[j - 1] = range.get_Item(i, j).Value2;
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show("Caught Exception while filling Data Table:\n" + ex.Message);
                            return;
                        }
                    }
                    if (i > 1 && !string.IsNullOrEmpty(row[cols - 1].ToString())) dataTable.Rows.Add(row); //Ensure entry has a Fax number.
                }
            }
        }
    }
}
