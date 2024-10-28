using System.IO.Compression;

namespace AutoExportDatabase
{
    public class FileCreator
    {
        public void CreateFileSQL(string filePath, string database, List<string> content)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                using (StreamWriter sw = new StreamWriter(filePath))
                {

                    sw.WriteLine($"CREATE DATABASE {database};");

                    sw.WriteLine();

                    foreach (string contentCreateTable in content)
                    {
                        sw.WriteLine();

                        sw.Write(contentCreateTable);
                        sw.WriteLine();

                    }

                }

                Console.WriteLine($"File {filePath} created with success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void CreateZipFile(string sourcePath, string zipPath)
        {
            try
            {
                ZipFile.CreateFromDirectory(sourcePath, zipPath);

                Console.WriteLine($"zip file {zipPath} created with success!");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }
}