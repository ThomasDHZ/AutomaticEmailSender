using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EmailSenderEditor
{
    public class SystemTrayApp : IDisposable
    {
        private NotifyIcon trayIcon;
        private ContextMenuStrip contextMenu;
        public static string configPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\EmailSender\config.json";

        public SystemTrayApp()
        {
            trayIcon = new NotifyIcon
            {
                Icon = new Icon(Path.Combine(Application.StartupPath, "EmailIcon.ico")),
                Text = "Email Sender",
                Visible = true
            };

            trayIcon.DoubleClick += (s, e) =>
            {
                string pythonExe = Path.Combine(Application.StartupPath, "EmailSender.exe");
                string pythonScript = Path.Combine(Application.StartupPath, "EmailSender.py");
                string scriptArguments = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\EmailSender\config.json";
                ScriptRunner.RunEmailScript(pythonExe, pythonScript, scriptArguments);
            };

            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Edit Email Settings", null, (s, e) => ShowPropertiesForm());
            contextMenu.Items.Add("Exit", null, (s, e) => Application.Exit());
            contextMenu.Items.Add("Run Email Script", null, (s, e) =>
            {
                string pythonExe = Path.Combine(Application.StartupPath, "EmailSender.exe");
                string pythonScript = Path.Combine(Application.StartupPath, "EmailSender.py");
                string scriptArguments = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\EmailSender\config.json";
                ScriptRunner.RunEmailScript(pythonExe, pythonScript, scriptArguments);
            });

            trayIcon.ContextMenuStrip = contextMenu;
        }

        public void ShowPropertiesForm()
        {
            FormCollection forms = Application.OpenForms;
            foreach (Form form in forms)
            {
                if (form is PropertiesForm propertiesForm)
                {
                    propertiesForm.RestoreForm();
                    return;
                }
            }

            PropertiesForm newForm = new PropertiesForm(this);
            newForm.Show();
        }

        public void Dispose()
        {
            trayIcon.Visible = false;
            trayIcon.Dispose();
            contextMenu.Dispose();
        }
    }
}