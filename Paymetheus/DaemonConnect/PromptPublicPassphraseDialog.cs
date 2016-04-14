using Paymetheus.Rpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Paymetheus.DaemonConnect
{
    public sealed class PromptPublicPassphraseDialog : ConnectionWizardDialog
    {
        public PromptPublicPassphraseDialog(StartupWizard wizard) : base(wizard)
        {
            OpenWalletCommand = new DelegateCommand(OpenWallet);
        }

        public string PublicPassphrase { get; set; } = "";

        public DelegateCommand OpenWalletCommand { get; }
        private async void OpenWallet()
        {
            try
            {
                OpenWalletCommand.Executable = false;
                await App.Current.WalletRpcClient.OpenWallet(PublicPassphrase);
                Wizard.InvokeWalletOpened();
            }
            catch (Exception ex) when (ErrorHandling.IsClientError(ex))
            {
                MessageBox.Show("Public data decryption was unsuccessful");
                MessageBox.Show(ex.ToString());
                return;
            }
            finally
            {
                OpenWalletCommand.Executable = true;
            }
        }
    }
}
