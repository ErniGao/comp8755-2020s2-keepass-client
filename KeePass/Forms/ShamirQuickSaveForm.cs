// Start of modification by B.L

using System;
using System.Linq;
using System.Windows.Forms;

namespace KeePass.Forms
{
    public partial class ShamirQuickSaveForm : Form
    {
        int shares, threshold;
        public ShamirQuickSaveForm()
        {
            InitializeComponent();
        }
        
        private void finishButton_Click(object sender, EventArgs e)
        {
            shares = Convert.ToInt16(shareCount.Text);
            threshold = Convert.ToInt16(thresholdCount.Text);
        }
        
        public int GetThreshold()
        {
            return this.threshold;
        }
        
        public int GetShares()
        {
            return this.shares;
        }
    }
}

// End of modification by B.L