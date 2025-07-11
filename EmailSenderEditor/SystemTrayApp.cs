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
        private readonly string configPath = Path.Combine(Application.StartupPath, @"..\..\", "config.json");

        public SystemTrayApp()
        {
            trayIcon = new NotifyIcon
            {
                Icon = new Icon(Path.Combine(Application.StartupPath, @"..\", "EmailIcon.ico")),
                Text = "Email Sender",
                Visible = true
            };

            trayIcon.DoubleClick += (s, e) => RunEmailScript();

            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Edit Email Settings", null, (s, e) => ShowPropertiesForm());
            contextMenu.Items.Add("Run Email Script", null, (s, e) => RunEmailScript());
            contextMenu.Items.Add("Exit", null, (s, e) => Application.Exit());

            trayIcon.ContextMenuStrip = contextMenu;
        }

        public void RunEmailScript()
        {
            try
            {
                string pythonExe = Path.Combine(Application.StartupPath, @"..\..\", "EmailSender.exe");
                string pythonScript = Path.Combine(Application.StartupPath, @"..\..\", "EmailSender.py");

                if (!File.Exists(pythonExe))
                {
                    MessageBox.Show("EmailSender.exe not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Ensure config.json is in the correct directory
                if (!File.Exists(configPath))
                {
                    MessageBox.Show("config.json not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = pythonExe,
                    Arguments = $"\"{pythonScript}\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    WorkingDirectory = Path.GetDirectoryName(pythonExe) // Set working directory to match config.json location
                };

                using (Process process = new Process { StartInfo = startInfo })
                {
                    process.Start();
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (!string.IsNullOrEmpty(output))
                        MessageBox.Show("Output: " + output, "Python Script Output");
                    if (!string.IsNullOrEmpty(error))
                        MessageBox.Show("Error: " + error, "Python Script Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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