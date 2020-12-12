using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//======================================================================
//
//        filename : ApiFile.cs
//        description : This is a file utility class. 
//                      It is used to read and write data into file system
//        created by Erni Gao at  Nov 2020
//   
//======================================================================

namespace KeePass.NetworkUtil
{
    class ApiFile
    {
        /// <summary>
        /// select a folder in the file system
        /// </summary>
        /// <returns>path of the selected folder</returns>
        public static string selectFolder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            string path = "";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }
            return path;
        }

        /// <summary>
        /// read all files in a specified folder in a byte array
        /// </summary>
        /// <param name="path">path of a folder</param>
        /// <returns>all data in the folder</returns>
        public static byte[] readAllFiles(string path)
        {
            // read folder name
            byte[] buffer = Encoding.UTF8.GetBytes(Path.GetFileName(path));  // convert folder name to byte array
            buffer = ApiArray.addHeader((byte)buffer.Length, buffer);

            var files = Directory.GetFiles(path);
            int count = 0;
            foreach (var file in files)
            {
                //get the name of the file
                string fileName = Path.GetFileName(file);
                byte[] fileNameByte = System.Text.Encoding.UTF8.GetBytes(fileName);
                byte[] nameBuffer = ApiArray.addHeader((byte)fileNameByte.Length, fileNameByte);

                //get content of the file
                byte[] content = readFile(Path.Combine(path, fileName));  //get content of this file
                byte[] fileLen = BitConverter.GetBytes(content.Length);
                byte[] lengthBuffer = ApiArray.addHeader((byte)fileLen.Length, fileLen); // (length of content length byte array, content length byte arrary)

                //combine all data in a file
                byte[] oneFile = ApiArray.concatArray(nameBuffer, lengthBuffer);
                oneFile = ApiArray.concatArray(oneFile, content);
                buffer = ApiArray.concatArray(buffer, oneFile);
                count++;

            }

            //buffer = [No. of files, folderNameLen, foldername, (filenameLen, fileName, contentLen, content) * i]
            buffer = ApiArray.addHeader((byte)count, buffer);

            return buffer;
        }

        /// <summary>
        /// read a file into a byte array
        /// </summary>
        /// <param name="path">the path of this file</param>
        /// <returns>all data in the file</returns>
        private static byte[] readFile(string path)
        {
            byte[] buffer;
            using (FileStream fsRead = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                buffer = new byte[fsRead.Length];
                int r = fsRead.Read(buffer, 0, buffer.Length);
            }
            return buffer;
        }

        /// <summary>
        /// write all files in a folder to a particular directory
        /// </summary>
        /// <param name="select_path">the path that folder will be written to</param>
        /// <param name="buffer">all data of this folder in a byte array</param>
        public static void writeAllFiles(string select_path, byte[] buffer)
        {
            //get number of files in the folder
            int fileNum = buffer[0];

            //get folder name
            int folderNameLen = buffer[1]; //get length of folder send to server 
            byte[] newBuffer = new byte[buffer.Length - 2];  //folder name + all files data
            Array.Copy(buffer, 2, newBuffer, 0, newBuffer.Length);
            byte[] folderName;
            byte[] content;
            ApiArray.splitArray(newBuffer, folderNameLen, out folderName, out content);
            string folderNameString = Encoding.UTF8.GetString(folderName);

            //path that will be used to save all files
            string dir = Path.Combine(select_path, folderNameString); // path that will save all the files
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            //write all files
            for (int i = 1; i <= fileNum; i++)
            {
                // get file name
                int nameLen = content[0];
                byte[] fileName = new byte[nameLen];
                Array.Copy(content, 1, fileName, 0, nameLen);

                byte[] discard;
                byte[] contentLeft;
                ApiArray.splitArray(content, nameLen + 1, out discard, out contentLeft);
                content = contentLeft;

                //get file length
                int lenIndicator = content[0];
                byte[] fileLen = new byte[lenIndicator];
                Array.Copy(content, 1, fileLen, 0, lenIndicator);
                int fileLength = BitConverter.ToInt32(fileLen, 0);
                ApiArray.splitArray(content, lenIndicator + 1, out discard, out contentLeft);
                content = contentLeft;

                //write file 
                byte[] fileContent;
                ApiArray.splitArray(content, fileLength, out fileContent, out contentLeft);
                string path = Path.Combine(dir, System.Text.Encoding.UTF8.GetString(fileName));
                writeFile(path, fileContent);
                content = contentLeft;
            }
        }

        /// <summary>
        /// write a file in a specified directory
        /// </summary>
        /// <param name="path">path of the file to write</param>
        /// <param name="buffer">file data in byte array</param>
        public static void writeFile(string path, byte[] buffer)
        {
            using (FileStream fsWrite = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fsWrite.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
