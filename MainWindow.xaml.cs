using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Programming_3B_Part_1
{
   
    public partial class MainWindow : Window
    {
        private int loggedInUserId;
        public MainWindow(int userId)
        {
            InitializeComponent();
            loggedInUserId = userId;  // Store the logged-in user ID
           
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            ReportIssuesForm reportIssuesForm = new ReportIssuesForm(loggedInUserId);
            reportIssuesForm.Show();
            this.Hide(); 
        }

        private void btnViewIssues_Click(object sender, RoutedEventArgs e)
        {
            ViewIssuesForm viewIssuesForm = new ViewIssuesForm(loggedInUserId);
            viewIssuesForm.Show();
            this.Close();  
        }

        private void btnLocalEvents_Click(object sender, RoutedEventArgs e)
        {
            LocalEventsForm localEventsForm = new LocalEventsForm(loggedInUserId);
            localEventsForm.Show();
            this.Close();
        }

        private void btnServiceRequestStatus_Click(object sender, RoutedEventArgs e)
        {
            ServiceRequestStatusForm serviceRequestStatusForm = new ServiceRequestStatusForm();
            serviceRequestStatusForm.Show();
            this.Close();
        }
    }
}