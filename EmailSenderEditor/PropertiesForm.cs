using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace EmailSenderEditor
{
    public partial class PropertiesForm : Form
    {
        private readonly SystemTrayApp trayApp;
        public static string configPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\EmailSender\config.json";

        public PropertiesForm(SystemTrayApp trayApp)
        {
            InitializeComponent();
            this.trayApp = trayApp;

            try
            {
                string pythonExe = Path.Combine(Application.StartupPath, "ConfigWriter.exe");
                string pythonScript = Path.Combine(Application.StartupPath, "ConfigWriter.py");
                string scriptArguments = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\EmailSender\config.json";
                ScriptRunner.RunEmailScript(pythonExe, pythonScript, scriptArguments, true);

                if (!File.Exists(configPath))
                {
                    File.AppendAllText("debug.log", $"{DateTime.Now}: config.json not found at: {configPath}\n");
                    MessageBox.Show($"config.json not found at: {configPath}", "Error");
                    return;
                }

                string jsonContent = File.ReadAllText(configPath);
                JsonEmailModel model = JsonConvert.DeserializeObject<JsonEmailModel>(jsonContent);

                SenderEmailText.Text = model.senderEmail;
                ReceiverText.Text = model.recipientEmail;
                SubjectText.Text = model.subject;
                MessageText.Text = model.message;
                ApiKeyText.Text = model.senderPassword;

                ApiKeyText.UseSystemPasswordChar = true;
            }
            catch (Exception ex)
            {
                File.AppendAllText("debug.log", $"{DateTime.Now}: Error loading config: {ex.Message}\n");
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
            }

            this.FormClosing += (s, e) =>
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true;
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                    this.Hide();
                }
            };
        }

        public void RestoreForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void RunEmailScript_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateEmailConfigSettings();
                string pythonExe = Path.Combine(Application.StartupPath, "EmailSender.exe");
                string pythonScript = Path.Combine(Application.StartupPath, "EmailSender.py");
                string scriptArguments = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\EmailSender\config.json";
                ScriptRunner.RunEmailScript(pythonExe, pythonScript, scriptArguments);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateEmailConfig_Click(object sender, EventArgs e)
        {
            UpdateEmailConfigSettings();
            MessageBox.Show("Message Settings Updated.", "Success");
        }

        private void ApiKeyText_Enter(object sender, EventArgs e)
        {
            ApiKeyText.UseSystemPasswordChar = false;
        }

        private void ApiKeyText_Leave(object sender, EventArgs e)
        {
            ApiKeyText.UseSystemPasswordChar = true;
        }

        private void UpdateEmailConfigSettings()
        {
            try
            {
                string jsonContent = JsonConvert.SerializeObject(new JsonEmailModel()
                {
                    senderEmail = SenderEmailText.Text,
                    senderPassword = ApiKeyText.Text,
                    recipientEmail = ReceiverText.Text,
                    subject = SubjectText.Text,
                    message = MessageText.Text
                });
                File.WriteAllText(configPath, jsonContent);
            }
            catch (Exception ex)
            {
                File.AppendAllText("debug.log", $"{DateTime.Now}: Error saving config: {ex.Message}\n");
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
            }
        }
    }
}