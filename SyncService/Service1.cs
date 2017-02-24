using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SyncService
{
    public partial class Service1 : ServiceBase
    {
        public BlinkSyncLib.Sync sync;
        public Service1()
        {
            InitializeComponent();
            sync = new BlinkSyncLib.Sync(@"C:\Blink\Target", @"C:\Blink\Source");
        }

        protected override void OnStart(string[] args)
        {
            sync.Start();
        }

        protected override void OnStop()
        {
            sync.Start();
        }
    }
}
