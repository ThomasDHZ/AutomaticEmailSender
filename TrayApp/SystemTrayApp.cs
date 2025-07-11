using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace TrayApp
{
    public class SystemTrayApp : IDisposable
    {
        private NotifyIcon trayIcon;
        private ContextMenuStrip contextMenu;
        private Config config;
        private readonly string configPath = Path.Combine(Application.StartupPath, "config.json");

        public SystemTrayApp()
        {
            config = LoadConfig();
            trayIcon = new NotifyIcon
            {
                Icon = SystemIcons.Application,
                Text = "TrayApp",
                Visible = true,
            };
            trayIcon.DoubleClick += (s, e) => RunScript();

            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Edit Properties", null, (s, e) => ShowPropertiesForm());
            contextMenu.Items.Add("Exit", null, (s, e) => Application.Exit());

            trayIcon.ContextMenuStrip = contextMenu;
        }

        private Config LoadConfig()
        {
            try
            {
                if(File.Exists(configPath))
                {
                    string json = File.ReadAllText(configPath);
                    return JsonConvert.DeserializeObject<Config>(json);
                }
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
