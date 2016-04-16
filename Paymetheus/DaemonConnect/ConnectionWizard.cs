using Paymetheus.Decred;
using Paymetheus.Rpc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paymetheus.DaemonConnect
{
    public class ConnectionWizard
    {

        public async void Connect(ConnectionContext context)
        {
            try
            {
                if (HasErrors(context))
                    return;

                context.NextPage = new WalletBinding();
                return;
                var rpcOptions = new ConsensusServerRpcOptions(context.NetworkAddress,
                    context.RpcUsername, context.RpcPassword, context.CertificateFilePath);
                try
                {
                    await App.Current.WalletRpcClient.StartBtcdRpc(rpcOptions);
                }
                catch (Exception ex) when (ErrorHandling.IsTransient(ex) || ErrorHandling.IsClientError(ex))
                {
                    context.ErrorMessage = $"Unable to start {ConsensusServerRpcOptions.ApplicationName} RPC.\n\nCheck connection settings and try again.";
                    //TODO: log the exception
                    //MessageBox.Show(ex.Message);
                    return;
                }
                var walletExists = await App.Current.WalletRpcClient.WalletExistsAsync();
                if (!walletExists)
                {
                    context.NextPage = new WalletBinding();
                }
                else
                {
                    // TODO: Determine whether the public encryption is enabled and a prompt for the
                    // public passphrase prompt is needed before the wallet can be opened.  If it
                    // does not, then the wallet can be opened directly here instead of creating
                    // another dialog.
                    //_wizard.CurrentDialog = new PromptPublicPassphraseDialog(Wizard);

                    //await _walletClient.OpenWallet("public");
                }
            }
            catch (Exception ex)
            {
                context.ErrorMessage = "Error";
            }
        }

        private bool HasErrors(ConnectionContext context)
        {
            if (string.IsNullOrWhiteSpace(context.NetworkAddress))
            {
                context.ErrorMessage = "Network address is required";
                return true;
            }
            if (string.IsNullOrWhiteSpace(context.RpcUsername))
            {
                context.ErrorMessage = "RPC username is required";
                return true;
            }
            if (string.IsNullOrWhiteSpace(context.RpcPassword))
            {
                context.ErrorMessage = "RPC password may not be empty";
                return true;
            }
            if (!File.Exists(context.CertificateFilePath))
            {
                context.ErrorMessage = "Certificate file not found";
                return true;
            }
            return false;
        }
    }
}
