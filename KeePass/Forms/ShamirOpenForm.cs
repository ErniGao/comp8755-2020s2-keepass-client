// Start of modification by B.L

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Numerics;

using KeePassLib.Shamir;

namespace KeePass.Forms
{
    public partial class ShamirOpenForm : Form
    {
        public ShamirOpenForm()
        {
            InitializeComponent();
        }
        private string path;
        private Boolean sharesSelected = false;

        private void finishButtonClick(object sender, EventArgs e)
        {
            string[] shares = GetConfigFiles();
        }

        public void Merge(string[] shares, string location)
        {
            try
            {
                Part[][] parts = new Part[shares.Length][];
                int rem = 0;
                for (int i = 0; i < shares.Length; i++)
                {
                    if (!string.IsNullOrEmpty(shares[i]))
                    {
                        byte[] lines = File.ReadAllBytes(shares[i]);
                        rem = Convert.ToInt16(lines[0]);
                        ulong xVal = Convert.ToUInt64(lines[1]);
                        if (rem > 0)
                            parts[i] = new Part[((lines.Length - 2) / 16) + 1];
                        else
                            parts[i] = new Part[(lines.Length - 2) / 16];
                        BigInteger x, y;
                        for (int j = 2, k = 0; j < lines.Length - rem; j = j + 16, k++)
                        {
                            y = new BigInteger(lines.Skip(j).Take(16).ToArray());
                            x = new BigInteger(xVal);
                            parts[i][k] = new Part(x, y);
                        }

                        if (rem > 0)
                        {
                            y = new BigInteger(lines.Skip(lines.Length - rem).Take(rem).ToArray());

                            x = new BigInteger(xVal);
                            parts[i][parts[i].Length - 1] = new Part(x, y);
                        }
                    }
                }
                ShamirMerge sm = new ShamirMerge();
                BigInteger[] results = sm.Merge(parts, shares.Length);

                
                byte[] byteArray;
                byte[] tempArray;
                string path = location;
                try
                {
                    // delete existing file in this location if it exists
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                    //reconstruct the database file 
                    using (FileStream fs = File.Create(path))
                    {
                        for (int j = 0; j < results.Length; j++)
                        {
                            byteArray = results[j].ToByteArray();

                            if (j == results.Length - 1)
                                tempArray = new byte[rem];
                            else
                                tempArray = new byte[8];

                            if (rem == 0)
                                tempArray = new byte[8];

                            //Taking the min of 8 or arraylength to chop off padded 0
                            for (int i = 0; i < Math.Min(byteArray.Length, 8); i++)
                            {
                                tempArray[i] = byteArray[i];
                            }

                            fs.Write(tempArray, 0, tempArray.Length);
                        }
                    }
                }
                catch (Exception) {}
                this.path = path;
                sharesSelected = true;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("The share configuration files may be corrupt. Please try using shares from another device if possible",
                        "Invalid configuration or shares", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void share1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename1 = folderBrowserDialog1.SelectedPath;
                textBox1.Text = filename1;
            }
        }

        private void share2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename2 = folderBrowserDialog1.SelectedPath;
                textBox2.Text = filename2;
            }
        }

        private void share3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename3 = folderBrowserDialog1.SelectedPath;
                textBox3.Text = filename3;
            }
        }

        private void share4_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename4 = folderBrowserDialog1.SelectedPath;
                textBox4.Text = filename4;
            }
        }

        private void share5_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename5 = folderBrowserDialog1.SelectedPath;
                textBox5.Text = filename5;
            }
        }

        public string GetPath()
        {
            return path;
        }

        public Boolean SharesSelected()
        {
            return sharesSelected;
        }

        /// <summary>
        /// Get all config files in the specified locations
        /// </summary>
        /// <returns> A list of the config file locations </returns>
        ///
        public string[] GetConfigFiles()
        {
            var textList = new List<string>();
            string name = "\\config";
            if (!string.IsNullOrEmpty(textBox1.Text))
                textList.Add(textBox1.Text+name);
            if (!string.IsNullOrEmpty(textBox2.Text))
                textList.Add(textBox2.Text + name);
            if (!string.IsNullOrEmpty(textBox3.Text))
                textList.Add(textBox3.Text + name);
            if (!string.IsNullOrEmpty(textBox4.Text))
                textList.Add(textBox4.Text + name);
            if (!string.IsNullOrEmpty(textBox5.Text))
                textList.Add(textBox5.Text + name);
            string[] textArray = new string[textList.Count];
            int count = 0;
            foreach (string s in textList)
            {
                textArray[count++] = s;
            }
            return textArray;
        }
    } 
}

// End of modification by B.L