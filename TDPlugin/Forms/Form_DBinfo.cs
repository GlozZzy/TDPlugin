using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TDPlugin.Forms
{
    public partial class Form_DBinfo : Form
    {
        string[] BDinfo;
        public Form_DBinfo()
        {
            InitializeComponent();
        }

        private void change_current_connection_from_textfile(object sender, EventArgs e)
        {
            if (tb_host.Text == "" || tb_port.Text == "" || tb_un.Text == "" || tb_ps.Text == "" || tb_namebd.Text == "")
            {
                MessageBox.Show("Fill in all the fields", "Error");
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(@"..\..\Resources\CurBDinfo.txt", false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(tb_host.Text);
                    sw.WriteLine(tb_port.Text);
                    sw.WriteLine(tb_un.Text);
                    sw.WriteLine(tb_ps.Text);
                    sw.WriteLine(tb_namebd.Text);
                }
                Close();
            }
        }

        private void get_current_connection_from_textfile(object sender, EventArgs e)
        {
            BDinfo = new string[5];

            using (StreamReader sr = new StreamReader(@"..\..\Resources\CurBDinfo.txt", Encoding.Default))
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    BDinfo[i] = line;
                    i++;
                }
            }

            tb_host.Text = BDinfo[0];
            tb_port.Text = BDinfo[1];
            tb_un.Text = BDinfo[2];
            tb_ps.Text = BDinfo[3];
            tb_namebd.Text = BDinfo[4];

        }
    }
}
