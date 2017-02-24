using Eneter.Messaging.EndPoints.Rpc;
using Eneter.Messaging.MessagingSystems.MessagingSystemBase;
using Eneter.Messaging.MessagingSystems.TcpMessagingSystem;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ARP_read02
{
    public partial class Form1 : MaterialForm
    {
        static Form1 formContext;
        IRpcFactory aFactory;
        IRpcService<IMyService> aService;
        public static int max_ip = 20;
        public static List<string> connected_hosts = new List<string>();
        public static string currentInputFile = null;
        
        public Form1()
        {


            aFactory = new RpcFactory();
            aService = aFactory.CreateSingleInstanceService<IMyService>(new MyService());
            // Use TCP for the communication.
            // You also can use other protocols e.g. WebSockets.
            IMessagingSystemFactory aMessaging = new TcpMessagingSystemFactory();

            IDuplexInputChannel anInputChannel =
                aMessaging.CreateDuplexInputChannel("tcp://192.168.1.102:8041/");

            // Attach the input channel to the RpcService and start listening.
            aService.AttachDuplexInputChannel(anInputChannel);
            //IS THIS SERVICE MULTITHREADED ?


            InitializeComponent();

            button2.Enabled = false;
            button3.Enabled = true;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            formContext = this; //don't run more than 1 instances of this form
        }

        private void pingBtn_Click(object sender, EventArgs e)
        {
            Pinger.PingUp();
        }

        private void fetchBtn_Click(object sender, EventArgs e)
        {
            connected_hosts.Clear();
            List<IPInfo> list = IPInfo.GetIPInfo();
            foreach (IPInfo host in list)
            {
                string mac = host.MacAddress;

                if (host.IPAddress.StartsWith("192.168") && !mac.StartsWith("ff"))
                {
                    if (!connected_hosts.Contains(mac))
                        connected_hosts.Add(mac);
                }
            }

            //display btn 
            label1.Text = "Connected:\n\n";

            foreach (string fill in connected_hosts)
                label1.Text += fill + "\n";
        }

        private void stopRPC_Click(object sender, EventArgs e)
        {
            if (aService.IsDuplexInputChannelAttached == true)
            {
                Console.WriteLine("Duplex Input channel was attached");
            }
            aService.DetachDuplexInputChannel();
            //if (!aService.IsDuplexInputChannelAttached == true)
            //{
            Console.WriteLine("Service Ended");
            // }
        }

        public static Form1 getFormContext()
        {
            return formContext;
            //return this;
        }

        public void updateConStatus(string mac)
        {
            this.conStatus.Text += mac;
        }

        private void setMaxIp_Click(object sender, EventArgs e)
        {
            Form2 testDialog = new Form2();

            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            testDialog.ShowDialog(this);
            testDialog.TextBox1.Text = max_ip + "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var FD = new System.Windows.Forms.OpenFileDialog();
            if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileToOpen = FD.FileName;
                materialLabel2.Text+= fileToOpen;
                currentInputFile = fileToOpen;

            }
        }

        private void EncryptTargetFile(string inputFile, string outputFile)
        {
            FileStream fs = null, fsIn = null;
            CryptoStream cs = null;

            try
            {
                //string encDecKey = textBox1.Text.ToString();
                string encDecKey = MyService.enKey;
                //override from textbox
                if (!textBox1.Text.ToString().Equals(""))
                {
                    encDecKey = textBox1.Text.ToString();
                }

                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(encDecKey);

                string targetFile = outputFile;
                fs = new FileStream(targetFile, FileMode.Create);

                RijndaelManaged RMOBJ = new RijndaelManaged();

                cs = new CryptoStream(fs,
                    RMOBJ.CreateEncryptor(key, key),
                    CryptoStreamMode.Write);

                fsIn = new FileStream(inputFile, FileMode.Open);

                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);


                fsIn.Close();
                cs.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                //fsIn.Close();
                // cs.Close();
                // fs.Close();
            }
            finally
            {
                if (fsIn != null)
                    fsIn.Close();
                if (cs != null)
                    cs.Close();
                if (fs != null)
                    fs.Close();
            }
        }


        

        private void button3_Click(object sender, EventArgs e)
        {
            
            
            
            
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            //copy the folder into source(encrypted) and sync the source with target
            //before copying the folder into source i will make an entry in fileVault about the current user and the filename in the source folder

            

            if (currentInputFile==null)
            {
                MessageBox.Show("Select Target File", "Error!");
                return;
            }

            //step 1 make entry in the vault


            string fileToCopy;

            string[] breakApartCurrFile = currentInputFile.Split('.');
            fileToCopy = breakApartCurrFile[0] + ".e" + breakApartCurrFile[1];

            string[] breakApartSlash = breakApartCurrFile[0].Split('\\');

            string uriInSafe = @"C:\Blink\Source\" + breakApartSlash[breakApartSlash.Length - 1];
            try
            {
                XDocument doc = XDocument.Load(@"C:\Users\sohan\onedrive\documents\visual studio 2015\Projects\ARP_read02\ARP_read02\assets\fileVault.xml");
                XElement root = new XElement("file");

                root.Add(new XAttribute("uriOutSafe", currentInputFile));
                root.Add(new XAttribute("uriInSafe", uriInSafe));
                root.Add(new XAttribute("user", MyService.macAddressForEncryption));

                //change mac address to something permanent during RPC
                //root.Add(new XAttribute("user", myMac));



                doc.Element("vault").Add(root);
                doc.Save(@"C:\Users\sohan\onedrive\documents\visual studio 2015\Projects\ARP_read02\ARP_read02\assets\fileVault.xml");

                
            }
            catch (Exception ex)
            {
                //return error messgae at RPC
                Console.WriteLine(ex.Message);
            }

            //string[] breakApartSlash[];

            

            EncryptTargetFile(currentInputFile, breakApartCurrFile[0]+".e"+breakApartCurrFile[1]);

            //delete the currentInputFile and move the encrypted file to source and sync source with target
            if (File.Exists(currentInputFile))
            {
                File.Delete(currentInputFile);
            }
            File.Move(fileToCopy, uriInSafe);
            File.Delete(fileToCopy);


            BlinkSyncLib.Sync sync = new BlinkSyncLib.Sync(@"C:\Blink\Target", @"C:\Blink\Source");
            sync.Start();
            sync = new BlinkSyncLib.Sync(@"C:\Blink\Source", @"C:\Blink\Target");
            sync.Start();
        }

        
    }

    public interface IMyService
    {
        string showIsConnected(string ip, int strength);
        string authenticate(string mac, string text);
        long sendPublicData(long b, long g, long A);
        string register(string mac, string pass);
        string[] getDirs(string dirname);
        string[] getFiles(string dirname);
        string toggleEncryption(string mac, int signal);
        string remoteRetrieve(string mac, string pass, string file);
        //string GetEcho(string text);
    }
    public class MyService : IMyService
    {
        private bool flag = true;
        private long y, B, kb;
        long maxg = 32768, max = 1000;
        static string keyBIN;
        public static string enKey;
        public static string macAddressForEncryption = null; //one mac id at a time
        int allowedEncryption = 0;
        static long power(long x, long y, long p)
        {
            long res = 1;      // Initialize result
            x = x % p;  // Update x if it is more than or equal to p
            while (y > 0)
            {
                if ((y & 1) == 1)  // If y is odd, multiply x with result
                    res = (res * x) % p;
                // y must be even now
                y = y >> 1; // y = y/2
                x = (x * x) % p;
            }
            return res;
        }

        public string remoteRetrieve(string mac, string pass,string file)
        {
            //this will be done using RPC

            //get mac from user during RPC
            //whhy mac? so that one user cant access other users files!
            // get pass from user during RPC
            //Form1 context = Form1.getFormContext();
            if (file.Equals(""))
            {
                return "Please select a file";
            }


            string result = clickDecryptOnClientOrServer(mac, pass, file);
            return result;
            //we decrypt via client side so currently it is decryptonclient
        }

        private string clickDecryptOnClientOrServer(string mac, string pass, string file)
        {

            //string[] breakApart = file.Split('.');

            DecryptTargetFile(file,file+".d" /*breakApart[0] + ".d" + breakApart[1]*/, pass, mac);

            return "Successfully exited remote call";
        }

        private void DecryptTargetFile(string inputFile, string outputFile, string pwd = @"myPass123", string mac = "")
        {

            FileStream fsOut = null, fs = null;
            CryptoStream cs = null;

            try
            {
                // string encDecKey = textBox1.Text.ToString();
                string encDecKey = decrypt(pwd);
                //here we take plain text pwd.. need to encrypt it before

                //override key from textbox

                //override disabled

                //if (!textBox1.Text.ToString().Equals(""))
                //{
                //    encDecKey = textBox1.Text.ToString();
               // }


                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(encDecKey);

                fs = new FileStream(inputFile, FileMode.Open);

                RijndaelManaged RMOBJ = new RijndaelManaged();

                cs = new CryptoStream(fs,
                    RMOBJ.CreateDecryptor(key, key),
                    CryptoStreamMode.Read);

                fsOut = new FileStream(outputFile, FileMode.Create);

                int data;
                while ((data = cs.ReadByte()) != -1)
                    fsOut.WriteByte((byte)data);

                fsOut.Close();
                cs.Close();
                fs.Close();

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error!");
                // fsOut.Close();
                // cs.Close();
                //fsCrypt.Close();
            }
            finally
            {
                if (fsOut != null)
                    fsOut.Close();
                if (cs != null)
                    cs.Close();
                if (fs != null)
                    fs.Close();
            }
        }







        public string toggleEncryption(string mac, int signal)
        {

            Form1 formCnt = Form1.getFormContext();
            if (allowedEncryption == 0 && signal == 1) //
            {
                formCnt.BeginInvoke(new MethodInvoker(delegate ()
                {
                    //formCnt.conStatus.Text = "Bob's key:" + kb;
                    formCnt.button2.Enabled = true;
                }));
                
                allowedEncryption = 1;
                macAddressForEncryption = mac;
                return "encstarted";
                
            }
            else if(allowedEncryption ==0 && signal == 0) //
            {
                //what if someone else sends 0
                return "alreadystopped";
                
            }else if(allowedEncryption ==1 && signal == 1) //
            {
                return "alreadyinuse";
            }else if(allowedEncryption ==1 && signal ==0)
            {
                //what if someone else posts signal 0

                allowedEncryption = 0;
                formCnt.BeginInvoke(new MethodInvoker(delegate ()
                {
                    Form1.getFormContext().button2.Enabled = false;
                }));
                
                return "encstopped";
            }
            return "stuff";
        }

        public string[] getDirs(string dirname)
        {
            if (dirname.Equals("xyzzyspoonshift1"))
            {
                return Directory.EnumerateDirectories(@"C:\Blink\Source").ToArray();
            }
            return Directory.EnumerateDirectories(dirname).ToArray();
        }

        public string[] getFiles(string dirname)
        {
            if (dirname.Equals("xyzzyspoonshift1"))
            {
                return Directory.EnumerateFiles(@"C:\Blink\Source").ToArray();
            }
            return Directory.EnumerateFiles(dirname).ToArray();
        }





        public string register(string mac, string pass)
        {
            try { 
            XDocument doc = XDocument.Load(@"C:\Users\sohan\onedrive\documents\visual studio 2015\Projects\ARP_read02\ARP_read02\assets\uAuth.xml");
            XElement root = new XElement("user");
               
            root.Add(new XAttribute("ip", mac));

            root.Add(new XAttribute("passkey", pass));

                

                doc.Element("users").Add(root);
                doc.Save(@"C:\Users\sohan\onedrive\documents\visual studio 2015\Projects\ARP_read02\ARP_read02\assets\uAuth.xml");

                return "Registration Successful";
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public long sendPublicData(long b, long g, long A)
        {

            Random r = new Random();
            y = r.Next() % (max);
            //System.out.println(" y =" + y);
            B = power(b, y, g);
            kb = maxg + power(A, y, g); //Bob's key
            keyBIN = Convert.ToString(kb, 2);

            Form1 form = Form1.getFormContext();
            form.BeginInvoke(new MethodInvoker(delegate ()
            {
                form.conStatus.Text = "Bob's key:" + kb;
            }));

            return B;
        }

        //dependency injection
        public string showIsConnected(string mac, int strength)
        {
            //if(connected_list.Contains(mac))
            Console.WriteLine(mac + " was connected");

            //one mac id at a time
            macAddressForEncryption = mac;

            Form1 form = Form1.getFormContext();
            form.BeginInvoke(new MethodInvoker(delegate ()
            {
                form.conStatus.Text = mac + " is connected, Strength:" + strength;
            }));
            //form.conStatus.Text += mac;
            return "Desktop App knows your presence";
        }
        public string authenticate(string mac, string text)
        {
            
            Console.WriteLine("This is the received encrypted text : "+ text);
            Form1 form = Form1.getFormContext();
            string status = decrypt(text); ;
            form.BeginInvoke(new MethodInvoker(delegate ()
            {

                form.conStatus.Text = status;
            }));
            //password = "tejpaltejpaltejp" is hardcoded




            var xdoc = XDocument.Load(@"C:\Users\sohan\onedrive\documents\visual studio 2015\Projects\ARP_read02\ARP_read02\assets\uAuth.xml");
            var parameters = xdoc.Descendants("user")
                                 .ToDictionary(p => (string)p.Attribute("ip"),
                                               p => (string)p.Attribute("passkey"));




            //var stage = parameters["SID_STAGE"];
            string pass;

            if (parameters.ContainsKey(mac))
            {
                pass = parameters[mac];
                Console.WriteLine("pass:"+pass);
            }else
            {
               // flag = true;
                return "Not Registered";
            }







            if (status.Equals(pass))//from db
            {
                //flag = true;
                return "Success";
            }
            else
            {
                //flag = true;
                return "Failure";
            }

        }

        public string decrypt(string cipher)
        {
            string msg = cipher;
            string dMsg = "";
            int[][] matrix = new int[4][];
            matrix[0] = new int[4];
            matrix[1] = new int[4];
            matrix[2] = new int[4];
            matrix[3] = new int[4];
            int[][] key = new int[4][];
            key[0] = new int[4];
            key[1] = new int[4];
            key[2] = new int[4];
            key[3] = new int[4];
            /* key[0] = new int[4] { 1, 0, 1, 1};
             key[1] = new int[4] { 0, 0, 1, 0 };
             key[2] = new int[4] { 1, 1, 1, 1 };
             key[3] = new int[4] { 0, 1, 1, 1 };*/

            //int keyMsg = (int)Math.Pow(9, 5);
            string binary = keyBIN;
            int index = 0;
            Console.WriteLine("Key Matrix");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    key[i][j] = (int)binary[index] - 48;
                    index++;
                }

            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(key[i][j] + " ");
                }
                Console.WriteLine();
            }

            int k = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (k < msg.Length)
                    {
                        matrix[i][j] = (int)msg[k];
                        Console.Write(msg[k] + ", ");
                        k += 1;
                    }
                }
                Console.WriteLine();
            }

            // Code for showing original matrix

            Console.WriteLine("Original Matrix");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }

            // Code for reverse column

            matrix = Transpose(matrix);

            matrix[0] = rotaterow(matrix[0], 1);
            matrix[1] = rotaterow(matrix[1], 2);
            matrix[2] = rotaterow(matrix[2], 3);
            matrix = Transpose(matrix);

            Console.WriteLine("Reverse Column Matrix");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }

            // Code for reverse row
            matrix[0] = rotaterow(matrix[0], 1);
            matrix[1] = rotaterow(matrix[1], 2);
            matrix[2] = rotaterow(matrix[2], 3);

            Console.WriteLine("Reverse Row Matrix");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }

            // Subtracting key
            Console.WriteLine("Subtracting Key");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    matrix[i][j] -= key[i][j];
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }

            //Original Matrix
            matrix = Transpose(matrix);
            Console.WriteLine("Original Matrix");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }

            //Printing the decrypted Message
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (matrix[i][j] == 42)
                        continue;
                    dMsg += (char)matrix[i][j];
                }
            }
            Console.WriteLine(dMsg);
            //code for automatic encryption key

            if (dMsg.Length == 8)
                enKey = dMsg;
            else if (dMsg.Length > 8)
                enKey = dMsg.Substring(0, 8);
            else
            {
                enKey = dMsg;
                while (enKey.Length < 8)
                {
                    enKey += dMsg;
                }
                enKey = enKey.Substring(0, 8);
            }
            return dMsg;
        }

        public static int[][] Transpose(int[][] matrix)
        {

            int[][] result = new int[4][];
            result[0] = new int[4];
            result[1] = new int[4];
            result[2] = new int[4];
            result[3] = new int[4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result[j][i] = matrix[i][j];
                }
            }

            return result;
        }

        public static int[] rotaterow(int[] arr, int no)
        {
            int temp = 0;
            while (no != 0)
            {
                temp = arr[3];
                arr[3] = arr[2];
                arr[2] = arr[1];
                arr[1] = arr[0];
                arr[0] = temp;
                no--;
            }
            return arr;
        }

        //public string GetEcho(string text)
        //{
        //   Console.WriteLine("Received text = {0}", text);

        //  return text;
        //        }
    }
}
