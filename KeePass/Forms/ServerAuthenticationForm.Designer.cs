namespace KeePass.Forms
{
    partial class ServerAuthenticationForm
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
            this.confirm_btn = new System.Windows.Forms.Button();
            this.pinTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // confirm_btn
            // 
            this.confirm_btn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirm_btn.Location = new System.Drawing.Point(541, 195);
            this.confirm_btn.Name = "confirm_btn";
            this.confirm_btn.Size = new System.Drawing.Size(104, 48);
            this.confirm_btn.TabIndex = 11;
            this.confirm_btn.Text = "confirm";
            this.confirm_btn.UseVisualStyleBackColor = true;
            this.confirm_btn.Click += new System.EventHandler(this.confirm_btn_Click);
            // 
            // pinTxt
            // 
            this.pinTxt.Location = new System.Drawing.Point(188, 203);
            this.pinTxt.Name = "pinTxt";
            this.pinTxt.Size = new System.Drawing.Size(287, 28);
            this.pinTxt.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(185, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(398, 28);
            this.label1.TabIndex = 9;
            this.label1.Text = "Please enter PIN shown in Server";
            // 
            // ServerAuthenticationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 473);
            this.ControlBox = false;
            this.Controls.Add(this.confirm_btn);
            this.Controls.Add(this.pinTxt);
            this.Controls.Add(this.label1);
            this.Name = "ServerAuthenticationForm";
            this.Text = "ServerAuthenticationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button confirm_btn;
        private System.Windows.Forms.TextBox pinTxt;
        private System.Windows.Forms.Label label1;
    }
}