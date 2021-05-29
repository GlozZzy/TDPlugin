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
using TDPlugin.Tools;

namespace TDPlugin.Forms
{
    public partial class Form_Mark : Form
    {
        IDBManager bd;
        string[] BDinfo;

        public int linefrom;
        public int lineto;

        public Form_Mark()
        {
            InitializeComponent();

            BDinfo = new string[5];
            using (StreamReader sr = new StreamReader(@"..\..\Resources\CurDBInfo.txt", Encoding.Default))
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    BDinfo[i] = line;
                    i++;
                }
            }
            lab_db_connection.Text = BDinfo[4];
        }

        private void button_accept_Click(object sender, EventArgs e)
        {
            if (filename.Text == "" || markname.Text == "" || comment.Text == "")
            {
                MessageBox.Show("Fill in all the fields", "Error");
            }
            else if (numericUpDownFrom.Value > numericUpDownTo.Value) MessageBox.Show("Incorrect lines range", "Error");
            else
            {
                bd = new DB_manager(BDinfo[0], BDinfo[1], BDinfo[2], BDinfo[3], BDinfo[4]);

                if (bd.check_connection())
                {
                    if (bd.search_exist_file(filename.Text))
                        if (bd.search_exist_issue(filename.Text, markname.Text))
                            bd.add_new_record_comment(filename.Text, markname.Text, comment.Text, BDinfo[2], 0);
                        else
                        {
                            bd.add_new_record_issue(filename.Text, markname.Text, 0, (int)numericUpDownFrom.Value, (int)numericUpDownTo.Value);
                            bd.add_new_record_comment(filename.Text, markname.Text, comment.Text, BDinfo[2], 0);
                        }
                    else
                    {
                        bd.add_new_record_file(filename.Text);
                        bd.add_new_record_issue(filename.Text, markname.Text, 0, (int)numericUpDownFrom.Value, (int)numericUpDownTo.Value);
                        bd.add_new_record_comment(filename.Text, markname.Text, comment.Text, BDinfo[2], 0);
                    }
                    comment.Text = "";
                    MessageBox.Show("For ease of use of the plugin, create comments between the marked lines", "The problem is noted.");
                }
                else
                {
                    MessageBox.Show("Some problems with db connection", "Error");
                }
                linefrom = (int)numericUpDownFrom.Value;
                lineto = (int)numericUpDownTo.Value;
            }
        }
    }
}
