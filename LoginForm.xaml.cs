using System.Windows;

namespace Programming_3B_Part_1
{
    public partial class LoginForm : Window
    {
        private int userId;  

        
        public LoginForm()
        {
            InitializeComponent();
        }

        public LoginForm(int loggedInUserId)
        {
            InitializeComponent();
            userId = loggedInUserId;  
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            // Get the userId if authentication is successful
            int authenticatedUserId = DatabaseHelper.AuthenticateUserAndGetUserId(username, password);

            if (authenticatedUserId != 0)  
            {
                MessageBox.Show($"Welcome, {username}!");

                
                var mainWindow = new MainWindow(authenticatedUserId);
                mainWindow.Show();

                
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();  
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            
            var signUpForm = new SignUpForm();
            signUpForm.ShowDialog();  
        }
    }
}