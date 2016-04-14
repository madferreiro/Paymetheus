using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paymetheus.DaemonConnect
{
    public sealed class StartupWizard : WizardViewModelBase
    {
        public StartupWizard(ShellViewModel shell) : base(shell)
        {
            CurrentDialog = new ConsensusServerRpcConnectionDialog(this);
            Shell = shell;
        }

        public ShellViewModel Shell { get; }

        public event EventHandler WalletOpened;

        public void InvokeWalletOpened()
        {
            App.Current.MarkWalletLoaded();
            WalletOpened?.Invoke(this, new EventArgs());
        }
    }
}
