using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Programming_3B_Part_1
{
    public partial class AddEventForm : Window
    {
        private HashSet<string> uniqueCategories;

        public AddEventForm(HashSet<string> categories)
        {
            InitializeComponent();
            uniqueCategories = categories;
            CategoryListBox.ItemsSource = uniqueCategories.ToList();
        }

        // Handle adding new category
        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            string newCategory = NewCategoryTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(newCategory))
            {
                MessageBox.Show("Please enter a valid category.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (uniqueCategories.Contains(newCategory))
            {
                MessageBox.Show("Category already exists.", "Duplicate Category", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                uniqueCategories.Add(newCategory);
                CategoryListBox.ItemsSource = null;
                CategoryListBox.ItemsSource = uniqueCategories.ToList();
                MessageBox.Show("Category added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            NewCategoryTextBox.Clear();
        }

        private void AddEventButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleTextBox.Text;
            string category = CategoryListBox.SelectedItem?.ToString() ?? string.Empty;
            DateTime date = DatePicker.SelectedDate.HasValue ? DatePicker.SelectedDate.Value : DateTime.Now;
            string description = DescriptionTextBox.Text;
            string location = LocationTextBox.Text;
            int importance = int.TryParse(ImportanceTextBox.Text, out var value) ? value : 0;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(location))
            {
                MessageBox.Show("Please fill in all required fields.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Event newEvent = new Event(title, category, date, description, location, importance);

            LocalEventsForm localEventsForm = Application.Current.Windows.OfType<LocalEventsForm>().FirstOrDefault();
            localEventsForm?.AddEvent(newEvent);

            this.DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        
    }
}