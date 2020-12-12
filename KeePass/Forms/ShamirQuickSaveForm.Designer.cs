namespace KeePass.Forms
{
    partial class ShamirQuickSaveForm
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
            this.finishButton = new System.Windows.Forms.Button();
            this.thresholdCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.shareCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // finishButton
            // 
            this.finishButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.finishButton.Location = new System.Drawing.Point(660, 366);
            this.finishButton.Margin = new System.Windows.Forms.Padding(4);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(82, 28);
            this.finishButton.TabIndex = 15;
            this.finishButton.Text = "Finish";
            this.finishButton.UseVisualStyleBackColor = true;
            this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
            // 
            // thresholdCount
            // 
            this.thresholdCount.HideSelection = false;
            this.thresholdCount.Location = new System.Drawing.Point(349, 202);
            this.thresholdCount.Margin = new System.Windows.Forms.Padding(4);
            this.thresholdCount.Name = "thresholdCount";
            this.thresholdCount.Size = new System.Drawing.Size(127, 22);
            this.thresholdCount.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 205);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Threshold:";
            // 
            // shareCount
            // 
            this.shareCount.HideSelection = false;
            this.shareCount.Location = new System.Drawing.Point(349, 138);
            this.shareCount.Margin = new System.Windows.Forms.Padding(4);
            this.shareCount.Name = "shareCount";
            this.shareCount.Size = new System.Drawing.Size(127, 22);
            this.shareCount.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 138);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Shares:";
            // 
            // ShamirQuickSaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 554);
            this.Controls.Add(this.finishButton);
            this.Controls.Add(this.thresholdCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.shareCount);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ShamirQuickSaveForm";
            this.Text = "Save Shares As";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button finishButton;
        private System.Windows.Forms.TextBox thresholdCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox shareCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}