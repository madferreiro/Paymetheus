using Microsoft.Win32;
using Paymetheus.DaemonConnect;
using Paymetheus.Helpers;
using System.Windows;
using System.Windows.Controls;

namespace Paymetheus
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private ConnectionWizard _connectionWizard { get; set; }
        private string _certificateFilePath { get; set; }

        public LoginPage()
        {
            InitializeComponent();
            _connectionWizard = new ConnectionWizard();
        }

        private void SelectFileClick(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.ShowDialog();
            _certificateFilePath = dialog.FileName;
        }

        private ConnectionContext EnrichConnectionWizard()
        {
            var context = new ConnectionContext();
            context.NetworkAddress = Location.Text;
            context.RpcUsername = Username.Text;
            context.RpcPassword = Password.Text;
            context.CertificateFilePath = _certificateFilePath;
            return context;
        }
        
        private void ContinueClick(object sender, RoutedEventArgs e)
        {
            var context = EnrichConnectionWizard();
            _connectionWizard.Connect(context);
            if(string.IsNullOrEmpty(context.ErrorMessage))
                Navigator.Instance.NavigateTo(context.NextPage);
            else
                MessageBox.Show(context.ErrorMessage);
        }

        private void NeedHelpClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Need Help Button");
        }
    }
}
