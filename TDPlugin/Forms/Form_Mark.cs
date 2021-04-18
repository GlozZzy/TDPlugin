using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TDPlugin.Forms
{
    public partial class Form_Mark : Form
    {
        BD_manager bd;

        public Form_Mark()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] BDinfo = new string[5];
            using (StreamReader sr = new StreamReader("CurBDInfo.txt", Encoding.Default))
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    BDinfo[i] = line;
                    i++;
                }
            }

            bd = new BD_manager(BDinfo[0], BDinfo[1], BDinfo[2], BDinfo[3], BDinfo[4]);

            if (bd.search_exist_nametd(namemarkTB.Text))
                bd.add_new_record_comment(namemarkTB.Text, (int)num_val.Value, commentTB.Text);
            else
                bd.add_new_record_td(namemarkTB.Text, (int)num_val.Value, commentTB.Text);
            bd.recount_avg_value(namemarkTB.Text);
            Close();
        }

        
    }
}
