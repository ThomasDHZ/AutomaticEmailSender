namespace EmailSenderEditor
{
    partial class PropertiesForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.UpdateEmailConfig = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SenderEmailText = new System.Windows.Forms.TextBox();
            this.ApiKeyText = new System.Windows.Forms.TextBox();
            this.MessageText = new System.Windows.Forms.TextBox();
            this.SubjectText = new System.Windows.Forms.TextBox();
            this.ReceiverText = new System.Windows.Forms.TextBox();
            this.RunEmailScript = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // UpdateEmailConfig
            // 
            this.UpdateEmailConfig.Location = new System.Drawing.Point(34, 230);
            this.UpdateEmailConfig.Name = "UpdateEmailConfig";
            this.UpdateEmailConfig.Size = new System.Drawing.Size(180, 40);
            this.UpdateEmailConfig.TabIndex = 0;
            this.UpdateEmailConfig.Text = "Update Email Config";
            this.UpdateEmailConfig.UseVisualStyleBackColor = true;
            this.UpdateEmailConfig.Click += new System.EventHandler(this.UpdateEmailConfig_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sender Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "API Key:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Receiver Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Subject:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Message:";
            // 
            // SenderEmailText
            // 
            this.SenderEmailText.Location = new System.Drawing.Point(180, 15);
            this.SenderEmailText.Name = "SenderEmailText";
            this.SenderEmailText.Size = new System.Drawing.Size(280, 26);
            this.SenderEmailText.TabIndex = 6;
            // 
            // ApiKeyText
            // 
            this.ApiKeyText.Location = new System.Drawing.Point(180, 180);
            this.ApiKeyText.Name = "ApiKeyText";
            this.ApiKeyText.Size = new System.Drawing.Size(280, 26);
            this.ApiKeyText.TabIndex = 10;
            this.ApiKeyText.Enter += new System.EventHandler(this.ApiKeyText_Enter);
            this.ApiKeyText.Leave += new System.EventHandler(this.ApiKeyText_Leave);
            // 
            // MessageText
            // 
            this.MessageText.Location = new System.Drawing.Point(180, 140);
            this.MessageText.Name = "MessageText";
            this.MessageText.Size = new System.Drawing.Size(280, 26);
            this.MessageText.TabIndex = 7;
            // 
            // SubjectText
            // 
            this.SubjectText.Location = new System.Drawing.Point(180, 97);
            this.SubjectText.Name = "SubjectText";
            this.SubjectText.Size = new System.Drawing.Size(280, 26);
            this.SubjectText.TabIndex = 8;
            // 
            // ReceiverText
            // 
            this.ReceiverText.Location = new System.Drawing.Point(180, 60);
            this.ReceiverText.Name = "ReceiverText";
            this.ReceiverText.Size = new System.Drawing.Size(280, 26);
            this.ReceiverText.TabIndex = 9;
            // 
            // RunEmailScript
            // 
            this.RunEmailScript.Location = new System.Drawing.Point(280, 230);
            this.RunEmailScript.Name = "RunEmailScript";
            this.RunEmailScript.Size = new System.Drawing.Size(180, 40);
            this.RunEmailScript.TabIndex = 0;
            this.RunEmailScript.Text = "Run Email Script";
            this.RunEmailScript.UseVisualStyleBackColor = true;
            this.RunEmailScript.Click += new System.EventHandler(this.RunEmailScript_Click);
            // 
            // PropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.ReceiverText);
            this.Controls.Add(this.SubjectText);
            this.Controls.Add(this.MessageText);
            this.Controls.Add(this.ApiKeyText);
            this.Controls.Add(this.SenderEmailText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RunEmailScript);
            this.Controls.Add(this.UpdateEmailConfig);
            this.Name = "PropertiesForm";
            this.Text = "Email Sender";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button UpdateEmailConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SenderEmailText;
        private System.Windows.Forms.TextBox ApiKeyText;
        private System.Windows.Forms.TextBox MessageText;
        private System.Windows.Forms.TextBox SubjectText;
        private System.Windows.Forms.TextBox ReceiverText;
        private System.Windows.Forms.Button RunEmailScript;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}