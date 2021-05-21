
namespace TDPlugin.Forms
{
    partial class Form_Statistic
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.but_mark_pr = new System.Windows.Forms.Button();
            this.but_mark_next = new System.Windows.Forms.Button();
            this.textBox_comm = new System.Windows.Forms.TextBox();
            this.but_file_del = new System.Windows.Forms.Button();
            this.but_com_next = new System.Windows.Forms.Button();
            this.but_com_pr = new System.Windows.Forms.Button();
            this.but_com_del = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.but_file_next = new System.Windows.Forms.Button();
            this.but_file_pr = new System.Windows.Forms.Button();
            this.textBox_file = new System.Windows.Forms.TextBox();
            this.textBox_mark = new System.Windows.Forms.TextBox();
            this.but_mark_del = new System.Windows.Forms.Button();
            this.but_mark_chg = new System.Windows.Forms.Button();
            this.but_file_chg = new System.Windows.Forms.Button();
            this.button_accept_file = new System.Windows.Forms.Button();
            this.button_accept_mark = new System.Windows.Forms.Button();
            this.button_file_cancel = new System.Windows.Forms.Button();
            this.button_mark_cancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lab_db_connection = new System.Windows.Forms.Label();
            this.button_disagree = new System.Windows.Forms.Button();
            this.button_agree = new System.Windows.Forms.Button();
            this.panel_opt = new System.Windows.Forms.Panel();
            this.button_cl = new System.Windows.Forms.Button();
            this.button_opt = new System.Windows.Forms.Button();
            this.comboBox_val = new System.Windows.Forms.ComboBox();
            this.button_comment = new System.Windows.Forms.Button();
            this.panel_opt_vote = new System.Windows.Forms.Panel();
            this.button_close_stngs = new System.Windows.Forms.Button();
            this.button_open_stngs = new System.Windows.Forms.Button();
            this.button_com_acept = new System.Windows.Forms.Button();
            this.button_com_cancel = new System.Windows.Forms.Button();
            this.label_advice_com = new System.Windows.Forms.Label();
            this.button_disagree_accept = new System.Windows.Forms.Button();
            this.button_disagree_cancel = new System.Windows.Forms.Button();
            this.label_advice_disagree = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel_opt.SuspendLayout();
            this.panel_opt_vote.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name mark";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label4.Location = new System.Drawing.Point(393, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "severity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label6.Location = new System.Drawing.Point(12, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 24);
            this.label6.TabIndex = 4;
            this.label6.Text = "Comments";
            // 
            // but_mark_pr
            // 
            this.but_mark_pr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.but_mark_pr.Location = new System.Drawing.Point(519, 67);
            this.but_mark_pr.Name = "but_mark_pr";
            this.but_mark_pr.Size = new System.Drawing.Size(45, 31);
            this.but_mark_pr.TabIndex = 6;
            this.but_mark_pr.TabStop = false;
            this.but_mark_pr.Text = "<--";
            this.but_mark_pr.UseVisualStyleBackColor = true;
            this.but_mark_pr.Click += new System.EventHandler(this.but_mark_pr_Click);
            // 
            // but_mark_next
            // 
            this.but_mark_next.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.but_mark_next.Location = new System.Drawing.Point(567, 67);
            this.but_mark_next.Name = "but_mark_next";
            this.but_mark_next.Size = new System.Drawing.Size(45, 31);
            this.but_mark_next.TabIndex = 7;
            this.but_mark_next.TabStop = false;
            this.but_mark_next.Text = "-->";
            this.but_mark_next.UseVisualStyleBackColor = true;
            this.but_mark_next.Click += new System.EventHandler(this.but_mark_next_Click);
            // 
            // textBox_comm
            // 
            this.textBox_comm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBox_comm.Location = new System.Drawing.Point(55, 174);
            this.textBox_comm.Multiline = true;
            this.textBox_comm.Name = "textBox_comm";
            this.textBox_comm.ReadOnly = true;
            this.textBox_comm.Size = new System.Drawing.Size(557, 111);
            this.textBox_comm.TabIndex = 8;
            this.textBox_comm.TabStop = false;
            // 
            // but_file_del
            // 
            this.but_file_del.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.but_file_del.Location = new System.Drawing.Point(377, 41);
            this.but_file_del.Name = "but_file_del";
            this.but_file_del.Size = new System.Drawing.Size(180, 35);
            this.but_file_del.TabIndex = 11;
            this.but_file_del.TabStop = false;
            this.but_file_del.Text = "Delete File";
            this.but_file_del.UseVisualStyleBackColor = true;
            this.but_file_del.Click += new System.EventHandler(this.but_file_del_Click);
            // 
            // but_com_next
            // 
            this.but_com_next.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.but_com_next.Location = new System.Drawing.Point(10, 232);
            this.but_com_next.Name = "but_com_next";
            this.but_com_next.Size = new System.Drawing.Size(40, 34);
            this.but_com_next.TabIndex = 13;
            this.but_com_next.TabStop = false;
            this.but_com_next.Text = "▼";
            this.but_com_next.UseVisualStyleBackColor = true;
            this.but_com_next.Click += new System.EventHandler(this.but_com_next_Click);
            // 
            // but_com_pr
            // 
            this.but_com_pr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.but_com_pr.Location = new System.Drawing.Point(10, 194);
            this.but_com_pr.Name = "but_com_pr";
            this.but_com_pr.Size = new System.Drawing.Size(40, 34);
            this.but_com_pr.TabIndex = 12;
            this.but_com_pr.TabStop = false;
            this.but_com_pr.Text = "▲";
            this.but_com_pr.UseVisualStyleBackColor = true;
            this.but_com_pr.Click += new System.EventHandler(this.but_com_pr_Click);
            // 
            // but_com_del
            // 
            this.but_com_del.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.but_com_del.Location = new System.Drawing.Point(0, 41);
            this.but_com_del.Name = "but_com_del";
            this.but_com_del.Size = new System.Drawing.Size(175, 35);
            this.but_com_del.TabIndex = 14;
            this.but_com_del.TabStop = false;
            this.but_com_del.Text = "Delete Comment";
            this.but_com_del.UseVisualStyleBackColor = true;
            this.but_com_del.Click += new System.EventHandler(this.but_com_del_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.Location = new System.Drawing.Point(12, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 24);
            this.label3.TabIndex = 15;
            this.label3.Text = "File name";
            // 
            // but_file_next
            // 
            this.but_file_next.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.but_file_next.Location = new System.Drawing.Point(567, 32);
            this.but_file_next.Name = "but_file_next";
            this.but_file_next.Size = new System.Drawing.Size(45, 30);
            this.but_file_next.TabIndex = 18;
            this.but_file_next.TabStop = false;
            this.but_file_next.Text = "-->";
            this.but_file_next.UseVisualStyleBackColor = true;
            this.but_file_next.Click += new System.EventHandler(this.but_file_next_Click);
            // 
            // but_file_pr
            // 
            this.but_file_pr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.but_file_pr.Location = new System.Drawing.Point(519, 32);
            this.but_file_pr.Name = "but_file_pr";
            this.but_file_pr.Size = new System.Drawing.Size(45, 30);
            this.but_file_pr.TabIndex = 17;
            this.but_file_pr.TabStop = false;
            this.but_file_pr.Text = "<--";
            this.but_file_pr.UseVisualStyleBackColor = true;
            this.but_file_pr.Click += new System.EventHandler(this.but_file_pr_Click);
            // 
            // textBox_file
            // 
            this.textBox_file.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_file.Location = new System.Drawing.Point(125, 32);
            this.textBox_file.Name = "textBox_file";
            this.textBox_file.ReadOnly = true;
            this.textBox_file.Size = new System.Drawing.Size(212, 29);
            this.textBox_file.TabIndex = 19;
            this.textBox_file.TabStop = false;
            // 
            // textBox_mark
            // 
            this.textBox_mark.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_mark.Location = new System.Drawing.Point(125, 67);
            this.textBox_mark.Name = "textBox_mark";
            this.textBox_mark.ReadOnly = true;
            this.textBox_mark.Size = new System.Drawing.Size(212, 29);
            this.textBox_mark.TabIndex = 20;
            this.textBox_mark.TabStop = false;
            // 
            // but_mark_del
            // 
            this.but_mark_del.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.but_mark_del.Location = new System.Drawing.Point(181, 41);
            this.but_mark_del.Name = "but_mark_del";
            this.but_mark_del.Size = new System.Drawing.Size(190, 35);
            this.but_mark_del.TabIndex = 21;
            this.but_mark_del.TabStop = false;
            this.but_mark_del.Text = "Delete Mark";
            this.but_mark_del.UseVisualStyleBackColor = true;
            this.but_mark_del.Click += new System.EventHandler(this.but_mark_del_Click);
            // 
            // but_mark_chg
            // 
            this.but_mark_chg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.but_mark_chg.Location = new System.Drawing.Point(94, 0);
            this.but_mark_chg.Name = "but_mark_chg";
            this.but_mark_chg.Size = new System.Drawing.Size(227, 35);
            this.but_mark_chg.TabIndex = 24;
            this.but_mark_chg.TabStop = false;
            this.but_mark_chg.Text = "Change Mark";
            this.but_mark_chg.UseVisualStyleBackColor = true;
            this.but_mark_chg.Click += new System.EventHandler(this.but_mark_chg_Click);
            // 
            // but_file_chg
            // 
            this.but_file_chg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.but_file_chg.Location = new System.Drawing.Point(330, 0);
            this.but_file_chg.Name = "but_file_chg";
            this.but_file_chg.Size = new System.Drawing.Size(227, 35);
            this.but_file_chg.TabIndex = 22;
            this.but_file_chg.TabStop = false;
            this.but_file_chg.Text = "Change File name";
            this.but_file_chg.UseVisualStyleBackColor = true;
            this.but_file_chg.Click += new System.EventHandler(this.but_file_chg_Click);
            // 
            // button_accept_file
            // 
            this.button_accept_file.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.button_accept_file.Location = new System.Drawing.Point(330, 0);
            this.button_accept_file.Name = "button_accept_file";
            this.button_accept_file.Size = new System.Drawing.Size(227, 35);
            this.button_accept_file.TabIndex = 25;
            this.button_accept_file.TabStop = false;
            this.button_accept_file.Text = "Accept";
            this.button_accept_file.UseVisualStyleBackColor = true;
            this.button_accept_file.Click += new System.EventHandler(this.button_accept_file_Click);
            // 
            // button_accept_mark
            // 
            this.button_accept_mark.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.button_accept_mark.Location = new System.Drawing.Point(94, 0);
            this.button_accept_mark.Name = "button_accept_mark";
            this.button_accept_mark.Size = new System.Drawing.Size(227, 35);
            this.button_accept_mark.TabIndex = 26;
            this.button_accept_mark.TabStop = false;
            this.button_accept_mark.Text = "Accept";
            this.button_accept_mark.UseVisualStyleBackColor = true;
            this.button_accept_mark.Click += new System.EventHandler(this.button_accept_mark_Click);
            // 
            // button_file_cancel
            // 
            this.button_file_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.button_file_cancel.Location = new System.Drawing.Point(94, 0);
            this.button_file_cancel.Name = "button_file_cancel";
            this.button_file_cancel.Size = new System.Drawing.Size(227, 35);
            this.button_file_cancel.TabIndex = 27;
            this.button_file_cancel.TabStop = false;
            this.button_file_cancel.Text = "Cancel";
            this.button_file_cancel.UseVisualStyleBackColor = true;
            this.button_file_cancel.Visible = false;
            this.button_file_cancel.Click += new System.EventHandler(this.button_file_cancel_Click);
            // 
            // button_mark_cancel
            // 
            this.button_mark_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.button_mark_cancel.Location = new System.Drawing.Point(330, 0);
            this.button_mark_cancel.Name = "button_mark_cancel";
            this.button_mark_cancel.Size = new System.Drawing.Size(227, 35);
            this.button_mark_cancel.TabIndex = 28;
            this.button_mark_cancel.TabStop = false;
            this.button_mark_cancel.Text = "Cancel";
            this.button_mark_cancel.UseVisualStyleBackColor = true;
            this.button_mark_cancel.Visible = false;
            this.button_mark_cancel.Click += new System.EventHandler(this.button_mark_cancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lab_db_connection);
            this.panel1.Location = new System.Drawing.Point(10, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 18);
            this.panel1.TabIndex = 31;
            // 
            // lab_db_connection
            // 
            this.lab_db_connection.AutoSize = true;
            this.lab_db_connection.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lab_db_connection.Dock = System.Windows.Forms.DockStyle.Right;
            this.lab_db_connection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab_db_connection.ForeColor = System.Drawing.Color.Blue;
            this.lab_db_connection.Location = new System.Drawing.Point(524, 0);
            this.lab_db_connection.Name = "lab_db_connection";
            this.lab_db_connection.Size = new System.Drawing.Size(78, 13);
            this.lab_db_connection.TabIndex = 13;
            this.lab_db_connection.Text = "db_connection";
            this.lab_db_connection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_disagree
            // 
            this.button_disagree.BackColor = System.Drawing.Color.Gainsboro;
            this.button_disagree.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button_disagree.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button_disagree.Location = new System.Drawing.Point(188, 0);
            this.button_disagree.Name = "button_disagree";
            this.button_disagree.Size = new System.Drawing.Size(115, 34);
            this.button_disagree.TabIndex = 34;
            this.button_disagree.TabStop = false;
            this.button_disagree.Text = "disagree";
            this.button_disagree.UseVisualStyleBackColor = true;
            this.button_disagree.Click += new System.EventHandler(this.button_disagree_Click);
            // 
            // button_agree
            // 
            this.button_agree.BackColor = System.Drawing.Color.Gainsboro;
            this.button_agree.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button_agree.ForeColor = System.Drawing.Color.Green;
            this.button_agree.Location = new System.Drawing.Point(66, 0);
            this.button_agree.Name = "button_agree";
            this.button_agree.Size = new System.Drawing.Size(116, 34);
            this.button_agree.TabIndex = 33;
            this.button_agree.TabStop = false;
            this.button_agree.Text = "agree";
            this.button_agree.UseVisualStyleBackColor = true;
            this.button_agree.Click += new System.EventHandler(this.button_agree_Click);
            // 
            // panel_opt
            // 
            this.panel_opt.Controls.Add(this.button_cl);
            this.panel_opt.Controls.Add(this.button_file_cancel);
            this.panel_opt.Controls.Add(this.but_file_del);
            this.panel_opt.Controls.Add(this.but_com_del);
            this.panel_opt.Controls.Add(this.but_mark_del);
            this.panel_opt.Controls.Add(this.button_mark_cancel);
            this.panel_opt.Controls.Add(this.but_file_chg);
            this.panel_opt.Controls.Add(this.but_mark_chg);
            this.panel_opt.Controls.Add(this.button_accept_file);
            this.panel_opt.Controls.Add(this.button_accept_mark);
            this.panel_opt.Location = new System.Drawing.Point(55, 291);
            this.panel_opt.Name = "panel_opt";
            this.panel_opt.Size = new System.Drawing.Size(557, 81);
            this.panel_opt.TabIndex = 35;
            this.panel_opt.Visible = false;
            // 
            // button_cl
            // 
            this.button_cl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button_cl.Location = new System.Drawing.Point(0, 0);
            this.button_cl.Name = "button_cl";
            this.button_cl.Size = new System.Drawing.Size(88, 35);
            this.button_cl.TabIndex = 38;
            this.button_cl.TabStop = false;
            this.button_cl.Text = "<<";
            this.button_cl.UseVisualStyleBackColor = true;
            this.button_cl.Click += new System.EventHandler(this.button_cl_Click);
            // 
            // button_opt
            // 
            this.button_opt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button_opt.Location = new System.Drawing.Point(55, 291);
            this.button_opt.Name = "button_opt";
            this.button_opt.Size = new System.Drawing.Size(88, 35);
            this.button_opt.TabIndex = 36;
            this.button_opt.TabStop = false;
            this.button_opt.Text = "Options";
            this.button_opt.UseVisualStyleBackColor = true;
            this.button_opt.Click += new System.EventHandler(this.button4_Click);
            // 
            // comboBox_val
            // 
            this.comboBox_val.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_val.Enabled = false;
            this.comboBox_val.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_val.FormattingEnabled = true;
            this.comboBox_val.Items.AddRange(new object[] {
            "comment",
            "proposal",
            "low importance",
            "high importance",
            "critical"});
            this.comboBox_val.Location = new System.Drawing.Point(343, 65);
            this.comboBox_val.Name = "comboBox_val";
            this.comboBox_val.Size = new System.Drawing.Size(170, 32);
            this.comboBox_val.TabIndex = 37;
            // 
            // button_comment
            // 
            this.button_comment.BackColor = System.Drawing.Color.Gainsboro;
            this.button_comment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button_comment.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_comment.Location = new System.Drawing.Point(309, 0);
            this.button_comment.Name = "button_comment";
            this.button_comment.Size = new System.Drawing.Size(145, 34);
            this.button_comment.TabIndex = 38;
            this.button_comment.TabStop = false;
            this.button_comment.Text = "add comment";
            this.button_comment.UseVisualStyleBackColor = true;
            this.button_comment.Click += new System.EventHandler(this.button_comment_Click);
            // 
            // panel_opt_vote
            // 
            this.panel_opt_vote.Controls.Add(this.button_agree);
            this.panel_opt_vote.Controls.Add(this.button_close_stngs);
            this.panel_opt_vote.Controls.Add(this.button_comment);
            this.panel_opt_vote.Controls.Add(this.button_disagree);
            this.panel_opt_vote.Location = new System.Drawing.Point(59, 106);
            this.panel_opt_vote.Name = "panel_opt_vote";
            this.panel_opt_vote.Size = new System.Drawing.Size(454, 38);
            this.panel_opt_vote.TabIndex = 39;
            this.panel_opt_vote.Visible = false;
            // 
            // button_close_stngs
            // 
            this.button_close_stngs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button_close_stngs.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_close_stngs.Location = new System.Drawing.Point(0, 0);
            this.button_close_stngs.Name = "button_close_stngs";
            this.button_close_stngs.Size = new System.Drawing.Size(60, 34);
            this.button_close_stngs.TabIndex = 40;
            this.button_close_stngs.TabStop = false;
            this.button_close_stngs.Text = "<<";
            this.button_close_stngs.UseVisualStyleBackColor = true;
            this.button_close_stngs.Click += new System.EventHandler(this.button_close_stngs_Click);
            // 
            // button_open_stngs
            // 
            this.button_open_stngs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button_open_stngs.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_open_stngs.Location = new System.Drawing.Point(59, 106);
            this.button_open_stngs.Name = "button_open_stngs";
            this.button_open_stngs.Size = new System.Drawing.Size(60, 34);
            this.button_open_stngs.TabIndex = 41;
            this.button_open_stngs.TabStop = false;
            this.button_open_stngs.Text = ">>";
            this.button_open_stngs.UseVisualStyleBackColor = true;
            this.button_open_stngs.Click += new System.EventHandler(this.button_open_stngs_Click);
            // 
            // button_com_acept
            // 
            this.button_com_acept.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button_com_acept.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_com_acept.Location = new System.Drawing.Point(534, 138);
            this.button_com_acept.Name = "button_com_acept";
            this.button_com_acept.Size = new System.Drawing.Size(37, 34);
            this.button_com_acept.TabIndex = 42;
            this.button_com_acept.TabStop = false;
            this.button_com_acept.Text = "✔️";
            this.button_com_acept.UseVisualStyleBackColor = true;
            this.button_com_acept.Visible = false;
            this.button_com_acept.Click += new System.EventHandler(this.button_com_acept_Click);
            // 
            // button_com_cancel
            // 
            this.button_com_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button_com_cancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_com_cancel.Location = new System.Drawing.Point(575, 138);
            this.button_com_cancel.Name = "button_com_cancel";
            this.button_com_cancel.Size = new System.Drawing.Size(37, 34);
            this.button_com_cancel.TabIndex = 43;
            this.button_com_cancel.TabStop = false;
            this.button_com_cancel.Text = "❌";
            this.button_com_cancel.UseVisualStyleBackColor = true;
            this.button_com_cancel.Visible = false;
            this.button_com_cancel.Click += new System.EventHandler(this.button_com_cancel_Click);
            // 
            // label_advice_com
            // 
            this.label_advice_com.AutoSize = true;
            this.label_advice_com.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label_advice_com.Location = new System.Drawing.Point(349, 147);
            this.label_advice_com.Name = "label_advice_com";
            this.label_advice_com.Size = new System.Drawing.Size(179, 24);
            this.label_advice_com.TabIndex = 42;
            this.label_advice_com.Text = "Write your comment";
            this.label_advice_com.Visible = false;
            // 
            // button_disagree_accept
            // 
            this.button_disagree_accept.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button_disagree_accept.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_disagree_accept.Location = new System.Drawing.Point(534, 138);
            this.button_disagree_accept.Name = "button_disagree_accept";
            this.button_disagree_accept.Size = new System.Drawing.Size(37, 34);
            this.button_disagree_accept.TabIndex = 44;
            this.button_disagree_accept.TabStop = false;
            this.button_disagree_accept.Text = "✔️";
            this.button_disagree_accept.UseVisualStyleBackColor = true;
            this.button_disagree_accept.Visible = false;
            this.button_disagree_accept.Click += new System.EventHandler(this.button_disagree_accept_Click);
            // 
            // button_disagree_cancel
            // 
            this.button_disagree_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button_disagree_cancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_disagree_cancel.Location = new System.Drawing.Point(575, 138);
            this.button_disagree_cancel.Name = "button_disagree_cancel";
            this.button_disagree_cancel.Size = new System.Drawing.Size(37, 34);
            this.button_disagree_cancel.TabIndex = 45;
            this.button_disagree_cancel.TabStop = false;
            this.button_disagree_cancel.Text = "❌";
            this.button_disagree_cancel.UseVisualStyleBackColor = true;
            this.button_disagree_cancel.Visible = false;
            this.button_disagree_cancel.Click += new System.EventHandler(this.button_disagree_cancel_Click);
            // 
            // label_advice_disagree
            // 
            this.label_advice_disagree.AutoSize = true;
            this.label_advice_disagree.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label_advice_disagree.Location = new System.Drawing.Point(149, 147);
            this.label_advice_disagree.Name = "label_advice_disagree";
            this.label_advice_disagree.Size = new System.Drawing.Size(379, 24);
            this.label_advice_disagree.TabIndex = 46;
            this.label_advice_disagree.Text = "Write below why you disagree with this mark";
            this.label_advice_disagree.Visible = false;
            // 
            // Form_Statistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 382);
            this.Controls.Add(this.label_advice_disagree);
            this.Controls.Add(this.button_disagree_accept);
            this.Controls.Add(this.button_disagree_cancel);
            this.Controls.Add(this.label_advice_com);
            this.Controls.Add(this.button_com_acept);
            this.Controls.Add(this.button_com_cancel);
            this.Controls.Add(this.panel_opt_vote);
            this.Controls.Add(this.comboBox_val);
            this.Controls.Add(this.panel_opt);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox_mark);
            this.Controls.Add(this.textBox_file);
            this.Controls.Add(this.but_file_next);
            this.Controls.Add(this.but_file_pr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.but_com_next);
            this.Controls.Add(this.but_com_pr);
            this.Controls.Add(this.textBox_comm);
            this.Controls.Add(this.but_mark_next);
            this.Controls.Add(this.but_mark_pr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_opt);
            this.Controls.Add(this.button_open_stngs);
            this.MinimumSize = new System.Drawing.Size(612, 383);
            this.Name = "Form_Statistic";
            this.Text = "Project statistics";
            this.Load += new System.EventHandler(this.Form_statistic_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_opt.ResumeLayout(false);
            this.panel_opt_vote.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button but_mark_pr;
        private System.Windows.Forms.Button but_mark_next;
        private System.Windows.Forms.TextBox textBox_comm;
        private System.Windows.Forms.Button but_file_del;
        private System.Windows.Forms.Button but_com_next;
        private System.Windows.Forms.Button but_com_pr;
        private System.Windows.Forms.Button but_com_del;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button but_file_next;
        private System.Windows.Forms.Button but_file_pr;
        private System.Windows.Forms.TextBox textBox_file;
        private System.Windows.Forms.TextBox textBox_mark;
        private System.Windows.Forms.Button but_mark_del;
        private System.Windows.Forms.Button but_mark_chg;
        private System.Windows.Forms.Button but_file_chg;
        private System.Windows.Forms.Button button_accept_file;
        private System.Windows.Forms.Button button_accept_mark;
        private System.Windows.Forms.Button button_file_cancel;
        private System.Windows.Forms.Button button_mark_cancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lab_db_connection;
        private System.Windows.Forms.Button button_disagree;
        private System.Windows.Forms.Button button_agree;
        private System.Windows.Forms.Panel panel_opt;
        private System.Windows.Forms.Button button_opt;
        private System.Windows.Forms.Button button_cl;
        private System.Windows.Forms.ComboBox comboBox_val;
        private System.Windows.Forms.Button button_comment;
        private System.Windows.Forms.Panel panel_opt_vote;
        private System.Windows.Forms.Button button_close_stngs;
        private System.Windows.Forms.Button button_open_stngs;
        private System.Windows.Forms.Button button_com_cancel;
        private System.Windows.Forms.Button button_com_acept;
        private System.Windows.Forms.Label label_advice_com;
        private System.Windows.Forms.Button button_disagree_accept;
        private System.Windows.Forms.Button button_disagree_cancel;
        private System.Windows.Forms.Label label_advice_disagree;
    }
}