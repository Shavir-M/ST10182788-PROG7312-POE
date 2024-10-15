using System.Windows;

namespace Programming_3B_Part_1
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Initialize the database to ensure the Users table exists
            DatabaseHelper.InitializeDatabase();

            // Create and show the LoginForm
            var loginForm = new LoginForm();
            loginForm.Show();

            // Do not close the app after the LoginForm is closed, wait for further actions
        }
    }
}