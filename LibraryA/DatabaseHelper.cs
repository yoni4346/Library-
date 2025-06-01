using System;
using System.Data;
using MySql.Data.MySqlClient; 
using System.Windows.Forms;
using System.IO; 

public static class DatabaseHelper
{
    private static string server = "localhost"; 
    private static string database = "mylibrary_db"; 
    private static string uid = "mylibrary_user"; 
    private static string password = "4346"; 
    private static string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
    public static void InitializeDatabaseTables()
    {
        string scriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database_script.sql");
        if (!File.Exists(scriptPath))
        {
            MessageBox.Show($"Database script not found at {scriptPath}.\nPlease ensure it's in the output directory and tables are created manually if needed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        string scriptContent = File.ReadAllText(scriptPath);

        try
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var commands = scriptContent.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                int commandsExecuted = 0;
                foreach (var commandText in commands)
                {
                    string trimmedCommand = commandText.Trim();
                    if (!string.IsNullOrWhiteSpace(trimmedCommand) &&
                        !trimmedCommand.StartsWith("--") &&
                        !trimmedCommand.StartsWith("/*") &&
                        !trimmedCommand.ToUpper().StartsWith("USE "))
                    {
                        if (trimmedCommand.ToUpper().StartsWith("CREATE TABLE") || trimmedCommand.ToUpper().StartsWith("INSERT"))
                        {
                            using (var command = new MySqlCommand(trimmedCommand, connection))
                            {
                                command.ExecuteNonQuery();
                                commandsExecuted++;
                            }
                        }
                    }
                }
                if (commandsExecuted > 0)
                    Console.WriteLine($"{commandsExecuted} commands from script executed for table initialization.");
                else
                    Console.WriteLine("No applicable commands for table initialization found in script or script focused on DB creation.");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Database Table Initialization Error: {ex.Message}\nConsider creating tables manually using MySQL Workbench or a similar tool.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


    public static MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }

    public static int ExecuteNonQuery(string query, MySqlParameter[] parameters = null)
    {
        try
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    return command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Database Error: {ex.Message}\nQuery: {query}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return -1;
        }
    }

    public static DataTable ExecuteQuery(string query, MySqlParameter[] parameters = null)
    {
        DataTable dataTable = new DataTable();
        try
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Database Error: {ex.Message}\nQuery: {query}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return dataTable;
    }

    public static object ExecuteScalar(string query, MySqlParameter[] parameters = null)
    {
        try
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    return command.ExecuteScalar();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Database Error: {ex.Message}\nQuery: {query}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
    }
}