using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using KeePass.NetworkUtil;
//=======================================================================================
//
//        filename : RemoteControlForm.cs
//        description : this is the home page for all network functions. 
//                      You can use transfer, retrieval & delete functions in this page
//        created by Erni Gao at  Nov 2020
//   
//=======================================================================================

namespace KeePass.Forms
{
    public partial class RemoteControlForm : Form
    {
        private const string CLIENTID = "clientA";  //client id
        private const int MAXLEN = 1024 * 1024 * 3; //max length of data received from KeePass-server at a time

        //message header
        private const byte CIDH = 0;   //client id
        private const byte CKEYH = 1;  //client public key
        private const byte SKEYH = 2;  //server public key
        private const byte SHAREH = 3;  //one share of KeePass password database
        private const byte REQUESTH = 4;   //request share list
        private const byte LISTH = 5;   //list of all shares held in server
        private const byte SELECTEDSHAREH = 6;  //select one share stored in server
        private const byte RETRIEVEH = 61;  //retrieve a selected share
        private const byte DELETEH = 62;    //delete a selected share

        //step header
        private const byte STEP0H = 0;
        private const byte STEP1H = 1;
        private const byte STEP2H = 2;
        private const byte STEP3H = 3;
        private const byte STEP4H = 4;
        private const byte STEP5H = 5;
        private const byte STEP6H = 6;

        private Socket socketSender;  //socket that is used to send message to KeePass-server
        private byte[] serverPublicKey; //server's public key
        private byte[] commonKey;   //common key for client and server that will be used to encrypt/decrypt data
        private string selectPath;  //path of selected share that will be send to KeePass-server
        private string retrievalPath;   //path that will be used to store the share retrieved from server
        private string selectedShare;   //the share that is selected in the drop down list

        public RemoteControlForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cancel the check for cross thread calls when loading form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoteControlForm_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// establish TCP/IP connection when clicking "connection" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //get KeePass-server's ip adddress that it will connect to
            IPAddress ip = IPAddress.Parse(txtIP.Text);
            IPEndPoint endPoint = new IPEndPoint(ip, Convert.ToInt32(txtPort.Text));

            //create a socket for listening
            socketSender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socketSender.Connect(endPoint);
                byte[] buffer = ApiArray.addHeader(CIDH, STEP0H, System.Text.Encoding.UTF8.GetBytes(CLIENTID));
                socketSender.Send(buffer);
                showMessage(CLIENTID + " connects to KeePass-server successfully");

                string msgTitle = "Please use this Remote Control Panel for the following features:";
                showBoldMessage(msgTitle);
                string msg = "1. Click \"Select\" button to select a share and click \"Send\" button to send it to KeePass-server" + "\r\n"
                   + "2. Click \"Shares\" button to show availabe shares on KeePass-server" + "\r\n"
                   + "3. Click \"Retrieve\" button to retrieve shares on KeePass-server" + "\r\n"
                   + "4. Click \"Delete\" button to delete shares on KeePass-server" + "\r\n";
                txtLog.AppendText(msg);

                //use another thread to receive data from server
                Thread th1 = new Thread(receive);
                th1.IsBackground = true;
                th1.Start();
            }
            catch
            {
            }
        }

        /// <summary>
        /// select share that will be sent to KeePass-server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileSelect_Click(object sender, EventArgs e)
        {
            //select a folder
            selectPath = ApiFile.selectFolder();
            //show selected share name on text log
            showMessage("Share " + Path.GetFileName(selectPath) + " has been seleted");
        }

        /// <summary>
        /// send selected share to KeePass-server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileSend_Click(object sender, EventArgs e)
        {
            //encrypt the share data that will be send to server
            commonKey = deriveCommonKey();
            byte[] buffer = ApiFile.readAllFiles(selectPath);
            byte[] encryptedBuffer = EncryptionScheme.saltedEncryption(buffer, commonKey);

            //add headers to encrypted data
            encryptedBuffer = ApiArray.addHeader(SHAREH, STEP3H, encryptedBuffer);

            txtLog.AppendText("Share " + Path.GetFileName(selectPath) + " has been send to KeePass-server successfully" + "\r\n");
            //showMessage("Share " + Path.GetFileName(selectPath) + " has been send to KeePass-server successfully");

            socketSender.Send(encryptedBuffer);

            //delect the share after this share is sent to server
            Directory.Delete(selectPath, true);
            //finish the send session and empty the common key
            commonKey = null;
            //empty the path that used to store selected share after the share send to server
            selectPath = null;
        }

        /// <summary>
        /// show the share names that are available on KeePass-server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShares_Click(object sender, EventArgs e)
        {
            // clear all share names previously listed in combo
            comboShares.Items.Clear();

            // common key used to decrypt data received from server
            commonKey = deriveCommonKey();

            //send request command to KeePass-server
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes("request shares");
            buffer = ApiArray.addHeader(REQUESTH, STEP3H, buffer);
            socketSender.Send(buffer);
        }

        /// <summary>
        /// retrieve one selected share from server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            if (commonKey == null) //client has to check share availability before retrieval
            {
                showBoldMessage("Please click the \"Shares\" button to get valid shares that can be retrieved from server");
            }
            else
            {
                //path used to store retrieved share
                retrievalPath = ApiFile.selectFolder();
                showMessage("Share " + selectedShare + " has been saved in " + retrievalPath);

                if (selectedShare == null)
                { 
                    //select one share before retrieve it 
                    showRedMessage("Please use drop down list to select a share that you will retrieve from server");
                }
                else
                {
                    //client encrypts selected share name and send it to server
                    byte[] buffer = EncryptionScheme.saltedEncryption(System.Text.Encoding.UTF8.GetBytes(selectedShare), commonKey);
                    buffer = ApiArray.addHeader(RETRIEVEH, buffer);
                    buffer = ApiArray.addHeader(SELECTEDSHAREH, STEP5H, buffer);
                    socketSender.Send(buffer);

                    //clear the selected share after the selected share name is sent to server
                    selectedShare = null;
                    //clear drop down list after the selected share name is sent to server
                    comboShares.Items.Clear();
                    comboShares.Text = "Please select a remote share";
                }

            }
        }

        /// <summary>
        /// delete a selected share that is stored in KeePass-server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (commonKey == null)
            { //client has to check share availability before delete it 
                showMessage("please click the \"Shares\" button to get valid shares that will be deleted in server");
            }
            else
            {
                if (selectedShare == null)
                {
                    //select one share before retrieve it 
                    showMessage("Please select a share that you will delete in server");
                }
                else
                {
                    //encrypt share name
                    byte[] buffer = EncryptionScheme.saltedEncryption(System.Text.Encoding.UTF8.GetBytes(selectedShare), commonKey);

                    // add header and send it to server
                    buffer = ApiArray.addHeader(DELETEH, buffer);
                    buffer = ApiArray.addHeader(SELECTEDSHAREH, STEP5H, buffer);
                    socketSender.Send(buffer);

                    comboShares.Items.Clear();
                    //empty common key after delete session ends
                    commonKey = null;
                    showMessage("Share " + selectedShare + " has been deleted successfully");
                    comboShares.Text = "Please select a remote share";
                }
            }
        }


        /// <summary>
        /// client receives data from server
        /// </summary>
        void receive()
        {
            try
            {
                while (true)
                {
                    //receive data from KeePass-server and store it in buffer
                    byte[] buffer = new byte[MAXLEN];
                    int len = socketSender.Receive(buffer);

                    if (len == 0) //break this loop when server cannot receive any data from client
                    {
                        break;
                    }

                    //seperate headers from data
                    byte msgHeader = buffer[0];
                    byte stepHeader = buffer[1];
                    byte[] data = new byte[len - 2];
                    Array.Copy(buffer, 2, data, 0, len - 2);

                    if (msgHeader == SKEYH && stepHeader == STEP2H)
                    {
                        //get KeePass-server public key
                        serverPublicKey = data;
                    }
                    else if (msgHeader == LISTH && stepHeader == STEP4H)
                    {  //show names of shares that are availabe in KeePass server

                        //get all share names and put it on drop down list
                        byte[] decryptedNames = EncryptionScheme.saltedDecryption(data, commonKey);
                        string shareNames = System.Text.Encoding.UTF8.GetString(decryptedNames);
                        showBoldMessage("Please use drop down list to select one share that is available from KeePass-server");
                        string[] nameList = shareNames.Split('-');
                        foreach (var name in nameList)
                        {
                            comboShares.Items.Add(name);
                        }
                    }
                    else if (msgHeader == SHAREH && stepHeader == STEP6H)
                    {
                        // decrypted data received from KeePass-server and save it locally 
                        byte[] decryptedContent = EncryptionScheme.saltedDecryption(data, commonKey);
                        ApiFile.writeAllFiles(retrievalPath, decryptedContent);

                        //empty the path that will be used to store the share retrieved from server
                        retrievalPath = null;
                        //empty the common key after this retrieval session
                        commonKey = null;
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// use Diffie Hellman to derive common key used for encryption & decryption
        /// </summary>
        /// <returns>a common key used for AES encryption & decryption</returns>
        private byte[] deriveCommonKey()
        {
            //generate public key
            ECDiffieHellmanCng ecd;
            byte[] clientPublicKey;
            EncryptionScheme.publicKeyGenerator(out ecd, out clientPublicKey);

            txtLog.Clear();

            //use hashed public key for client authentication
            byte[] hashed_CK = new MD5CryptoServiceProvider().ComputeHash(clientPublicKey);
            string msg = "Please enter " + Convert.ToBase64String(hashed_CK).Substring(0, 6) + " in server for authentication";
            showRedMessage(msg);

            //send public key to KeePass-server
            byte[] buffer = ApiArray.addHeader(CKEYH, STEP1H, clientPublicKey);
            socketSender.Send(buffer);

            byte[] key;
            while (true) //wait until KeePass receives server's public key
            {
                System.Threading.Thread.Sleep(1000);
                if (serverPublicKey != null)
                {
                    //use hashed public key for server authentication
                    byte[] hashed_SK = new MD5CryptoServiceProvider().ComputeHash(serverPublicKey);
                    ServerAuthenticationForm saForm = new ServerAuthenticationForm(hashed_SK);
                    saForm.ShowDialog();

                    //use both server's key and client's key to derive their common key
                    key = EncryptionScheme.deriveCommonKey(ecd, serverPublicKey);

                    break;
                }
            }

            //empty public key after common key is derived
            serverPublicKey = null;
            return key;
        }

        /// <summary>
        /// show messages on text box
        /// </summary>
        /// <param name="str">messages that will be shown on message log</param>
        void showMessage(string str)
        {
            txtLog.Text += str + "\n";
            Application.DoEvents();
        }

        /// <summary>
        /// show messages on text box with bold font
        /// </summary>
        /// <param name="str">messages that will be shown on message log</param>
        void showBoldMessage(string str)
        {
            int index = txtLog.Text.Length;
            txtLog.Select(index, str.Length);
            txtLog.SelectionColor = Color.Black;
            txtLog.SelectionFont = new Font(FontFamily.GenericMonospace, 12, FontStyle.Bold);
            txtLog.AppendText(str + "\r\n");
            Application.DoEvents();

        }
        /// <summary>
        /// show messages in red colour on text box
        /// </summary>
        /// <param name="str">messages that will be shown on message log</param>
        void showRedMessage(string str)
        {
            int index = txtLog.Text.Length;
            txtLog.Select(index, str.Length);
            txtLog.SelectionColor = Color.Red;
            Font font = new Font(FontFamily.GenericMonospace, 12, FontStyle.Bold);
            txtLog.SelectionFont = font;
            txtLog.AppendText(str + "\r\n");
            Application.DoEvents();

        }

        /// <summary>
        /// get selected item in combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboShares_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedShare = comboShares.SelectedItem.ToString();
        } 
    }
}
