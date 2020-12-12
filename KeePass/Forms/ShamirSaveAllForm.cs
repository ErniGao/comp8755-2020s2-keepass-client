// Start of modification by B.L

using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace KeePass.Forms
{
    public partial class ShamirSaveAllForm : Form
    {
        int shares, threshold;

        public ShamirSaveAllForm()
        {
            InitializeComponent();
        }

        //add a location to the box
        private void addButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!listBox1.Items.Contains(folderBrowserDialog1.SelectedPath))
                listBox1.Items.Add(folderBrowserDialog1.SelectedPath);
            }
        }

        public string[] GetLocations()
        {
            return listBox1.Items.Cast<String>().ToArray();
        }

        //remove a location to the box
        private void removeButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                for (int i = listBox1.SelectedItems.Count - 1; i >= 0; i--)
                {
                    listBox1.Items.Remove(listBox1.SelectedItems[i]);
                }
            }
        }

        private void finishButton_Click(object sender, EventArgs e)
        {
            shares = Convert.ToInt16(shareCount.Text);
            threshold = Convert.ToInt16(thresholdCount.Text);
            
            if (GetLocations().Length != shares)
            {
                throw new InvalidOperationException("The number of locations supplied is not equal to the number of shares!");
            }
            else if (this.shares < this.threshold)
            {
                throw new InvalidOperationException("The threshold must be lower than the number of distributed shares!");
            }
        }

        public int GetShares()
        {
            return this.shares;
        }

        public int GetThreshold()
        {
            return this.threshold;
        }
    }
}

// End of modification by B.L