using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PollensValues
{
    public class ReadCsvFile
    {
        public void ReadCsvFileData(string route, DataGridView dgv)
        {
            StreamReader oStreamReader = new StreamReader(route);
            DataTable oDataTable = null;

            int RowCount = 0;

            string[] ColumnNames = null;

            string[] oStreamDataValues = null;

            //using while loop read the stream data till end
            while (!oStreamReader.EndOfStream)
            {
                String oStreamRowData = oStreamReader.ReadLine().Trim();
                if (oStreamRowData.Length > 0)
                {
                    oStreamDataValues = oStreamRowData.Split('\t');
                    //Bcoz the first row contains column names, we will poluate 
                    //the column name by 
                    //reading the first row and RowCount-0 will be true only once
                    if (RowCount == 0)
                    {
                        RowCount = 1;
                        ColumnNames = oStreamRowData.Split('\t');
                        oDataTable = new DataTable();

                        //using foreach looping through all the column names 
                        foreach (string csvcolumn in ColumnNames)
                        {
                            DataColumn oDataColumn = new DataColumn(csvcolumn, typeof(string));

                            //setting the default value of empty.string to newly created column
                            oDataColumn.DefaultValue = string.Empty;

                            //adding the newly created column to the table
                            oDataTable.Columns.Add(oDataColumn);
                        }
                    }
                    else
                    {
                        //creates a new DataRow with the same schema as of the oDataTable  
                        DataRow oDataRow = oDataTable.NewRow();

                        //using foreach looping through all the column names
                        for (int i = 0; i < ColumnNames.Length; i++)
                        {
                            oDataRow[ColumnNames[i]] = oStreamDataValues[i] == null ? string.Empty : oStreamDataValues[i].ToString();
                        }
                        //adding the newly created row with data to the oDataTable
                        oDataTable.Rows.Add(oDataRow);
                    }
                }
            }
            //close the oStreamReader object
            oStreamReader.Close();

            //release all the resources used by the oStreamReader object
            oStreamReader.Dispose();

            //Looping through all the rows in the Datatable
            foreach (DataRow oDataRow in oDataTable.Rows)
            {
                string RowValues = string.Empty;

                //Looping through all the columns in a row
                foreach (string csvcolumn in ColumnNames)
                {
                    //concatenating the values for display purpose
                    RowValues += csvcolumn + "=" + oDataRow[csvcolumn].ToString() + ";  ";
                }

                //Displaying the result on the console window                
                Console.WriteLine(RowValues);
                dgv.ReadOnly = true;
                dgv.DataSource = oDataTable;
            }
                string connectionString = ConfigurationManager.ConnectionStrings["SQLServerConnectionString"].ConnectionString;

            // open the destination data
            using (SqlConnection destinationConnection = new SqlConnection(connectionString))
            {
                // open the connection
                    destinationConnection.Open();

                // take note of SqlBulkCopyOptions.KeepIdentity , you may or may not want to use this for your situation.  
                using (var bulkCopy = new SqlBulkCopy(destinationConnection.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
                {
                    // my DataTable column names match my SQL Column names, so I simply made this loop. However if your column names don't match, just pass in which datatable name matches the SQL column name in Column Mappings
                    //foreach (DataColumn col in oDataTable.Columns)
                    //{
                    //bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                    //}
                    bulkCopy.BulkCopyTimeout = 600;
                    bulkCopy.DestinationTableName = "polenes";
                    bulkCopy.WriteToServer(oDataTable);
                    MessageBox.Show(Convert.ToString(oDataTable.Rows.Count) + " rows inserted.");
                }
            }
        }
        }
    }

