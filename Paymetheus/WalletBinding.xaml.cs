﻿using Paymetheus.DaemonConnect;
using Paymetheus.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Paymetheus
{
    /// <summary>
    /// Interaction logic for WalletBinding.xaml
    /// </summary>
    public partial class WalletBinding : Page
    {
        private ConnectionWizard _connectionWizard { get; set; }

        public WalletBinding()
        {
            InitializeComponent();
            _connectionWizard = new ConnectionWizard();
        }


        private void ContinueClick(object sender, RoutedEventArgs e)
        {
            Navigator.Instance.NavigateTo(new FramePage());
        }
    }
}
