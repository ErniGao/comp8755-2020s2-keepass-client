namespace KeePass.Forms
{
    partial class ShamirOpenForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.share1 = new System.Windows.Forms.Button();
            this.share2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.share3 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.share4 = new System.Windows.Forms.Button();
            this.share5 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // finishButton
            // 
            this.finishButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.finishButton.Location = new System.Drawing.Point(590, 415);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(75, 23);
            this.finishButton.TabIndex = 0;
            this.finishButton.Text = "Finish";
            this.finishButton.UseVisualStyleBackColor = true;
            this.finishButton.Click += new System.EventHandler(this.finishButtonClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(87, 139);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(359, 20);
            this.textBox1.TabIndex = 1;
            // 
            // share1
            // 
            this.share1.Location = new System.Drawing.Point(484, 139);
            this.share1.Name = "share1";
            this.share1.Size = new System.Drawing.Size(75, 23);
            this.share1.TabIndex = 2;
            this.share1.Text = "share1";
            this.share1.UseVisualStyleBackColor = true;
            this.share1.Click += new System.EventHandler(this.share1_Click);
            // 
            // share2
            // 
            this.share2.Location = new System.Drawing.Point(484, 177);
            this.share2.Name = "share2";
            this.share2.Size = new System.Drawing.Size(75, 23);
            this.share2.TabIndex = 4;
            this.share2.Text = "share2";
            this.share2.UseVisualStyleBackColor = true;
            this.share2.Click += new System.EventHandler(this.share2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(87, 179);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(359, 20);
            this.textBox2.TabIndex = 3;
            // 
            // share3
            // 
            this.share3.Location = new System.Drawing.Point(484, 219);
            this.share3.Name = "share3";
            this.share3.Size = new System.Drawing.Size(75, 23);
            this.share3.TabIndex = 6;
            this.share3.Text = "share3";
            this.share3.UseVisualStyleBackColor = true;
            this.share3.Click += new System.EventHandler(this.share3_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(87, 221);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(359, 20);
            this.textBox3.TabIndex = 5;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(87, 296);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(359, 20);
            this.textBox5.TabIndex = 7;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(87, 257);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(359, 20);
            this.textBox4.TabIndex = 8;
            // 
            // share4
            // 
            this.share4.Location = new System.Drawing.Point(484, 257);
            this.share4.Name = "share4";
            this.share4.Size = new System.Drawing.Size(75, 23);
            this.share4.TabIndex = 9;
            this.share4.Text = "share4";
            this.share4.UseVisualStyleBackColor = true;
            this.share4.Click += new System.EventHandler(this.share4_Click);
            // 
            // share5
            // 
            this.share5.Location = new System.Drawing.Point(484, 293);
            this.share5.Name = "share5";
            this.share5.Size = new System.Drawing.Size(75, 23);
            this.share5.TabIndex = 10;
            this.share5.Text = "share5";
            this.share5.UseVisualStyleBackColor = true;
            this.share5.Click += new System.EventHandler(this.share5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Please select up to 5 locations to open shares from ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(332, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "It doesn\'t matter which text boxes you use and they can be left empty";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(321, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "The only scheme that can be used is 5 shares and a threshold of 3";
            // 
            // ShamirOpenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.share5);
            this.Controls.Add(this.share4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.share3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.share2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.share1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.finishButton);
            this.Name = "ShamirOpenForm";
            this.Text = "Open Shares";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button finishButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button share1;
        private System.Windows.Forms.Button share2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button share3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button share4;
        private System.Windows.Forms.Button share5;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}