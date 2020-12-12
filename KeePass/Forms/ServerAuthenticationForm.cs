using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//======================================================================================
//
//        filename : ServerAuthenticationForm.cs
//        description : This WinForm is used for server authentication. 
//                      User has to enter PIN shown on KeePass-server to this window.
//        created by Erni Gao at  Nov 2020
//   
//======================================================================================

namespace KeePass.Forms
{
    public partial class ServerAuthenticationForm : Form
    {
        byte[] hashedSK = null;  //hashed public key get from main form
        private int count = 0;   // number of times of wrong pin entries
        public ServerAuthenticationForm(byte[] hashedKey)
        {
            InitializeComponent();
            if (hashedSK == null)
            {
                hashedSK = hashedKey;
            }
        }

        /// <summary>
        /// get pin entered by end user
        /// </summary>
        /// <returns></returns>
        private string getPin()
        {
            return pinTxt.Text;
        }

        /// <summary>
        /// check the correctness of pin entry when clicking confirm button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirm_btn_Click(object sender, EventArgs e)
        {
            string pin = getPin();
            string hashResult = Convert.ToBase64String(hashedSK).Substring(0, 6);
            if (pin.Trim() == hashResult)
            {
                hashedSK = null;
                this.Close();
            }
            else
            {
                count += 1;
                label1.Text = "PIN is incorrect. Please retry";
                label1.ForeColor = Color.Red;
                pinTxt.Clear();
                if (count > 4)
                {
                    Application.ExitThread();
                }
            }
        }
    }
}
