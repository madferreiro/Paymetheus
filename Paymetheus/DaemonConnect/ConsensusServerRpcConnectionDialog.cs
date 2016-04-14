using System;
using System.IO;
using System.Windows;
using Paymetheus.Rpc;
using Paymetheus.Decred;

namespace Paymetheus.DaemonConnect
{

    public sealed class ConsensusServerRpcConnectionDialog : ConnectionWizardDialog
    {
        public ConsensusServerRpcConnectionDialog(StartupWizard wizard) : base(wizard)
        {
            ConnectCommand = new DelegateCommand(Connect);

            // Do not autofill local defaults if they don't exist.
            if (!File.Exists(ConsensusServerCertificateFile))
            {
                ConsensusServerNetworkAddress = "";
                ConsensusServerCertificateFile = "";
            }
        }

        public string ConsensusServerApplicationName => ConsensusServerRpcOptions.ApplicationName;
        public string CurrencyName => BlockChain.CurrencyName;
        public string ConsensusServerNetworkAddress { get; set; } = "localhost";
        public string ConsensusServerRpcUsername { get; set; } = "";
        public string ConsensusServerRpcPassword { private get; set; } = "";
        public string ConsensusServerCertificateFile { get; set; } = ConsensusServerRpcOptions.LocalCertificateFilePath();

        public DelegateCommand ConnectCommand { get; }
        private async void Connect()
        {
            try
            {
                ConnectCommand.Executable = false;

                if (string.IsNullOrWhiteSpace(ConsensusServerNetworkAddress))
                {
                    MessageBox.Show("Network address is required");
                    return;
                }
                if (string.IsNullOrWhiteSpace(ConsensusServerRpcUsername))
                {
                    MessageBox.Show("RPC username is required");
                    return;
                }
                if (ConsensusServerRpcPassword.Length == 0)
                {
                    MessageBox.Show("RPC password may not be empty");
                    return;
                }
                if (!File.Exists(ConsensusServerCertificateFile))
                {
                    MessageBox.Show("Certificate file not found");
                    return;
                }

                var rpcOptions = new ConsensusServerRpcOptions(ConsensusServerNetworkAddress,
                    ConsensusServerRpcUsername, ConsensusServerRpcPassword, ConsensusServerCertificateFile);
                try
                {
                    await App.Current.WalletRpcClient.StartBtcdRpc(rpcOptions);
                }
                catch (Exception ex) when (ErrorHandling.IsTransient(ex) || ErrorHandling.IsClientError(ex))
                {
                    MessageBox.Show($"Unable to start {ConsensusServerRpcOptions.ApplicationName} RPC.\n\nCheck connection settings and try again.", "Error");
                    MessageBox.Show(ex.Message);
                    return;
                }

                var walletExists = await App.Current.WalletRpcClient.WalletExistsAsync();
                if (!walletExists)
                {
                    _wizard.CurrentDialog = new CreateOrImportSeedDialog(Wizard);
                }
                else
                {
                    // TODO: Determine whether the public encryption is enabled and a prompt for the
                    // public passphrase prompt is needed before the wallet can be opened.  If it
                    // does not, then the wallet can be opened directly here instead of creating
                    // another dialog.
                    _wizard.CurrentDialog = new PromptPublicPassphraseDialog(Wizard);

                    //await _walletClient.OpenWallet("public");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                ConnectCommand.Executable = true;
            }
        }
    }

}
