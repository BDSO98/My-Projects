using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QueryPal
{
    public partial class frmQueryPal : Form
    {
        private string serverInstance;
        private bool instancesLoaded = false;
        public frmQueryPal()
        {
            InitializeComponent();
            InitializeContextMenu();
            this.AutoScaleMode = AutoScaleMode.Dpi;

        }

        private DataTable dt_Results;

        private void frmQueryPal_Load(object sender, EventArgs e)
        {
            this.Text = "QueryPal v." + Application.ProductVersion;

        }

        private void LoadSqlServerInstances()
        {
            try
            {
                // Get the available SQL Server instances
                DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();

                // Add an empty string as the default item
                cbInstances.Items.Add("");

                // Loop through the DataTable and add instances to the ComboBox
                foreach (DataRow row in servers.Rows)
                {
                    string serverName = row["ServerName"].ToString();
                    string instanceName = row["InstanceName"].ToString();

                    // If instance name is empty, it's the default instance
                    string comboItem = string.IsNullOrEmpty(instanceName) ? serverName : $"{serverName}\\{instanceName}";

                    cbInstances.Items.Add(comboItem);
                }

                instancesLoaded = true; // Set the flag to true after loading
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                Console.WriteLine($"Error loading SQL Server instances: {ex.Message}");
            }
        }

        private void btnFileDialog_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "SQL Files (*.sql)|*.sql|All Files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Display the file name in the TextBox
                    txtQuery.Text = openFileDialog.FileName;
                }
            }
        }

        private void LoadDatabases(string serverInstance)
        {
            // Clear existing items in CheckedListBox
            clbDatabases.Items.Clear();

            // Connection string for master database
            string masterConnectionString = $"Data Source={serverInstance};Initial Catalog=master;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(masterConnectionString))
                {
                    connection.Open();

                    // Query to get database names
                    string query = "";
                    if (chkViewSystemDbs.Checked)
                    {
                        query = "SELECT name FROM sys.databases ORDER BY name ASC";
                    }
                    else
                    {
                        query = "SELECT name FROM sys.databases WHERE database_id > 4 ORDER BY name ASC"; // Exclude system databases
                    }
                    
                     

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Populate CheckedListBox with database names
                            while (reader.Read())
                            {
                                clbDatabases.Items.Add(reader["name"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading databases: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbInstancias_SelectedIndexChanged(object sender, EventArgs e)
        {
            serverInstance = cbInstances.SelectedItem.ToString();

            // Load databases for the selected SQL Server instance
            LoadDatabases(serverInstance);
        }


      


        private string ReadQueryFromFile(string filePath)
        {
            try
            {
                // Read the query from the specified file
                return System.IO.File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                throw new InvalidOperationException($"Error reading query from file: {ex.Message}", ex);
            }
        }

        private async void btnExecute_Click(object sender, EventArgs e)
        {
            // Validate SQL Server instance selection
            if (cbInstances.SelectedItem == null)
            {
                MessageBox.Show("Please select a SQL Server instance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate at least one database selected
            if (clbDatabases.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            // Validate query file selection
            if (string.IsNullOrWhiteSpace(txtQuery.Text) || !System.IO.File.Exists(txtQuery.Text))
            {
                MessageBox.Show("Please select a valid query file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the SQL query file path
            string queryFilePath = txtQuery.Text;

            // Get the SQL Server instance from the ComboBox
            string selectedInstance = cbInstances.SelectedItem.ToString();

            // Clear existing text in the result TextBox
            txtResults.Text = "";

            // Create a DataTable to store results
           
            dt_Results = new DataTable();
            dt_Results.Columns.Add("Database", typeof(string));
            dt_Results.Columns.Add("Result", typeof(string));


            // Iterate through checked databases in CheckedListBox
            foreach (var checkedItem in clbDatabases.CheckedItems)
            {
                string databaseName = checkedItem.ToString();

                // Execute the query for each checked database
                string result = await ExecuteQueryOnDatabase(selectedInstance, databaseName, queryFilePath);
                dt_Results.Rows.Add(databaseName,result);
            }

           

        }

        private async Task<string> ExecuteQueryOnDatabase(string serverInstance, string databaseName, string query)
        {
            // Connection string for the selected database
            string connectionString = $"Data Source={serverInstance};Initial Catalog={databaseName};Integrated Security=True";

            string result = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    // Read the SQL query from the file
                    string queryFromFile = ReadQueryFromFile(query);

                    using (SqlCommand command = new SqlCommand(queryFromFile, connection))
                    {
                        if (queryFromFile.TrimStart().StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
                        {
                            // Execute SELECT query
                            using (SqlDataReader reader = await command.ExecuteReaderAsync())
                            {
                                // Handle the result set
                                txtResults.AppendText($"Results for database {databaseName}:\r\n");

                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        for (int i = 0; i < reader.FieldCount; i++)
                                        {
                                            txtResults.AppendText($"{reader.GetName(i)}: {reader[i]}\t");
                                            result += $"{reader.GetName(i)}: {reader[i]}\t";
                                        }
                                        txtResults.AppendText("\r\n");
                                        result += "\r\n";
                                    }
                                }
                                else
                                {
                                    txtResults.AppendText("Query executed successfully.\r\n");
                                    result += "Query executed successfully.\r\n";
                                }

                                txtResults.AppendText("\r\n");
                                result += "\r\n";
                            }
                        }
                        else
                        {
                            // Execute INSERT, UPDATE, DELETE, etc.
                            int rowsAffected = await command.ExecuteNonQueryAsync();

                            if (rowsAffected > 0)
                            {
                                txtResults.AppendText($"{rowsAffected} rows affected by the query in {databaseName}.\r\n\r\n");
                                result += $"{rowsAffected} rows affected by the query in {databaseName}.\r\n\r\n";
                            }
                            else
                            {
                                txtResults.AppendText("Query executed successfully.\r\n");
                                result += "Query executed successfully.\r\n";
                            }
                        }
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                txtResults.AppendText($"Error executing query on {databaseName}: {ex.Message}\r\n\r\n");
                result = $"Error executing query on {databaseName}: {ex.Message}\r\n\r\n";
                return result;
            }
        }


        private void cbInstances_Click(object sender, EventArgs e)
        {
            // Load SQL Server instances only if they haven't been loaded yet
            if (cbInstances.Items.Count == 0 )
            {
                LoadSqlServerInstances();
            }
        }


        private void InitializeContextMenu()
        {
            // Create a context menu
            ContextMenu contextMenu = new ContextMenu();

            // Add "Select All" menu item
            MenuItem selectAllMenuItem = new MenuItem("Select All");
            selectAllMenuItem.Click += SelectAllMenuItem_Click;
            contextMenu.MenuItems.Add(selectAllMenuItem);

            // Add "Select None" menu item
            MenuItem selectNoneMenuItem = new MenuItem("Select None");
            selectNoneMenuItem.Click += SelectNoneMenuItem_Click;
            contextMenu.MenuItems.Add(selectNoneMenuItem);

            // Attach the context menu to the CheckedListBox
            clbDatabases.ContextMenu = contextMenu;
        }

        private void SelectAllMenuItem_Click(object sender, EventArgs e)
        {
            // Select all items in the CheckedListBox
            for (int i = 0; i < clbDatabases.Items.Count; i++)
            {
                clbDatabases.SetItemChecked(i, true);
            }
        }

        private void SelectNoneMenuItem_Click(object sender, EventArgs e)
        {
            // Deselect all items in the CheckedListBox
            for (int i = 0; i < clbDatabases.Items.Count; i++)
            {
                clbDatabases.SetItemChecked(i, false);
            }
        }


        private void ExportToExcel(System.Data.DataTable dataTable)
        {
            try
            {
               


                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Results");

                    // Add headers
                    worksheet.Cells[1, 1].Value = "Database";
                    worksheet.Cells[1, 2].Value = "Result";

                    // Add data
                    int row = 2;
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        worksheet.Cells[row, 1].Value = dataRow["Database"];
                        worksheet.Cells[row, 2].Value = dataRow["Result"];
                        row++;
                    }

                    // Save the Excel file
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Excel Files|*.xlsx|All Files|*.*",
                        Title = "Save Excel File",
                        FileName = "QueryResults.xlsx"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo excelFile = new FileInfo(saveFileDialog.FileName);
                        excelPackage.SaveAs(excelFile);

                        MessageBox.Show($"Excel file saved successfully: {excelFile.FullName}", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbExportResults_Click(object sender, EventArgs e)
        {
            if(dt_Results == null)
            {
                MessageBox.Show("There are no results to export.", "Export failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (dt_Results.Rows.Count > 0)
                {
                    //Exports to excel file
                    ExportToExcel(dt_Results);
                }
                else
                {
                    MessageBox.Show("There are no results to export.", "Export failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
          
          
        }

        private void llQuery_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(txtQuery.Text != string.Empty && txtQuery.Text.ToUpper().Contains(".SQL"))
            {
                // Show QueryEditorForm and load the query content from the file path
                using (frmQueryEditor queryEditorForm = new frmQueryEditor())
                {
                    // Assuming txtQuery is the TextBox with the file path
                    queryEditorForm.LoadQuery(txtQuery.Text);

                    // Show the QueryEditorForm
                    queryEditorForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Choose a valid file.","Invalid file",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}

