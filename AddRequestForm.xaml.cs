using System;
using System.Windows;
using System.Windows.Controls;

namespace Programming_3B_Part_1
{
    public partial class AddRequestForm : Window
    {
        public ServiceRequest NewRequest { get; private set; }

        public AddRequestForm()
        {
            InitializeComponent();
        }

        private void AddRequestButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(RequestIdTextBox.Text, out int requestId) && !string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
            {
                NewRequest = new ServiceRequest
                {
                    RequestID = requestId,
                    Description = DescriptionTextBox.Text,
                    Status = (StatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "Pending"
                };
                DialogResult = true;  // Close the form and indicate success
            }
            else
            {
                MessageBox.Show("Please enter valid data for all fields.");
            }
        }
    }
}