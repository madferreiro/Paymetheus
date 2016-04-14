using Paymetheus.Decred.Util;
using Paymetheus.Decred.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Paymetheus.DaemonConnect
{
    public sealed class CreateOrImportSeedDialog : ConnectionWizardDialog
    {
        public CreateOrImportSeedDialog(StartupWizard wizard) : base(wizard)
        {
            _randomSeed = WalletSeed.GenerateRandomSeed();

            ContinueCommand = new DelegateCommand(Continue);
            ContinueCommand.Executable = false;
        }

        private byte[] _randomSeed;
        private PgpWordList _pgpWordList = new PgpWordList();

        // TODO: Convert seed using a wordlist instead of encoding as hex so this is easier
        // for the user to write down and type into the next dialog.
        public string Bip0032SeedHex => Hexadecimal.Encode(_randomSeed);

        private bool _createChecked;
        public bool CreateChecked
        {
            get { return _createChecked; }
            set
            {
                _createChecked = value;
                RaisePropertyChanged();
                ContinueCommand.Executable = true;
            }
        }

        private bool _importChecked;
        public bool ImportChecked
        {
            get { return _importChecked; }
            set
            {
                _importChecked = value;
                RaisePropertyChanged();
                ContinueCommand.Executable = true;
            }
        }

        public string ImportedSeed { get; set; }

        public DelegateCommand ContinueCommand { get; }
        private void Continue()
        {
            try
            {
                ContinueCommand.Executable = false;

                if (CreateChecked)
                {
                    Wizard.CurrentDialog = new ConfirmSeedBackupDialog(Wizard, this, _randomSeed, _pgpWordList);
                }
                else
                {
                    var seed = WalletSeed.DecodeAndValidateUserInput(ImportedSeed, _pgpWordList);
                    Wizard.CurrentDialog = new PromptPassphrasesDialog(Wizard, seed);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                ContinueCommand.Executable = true;
            }
        }
    }

}
