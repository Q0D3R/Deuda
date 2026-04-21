using System;
using System.Collections.Generic;
using System.Text;

namespace Deuda.Components.Layout
{
    public partial class MainLayout
    {
        private DateTime lastSynced = DateTime.Now;
        private bool isSyncing = false;

        // You can call this when refreshing your Debt List
        public async Task TriggerSync()
        {
            isSyncing = true;
            await Task.Delay(1500); // Simulate network sync
            lastSynced = DateTime.Now;
            isSyncing = false;
        }
    }
}
