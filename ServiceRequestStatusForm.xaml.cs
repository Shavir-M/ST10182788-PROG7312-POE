using Programming_3B_Part_1;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Programming_3B_Part_1
{

    public partial class ServiceRequestStatusForm : Window
    {

        private ServiceRequestViewModel viewModel;

        private bool titleSortCheck = true;

        private bool isFirstLoad = true;

        private bool statusSortCheck = true;

        private bool dateSortCheck = true;


        public ServiceRequestStatusForm()
        {
            InitializeComponent();
            viewModel = new ServiceRequestViewModel();
            DataContext = viewModel;
        }


        /// Method to search events by title

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string selectedStatus = cbStatusFilter.SelectedItem is ComboBoxItem selectedItem ? selectedItem.Content.ToString() : null;
            string searchTerm = txtSearch.Text.ToLower();
            DateTime? startDate = dpStart.SelectedDate;
            DateTime? endDate = dpEnd.SelectedDate;

            viewModel.FilterRequests(searchTerm, selectedStatus, startDate, endDate);
        }

        /// Method to sort events by title in ascending or descending order

        private void btnTitleSort_Click(object sender, RoutedEventArgs e)
        {
            var filteredRequests = lstRequests.Items.Cast<ServiceRequest>().ToList();
            viewModel.SortRequestsByTitle(titleSortCheck, filteredRequests);
            if (titleSortCheck)
            {
                this.titleSortCheck = false;
            }
            else
            {
                titleSortCheck = true;
            }
        }


        /// Method to handle category filtering

        private void cbStatusFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isFirstLoad)
            {
                isFirstLoad = false;
            }
            else
            {
                string selectedStatus = cbStatusFilter.SelectedItem is ComboBoxItem selectedItem ? selectedItem.Content.ToString() : null;
                string searchTerm = txtSearch.Text.ToLower();
                DateTime? startDate = dpStart.SelectedDate;
                DateTime? endDate = dpEnd.SelectedDate;

                viewModel.FilterRequests(searchTerm, selectedStatus, startDate, endDate);
            }
        }


        /// Method to sort events by category in ascending or descending order

        private void btnStatusSort_Click(object sender, RoutedEventArgs e)
        {
            var filteredRequests = lstRequests.Items.Cast<ServiceRequest>().ToList();
            viewModel.SortRequestsByStatus(statusSortCheck, filteredRequests);
            if (this.statusSortCheck)
            {
 
                this.statusSortCheck = false;
            }
            else
            {
 
                this.statusSortCheck = true;
            }
        }

        /// Method to handle start date filtering

        private void dpStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpStart.SelectedDate.HasValue && dpEnd.SelectedDate.HasValue)
            {
                if (dpEnd.SelectedDate.Value < dpStart.SelectedDate.Value)
                {
                    MessageBox.Show("End date cannot be before start date.", "Invalid Date Range", MessageBoxButton.OK, MessageBoxImage.Warning);
                    dpEnd.SelectedDate = dpStart.SelectedDate;
                    return;
                }
            }

            string selectedStatus = cbStatusFilter.SelectedItem is ComboBoxItem selectedItem ? selectedItem.Content.ToString() : null;
            string searchTerm = txtSearch.Text.ToLower();
            DateTime? startDate = dpStart.SelectedDate;
            DateTime? endDate = dpEnd.SelectedDate;

            viewModel.FilterRequests(searchTerm, selectedStatus, startDate, endDate);
        }


        /// Method to handle end date filtering

        private void dpEnd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpStart.SelectedDate.HasValue && dpEnd.SelectedDate.HasValue)
            {
                if (dpEnd.SelectedDate.Value < dpStart.SelectedDate.Value)
                {
                    MessageBox.Show("End date cannot be before start date.", "Invalid Date Range", MessageBoxButton.OK, MessageBoxImage.Warning);
                    dpEnd.SelectedDate = dpStart.SelectedDate;
                    return;
                }
            }

            string selectedStatus = cbStatusFilter.SelectedItem is ComboBoxItem selectedItem ? selectedItem.Content.ToString() : null;
            string searchTerm = txtSearch.Text.ToLower();
            DateTime? startDate = dpStart.SelectedDate;
            DateTime? endDate = dpEnd.SelectedDate;

            viewModel.FilterRequests(searchTerm, selectedStatus, startDate, endDate);
        }


        /// Method to sort events by date in ascending or descending order

        private void btnDateSort_Click(object sender, RoutedEventArgs e)
        {
            var filteredRequests = lstRequests.Items.Cast<ServiceRequest>().ToList();
            viewModel.SortRequestsByDate(dateSortCheck, filteredRequests);
            if (this.dateSortCheck)
            {
                this.dateSortCheck = false;
            }
            else
            { 
                this.dateSortCheck = true;
            }
        }


        /// Method to sort events by category in ascending or descending order

        private void btnPrioritySort_Click(object sender, RoutedEventArgs e)
        {
            var filteredRequests = lstRequests.Items.Cast<ServiceRequest>().ToList();
            viewModel.SortRequestsByStatus(statusSortCheck, filteredRequests);
            if (this.statusSortCheck)
            {

                this.statusSortCheck = false;
            }
            else
            {
  
                this.statusSortCheck = true;
            }
        }



        private void lstRequests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstRequests.SelectedItem is ServiceRequest selectedRequest)
            {
                txtRequestID.Text = selectedRequest.ServiceRequestID.ToString();
                txtRequestTitle.Text = selectedRequest.Title;
                txtRequestStatus.Text = selectedRequest.Status;
                txtRequestDate.Text = selectedRequest.DateSubmitted.ToString("MMMM dd, yyyy");
                txtRequestDescription.Text = selectedRequest.Description;
            }
        }

        // Clear Filters Button Click Handler
        private void btnClearFilters_Click(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = string.Empty;
            cbStatusFilter.SelectedIndex = 0;
            dpStart.SelectedDate = null;
            dpEnd.SelectedDate = null;

        }

        // Return to Main Menu Button Click Handler
        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {

            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }



    }
}
