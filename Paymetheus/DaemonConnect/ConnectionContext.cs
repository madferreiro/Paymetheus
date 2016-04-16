using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Paymetheus.DaemonConnect
{
    public class ConnectionContext
    {
        public Page InnerFrame { get; set; }
        public Page NextPage { get; set; }
        public string ErrorMessage { get; set; }

        public string NetworkAddress { get; set; }
        public string RpcUsername { get; set; }
        public string RpcPassword { get; set; }
        public string CertificateFilePath { get; set; }
    }
}
