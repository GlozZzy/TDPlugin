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
        string[] severity =
            { "Comment",
            "Proposal",
            "Low importance",
            "High importance",
            "Critical" };

        string username;

        HandlerClass Hclass;

        public Form_Statistic()
        {
            InitializeComponent();
        }

        

        private void but_com_pr_Click(object sender, EventArgs e)
        {
            if (textBox_mark.Text != "")
            {
                Hclass.curr_comm--;
                if (Hclass.curr_comm < 0) Hclass.curr_comm = 0;
                Hclass.update_cur_com();
                if (Hclass.comm == null) textBox_comm.Text = "";
                else textBox_comm.Text = Hclass.comm.author + ": " + Hclass.comm.text;
            }
        }

        private void but_com_next_Click(object sender, EventArgs e)
        {
            if (textBox_mark.Text != "")
            {
                if (Hclass.comm != null) Hclass.curr_comm++;
                Hclass.update_cur_com();
                if (Hclass.comm == null) textBox_comm.Text = "";
                else textBox_comm.Text = Hclass.comm.author + ": " + Hclass.comm.text;
            }
        }




        private void but_mark_pr_Click(object sender, EventArgs e)
        {
            if (textBox_file.Text != "")
            {
                Hclass.cur_issue--;
                if (Hclass.cur_issue < 0) Hclass.cur_issue = 0;
                Hclass.update_cur_issue();

                if (Hclass.issue != null)
                {
                    textBox_mark.Text = Hclass.issue.name;
                    comboBox_val.Text = severity[Hclass.issue.severity];
                    textBox_linefrom.Text = "" + Hclass.issue.linefrom;
                    textBox_lineto.Text = "" + Hclass.issue.lineto;
                    Hclass.curr_comm = 0;
                    but_com_pr_Click(sender, e);
                }
                else
                {
                    Hclass.comm = null;
                    textBox_mark.Text = "";
                    comboBox_val.SelectedIndex = -1;
                    textBox_comm.Text = "";
                    textBox_linefrom.Text = "";
                    textBox_lineto.Text = "";
                }
            }
        }

        private void but_mark_next_Click(object sender, EventArgs e)
        {
            if (textBox_file.Text != "")
            {
                if (Hclass.issue != null) Hclass.cur_issue++;
                Hclass.update_cur_issue();

                if (Hclass.issue != null)
                {
                    textBox_mark.Text = Hclass.issue.name;
                    comboBox_val.Text = severity[Hclass.issue.severity];
                    textBox_linefrom.Text = "" + Hclass.issue.linefrom;
                    textBox_lineto.Text = "" + Hclass.issue.lineto;
                    Hclass.curr_comm = 0;
                    but_com_pr_Click(sender, e);
                }
                else
                {
                    Hclass.comm = null;
                    textBox_mark.Text = "";
                    comboBox_val.SelectedIndex = -1;
                    textBox_linefrom.Text = "";
                    textBox_lineto.Text = "";
                    textBox_comm.Text = "";
                }
            }
        }




        private void but_file_pr_Click(object sender, EventArgs e)
        {
            Hclass.curr_file--;
            if (Hclass.curr_file < 0) Hclass.curr_file = 0;
            Hclass.update_cur_file();

            if (Hclass.file != null)
            {
                textBox_file.Text = Hclass.file.name;
                Hclass.cur_issue = 0;
                but_mark_pr_Click(sender, e);
            }
            else
            {
                Hclass.issue = null;
                Hclass.comm = null;
                textBox_file.Text = "";
                textBox_mark.Text = "";
                comboBox_val.SelectedIndex = -1;
                textBox_comm.Text = "";
            }
        }


        private void but_file_next_Click(object sender, EventArgs e)
        {
            if (Hclass.file != null) Hclass.curr_file++;
            Hclass.update_cur_file();

            if (Hclass.file != null)
            {
                textBox_file.Text = Hclass.file.name;
                Hclass.cur_issue = 0;
                but_mark_pr_Click(sender, e);
            }
            else
            {
                Hclass.issue = null;
                Hclass.comm = null;
                textBox_file.Text = "";
                textBox_mark.Text = "";
                comboBox_val.SelectedIndex = -1;
                textBox_comm.Text = "";
            }
        }




        private void but_com_del_Click(object sender, EventArgs e)
        {
            if (Hclass.comm != null)
            {
                string message = "Are you sure you want to delete the comment?";
                string caption = "Confirmation of action";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    Hclass.del_record("comment");
                    but_com_pr_Click(sender, e);
                }
            }
        }


        private void but_mark_del_Click(object sender, EventArgs e)
        {
            if (Hclass.issue != null)
            {
                string message = "Are you sure you want to delete the " + textBox_mark.Text + "?";
                string caption = "Confirmation of action";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    Hclass.del_record("issue");
                    but_mark_pr_Click(sender, e);
                }
            }
        }


        private void but_file_del_Click(object sender, EventArgs e)
        {
            if (Hclass.file != null)
            {
                string message = "Are you sure you want to delete the note " + textBox_file.Text + "?";
                string caption = "Confirmation of action";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    Hclass.del_record("file");
                    but_file_pr_Click(sender, e);
                }
            }
        }


        private void but_mark_chg_Click(object sender, EventArgs e)
        {
            if (Hclass.issue != null)
            {
                disable_interface();

                button_mark_cancel.Visible = true;
                button_accept_mark.Visible = true;
                textBox_mark.ReadOnly = false;
                but_mark_chg.Visible = false;
                comboBox_val.Enabled = true;

                textBox_linefrom.ReadOnly = false;
                textBox_lineto.ReadOnly = false;
            }
        }


        private void but_file_chg_Click(object sender, EventArgs e)
        {
            if (Hclass.file != null)
            {
                textBox_file.ReadOnly = false;
                but_file_chg.Visible = false;
                button_file_cancel.Visible = true;
                button_accept_file.Visible = true;

                disable_interface();
            }
        }


        private void button_accept_mark_Click(object sender, EventArgs e)
        {
            if (textBox_mark.Text != "")
            {
                try 
                {
                    var a = int.Parse(textBox_linefrom.Text);
                    var b = int.Parse(textBox_lineto.Text);
                    if (a <= b)
                    {
                        Hclass.edit_record_issue(textBox_mark.Text, comboBox_val.SelectedIndex, a, b);

                        textBox_mark.ReadOnly = true;
                        but_mark_chg.Visible = true;
                        button_mark_cancel.Visible = false;
                        button_accept_mark.Visible = false;

                        comboBox_val.Enabled = false;
                        textBox_linefrom.ReadOnly = true;
                        textBox_lineto.ReadOnly = true;

                        enable_interface();
                    }
                    else MessageBox.Show("Incorrect lines range", "Error");
                }
                catch { MessageBox.Show("Incorrect lines range", "Error"); }
            }
            else
            {
                string message = "Are you sure you want to delete the " + Hclass.issue.name + "?";
                string caption = "Confirmation of action";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    Hclass.del_record("issue");
                    but_mark_pr_Click(sender, e);
                }
                else
                {
                    textBox_mark.Text = Hclass.issue.name;
                }
                Hclass.update_cur_issue();

                textBox_mark.ReadOnly = true;
                but_mark_chg.Visible = true;
                button_mark_cancel.Visible = false;
                button_accept_mark.Visible = false;

                comboBox_val.Enabled = false;
                textBox_linefrom.ReadOnly = true;
                textBox_lineto.ReadOnly = true;

                enable_interface();
            }

            
        }

        private void button_accept_file_Click(object sender, EventArgs e)
        {
            if (textBox_file.Text != "")
            {
                Hclass.edit_record_file(textBox_file.Text);
            }
            else
            {
                string message = "Are you sure you want to delete the note " + Hclass.file.name + "?";
                string caption = "Confirmation of action";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    Hclass.del_record("file");
                    but_file_pr_Click(sender, e);
                }
                else
                {
                    textBox_file.Text = Hclass.file.name;
                }
            }
            Hclass.update_cur_file();

            textBox_file.ReadOnly = true;
            but_file_chg.Visible = true;
            button_file_cancel.Visible = false;
            button_accept_file.Visible = false;

            enable_interface();
        }

        private void button_file_cancel_Click(object sender, EventArgs e)
        {
            textBox_file.Text = Hclass.file.name;
            textBox_file.ReadOnly = true;
            but_file_chg.Visible = true;
            button_file_cancel.Visible = false;
            button_accept_file.Visible = false;

            enable_interface();
        }

        private void button_mark_cancel_Click(object sender, EventArgs e)
        {
            textBox_mark.Text = Hclass.issue.name;
            textBox_mark.ReadOnly = true;
            but_mark_chg.Visible = true;
            button_mark_cancel.Visible = false;
            button_accept_mark.Visible = false;

            comboBox_val.Enabled = false;
            comboBox_val.Text = severity[Hclass.issue.severity];

            textBox_linefrom.ReadOnly = true;
            textBox_linefrom.Text = "" + Hclass.issue.linefrom;
            textBox_lineto.ReadOnly = true;
            textBox_lineto.Text = "" + Hclass.issue.lineto;

            enable_interface();
        }





        private void Form_statistic_Load(object sender, EventArgs e)
        {
            Hclass = new HandlerClass();
            var DBinfo = Hclass.get_dbinfo();

            username = DBinfo[2];

            if (Hclass.db.check_connection())
            {
                Hclass.get_first_info();
                lab_db_connection.Text = DBinfo[4];

                Hclass.file = Hclass.db.get_file(Hclass.curr_file);

                if (Hclass.file != null)
                {
                    textBox_file.Text = Hclass.file.name;
                    Hclass.issue = Hclass.db.get_issue(Hclass.file, Hclass.cur_issue);
                    if (Hclass.issue != null)
                    {
                        textBox_mark.Text = Hclass.issue.name;
                        comboBox_val.Text = severity[Hclass.issue.severity];
                        textBox_linefrom.Text = "" + Hclass.issue.linefrom;
                        textBox_lineto.Text = "" + Hclass.issue.lineto;
                        Hclass.comm = Hclass.db.get_comment(Hclass.issue, Hclass.curr_comm);
                        if (Hclass.comm != null) textBox_comm.Text = Hclass.comm.author + ": " + Hclass.comm.text;
                        else textBox_comm.Text = "";
                    }
                    else
                    {
                        textBox_mark.Text = "";
                        textBox_linefrom.Text = "";
                        textBox_lineto.Text = "";
                        comboBox_val.SelectedIndex = -1;
                        textBox_comm.Text = "";
                    }
                }
                else
                {
                    textBox_file.Text = "";
                    textBox_mark.Text = "";
                    comboBox_val.SelectedIndex = -1;
                    textBox_linefrom.Text = "";
                    textBox_lineto.Text = "";
                    textBox_mark.Text = "";
                    textBox_comm.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Some problems with db connection", "Error");

                but_mark_chg.Enabled = false;
                but_file_chg.Enabled = false;

                disable_interface();

                button_opt.Enabled = false;
                button_open_stngs.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel_opt.Visible = true;
            panel_opt.Location = new Point(button_cl.Location.X + 74, button_cl.Location.Y - 78 + panel_footer.Location.Y);
            button_cl.Visible = true;
        }

        private void button_cl_Click(object sender, EventArgs e)
        {
            panel_opt.Visible = false;
            button_cl.Visible = false;
        }
        

        private void button_open_stngs_Click(object sender, EventArgs e)
        {
            panel_opt_vote.Visible = true;
            panel_opt_vote.Location = new Point(button_close_stngs.Location.X + 63 + panel_right.Location.X, button_close_stngs.Location.Y + 1);
            button_close_stngs.Visible = true;
            button_open_stngs.Visible = false;
        }

        private void button_close_stngs_Click(object sender, EventArgs e)
        {
            panel_opt_vote.Visible = false;
            button_close_stngs.Visible = false;
            button_open_stngs.Visible = true;
        }

        private void button_agree_Click(object sender, EventArgs e)
        {
            if (Hclass.issue != null)
            {
                if (Hclass.db.search_exist_author_comment(Hclass.issue, username, 1) != null)
                    MessageBox.Show("You have already agreed with this problem", "No changes");
                else 
                { 
                    var a = Hclass.db.search_exist_author_comment(Hclass.issue, username, -1);
                    if (a != null)
                    {
                        string message = "Do you want to replace your 'disagree' comment?";
                        string caption = "You have already disagreed with this problem";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;

                        // Displays the MessageBox.
                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            Hclass.db.delete_record_comment(a);
                            Hclass.db.add_new_record_comment(Hclass.file.name, Hclass.issue.name, "", username, 1);
                        }
                    }
                    else 
                    {
                        button_close_stngs_Click(sender, e);
                        Hclass.db.add_new_record_comment(Hclass.file.name, Hclass.issue.name, "", username, 1);
                        MessageBox.Show("Your opinion was taken into account", "Successfully");
                    }
                }
            }
        }

        private void button_disagree_Click(object sender, EventArgs e)
        {
            if (Hclass.issue != null)
            {
                if (Hclass.db.search_exist_author_comment(Hclass.issue, username, -1) != null)
                    MessageBox.Show("You have already disagreed with this problem", "No changes");
                else
                {
                    var a = Hclass.db.search_exist_author_comment(Hclass.issue, username, 1);
                    if (a != null)
                    {
                        string message = "Do you want to replace your 'agree' comment?";
                        string caption = "You have already agreed with this problem";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;

                        // Displays the MessageBox.
                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            button_close_stngs_Click(sender, e);
                            Hclass.db.delete_record_comment(a);
                            button_disagree.BackColor = Color.LightSkyBlue;
                            disable_interface();
                            textBox_comm.Text = "";
                            textBox_comm.ReadOnly = false;

                            label_advice_disagree.Visible = true;
                            button_disagree_accept.Visible = true;
                            button_disagree_cancel.Visible = true;
                        }
                    }
                    else 
                    {
                        button_close_stngs_Click(sender, e);
                        button_disagree.BackColor = Color.LightSkyBlue;
                        disable_interface();
                        textBox_comm.Text = "";
                        textBox_comm.ReadOnly = false;

                        label_advice_disagree.Visible = true;
                        button_disagree_accept.Visible = true;
                        button_disagree_cancel.Visible = true;
                    }
                }
            } 
        }

        private void button_comment_Click(object sender, EventArgs e)
        {
            if (Hclass.issue != null)
            {
                button_close_stngs_Click(sender, e);
                button_comment.BackColor = Color.LightSkyBlue;
                disable_interface();
                textBox_comm.Text = "";
                textBox_comm.ReadOnly = false;

                label_advice_com.Visible = true;
                button_com_acept.Visible = true;
                button_com_cancel.Visible = true;
            }

        }


        private void disable_interface() 
        { 
            but_mark_del.Enabled = false;
            but_mark_next.Enabled = false;
            but_mark_pr.Enabled = false;
            but_file_del.Enabled = false;
            but_file_next.Enabled = false;
            but_file_pr.Enabled = false;
            but_com_del.Enabled = false;
            but_com_next.Enabled = false;
            but_com_pr.Enabled = false;

            button_agree.Enabled = false;
            button_comment.Enabled = false;
            button_disagree.Enabled = false;

            but_mark_chg.Enabled = false;
            but_file_chg.Enabled = false;
        }

        private void enable_interface()
        {
            but_mark_del.Enabled = true;
            but_mark_next.Enabled = true;
            but_mark_pr.Enabled = true;
            but_file_del.Enabled = true;
            but_file_next.Enabled = true;
            but_file_pr.Enabled = true;
            but_com_del.Enabled = true;
            but_com_next.Enabled = true;
            but_com_pr.Enabled = true;

            button_agree.Enabled = true;
            button_comment.Enabled = true;
            button_disagree.Enabled = true;

            but_mark_chg.Enabled = true;
            but_file_chg.Enabled = true;
        }


        private void button_com_acept_Click(object sender, EventArgs e)
        {
            if (textBox_comm.Text != "")
            {
                Hclass.db.add_new_record_comment(Hclass.file.name, Hclass.issue.name, textBox_comm.Text, username, 0);
                enable_interface();

                label_advice_com.Visible = false;
                button_com_acept.Visible = false;
                button_com_cancel.Visible = false;

                but_com_next_Click(sender, e);
                textBox_comm.ReadOnly = true;
                button_comment.BackColor = Color.Gainsboro;
            }
        }

        private void button_com_cancel_Click(object sender, EventArgs e)
        {
            enable_interface();
            if (Hclass.comm != null)
                textBox_comm.Text = Hclass.comm.author + ": " + Hclass.comm.text;
            else textBox_comm.Text = "";

            label_advice_com.Visible = false;
            button_com_acept.Visible = false;
            button_com_cancel.Visible = false;
            textBox_comm.ReadOnly = true;
            button_comment.BackColor = Color.Gainsboro;
        }

        private void button_disagree_accept_Click(object sender, EventArgs e)
        {
            if (textBox_comm.Text != "")
            {
                Hclass.db.add_new_record_comment(Hclass.file.name, Hclass.issue.name, textBox_comm.Text, username, -1);
                enable_interface();

                label_advice_disagree.Visible = false;
                button_disagree_accept.Visible = false;
                button_disagree_cancel.Visible = false;

                but_com_next_Click(sender, e);
                textBox_comm.ReadOnly = true;
                button_disagree.BackColor = Color.Gainsboro;
            }
        }

        private void button_disagree_cancel_Click(object sender, EventArgs e)
        {
            enable_interface();
            if (Hclass.comm != null) textBox_comm.Text = Hclass.comm.author + ": " + Hclass.comm.text;
            else textBox_comm.Text = "";

            label_advice_disagree.Visible = false;
            button_disagree_accept.Visible = false;
            button_disagree_cancel.Visible = false;

            textBox_comm.ReadOnly = true;
            button_disagree.BackColor = Color.Gainsboro;
        }

        private void textBox_linefrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox_lineto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
