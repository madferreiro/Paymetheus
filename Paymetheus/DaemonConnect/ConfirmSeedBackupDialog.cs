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
    public sealed class ConfirmSeedBackupDialog : ConnectionWizardDialog
    {
        public ConfirmSeedBackupDialog(StartupWizard wizard, CreateOrImportSeedDialog previousDialog,
            byte[] seed, PgpWordList pgpWordlist)
            : base(wizard)
        {
            _previousDialog = previousDialog;
            _seed = seed;
            _pgpWordList = pgpWordlist;

            ConfirmSeedCommand = new DelegateCommand(ConfirmSeed);
            BackCommand = new DelegateCommand(Back);
        }

        private CreateOrImportSeedDialog _previousDialog;
        private byte[] _seed;
        private PgpWordList _pgpWordList;

        public string Input { get; set; } = "";

        public DelegateCommand ConfirmSeedCommand { get; }
        private void ConfirmSeed()
        {
            try
            {
                ConfirmSeedCommand.Executable = false;

                var decodedSeed = WalletSeed.DecodeAndValidateUserInput(Input, _pgpWordList);
                if (ValueArray.ShallowEquals(_seed, decodedSeed))
                {
                    _wizard.CurrentDialog = new PromptPassphrasesDialog(Wizard, _seed);
                }
                else
                {
                    MessageBox.Show("Seed does not match");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid seed");
            }
            finally
            {
                ConfirmSeedCommand.Executable = true;
            }
        }

        public DelegateCommand BackCommand { get; }
        private void Back()
        {
            Wizard.CurrentDialog = _previousDialog;
        }
    }

}
