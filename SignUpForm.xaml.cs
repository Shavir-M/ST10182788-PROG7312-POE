using System.Windows;

namespace Programming_3B_Part_1
{
    public partial class SignUpForm : Window
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            // Simple validation
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            // Use DatabaseHelper to add the user to the SQLite database
            bool success = DatabaseHelper.AddUser(username, password);

            if (success)
            {
                MessageBox.Show("Account created successfully!");
                this.DialogResult = true;  
                this.Close();  
            }
            else
            {
                MessageBox.Show("Username already exists. Please choose a different username.");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            
            this.DialogResult = false;
            this.Close();  
        }
    }
}