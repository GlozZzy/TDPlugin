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
using TDPlugin.Tools;
using TDPlugin.DBclasses;

namespace TDPlugin.Forms
{
    public partial class Form_Statistic : Form
    {
        DB_manager bd;

        Filename file;
        Mark mark;
        Comment comm;

        int curr_file;
        int curr_mark;
        int curr_comm;

        string cur_filename;
        string cur_markname;

        public Form_Statistic()
        {
            InitializeComponent();
        }

        
        

        private void but_com_pr_Click(object sender, EventArgs e)
        {
            if (mark != null)
            {
                curr_comm--;
                if (curr_comm < 0) curr_comm = 0;
                comm = bd.get_comment(mark, curr_comm);
                if (comm == null) textBox_comm.Text = "";
                else textBox_comm.Text = comm.text;
            }
        }

        private void but_com_next_Click(object sender, EventArgs e)
        {
            if (mark != null)
            {
                if (textBox_comm.Text != "") curr_comm++;
                comm = bd.get_comment(mark, curr_comm);
                if (comm == null) textBox_comm.Text = "";
                else textBox_comm.Text = comm.text;
            }
        }




        private void but_mark_pr_Click(object sender, EventArgs e)
        {
            if (file != null)
            {
                curr_mark--;
                if (curr_mark < 0) curr_mark = 0;
                mark = bd.get_mark(file, curr_mark);

                if (mark != null)
                {
                    textBox_mark.Text = mark.name;
                    lab_mark_avg.Text = "" + mark.avg_val;
                    curr_comm = 0;
                    but_com_pr_Click(sender, e);
                }
                else
                {
                    comm = null;
                    textBox_mark.Text = "";
                    lab_mark_avg.Text = "";
                    textBox_comm.Text = "";
                }
            }
        }

        private void but_mark_next_Click(object sender, EventArgs e)
        {
            if (file != null)
            {
                if (mark != null) curr_mark++;
                mark = bd.get_mark(file, curr_mark);

                if (mark != null)
                {
                    textBox_mark.Text = mark.name;
                    lab_mark_avg.Text = "" + mark.avg_val;
                    curr_comm = 0;
                    but_com_pr_Click(sender, e);
                }
                else
                {
                    comm = null;
                    textBox_mark.Text = "";
                    lab_mark_avg.Text = "";
                    textBox_comm.Text = "";
                }
            }
        }




        private void but_file_pr_Click(object sender, EventArgs e)
        {
            curr_file--;
            if (curr_file < 0) curr_file = 0;
            file = bd.get_file(curr_file);

            if (file != null)
            {
                textBox_file.Text = file.name;
                lab_file_avg.Text = "" + file.avg_val;
                curr_mark = 0;
                but_mark_pr_Click(sender, e);
            }
            else
            {
                mark = null;
                comm = null;
                textBox_file.Text = "";
                lab_file_avg.Text = "";
                textBox_mark.Text = "";
                lab_mark_avg.Text = "";
                textBox_comm.Text = "";
            }
        }


        private void but_file_next_Click(object sender, EventArgs e)
        {
            if (file != null) curr_file++;
            file = bd.get_file(curr_file);

            if (file != null)
            {
                textBox_file.Text = file.name;
                lab_file_avg.Text = "" + file.avg_val;
                curr_mark = 0;
                but_mark_pr_Click(sender, e);
            }
            else
            {
                mark = null;
                comm = null;
                textBox_file.Text = "";
                lab_file_avg.Text = "";
                textBox_mark.Text = "";
                lab_mark_avg.Text = "";
                textBox_comm.Text = "";
            }
        }




        private void but_com_del_Click(object sender, EventArgs e)
        {
            if (comm != null)
            {
                string message = "Are you sure you want to delete the comment?";
                string caption = "Confirmation of action";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    bd.delete_record_comment(comm);
                    bd.recount_mark_avg_value(textBox_file.Text, textBox_mark.Text);
                    bd.recount_file_avg_value(textBox_file.Text);
                    but_com_pr_Click(sender, e);
                }
            }
        }


        private void but_mark_del_Click(object sender, EventArgs e)
        {
            if (mark != null)
            {
                string message = "Are you sure you want to delete the " + textBox_mark.Text + "?";
                string caption = "Confirmation of action";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    bd.delete_record_mark(mark);
                    bd.recount_file_avg_value(textBox_file.Text);
                    but_mark_pr_Click(sender, e);
                }
            }
        }


        private void but_file_del_Click(object sender, EventArgs e)
        {
            if (file != null)
            {
                string message = "Are you sure you want to delete the note " + textBox_file.Text + "?";
                string caption = "Confirmation of action";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    bd.delete_record_file(file);
                    but_file_pr_Click(sender, e);
                }
            }
        }


        private void but_mark_chg_Click(object sender, EventArgs e)
        {
            if (mark != null)
            {
                cur_markname = textBox_mark.Text;
                textBox_mark.ReadOnly = false;
                but_mark_chg.Visible = false;
                button_mark_cancel.Visible = true;

                button1.Enabled = false;

                but_mark_del.Enabled = false;
                but_mark_next.Enabled = false;
                but_mark_pr.Enabled = false;
                but_file_del.Enabled = false;
                but_file_next.Enabled = false;
                but_file_pr.Enabled = false;
                but_com_del.Enabled = false;
                but_com_next.Enabled = false;
                but_com_pr.Enabled = false;
            }
        }


        private void but_file_chg_Click(object sender, EventArgs e)
        {
            if (file != null)
            {
                cur_filename = textBox_file.Text;
                textBox_file.ReadOnly = false;
                but_file_chg.Visible = false;
                button_file_cancel.Visible = true;

                button1.Enabled = false;

                but_mark_del.Enabled = false;
                but_mark_next.Enabled = false;
                but_mark_pr.Enabled = false;
                but_file_del.Enabled = false;
                but_file_next.Enabled = false;
                but_file_pr.Enabled = false;
                but_com_del.Enabled = false;
                but_com_next.Enabled = false;
                but_com_pr.Enabled = false;
            }
        }


        private void button_accept_mark_Click(object sender, EventArgs e)
        {
            if (textBox_mark.Text != "")
            {
                bd.edit_record_mark(mark, textBox_mark.Text);
            }
            else
            {
                string message = "Are you sure you want to delete the " + cur_markname + "?";
                string caption = "Confirmation of action";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    bd.delete_record_mark(mark);
                    but_mark_pr_Click(sender, e);
                }
                else
                {
                    textBox_mark.Text = cur_markname;
                }
            }

            textBox_mark.ReadOnly = true;
            but_mark_chg.Visible = true;
            button_mark_cancel.Visible = false;

            button1.Enabled = true;

            but_mark_del.Enabled = true;
            but_mark_next.Enabled = true;
            but_mark_pr.Enabled = true;
            but_file_del.Enabled = true;
            but_file_next.Enabled = true;
            but_file_pr.Enabled = true;
            but_com_del.Enabled = true;
            but_com_next.Enabled = true;
            but_com_pr.Enabled = true;
        }

        private void button_accept_file_Click(object sender, EventArgs e)
        {
            if (textBox_file.Text != "")
            {
                bd.edit_record_file(file, textBox_file.Text);
            }
            else
            {
                string message = "Are you sure you want to delete the note " + cur_filename + "?";
                string caption = "Confirmation of action";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    bd.delete_record_file(file);
                    but_file_pr_Click(sender, e);
                }
                else
                {
                    textBox_file.Text = cur_filename;
                }
            }

            textBox_file.ReadOnly = true;
            but_file_chg.Visible = true;
            button_file_cancel.Visible = false;

            button1.Enabled = true;

            but_mark_del.Enabled = true;
            but_mark_next.Enabled = true;
            but_mark_pr.Enabled = true;
            but_file_del.Enabled = true;
            but_file_next.Enabled = true;
            but_file_pr.Enabled = true;
            but_com_del.Enabled = true;
            but_com_next.Enabled = true;
            but_com_pr.Enabled = true;
        }

        private void button_file_cancel_Click(object sender, EventArgs e)
        {
            textBox_file.Text = cur_filename;
            textBox_file.ReadOnly = true;
            but_file_chg.Visible = true;
            button_file_cancel.Visible = false;

            button1.Enabled = true;

            but_mark_del.Enabled = true;
            but_mark_next.Enabled = true;
            but_mark_pr.Enabled = true;
            but_file_del.Enabled = true;
            but_file_next.Enabled = true;
            but_file_pr.Enabled = true;
            but_com_del.Enabled = true;
            but_com_next.Enabled = true;
            but_com_pr.Enabled = true;
        }

        private void button_mark_cancel_Click(object sender, EventArgs e)
        {
            textBox_mark.Text = cur_markname;
            textBox_mark.ReadOnly = true;
            but_mark_chg.Visible = true;
            button_mark_cancel.Visible = false;

            button1.Enabled = true;

            but_mark_del.Enabled = true;
            but_mark_next.Enabled = true;
            but_mark_pr.Enabled = true;
            but_file_del.Enabled = true;
            but_file_next.Enabled = true;
            but_file_pr.Enabled = true;
            but_com_del.Enabled = true;
            but_com_next.Enabled = true;
            but_com_pr.Enabled = true;
        }





        private void Form_statistic_Load(object sender, EventArgs e)
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

            bd = new DB_manager(BDinfo[0], BDinfo[1], BDinfo[2], BDinfo[3], BDinfo[4]);

            if (bd.check_connection())
            {
                lab_db_connection.Text = BDinfo[4];
                curr_file = 0;
                curr_mark = 0;
                curr_comm = 0;

                file = bd.get_file(curr_file);

                if (file != null)
                {
                    textBox_file.Text = file.name;
                    lab_file_avg.Text = "" + file.avg_val;
                    mark = bd.get_mark(file, curr_mark);
                    if (mark != null)
                    {
                        textBox_mark.Text = mark.name;
                        lab_mark_avg.Text = "" + mark.avg_val;
                        comm = bd.get_comment(mark, curr_comm);
                        if (comm != null) textBox_comm.Text = comm.text;
                        else textBox_comm.Text = "";
                    }
                    else
                    {
                        textBox_mark.Text = "";
                        lab_mark_avg.Text = "";
                        textBox_comm.Text = "";
                    }
                }
                else
                {
                    textBox_file.Text = "";
                    lab_file_avg.Text = "";
                    textBox_mark.Text = "";
                    lab_mark_avg.Text = "";
                    textBox_comm.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Some problems with db connection", "Error");

                but_mark_chg.Enabled = false;
                but_file_chg.Enabled = false;
                but_mark_del.Enabled = false;
                but_mark_next.Enabled = false;
                but_mark_pr.Enabled = false;
                but_file_del.Enabled = false;
                but_file_next.Enabled = false;
                but_file_pr.Enabled = false;
                but_com_del.Enabled = false;
                but_com_next.Enabled = false;
                but_com_pr.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_statistic_Load(sender, e);
        }
    }
}
