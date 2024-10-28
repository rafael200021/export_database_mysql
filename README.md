# Database Exporter Console App

This C# console application automates the export of all databases from a specified connection. It generates `.sql` files containing `CREATE TABLE` statements for each table and then compresses the files into a zip archive for easy storage and transfer.

## Features

- **Database Export**: Connects to a database server and exports the `CREATE TABLE` statements of all tables within each database.
- **SQL File Generation**: Saves each table's schema as an `.sql` file for easy review or backup.
- **Automated Zipping**: Compresses the generated `.sql` files into a single zip archive for efficient storage and handling.
- **Configurable Connection**: Set up the database connection parameters to export databases from any supported server.

## Tech Stack

- **C# and .NET Core**: For the console application and file generation.
- **MySqlConnector**: For database connections and executing queries.
- **System.IO.Compression**: For zipping the generated files.

## Setup and Usage

1. Clone this repository.
2. Set the database connectionString in the Database Class.
4. Set the path in the FileCreator Class.
3. Run the console app to initiate the export process.

## Contributing

Contributions are welcome! Feel free to submit issues or pull requests to improve the functionality or add new features.