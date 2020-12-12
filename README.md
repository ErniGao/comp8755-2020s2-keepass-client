## Securing Network Communication in a Multi-factor Password Manager - KeePass

This program integrates secure network transmission with KeePass and a Shamir Secret Scheme has been integrated in by previous work. This program is based on this version of KeePass.

Shamir Secret Sharing is implemeted to split and reconstruction KeePass database. In current implementation, the database can be splitted into 5 pieces and at least 3 pieces are required to reconstruct this database. 

This project provides an online transmission to securely transfer some pieces of shares to a remote devices/ retrieve some pieces of shares from a remote device with two way authentication to guarantee the authenticity and security of data and 

Currently, user can **send a share** to remote device (i.e KeePass server), **retrieve a share** from remote device and **delete a share** stored in remote device.

## System Requirements

This program builds upon KeePass version 2.41 and it uses the version 4.6 of the .Net framework. 

All Windows operating systems later than Windows XP should support KeePass, and this program is tested under Windows10.

KeePass is also be able to run on Linux and MacOS systems using Mono to enable .Net functionality. But this modified version of KeePass has not been tested in these system.  

**Run this program:** 

run KeePass in comp8755-2020s2-keepass-client/Build/KeePass/Release

**Recompile this program:** 

Currently, KeePass has been successfully complied and you can simply click to run **release version** of KeePass. However, if you would like to recomplie the original code before running this program, you have to **strictly follow** steps below:

1. open KeePass.sln in visual studio

2. check .Net version

   - right click KeePass and click **Properties**  (*this procedure applies to KeePassLib and TriUtil as well*)

   ![设置.Net版本1](C:\Users\gaoer\Pictures\设置.Net版本1.png)

   - In Application section, Target Framework must be set to **.Net Framework 4.6** (*this procedure applies to KeePassLib and TriUtil as well*)

   ![设置.Net版本2_LI](C:\Users\gaoer\Pictures\设置.Net版本2_LI.jpg)

   - In Signing section, uncheck the **Sign the assembly** check box (*this procedure applies to KeePassLib and TriUtil as well*)

   ![设置.Net版本3_LI](C:\Users\gaoer\Pictures\设置.Net版本3_LI.jpg)

3. Delete all previously complied files in Release folder (it should locate in  comp8755-2020s2-keepass-client/Build/KeePass/Release)
4. Make sure that you recomplie the Release version by select "**Release**" in solution configuration

![设置.Net版本3_LI (2)](C:\Users\gaoer\Pictures\设置.Net版本3_LI (2).jpg)

5. Right click KeePass project to **Clean** and **Rebuild** KeePass Project. *This procedure should apply to KeePassLib Project and TrlUtil Project as well*.

**Notes**:

- .Net Framework4.6 requirement is caused by implementation of Shamir Secret Sharing in previous work. The secure network communication part has been tested to successfully work on .Net Framework4.8 as well. But reconstruction function in Shamir Secret Scheme will fail under .NetFramework4.8 even shares can be correctly transferred between KeePass and KeePass-server.
- All the warnning on start up are caused by the previous work, and they are not related to this project's own work.

## How to Use

This program does not modify existing fearures of KeePass, and you can refer to https://keepass.info/index.html for general KeePass functionalities.

To use the secret sharing functionalities built in previous project, there are additional options available in the file menu:

- ShamirOpen: 

  Allows the user to select a number of shares to use to reconstruct a KeePass Database (.kdbx) file. The number should be three in this implementation. In will then prompt the user for the password to the database if it is successfully constructed. This operation will attempt to give the user the most up-to-data database by opening all possible databases given the shares and merge them.

- ShamirSaveAll:

  Saves the database to n number of shares (should be 5 in this implementation)

  **Requires** a database to be open before using ShamirSaveAll function

- ShamirQuickSave:

  Saves the database as shares to the locations used to open the current database. This keeps a history of the previous shares for each location specified.    If there are different versions of databses on different sets of shares, the program will attempt to merge all databsesa that can be reconstructed to give the most updated password entries possbile. 

  **Requires** a database to be open before using ShamirQuickSave function.

To use network functionalities developed in this project, there is a "**RemoteControl**" option in the file menu which provides following functions:

- **Share Transfer**:

  1. click "**Select**" button to select one share that has been split using ShamirSaveAll function or ShamirQuickSave function and click "**Send**" button to send one share to KeePass-server

  2. Before the share successfully sent to KeePass-server, there is a **two-way authentication** procedure

     1) you have to first enter pin shown on KeePass to KeePass-server

     <img src="C:\Users\gaoer\Pictures\client_autentication.png" alt="client_autentication"  />

     > ​										*pin shown on KeePass*

     ![serverside_client authentication](C:\Users\gaoer\Pictures\serverside_client authentication.png)

     > ​										*pin entered in KeePass-server*
  >
  
  2) you then need to enter pin show on KeePass-server in KeePass
  
     ![server_authentication](C:\Users\gaoer\Pictures\server_authentication.png)
  
     > ​										*pin shown on KeePass-server*
  
     ![clientside_server_authentication](C:\Users\gaoer\Pictures\clientside_server_authentication.png)
  
     > ​										*pin entered in KeePass*

- Share Retrieve:

  1. Before you retrieve share from KeePass-server, you have to click "Shares" button to check share availability on KeePass-server 

     ![select_share](C:\Users\gaoer\Pictures\select_share.png)

  2. A two-way authentication mentioned above will be processed 

  3. Use drop down list to select one share that will be retrieved 

  4. Click "**Retrieve**" button to retrieve share

  5. You have to select a location to save share retrieved from KeePass-server and this share is ready to use for reconstruction.

- Share Delete:

  1. Before you delete share, you have to click "**Shares**" button to check share availability on KeePass-server 
  2. A two-way authentication mentioned above will be processed
  3. Use drop down list to select one share that will be deleted
  4. Click "**Delete**" button to delete share and KeePass-server will delete this share

Before utilizing these network functions, a private connction must be established between KeePass and KeePass-server by the following steps:

1. click listening button on **KeePass-server** to listen potential KeePass connections

![listen_function](C:\Users\gaoer\Pictures\listen_function.png)

2. use file menu and click "**RemoteControl**" option in KeePass

![remote_control](C:\Users\gaoer\Pictures\remote_control.png)

3. click "**Connect**" button to establish connection with KeePass-server and then all functions available for network communication will be listed in message box

![KeePass_connect](C:\Users\gaoer\Pictures\KeePass_connect.png)

4. Select a client in Client List in KeePass-server to choose which client KeePass-server will communicate to 

![Server-clientList](C:\Users\gaoer\Pictures\Server-clientList.png)

 **Notes:**

1. KeePass-server's current IP is set as 127.0.0.1, and you should reset KeePass-server's IP in KeePass when running KeePass and KeePass-server in different devices.
2. Network communication functions work indepenetly from Shamir Secret Sharing Scheme. Network communication functions to transfer shares between remote devices. You can still transfer, retrieve and delete shares from KeePass-server even any function in Shamir Secret Scheme fails. 
3. I have provided a sample splitted databse in **share folder** under root of KeePass. There are two pieces in KeePass (comp8755-2020s2-keepass-client/shares) and three pieces in KeePass-server (comp8755-2020s2-keepass-server/KeePassServer/bin/Release/clientA), but there is no complete database stored on neither KeePass nor KeePass-server. You can retrieve shares from KeePass-server directly and use it for reconstruction with master password "1234".
4. If you recompile the program, then the existing splits cannot be reconstructed through ShamirOpen function. If you would like to keep this database, please save the complete database first before recompile the program and resplit the database in the recomplied version of KeePass.

## Project Structure 

- **KeePass.NetworkUtil**

  - ApiArray.cs

    This is a utility class used to combine, slice arrays and add headers

  - ApiFile.cs

    This is a file utility class. It is used to read files in KeePass-server and load to byte array in a particular format and write particular format byte arrays into file system (formats depends on message structure specified by protocols)

  - EncryptionScheme.cs

    This is an encryption utility class implementing salted AES encryption and decryption and Diffie-Hellman Key exchange.

- **KeePass.Forms**

  - MainForm.cs

    This WinForm class is the home page of this project. In this page, you can get access to the menu to linking pages such as creating a new database, splitting an existing database, reconstructing  a database and communicating with a remote device.

  - RemoteControlForm.cs

    This is the home page for all network functions. In this page, you can connect to KeePass-server, send a share to KeePass-server, retrieve a share from KeePass-server and delete a share stored in KeePass-server

  - ServerAuthenticationForm.cs

    This WinForm is used for server authentication. User has to enter PIN shown on KeePass-server in this window.

Notes:

1. This project structure only presents network functionalities. Please see the code directory for the entire project structure.