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

        IDBManager db;

        string username;

        Filename file;
        Issue issue;
        Comment comm;

        int curr_file;
        int cur_issue;
        int curr_comm;

        public Form_Statistic()
        {
            InitializeComponent();
        }

        

        private void but_com_pr_Click(object sender, EventArgs e)
        {
            if (issue != null)
            {
                curr_comm--;
                if (curr_comm < 0) curr_comm = 0;
                comm = db.get_comment(issue, curr_comm);
                if (comm == null) textBox_comm.Text = "";
                else textBox_comm.Text = comm.author + ": " + comm.text;
            }
        }

        private void but_com_next_Click(object sender, EventArgs e)
        {
            if (issue != null)
            {
                if (textBox_comm.Text != "") curr_comm++;
                comm = db.get_comment(issue, curr_comm);
                if (comm == null) textBox_comm.Text = "";
                else textBox_comm.Text = comm.author + ": " + comm.text;
            }
        }




        private void but_mark_pr_Click(object sender, EventArgs e)
        {
            if (file != null)
            {
                cur_issue--;
                if (cur_issue < 0) cur_issue = 0;
                issue = db.get_issue(file, cur_issue);

                if (issue != null)
                {
                    textBox_mark.Text = issue.name;
                    comboBox_val.Text = severity[issue.severity];
                    textBox_linefrom.Text = "" + issue.linefrom;
                    textBox_lineto.Text = "" + issue.lineto;
                    curr_comm = 0;
                    but_com_pr_Click(sender, e);
                }
                else
                {
                    comm = null;
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
            if (file != null)
            {
                if (issue != null) cur_issue++;
                issue = db.get_issue(file, cur_issue);

                if (issue != null)
                {
                    textBox_mark.Text = issue.name;
                    comboBox_val.Text = severity[issue.severity];
                    textBox_linefrom.Text = "" + issue.linefrom;
                    textBox_lineto.Text = "" + issue.lineto;
                    curr_comm = 0;
                    but_com_pr_Click(sender, e);
                }
                else
                {
                    comm = null;
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
            curr_file--;
            if (curr_file < 0) curr_file = 0;
            file = db.get_file(curr_file);

            if (file != null)
            {
                textBox_file.Text = file.name;
                cur_issue = 0;
                but_mark_pr_Click(sender, e);
            }
            else
            {
                issue = null;
                comm = null;
                textBox_file.Text = "";
                textBox_mark.Text = "";
                comboBox_val.SelectedIndex = -1;
                textBox_comm.Text = "";
            }
        }


        private void but_file_next_Click(object sender, EventArgs e)
        {
            if (file != null) curr_file++;
            file = db.get_file(curr_file);

            if (file != null)
            {
                textBox_file.Text = file.name;
                cur_issue = 0;
                but_mark_pr_Click(sender, e);
            }
            else
            {
                issue = null;
                comm = null;
                textBox_file.Text = "";
                textBox_mark.Text = "";
                comboBox_val.SelectedIndex = -1;
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
                    db.delete_record_comment(comm);
                    but_com_pr_Click(sender, e);
                }
            }
        }


        private void but_mark_del_Click(object sender, EventArgs e)
        {
            if (issue != null)
            {
                string message = "Are you sure you want to delete the " + textBox_mark.Text + "?";
                string caption = "Confirmation of action";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    db.delete_record_issue(issue);
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
                    db.delete_record_file(file);
                    but_file_pr_Click(sender, e);
                }
            }
        }


        private void but_mark_chg_Click(object sender, EventArgs e)
        {
            if (issue != null)
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
            if (file != null)
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
                        db.edit_record_issue(issue, textBox_mark.Text, comboBox_val.SelectedIndex, a, b);
                        issue = db.get_issue(file, cur_issue);

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
                string message = "Are you sure you want to delete the " + issue.name + "?";
                string caption = "Confirmation of action";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    db.delete_record_issue(issue);
                    but_mark_pr_Click(sender, e);
                }
                else
                {
                    textBox_mark.Text = issue.name;
                }

                issue = db.get_issue(file, cur_issue);

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
                db.edit_record_file(file, textBox_file.Text);
            }
            else
            {
                string message = "Are you sure you want to delete the note " + file.name + "?";
                string caption = "Confirmation of action";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    db.delete_record_file(file);
                    but_file_pr_Click(sender, e);
                }
                else
                {
                    textBox_file.Text = file.name;
                }
            }

            file = db.get_file(curr_file);

            textBox_file.ReadOnly = true;
            but_file_chg.Visible = true;
            button_file_cancel.Visible = false;
            button_accept_file.Visible = false;

            enable_interface();
        }

        private void button_file_cancel_Click(object sender, EventArgs e)
        {
            textBox_file.Text = file.name;
            textBox_file.ReadOnly = true;
            but_file_chg.Visible = true;
            button_file_cancel.Visible = false;
            button_accept_file.Visible = false;

            enable_interface();
        }

        private void button_mark_cancel_Click(object sender, EventArgs e)
        {
            textBox_mark.Text = issue.name;
            textBox_mark.ReadOnly = true;
            but_mark_chg.Visible = true;
            button_mark_cancel.Visible = false;
            button_accept_mark.Visible = false;

            comboBox_val.Enabled = false;
            comboBox_val.Text = severity[issue.severity];

            textBox_linefrom.ReadOnly = true;
            textBox_linefrom.Text = "" + issue.linefrom;
            textBox_lineto.ReadOnly = true;
            textBox_lineto.Text = "" + issue.lineto;

            enable_interface();
        }





        private void Form_statistic_Load(object sender, EventArgs e)
        {
            string[] BDinfo = new string[5];
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

            username = BDinfo[2];
            db = new DB_manager(BDinfo[0], BDinfo[1], BDinfo[2], BDinfo[3], BDinfo[4]);

            if (db.check_connection())
            {
                lab_db_connection.Text = BDinfo[4];
                curr_file = 0;
                cur_issue = 0;
                curr_comm = 0;

                file = db.get_file(curr_file);

                if (file != null)
                {
                    textBox_file.Text = file.name;
                    issue = db.get_issue(file, cur_issue);
                    if (issue != null)
                    {
                        textBox_mark.Text = issue.name;
                        comboBox_val.Text = severity[issue.severity];
                        textBox_linefrom.Text = "" + issue.linefrom;
                        textBox_lineto.Text = "" + issue.lineto;
                        comm = db.get_comment(issue, curr_comm);
                        if (comm != null) textBox_comm.Text = comm.author + ": " + comm.text;
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

        private void button_refresh_Click(object sender, EventArgs e)
        {
            Form_statistic_Load(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel_opt.Visible = true;
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
            button_close_stngs.Visible = true;
        }

        private void button_close_stngs_Click(object sender, EventArgs e)
        {
            panel_opt_vote.Visible = false;
            button_close_stngs.Visible = false;
        }

        private void button_agree_Click(object sender, EventArgs e)
        {
            if (issue != null)
            {
                if (db.search_exist_author_comment(issue, username, 1) != null)
                    MessageBox.Show("You have already agreed with this problem", "No changes");
                else 
                { 
                    var a = db.search_exist_author_comment(issue, username, -1);
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
                            db.delete_record_comment(a);
                            db.add_new_record_comment(file.name, issue.name, "", username, 1);
                        }
                    }
                    else 
                    {
                        button_close_stngs_Click(sender, e);
                        db.add_new_record_comment(file.name, issue.name, "", username, 1);
                        MessageBox.Show("Your opinion was taken into account", "Successfully");
                    }
                }
            }
        }

        private void button_disagree_Click(object sender, EventArgs e)
        {
            if (issue != null)
            {
                if (db.search_exist_author_comment(issue, username, -1) != null)
                    MessageBox.Show("You have already disagreed with this problem", "No changes");
                else
                {
                    var a = db.search_exist_author_comment(issue, username, 1);
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
                            db.delete_record_comment(a);
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
            if (issue != null)
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
                db.add_new_record_comment(file.name, issue.name, textBox_comm.Text, username, 0);
                enable_interface();

                label_advice_com.Visible = false;
                button_com_acept.Visible = false;
                button_com_cancel.Visible = false;

                curr_comm = 0;
                comm = db.get_comment(issue, curr_comm);
                textBox_comm.Text = comm.author + ": " + comm.text;
                textBox_comm.ReadOnly = true;
                button_comment.BackColor = Color.Gainsboro;
            }
        }

        private void button_com_cancel_Click(object sender, EventArgs e)
        {
            enable_interface();
            textBox_comm.Text = comm.author + ": " + comm.text;

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
                db.add_new_record_comment(file.name, issue.name, textBox_comm.Text, username, -1);
                enable_interface();

                label_advice_disagree.Visible = false;
                button_disagree_accept.Visible = false;
                button_disagree_cancel.Visible = false;

                curr_comm = 0;
                comm = db.get_comment(issue, curr_comm);
                textBox_comm.Text = comm.author + ": " + comm.text;
                textBox_comm.ReadOnly = true;
                button_disagree.BackColor = Color.Gainsboro;
            }
        }

        private void button_disagree_cancel_Click(object sender, EventArgs e)
        {
            enable_interface();
            textBox_comm.Text = comm.author + ": " + comm.text;

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
