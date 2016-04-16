using System.Windows.Controls;
using System.Windows.Media;

namespace Paymetheus
{
    /// <summary>
    /// Interaction logic for TransactionUserControl.xaml
    /// </summary>
    public partial class TransactionUserControl : UserControl
	{

        public enum TransactionType
        {
            Pending,
            Invalid,
            Confirmed
        }

        private TransactionType status { get; set; }
        public TransactionType Status { get {
            return status;
        }
            set
            {
                status = value;
                ChangeStatus();
            }
        }

		public TransactionUserControl()
		{
			this.InitializeComponent();

		}

        private void ChangeStatus()
        {

            confirmedSignal.Visibility = System.Windows.Visibility.Hidden;

            if (Status == TransactionType.Pending)
            {
                lblText.Text = "... Pending";
                lblText.Foreground = (Brush)this.Resources["PendingColor"];
                rectangle.Stroke = (Brush)this.Resources["PendingColor"];
            }
            else if (Status == TransactionType.Invalid)
            {
                lblText.Text = "X  Invalid";
                lblText.Foreground = (Brush)this.Resources["InvalidColor"];
                rectangle.Stroke = (Brush)this.Resources["InvalidColor"];

            }
            else if (Status == TransactionType.Confirmed)
            {
                lblText.Text = "    Confirmed";
                lblText.Foreground = (Brush)this.Resources["ConfirmedColor"];
                confirmedSignal.Visibility = System.Windows.Visibility.Visible;
                
                rectangle.Stroke = (Brush)this.Resources["ConfirmedColor"];

            }
            else
            {
                lblText.Text = "No Status";
                lblText.Foreground = Brushes.Gray;
                rectangle.Stroke = Brushes.Gray;
            }
        }
	}
}