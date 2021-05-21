﻿using System;
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

        public Form_Mark()
        {
            InitializeComponent();

            BDinfo = new string[5];
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
            lab_db_connection.Text = BDinfo[4];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (filename.Text == "" || markname.Text == "" || comment.Text == "")
            {
                MessageBox.Show("Fill in all the fields", "Error");
            }
            else
            {
                bd = new DB_manager(BDinfo[0], BDinfo[1], BDinfo[2], BDinfo[3], BDinfo[4]);

                if (bd.check_connection())
                {
                    if (bd.search_exist_file(filename.Text))
                        if (bd.search_exist_mark(filename.Text, markname.Text))
                            bd.add_new_record_comment(filename.Text, markname.Text, comment.Text, BDinfo[2], 0);
                        else
                        {
                            bd.add_new_record_mark(filename.Text, markname.Text, 0);
                            bd.add_new_record_comment(filename.Text, markname.Text, comment.Text, BDinfo[2], 0);
                        }
                    else
                    {
                        bd.add_new_record_file(filename.Text);
                        bd.add_new_record_mark(filename.Text, markname.Text, 0);
                        bd.add_new_record_comment(filename.Text, markname.Text, comment.Text, BDinfo[2], 0);
                    }
                    comment.Text = "";
                    MessageBox.Show("Everything went well", "Successfully");
                }
                else
                {
                    MessageBox.Show("Some problems with db connection", "Error");
                }
            }
        }
    }
}
