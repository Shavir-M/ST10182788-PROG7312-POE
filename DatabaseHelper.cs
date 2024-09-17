using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace Programming_3B_Part_1
{
    public class DatabaseHelper
    {
        private static string dbFilePath = "prog7312.db"; 

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
                string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Issues (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Location TEXT NOT NULL,
                    Category TEXT NOT NULL,
                    Description TEXT NOT NULL,
                    AttachedFiles TEXT,
                    Importance INTEGER DEFAULT 0  -- New column for importance count
                )";
                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                
                EnsureColumnExists(connection, "Issues", "Importance", "INTEGER DEFAULT 0");
            }
        }

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

        public static void IncrementIssueImportance(int issueId)
        {
            using (var connection = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
            {
                connection.Open();
                // Update the importance count for the selected issue
                string updateQuery = "UPDATE Issues SET Importance = Importance + 1 WHERE Id = @Id";
                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", issueId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}