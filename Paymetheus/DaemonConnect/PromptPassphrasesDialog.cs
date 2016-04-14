using Paymetheus.Decred.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Paymetheus.DaemonConnect
{

    public sealed class PromptPassphrasesDialog : ConnectionWizardDialog
    {
        public PromptPassphrasesDialog(StartupWizard wizard, byte[] seed) : base(wizard)
        {
            _seed = seed;

            CreateWalletCommand = new DelegateCommand(CreateWallet);
        }

        private byte[] _seed;

        private bool _usePublicEncryption;
        public bool UsePublicEncryption
        {
            get { return _usePublicEncryption; }
            set { _usePublicEncryption = value; RaisePropertyChanged(); }
        }
        public string PublicPassphrase { private get; set; } = "";
        public string PrivatePassphrase { private get; set; } = "";

        public DelegateCommand CreateWalletCommand { get; }
        private async void CreateWallet()
        {
            try
            {
                CreateWalletCommand.Executable = false;

                if (string.IsNullOrEmpty(PrivatePassphrase))
                {
                    MessageBox.Show("Private passphrase is required");
                    return;
                }

                var publicPassphrase = PublicPassphrase;
                if (!UsePublicEncryption)
                {
                    publicPassphrase = "public";
                }
                else
                {
                    if (string.IsNullOrEmpty(publicPassphrase))
                    {
                        MessageBox.Show("Public passphrase is required");
                        return;
                    }
                }

                await App.Current.WalletRpcClient.CreateWallet(publicPassphrase, PrivatePassphrase, _seed);

                ValueArray.Zero(_seed);
                Wizard.InvokeWalletOpened();
            }
            finally
            {
                CreateWalletCommand.Executable = true;
            }
        }
    }

}
