using AutoExportDatabase;

public class Export
{

    public static async void Main()
    {
        FileCreator fileCreator = new FileCreator();

        Database database = new Database();

        // Get list of databases

        List<string>? databases = database.GetDatabases();

        if (databases != null)

            foreach (string databaseName in databases)
            {
                
                // Get list of tables

                List<string>? tables = database.GetTables(databaseName);


                // Create the list of `CREATE TABLE` statements 

                List<string> contentCreateTable = new List<string>();

                if (tables != null)

                    foreach (string tableName in tables)
                    {

                        Console.WriteLine($"Table: {tableName}");

                        string? createTableSQL = database.GetCreateTable(tableName, databaseName);

                        if (createTableSQL != null)
                        {

                            contentCreateTable.Add(createTableSQL);


                        }

                    }


                // Path where the file will be created

                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "/Export/Files/", $"{databaseName}.sql");

                // Create the file

                fileCreator.CreateFileSQL(filePath, databaseName, contentCreateTable);

            }


        // Path to get the files 

        string sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "/Export//Files");

        string name = "database-export " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".zip";

        // Path where the zip file will be created

        string zipPath = Path.Combine(Directory.GetCurrentDirectory(), $"/Export/ZipFiles/{name}");

        // Create the zip file

        fileCreator.CreateZipFile(sourcePath, zipPath);

    }


}
