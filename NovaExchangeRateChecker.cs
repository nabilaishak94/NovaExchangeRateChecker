using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace NovaExchangeRateChecker
{
    partial class NovaExchangeRateChecker : ServiceBase
    {
        Controller con = new Controller();
        public NovaExchangeRateChecker()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
            con.init();
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
            con.Done();
        }
    }
}
