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
using Dropbox.Api.Files.Routes;
using Dropbox.Api.Files;
using System.IO;

namespace securefilecloudproject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string access_token = "zNVy2T_XM4AAAAAAAAADEHQiKkPrgIctAfHqfd89DbTqwFMilap_z2a5z_zF23Ty";

        private async  void Form2_Load(object sender, EventArgs e)
        {
            DropboxClient client = new DropboxClient(access_token);
            ListFolderResult result = await client.Files.ListFolderAsync("");
            IEnumerable<Metadata> myfiles = result.Entries;
            List<object> fnames = new List<object>();
            foreach (var item in myfiles)
            {
                fnames.Add(item.Name);
            }
                listBox1.Items.AddRange(fnames.ToArray());
                
            
             

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
           if(listBox1.SelectedItems .Count ==0)
           {
               MessageBox.Show("please select a file");
           }
            else
           {
               string filename = listBox1.SelectedItems[0].ToString();
               DropboxClient client = new DropboxClient(access_token);
               var  filedata = await client.Files.DownloadAsync("/" + filename);
               Stream fout = await filedata.GetContentAsStreamAsync();
               byte[] buffer = new byte[10000];
               long filesize = fout.Length;
                 FileStream fs=  new FileStream(@"F:\MYWORK\" + filename, FileMode.Create);
               long downloadcount = 0;
               while (true)
               {
                   int r = fout.Read(buffer, 0, buffer.Length);
                   fs.Write(buffer, 0, r);
                   if (r == 0)
                   {
                       break;
                   }
                   downloadcount += r;
                   int pre = (int)(downloadcount /filesize) * 100;
                   await Task.Delay(100);
                   progressBar1.Value = pre;
               }
                   fout.Close();
                   fout.Dispose();
                   fs.Close();
                   fs.Dispose();
                   button1.Text = "file download";
               
           }
        }
    } 
}
        