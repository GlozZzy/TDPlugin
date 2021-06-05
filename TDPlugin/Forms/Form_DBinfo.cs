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
        HandlerClass Hclass;
        public Form_DBinfo()
        {
            InitializeComponent();
            Hclass = new HandlerClass();
        }

        private void change_current_connection_from_textfile(object sender, EventArgs e)
        {
            if (tb_host.Text == "" || tb_port.Text == "" || tb_un.Text == "" || tb_ps.Text == "" || tb_namebd.Text == "")
            {
                MessageBox.Show("Fill in all the fields", "Error");
            }
            else
            {
                Hclass.set_dbinfo(tb_host.Text, tb_port.Text, tb_un.Text, tb_ps.Text, tb_namebd.Text);
                Close();
            }
        }

        private void get_current_connection_from_textfile(object sender, EventArgs e)
        {
            var DBinfo = Hclass.get_dbinfo();

            tb_host.Text = DBinfo[0];
            tb_port.Text = DBinfo[1];
            tb_un.Text = DBinfo[2];
            tb_ps.Text = DBinfo[3];
            tb_namebd.Text = DBinfo[4];
        }
    }
}
