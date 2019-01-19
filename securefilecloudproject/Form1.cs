using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dropbox.Api;
using Dropbox.Api.Users;
using Dropbox.Api.Files;
using System.IO;

namespace securefilecloudproject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public delegate void mydel();
        string access_token = "zNVy2T_XM4AAAAAAAAADEHQiKkPrgIctAfHqfd89DbTqwFMilap_z2a5z_zF23Ty";
        private async  void button1_Click(object sender, EventArgs e)
        {
            DropboxClient client = new DropboxClient(access_token );
            FullAccount faccount =await  client.Users.GetCurrentAccountAsync();
            MessageBox.Show("Account id :"+faccount .AccountId + Environment .NewLine +
                              "Country    :"+faccount .Country  + Environment .NewLine +
                              "Email      :"+faccount.Email  + Environment .NewLine +
                              "Name       :"+faccount.Name  );

 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DropboxClient client = new DropboxClient(access_token);
            progressBar1.Visible = true;
            DialogResult dialog = openFileDialog1.ShowDialog();
            string path = openFileDialog1.FileName ;
            Stream strm = File.OpenRead(@path);
            client.Files.BeginUpload("/one", null, true, null, false, strm, upload_completed, null);
        }
        private void upload_completed(IAsyncResult ar)
        {
            mydel del = updategui;
            if (ar.IsCompleted == true)
            {
                Invoke(del);
            }
        }
       private  void updategui()
        {
            progressBar1.Visible = false;
        }

       private void button3_Click(object sender, EventArgs e)
       {
           Form2 frm = new Form2();
           frm.Show ();
       }
    }
}
