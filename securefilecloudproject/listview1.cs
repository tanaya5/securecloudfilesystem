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
    public partial class listview1 : Form
    {
        public listview1()
        {
            InitializeComponent();
        }
        string access_token = "zNVy2T_XM4AAAAAAAAADEHQiKkPrgIctAfHqfd89DbTqwFMilap_z2a5z_zF23Ty";
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dlgresult = folderBrowserDialog1.ShowDialog();
            if(dlgresult ==DialogResult .OK )
            {
                string folderpath = folderBrowserDialog1.SelectedPath;
                DirectoryInfo di = new DirectoryInfo(folderpath);
                FileInfo[] files = di.GetFiles();
                foreach (FileInfo f in files )
                {
                    ListViewItem itm = new ListViewItem(f.Name);
                    itm.ImageIndex = 0;
                    listView2.Items.Add(itm);
                }
            }
        }
    }
}
