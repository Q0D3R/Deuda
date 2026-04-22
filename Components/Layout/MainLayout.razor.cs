using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.IO;

namespace Deuda.Components.Layout
{
    public partial class MainLayout
    {
        public bool IsDark { get; set; }
        private bool IsOnline = true; // Default to true
        private bool IsSyncing = false;

        private DateTime LastSynced = DateTime.Now;
        private string? AppVersion;
        private string? BuildDate;

        [RequiresAssemblyFiles()]
        protected override void OnInitialized()
        {
            // Use this instead of Assembly.Location
            var path = AppContext.BaseDirectory;

            // Detect system theme
            IsDark = Application.Current.RequestedTheme == AppTheme.Dark;

            // Subscribe to the global system event
            Application.Current.RequestedThemeChanged += OnThemeChanged;

            // Get Version
            var assembly = Assembly.GetExecutingAssembly();
            AppVersion = assembly.GetName().Version?.ToString(3);
            BuildDate = assembly.GetName().Version?.ToString(3);

            // Get Build Date (Approximation based on file write time)
            var fileInfo = new System.IO.FileInfo(path);
            BuildDate = fileInfo.LastWriteTime.ToString("MMM dd, yyyy");

            // Simple Connection Check (Standard for Hybrid/Web)
            // In a real Hybrid app, you'd use Connectivity.Current.NetworkAccess from MAUI
            IsOnline = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }

        // You can call this when refreshing your Debt List
        public async Task TriggerSync()
        {
            IsSyncing = true;
            await Task.Delay(1500); // Simulate network sync
            LastSynced = DateTime.Now;
            IsSyncing = false;
        }

        private void OnThemeChanged(object? sender, AppThemeChangedEventArgs e)
        {
            // 3. Update state and trigger re-render on the UI thread
            InvokeAsync(() =>
            {
                IsDark = e.RequestedTheme == AppTheme.Dark;
                StateHasChanged();
            });
        }

        public void Dispose()
        {
            // Always unsubscribe to prevent memory leaks
            Application.Current.RequestedThemeChanged -= OnThemeChanged;
        }
    }
}
