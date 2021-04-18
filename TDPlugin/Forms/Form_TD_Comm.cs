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
    public partial class Form_TD_Comm : Form
    {
        BD_manager bd;

        int curr_td;
        int curr_comm;


        public Form_TD_Comm()
        {
            InitializeComponent();

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

            curr_td = 0;
            curr_comm = 0;

            var td = bd.get_TD(curr_td);
            lab_name.Text = td.name;

            if (td.val > -1) 
            {
                var comm = bd.get_comment(td.name, curr_comm);
                lab_val.Text = td.val.ToString();
                textBox_comm.Text = comm;
            }
            else 
            {
                lab_val.Text = "";
                textBox_comm.Text = "";
            }
        }

        private void but_td_del_Click(object sender, EventArgs e)
        {
            if (lab_name.Text != "")
            {
                bd.delete_record_td(lab_name.Text);
                but_td_pr_Click(sender, e);
            }
            //curr_td = 0;
            //curr_comm = 0;

            //var td = bd.get_TD(curr_td);
            //lab_name.Text = td.name;

            //if (td.val > -1)
            //{
            //    var comm = bd.get_comment(td.name, curr_comm);
            //    lab_val.Text = td.val.ToString();
            //    textBox_comm.Text = comm;
            //}
            //else
            //{
            //    lab_val.Text = "";
            //    textBox_comm.Text = "";
            //}
        }

        private void but_com_del_Click(object sender, EventArgs e)
        {
            if (textBox_comm.Text != "")
            {
                bd.delete_record_comment(lab_name.Text, textBox_comm.Text);
                but_com_pr_Click(sender, e);
            }
        }

        private void but_com_pr_Click(object sender, EventArgs e)
        {
            if (lab_name.Text != "")
            {
                curr_comm--;
                if (curr_comm < 0) curr_comm = 0;
                var comm = bd.get_comment(lab_name.Text, curr_comm);
                textBox_comm.Text = comm;
            }
        }

        private void but_com_next_Click(object sender, EventArgs e)
        {
            if (lab_name.Text != "")
            {
                if (textBox_comm.Text != "") curr_comm++;
                var comm = bd.get_comment(lab_name.Text, curr_comm);
                textBox_comm.Text = comm;
            }
        }

        private void but_td_pr_Click(object sender, EventArgs e)
        {
            curr_td--;
            if (curr_td < 0) curr_td = 0;
            var td = bd.get_TD(curr_td);
            lab_name.Text = td.name;
            

            if (td.val > -1)
            {
                curr_comm = 0;
                var comm = bd.get_comment(lab_name.Text, curr_comm);
                lab_val.Text = td.val.ToString();
                textBox_comm.Text = comm;
            }
            else
            {
                textBox_comm.Text = "";
                lab_val.Text = "";
            }
        }

        private void but_td_next_Click(object sender, EventArgs e)
        {
            if (lab_name.Text != "") curr_td++;
            var td = bd.get_TD(curr_td);
            lab_name.Text = td.name;

            if (td.val > -1)
            {
                curr_comm = 0;
                var comm = bd.get_comment(lab_name.Text, curr_comm);
                lab_val.Text = td.val.ToString();
                textBox_comm.Text = comm;
            }
            else
            {
                textBox_comm.Text = "";
                lab_val.Text = "";
            }
        }
    }
}
