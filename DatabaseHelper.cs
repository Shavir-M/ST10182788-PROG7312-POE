using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Programming_3B_Part_1
{
    public static class DatabaseHelper
    {
        private static string dbFilePath = "prog7312.db";

        // Initialize the database and create tables if they don't exist
        public static void InitializeDatabase()
        {
            if (!File.Exists(dbFilePath))
            {
                SQLiteConnection.CreateFile(dbFilePath);
            }

            using (var connection = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
            {
                connection.Open();

                // Create the Issues table if it does not exist
                string createIssuesTableQuery = @"
                CREATE TABLE IF NOT EXISTS Issues (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Location TEXT NOT NULL,
                    Category TEXT NOT NULL,
                    Description TEXT NOT NULL,
                    AttachedFiles TEXT,
                    Importance INTEGER DEFAULT 0
                )";
                using (var command = new SQLiteCommand(createIssuesTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Create the Users table if it does not exist
                string createUsersTableQuery = @"
                CREATE TABLE IF NOT EXISTS Users (
                    UserId INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL UNIQUE,
                    Password TEXT NOT NULL
                )";
                using (var command = new SQLiteCommand(createUsersTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        // ============================ ISSUES TABLE METHODS ============================ //

        // Load all issues from the database
        public static List<Issue> LoadIssuesFromDatabase()
        {
            List<Issue> issues = new List<Issue>();

            using (var connection = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Issues";
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Issue issue = new Issue
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Location = reader["Location"].ToString(),
                                Category = reader["Category"].ToString(),
                                Description = reader["Description"].ToString(),
                                AttachedFiles = new List<string>(reader["AttachedFiles"].ToString().Split(';')),
                                Importance = Convert.ToInt32(reader["Importance"])
                            };
                            issues.Add(issue);
                        }
                    }
                }
            }

            return issues;
        }

        

        // Insert a new issue into the database
        public static void InsertIssue(Issue newIssue)
        {
            using (var connection = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Issues (Location, Category, Description, AttachedFiles) VALUES (@Location, @Category, @Description, @AttachedFiles)";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Location", newIssue.Location);
                    command.Parameters.AddWithValue("@Category", newIssue.Category);
                    command.Parameters.AddWithValue("@Description", newIssue.Description);
                    command.Parameters.AddWithValue("@AttachedFiles", string.Join(";", newIssue.AttachedFiles));
                    command.ExecuteNonQuery();
                }
            }
        }

        // Increment the importance count for a specific issue
        public static void IncrementIssueImportance(int issueId)
        {
            using (var connection = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
            {
                connection.Open();
                string updateQuery = "UPDATE Issues SET Importance = Importance + 1 WHERE Id = @Id";
                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", issueId);
                    command.ExecuteNonQuery();
                }
            }
        }

        // ============================ USERS TABLE METHODS ============================ //

        // Method to add a new user during signup
        public static bool AddUser(string username, string password)
        {
            string hashedPassword = HashPassword(password);  // Hash the password before storing it
            using (var connection = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
            {
                connection.Open();
                string insertUserQuery = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";

                try
                {
                    using (var command = new SQLiteCommand(insertUserQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", hashedPassword);
                        command.ExecuteNonQuery();
                    }
                    return true;  // User added successfully
                }
                catch (SQLiteException ex)
                {
                    if (ex.ResultCode == SQLiteErrorCode.Constraint)  // Handle unique constraint (username already exists)
                    {
                        return false;  // Username already exists
                    }
                    throw;
                }
            }
        }

        // Method to authenticate the user during login
        public static int AuthenticateUserAndGetUserId(string username, string password)
        {
            string hashedPassword = HashPassword(password);  // Hash the password for comparison
            using (var connection = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
            {
                connection.Open();
                string authenticateQuery = "SELECT UserId FROM Users WHERE Username = @Username AND Password = @Password";

                using (var command = new SQLiteCommand(authenticateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", hashedPassword);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);  // Return userId if authentication is successful
                    }
                    else
                    {
                        return 0;  // Return 0 if authentication fails
                    }
                }
            }
        }

        // ============================ HELPER METHODS ============================ //

        // Optional method to hash passwords (SHA-256)
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        // Optional method to ensure that a column exists in a table
        private static void EnsureColumnExists(SQLiteConnection connection, string tableName, string columnName, string columnDefinition)
        {
            // Check if the column already exists
            string checkColumnQuery = $"PRAGMA table_info({tableName})";
            using (var command = new SQLiteCommand(checkColumnQuery, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    bool columnExists = false;
                    while (reader.Read())
                    {
                        if (reader["name"].ToString().Equals(columnName, StringComparison.OrdinalIgnoreCase))
                        {
                            columnExists = true;
                            break;
                        }
                    }

                    // If the column does not exist, add it
                    if (!columnExists)
                    {
                        string addColumnQuery = $"ALTER TABLE {tableName} ADD COLUMN {columnName} {columnDefinition}";
                        using (var alterCommand = new SQLiteCommand(addColumnQuery, connection))
                        {
                            alterCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}