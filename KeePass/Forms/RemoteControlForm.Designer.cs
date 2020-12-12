namespace KeePass.Forms
{
    partial class RemoteControlForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.btnShares = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnFileSend = new System.Windows.Forms.Button();
            this.btnFileSelect = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.comboShares = new System.Windows.Forms.ComboBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(50, 195);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(974, 298);
            this.txtLog.TabIndex = 25;
            this.txtLog.Text = "";
            // 
            // btnShares
            // 
            this.btnShares.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnShares.Location = new System.Drawing.Point(50, 115);
            this.btnShares.Name = "btnShares";
            this.btnShares.Size = new System.Drawing.Size(108, 43);
            this.btnShares.TabIndex = 24;
            this.btnShares.Text = "Shares";
            this.btnShares.UseVisualStyleBackColor = true;
            this.btnShares.Click += new System.EventHandler(this.btnShares_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConnect.Location = new System.Drawing.Point(916, 50);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(108, 43);
            this.btnConnect.TabIndex = 23;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnFileSend
            // 
            this.btnFileSend.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFileSend.Location = new System.Drawing.Point(916, 514);
            this.btnFileSend.Name = "btnFileSend";
            this.btnFileSend.Size = new System.Drawing.Size(108, 43);
            this.btnFileSend.TabIndex = 22;
            this.btnFileSend.Text = "Send";
            this.btnFileSend.UseVisualStyleBackColor = true;
            this.btnFileSend.Click += new System.EventHandler(this.btnFileSend_Click);
            // 
            // btnFileSelect
            // 
            this.btnFileSelect.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFileSelect.Location = new System.Drawing.Point(760, 514);
            this.btnFileSelect.Name = "btnFileSelect";
            this.btnFileSelect.Size = new System.Drawing.Size(108, 43);
            this.btnFileSelect.TabIndex = 21;
            this.btnFileSelect.Text = "Select";
            this.btnFileSelect.UseVisualStyleBackColor = true;
            this.btnFileSelect.Click += new System.EventHandler(this.btnFileSelect_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.Location = new System.Drawing.Point(916, 124);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(108, 43);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRetrieve.Location = new System.Drawing.Point(760, 124);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(108, 43);
            this.btnRetrieve.TabIndex = 19;
            this.btnRetrieve.Text = "Retrieve";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // comboShares
            // 
            this.comboShares.FormattingEnabled = true;
            this.comboShares.Location = new System.Drawing.Point(170, 124);
            this.comboShares.Name = "comboShares";
            this.comboShares.Size = new System.Drawing.Size(287, 26);
            this.comboShares.TabIndex = 18;
            this.comboShares.Text = "Please select a remote share";
            this.comboShares.SelectedIndexChanged += new System.EventHandler(this.comboShares_SelectedIndexChanged);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(463, 59);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(66, 28);
            this.txtPort.TabIndex = 17;
            this.txtPort.Text = "50000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(314, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 18);
            this.label2.TabIndex = 16;
            this.label2.Text = "Server Port No.";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(174, 59);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 28);
            this.txtIP.TabIndex = 15;
            this.txtIP.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Server IP:";
            // 
            // RemoteControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1089, 622);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnShares);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnFileSend);
            this.Controls.Add(this.btnFileSelect);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRetrieve);
            this.Controls.Add(this.comboShares);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label1);
            this.Name = "RemoteControlForm";
            this.Text = "Remote Control Panel";
            this.Load += new System.EventHandler(this.RemoteControlForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Button btnShares;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnFileSend;
        private System.Windows.Forms.Button btnFileSelect;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.ComboBox comboShares;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label1;
    }
}