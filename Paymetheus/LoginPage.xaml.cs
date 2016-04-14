using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace Paymetheus
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void SelectFileClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.ShowDialog();
        }

        private void ContinueClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Continue Button");
        }

        private void NeedHelpClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Need Help Button");
        }
    }
}
