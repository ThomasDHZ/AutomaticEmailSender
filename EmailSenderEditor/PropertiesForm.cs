using System;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace EmailSenderEditor
{
    public partial class PropertiesForm : Form
    {
        private readonly SystemTrayApp trayApp;

        public PropertiesForm(SystemTrayApp trayApp)
        {
            InitializeComponent();
            this.trayApp = trayApp;

            try
            {
                string jsonContent = File.ReadAllText("..\\..\\config.json");
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
            trayApp.RunEmailScript();
        }

        private void UpdateEmailConfig_Click(object sender, EventArgs e)
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
                File.WriteAllText("..\\..\\config.json", jsonContent);
                MessageBox.Show("Message Settings Updated.", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
            }
        }

        private void ApiKeyText_Enter(object sender, EventArgs e)
        {
            ApiKeyText.UseSystemPasswordChar = false;
        }

        private void ApiKeyText_Leave(object sender, EventArgs e)
        {
            ApiKeyText.UseSystemPasswordChar = true;
        }
    }
}