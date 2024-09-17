using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Programming_3B_Part_1
{
    public partial class ReportIssuesForm : Window
    {
        private List<string> attachedFiles = new List<string>();  

        public ReportIssuesForm()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();  // Initialize the SQLite database using DatabaseHelper
        }

        // Update the progress bar based on form inputs
        private void UpdateProgressBar()
        {
            int totalFields = 3;
            int filledFields = 0;

            if (!string.IsNullOrWhiteSpace(txtLocation.Text))
                filledFields++;

            if (categoryComboBox.SelectedItem != null)
                filledFields++;

            if (!string.IsNullOrWhiteSpace(new TextRange(rtbDescription.Document.ContentStart, rtbDescription.Document.ContentEnd).Text.Trim()))
                filledFields++;

            
            double progress = (filledFields / (double)totalFields) * 100;
            progressBarFormFilling.Value = progress;
        }

        // Handle form submission with progress bar and success message
        private async void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            // Validate user input
            if (string.IsNullOrWhiteSpace(txtLocation.Text) ||
                categoryComboBox.SelectedItem == null ||
                string.IsNullOrWhiteSpace(new TextRange(rtbDescription.Document.ContentStart, rtbDescription.Document.ContentEnd).Text.Trim()))
            {
                MessageBox.Show("Please fill all the fields before submitting.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Prepare the data
            ComboBoxItem selectedItem = (ComboBoxItem)categoryComboBox.SelectedItem;
            string selectedText = selectedItem.Content.ToString();

            Issue newIssue = new Issue
            {
                Location = txtLocation.Text,
                Category = selectedText,  
                Description = new TextRange(rtbDescription.Document.ContentStart, rtbDescription.Document.ContentEnd).Text.Trim(),
                AttachedFiles = new List<string>(attachedFiles)
            };

            // Show the overlay progress bar
            btnAttachFile.IsEnabled = false;
            btnSubmit.IsEnabled = false;
            categoryComboBox.IsEnabled = false;
            txtLocation.IsEnabled = false;
            rtbDescription.IsEnabled = false;  
            OverlayStack.Visibility = Visibility.Visible;
            progressBarOverlay.Value = 0;

            
            await SimulateProgress();

            // Insert the new issue into the database using DatabaseHelper
            DatabaseHelper.InsertIssue(newIssue);

            // Hide the progress overlay and enable the form again
            OverlayStack.Visibility = Visibility.Collapsed;
            btnAttachFile.IsEnabled = true;
            btnSubmit.IsEnabled = true;
            categoryComboBox.IsEnabled = true;
            txtLocation.IsEnabled = true;
            rtbDescription.IsEnabled = true;

            // Provide feedback to user
            MessageBox.Show("Issue reported successfully! Thank you for your feedback.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            lblFeedback.Content = "Thank you for your submission!";

            
            ClearFields();
        }

        // Handle file attachment
        private void btnAttachFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true  
            };

            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    if (!attachedFiles.Contains(fileName))  
                    {
                        attachedFiles.Add(fileName);
                    }
                }
                lblFeedback.Content = $"{attachedFiles.Count} file(s) attached successfully!";
            }
        }

        // Simulate progress bar behavior
        private async Task SimulateProgress()
        {
            for (int i = 0; i <= 100; i++)
            {
                await Task.Delay(30); 
                progressBarOverlay.Value = i; 
            }
        }

        // Clear form fields
        private void ClearFields()
        {
            
            txtLocation.Clear();

            
            categoryComboBox.SelectedIndex = -1;

            
            rtbDescription.Document.Blocks.Clear();

            
            attachedFiles.Clear();

            
            lblFeedback.Content = string.Empty;

            
            progressBarFormFilling.Value = 0;
        }

        // Load issues from the database
        private List<Issue> LoadIssuesFromDatabase()
        {
            return DatabaseHelper.LoadIssuesFromDatabase();  
        }

        // Event handler for ComboBox selection change
        private void cmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblFeedback.Content = "Category selected! Describe the issue next.";
            UpdateProgressBar();
        }

        // Event handler for location text change
        private void txtLocation_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblFeedback.Content = "Location noted! Now, choose a category.";
            UpdateProgressBar();
        }

        // Event handler for description text change
        private void rtbDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProgressBar();
        }

        // Event handler for navigating back to the main menu
        private void btnBackToMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainMenu = new MainWindow();
            mainMenu.Show();
            this.Close(); 
        }
    }
}