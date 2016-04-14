using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paymetheus.DaemonConnect
{
    public class ConnectionWizardDialog : WizardDialogViewModelBase
    {
        public ConnectionWizardDialog(StartupWizard wizard) : base(wizard.Shell, wizard)
        {
            Wizard = wizard;
        }

        public StartupWizard Wizard { get; }
    }
}
