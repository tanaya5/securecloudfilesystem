using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Net.NetworkInformation;
using System.IO;


namespace securefilecloudproject
{
    public partial class encryptiondemo : Form
    {
        public encryptiondemo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputfile = @"F:\MYWORK\pic.jpg";
            string ext = Path.GetExtension(inputfile);
            string outputfile = inputfile.Replace(ext, "_enc" + ext);
            string password = "12345";
            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] bytedata = utf8.GetBytes(password);
            //generate hash code 
            MD5CryptoServiceProvider md5crypto = new MD5CryptoServiceProvider();
            byte[] key = md5crypto.ComputeHash(bytedata);
            FileStream fis = new FileStream (inputfile ,FileMode.Open );
            FileStream fout = new FileStream(outputfile, FileMode.Create);
            RijndaelManaged rjcrypto = new RijndaelManaged();
            CryptoStream cs = new CryptoStream(fout, rjcrypto.CreateEncryptor(key, key), CryptoStreamMode.Write);
            int data = 0;
            while ((data=fis.ReadByte ())!=-1)
            {
                cs.WriteByte((byte)data);

            }
            cs.Close();
            fout.Close();
            fis.Close();
            File.Delete(inputfile);
            File.Copy(outputfile, inputfile);
            File.Delete(outputfile);
            button1.Text = "done";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string inputfile = @"F:\MYWORK\pic.jpg";
            string ext = Path.GetExtension(inputfile);
            string outputfile = inputfile.Replace(ext, "_enc" + ext);
            string password = "12345";
            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] bytedata = utf8.GetBytes(password);
            //generate hash code 
            MD5CryptoServiceProvider md5crypto = new MD5CryptoServiceProvider();
            byte[] key = md5crypto.ComputeHash(bytedata);
            FileStream fis = new FileStream(inputfile, FileMode.Open);
            FileStream fout = new FileStream(outputfile, FileMode.Create);
            RijndaelManaged rjcrypto = new RijndaelManaged();
            CryptoStream cs = new CryptoStream(fis, rjcrypto.CreateDecryptor (key,key), CryptoStreamMode.Read );
            int data = 0;
            while ((data =cs.ReadByte()) != -1)
            {
                fout.WriteByte((byte)data);

            }
            cs.Close();
            fout.Close();
            fis.Close ();
            File.Delete(inputfile);
            File.Copy(outputfile, inputfile);
            File.Delete(outputfile);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send("www.google.com", 500);
                if(reply .Status ==IPStatus .Success )
                {

                }
                else
                {
                    MessageBox.Show("check internet");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
