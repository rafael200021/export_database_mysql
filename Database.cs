using MySqlConnector;

public class Database
{


    // Connection Example: Server=Server;User=User;Password=Password;
    public string connectionString = "yourconnectionstring";
    public MySqlConnection connection;
    public Database()
    {

        try
        {
            connection = new MySqlConnection(connectionString);

            connection.Open();

        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }


    }


    public List<string>? GetDatabases()
    {
        try
        {
            var command = new MySqlCommand("SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME  NOT IN ('information_schema','mysql', 'performance_schema', 'sys')", connection);

            List<string> databases = new List<string>();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    databases.Add(reader.GetString(0));
                }
            }

            return databases;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        return null;
    }
    public List<string>? GetTables(string databaseName)
    {
        try
        {
            var command = new MySqlCommand($"SELECT table_name FROM information_schema.tables WHERE table_schema = '{databaseName}'", connection);

            List<string> tables = new List<string>();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    tables.Add(reader.GetString(0));
                }
            }

            return tables;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        return null;
    }
    public string? GetCreateTable(string tableName, string database)
    {
        try
        {
            var command = new MySqlCommand($"SHOW CREATE TABLE {database}.{tableName}", connection);

            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return reader.GetString(1);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        return null;
    }
}