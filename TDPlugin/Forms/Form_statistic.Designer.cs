
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
            this.lab_mark_avg = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.but_mark_pr = new System.Windows.Forms.Button();
            this.but_mark_next = new System.Windows.Forms.Button();
            this.textBox_comm = new System.Windows.Forms.TextBox();
            this.but_file_del = new System.Windows.Forms.Button();
            this.but_com_next = new System.Windows.Forms.Button();
            this.but_com_pr = new System.Windows.Forms.Button();
            this.but_com_del = new System.Windows.Forms.Button();
            this.lab_file_avg = new System.Windows.Forms.Label();
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
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lab_db_connection = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
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
            // lab_mark_avg
            // 
            this.lab_mark_avg.AutoSize = true;
            this.lab_mark_avg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lab_mark_avg.Location = new System.Drawing.Point(348, 70);
            this.lab_mark_avg.Name = "lab_mark_avg";
            this.lab_mark_avg.Size = new System.Drawing.Size(40, 24);
            this.lab_mark_avg.TabIndex = 1;
            this.lab_mark_avg.Text = "???";
            this.lab_mark_avg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label4.Location = new System.Drawing.Point(322, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "avg value";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label6.Location = new System.Drawing.Point(12, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 24);
            this.label6.TabIndex = 4;
            this.label6.Text = "Comments";
            // 
            // but_mark_pr
            // 
            this.but_mark_pr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.but_mark_pr.Location = new System.Drawing.Point(402, 67);
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
            this.but_mark_next.Location = new System.Drawing.Point(450, 67);
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
            this.textBox_comm.Location = new System.Drawing.Point(55, 133);
            this.textBox_comm.Multiline = true;
            this.textBox_comm.Name = "textBox_comm";
            this.textBox_comm.ReadOnly = true;
            this.textBox_comm.Size = new System.Drawing.Size(440, 124);
            this.textBox_comm.TabIndex = 8;
            this.textBox_comm.TabStop = false;
            // 
            // but_file_del
            // 
            this.but_file_del.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.but_file_del.Location = new System.Drawing.Point(364, 304);
            this.but_file_del.Name = "but_file_del";
            this.but_file_del.Size = new System.Drawing.Size(131, 35);
            this.but_file_del.TabIndex = 11;
            this.but_file_del.TabStop = false;
            this.but_file_del.Text = "Delete File";
            this.but_file_del.UseVisualStyleBackColor = true;
            this.but_file_del.Click += new System.EventHandler(this.but_file_del_Click);
            // 
            // but_com_next
            // 
            this.but_com_next.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.but_com_next.Location = new System.Drawing.Point(10, 200);
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
            this.but_com_pr.Location = new System.Drawing.Point(10, 162);
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
            this.but_com_del.Location = new System.Drawing.Point(55, 304);
            this.but_com_del.Name = "but_com_del";
            this.but_com_del.Size = new System.Drawing.Size(159, 35);
            this.but_com_del.TabIndex = 14;
            this.but_com_del.TabStop = false;
            this.but_com_del.Text = "Delete Comment";
            this.but_com_del.UseVisualStyleBackColor = true;
            this.but_com_del.Click += new System.EventHandler(this.but_com_del_Click);
            // 
            // lab_file_avg
            // 
            this.lab_file_avg.AutoSize = true;
            this.lab_file_avg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lab_file_avg.Location = new System.Drawing.Point(348, 35);
            this.lab_file_avg.Name = "lab_file_avg";
            this.lab_file_avg.Size = new System.Drawing.Size(40, 24);
            this.lab_file_avg.TabIndex = 16;
            this.lab_file_avg.Text = "???";
            this.lab_file_avg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.but_file_next.Location = new System.Drawing.Point(450, 32);
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
            this.but_file_pr.Location = new System.Drawing.Point(402, 32);
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
            this.but_mark_del.Location = new System.Drawing.Point(220, 304);
            this.but_mark_del.Name = "but_mark_del";
            this.but_mark_del.Size = new System.Drawing.Size(138, 35);
            this.but_mark_del.TabIndex = 21;
            this.but_mark_del.TabStop = false;
            this.but_mark_del.Text = "Delete Mark";
            this.but_mark_del.UseVisualStyleBackColor = true;
            this.but_mark_del.Click += new System.EventHandler(this.but_mark_del_Click);
            // 
            // but_mark_chg
            // 
            this.but_mark_chg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.but_mark_chg.Location = new System.Drawing.Point(55, 263);
            this.but_mark_chg.Name = "but_mark_chg";
            this.but_mark_chg.Size = new System.Drawing.Size(216, 35);
            this.but_mark_chg.TabIndex = 24;
            this.but_mark_chg.TabStop = false;
            this.but_mark_chg.Text = "Change Mark name";
            this.but_mark_chg.UseVisualStyleBackColor = true;
            this.but_mark_chg.Click += new System.EventHandler(this.but_mark_chg_Click);
            // 
            // but_file_chg
            // 
            this.but_file_chg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.but_file_chg.Location = new System.Drawing.Point(277, 263);
            this.but_file_chg.Name = "but_file_chg";
            this.but_file_chg.Size = new System.Drawing.Size(218, 35);
            this.but_file_chg.TabIndex = 22;
            this.but_file_chg.TabStop = false;
            this.but_file_chg.Text = "Change File name";
            this.but_file_chg.UseVisualStyleBackColor = true;
            this.but_file_chg.Click += new System.EventHandler(this.but_file_chg_Click);
            // 
            // button_accept_file
            // 
            this.button_accept_file.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.button_accept_file.Location = new System.Drawing.Point(277, 263);
            this.button_accept_file.Name = "button_accept_file";
            this.button_accept_file.Size = new System.Drawing.Size(218, 35);
            this.button_accept_file.TabIndex = 25;
            this.button_accept_file.TabStop = false;
            this.button_accept_file.Text = "Accept";
            this.button_accept_file.UseVisualStyleBackColor = true;
            this.button_accept_file.Click += new System.EventHandler(this.button_accept_file_Click);
            // 
            // button_accept_mark
            // 
            this.button_accept_mark.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.button_accept_mark.Location = new System.Drawing.Point(55, 263);
            this.button_accept_mark.Name = "button_accept_mark";
            this.button_accept_mark.Size = new System.Drawing.Size(216, 35);
            this.button_accept_mark.TabIndex = 26;
            this.button_accept_mark.TabStop = false;
            this.button_accept_mark.Text = "Accept";
            this.button_accept_mark.UseVisualStyleBackColor = true;
            this.button_accept_mark.Click += new System.EventHandler(this.button_accept_mark_Click);
            // 
            // button_file_cancel
            // 
            this.button_file_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.button_file_cancel.Location = new System.Drawing.Point(55, 263);
            this.button_file_cancel.Name = "button_file_cancel";
            this.button_file_cancel.Size = new System.Drawing.Size(216, 35);
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
            this.button_mark_cancel.Location = new System.Drawing.Point(277, 263);
            this.button_mark_cancel.Name = "button_mark_cancel";
            this.button_mark_cancel.Size = new System.Drawing.Size(216, 35);
            this.button_mark_cancel.TabIndex = 28;
            this.button_mark_cancel.TabStop = false;
            this.button_mark_cancel.Text = "Cancel";
            this.button_mark_cancel.UseVisualStyleBackColor = true;
            this.button_mark_cancel.Visible = false;
            this.button_mark_cancel.Click += new System.EventHandler(this.button_mark_cancel_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(10, 304);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 35);
            this.button1.TabIndex = 29;
            this.button1.TabStop = false;
            this.button1.Text = "🗘";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lab_db_connection);
            this.panel1.Location = new System.Drawing.Point(10, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 18);
            this.panel1.TabIndex = 31;
            // 
            // lab_db_connection
            // 
            this.lab_db_connection.AutoSize = true;
            this.lab_db_connection.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lab_db_connection.Dock = System.Windows.Forms.DockStyle.Right;
            this.lab_db_connection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab_db_connection.ForeColor = System.Drawing.Color.Blue;
            this.lab_db_connection.Location = new System.Drawing.Point(407, 0);
            this.lab_db_connection.Name = "lab_db_connection";
            this.lab_db_connection.Size = new System.Drawing.Size(78, 13);
            this.lab_db_connection.TabIndex = 13;
            this.lab_db_connection.Text = "db_connection";
            this.lab_db_connection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form_statistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 349);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_mark_cancel);
            this.Controls.Add(this.button_file_cancel);
            this.Controls.Add(this.but_mark_chg);
            this.Controls.Add(this.but_file_chg);
            this.Controls.Add(this.but_mark_del);
            this.Controls.Add(this.textBox_mark);
            this.Controls.Add(this.textBox_file);
            this.Controls.Add(this.but_file_next);
            this.Controls.Add(this.but_file_pr);
            this.Controls.Add(this.lab_file_avg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.but_com_del);
            this.Controls.Add(this.but_com_next);
            this.Controls.Add(this.but_com_pr);
            this.Controls.Add(this.but_file_del);
            this.Controls.Add(this.textBox_comm);
            this.Controls.Add(this.but_mark_next);
            this.Controls.Add(this.but_mark_pr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lab_mark_avg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_accept_file);
            this.Controls.Add(this.button_accept_mark);
            this.MaximumSize = new System.Drawing.Size(525, 388);
            this.MinimumSize = new System.Drawing.Size(525, 388);
            this.Name = "Form_statistic";
            this.Text = "Project statistics";
            this.Load += new System.EventHandler(this.Form_statistic_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lab_mark_avg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button but_mark_pr;
        private System.Windows.Forms.Button but_mark_next;
        private System.Windows.Forms.TextBox textBox_comm;
        private System.Windows.Forms.Button but_file_del;
        private System.Windows.Forms.Button but_com_next;
        private System.Windows.Forms.Button but_com_pr;
        private System.Windows.Forms.Button but_com_del;
        private System.Windows.Forms.Label lab_file_avg;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lab_db_connection;
    }
}