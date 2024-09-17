using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Navigation;

namespace Programming_3B_Part_1
{
    /// <summary>
    /// Interaction logic for ViewIssuesForm.xaml
    /// </summary>
    public partial class ViewIssuesForm : Window
    {
        // Static HashSet to track upvotes 
        private static HashSet<int> upvotedIssues = new HashSet<int>();

        public ViewIssuesForm()
        {
            InitializeComponent();
            LoadIssuesToDataGrid();  
        }

        private void LoadIssuesToDataGrid()
        {
            List<Issue> issues = DatabaseHelper.LoadIssuesFromDatabase();  
            dataGridIssues.ItemsSource = issues;  
        }                                   

        // Handle the Hyperlink click to open the file
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            string filePath = e.Uri.LocalPath;

            // Check if the file exists before attempting to open it
            if (File.Exists(filePath))
            {
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
            else
            {
                MessageBox.Show($"The file '{filePath}' could not be found.", "File Not Found", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            e.Handled = true;
        }

        private void btnMarkImportant_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            int issueId = (int)btn.Tag;

            // Check if the issue has already been upvoted in this session
            if (upvotedIssues.Contains(issueId))
            {
                MessageBox.Show("You have already upvoted this issue.", "Duplicate Upvote", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Increment the importance count for the issue in the database
            DatabaseHelper.IncrementIssueImportance(issueId);

            // Add the issue to the HashSet
            upvotedIssues.Add(issueId);

            // Refresh DataGrid to display updated importance counts
            LoadIssuesToDataGrid();
        }

        // Event handler for setting row background color based on Importance
        private void DataGridIssues_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            
            var issue = e.Row.Item as Issue;

            if (issue != null)
            {
                // Check the Importance value and set the row's background color accordingly
                if (issue.Importance >= 10)
                {
                    e.Row.Background = new SolidColorBrush(Colors.LightCoral); 
                }
                else if (issue.Importance >= 5 && issue.Importance < 10)
                {
                    e.Row.Background = new SolidColorBrush(Colors.LightYellow); 
                }
                else
                {
                    e.Row.Background = new SolidColorBrush(Colors.White); 
                }
            }
        }

        private void btnBackToMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainMenu = new MainWindow();
            mainMenu.Show();
            this.Close();  
        }
    }
}