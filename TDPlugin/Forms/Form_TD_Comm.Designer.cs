
namespace TDPlugin.Forms
{
    partial class Form_TD_Comm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lab_name = new System.Windows.Forms.Label();
            this.lab_val = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.but_td_pr = new System.Windows.Forms.Button();
            this.but_td_next = new System.Windows.Forms.Button();
            this.textBox_comm = new System.Windows.Forms.TextBox();
            this.but_td_del = new System.Windows.Forms.Button();
            this.but_com_next = new System.Windows.Forms.Button();
            this.but_com_pr = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.but_com_del = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // lab_name
            // 
            this.lab_name.AutoSize = true;
            this.lab_name.Location = new System.Drawing.Point(70, 11);
            this.lab_name.Name = "lab_name";
            this.lab_name.Size = new System.Drawing.Size(0, 13);
            this.lab_name.TabIndex = 1;
            // 
            // lab_val
            // 
            this.lab_val.AutoSize = true;
            this.lab_val.Location = new System.Drawing.Point(70, 34);
            this.lab_val.Name = "lab_val";
            this.lab_val.Size = new System.Drawing.Size(0, 13);
            this.lab_val.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "avg Value";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Comments";
            // 
            // but_td_pr
            // 
            this.but_td_pr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.but_td_pr.Location = new System.Drawing.Point(12, 226);
            this.but_td_pr.Name = "but_td_pr";
            this.but_td_pr.Size = new System.Drawing.Size(34, 23);
            this.but_td_pr.TabIndex = 6;
            this.but_td_pr.Text = "<--";
            this.but_td_pr.UseVisualStyleBackColor = true;
            this.but_td_pr.Click += new System.EventHandler(this.but_td_pr_Click);
            // 
            // but_td_next
            // 
            this.but_td_next.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.but_td_next.Location = new System.Drawing.Point(52, 226);
            this.but_td_next.Name = "but_td_next";
            this.but_td_next.Size = new System.Drawing.Size(34, 23);
            this.but_td_next.TabIndex = 7;
            this.but_td_next.Text = "-->";
            this.but_td_next.UseVisualStyleBackColor = true;
            this.but_td_next.Click += new System.EventHandler(this.but_td_next_Click);
            // 
            // textBox_comm
            // 
            this.textBox_comm.Location = new System.Drawing.Point(73, 59);
            this.textBox_comm.Multiline = true;
            this.textBox_comm.Name = "textBox_comm";
            this.textBox_comm.ReadOnly = true;
            this.textBox_comm.Size = new System.Drawing.Size(249, 141);
            this.textBox_comm.TabIndex = 8;
            // 
            // but_td_del
            // 
            this.but_td_del.Location = new System.Drawing.Point(247, 226);
            this.but_td_del.Name = "but_td_del";
            this.but_td_del.Size = new System.Drawing.Size(75, 23);
            this.but_td_del.TabIndex = 11;
            this.but_td_del.Text = "Delete TD";
            this.but_td_del.UseVisualStyleBackColor = true;
            this.but_td_del.Click += new System.EventHandler(this.but_td_del_Click);
            // 
            // but_com_next
            // 
            this.but_com_next.Location = new System.Drawing.Point(19, 111);
            this.but_com_next.Name = "but_com_next";
            this.but_com_next.Size = new System.Drawing.Size(34, 23);
            this.but_com_next.TabIndex = 13;
            this.but_com_next.Text = "▼";
            this.but_com_next.UseVisualStyleBackColor = true;
            this.but_com_next.Click += new System.EventHandler(this.but_com_next_Click);
            // 
            // but_com_pr
            // 
            this.but_com_pr.Location = new System.Drawing.Point(19, 85);
            this.but_com_pr.Name = "but_com_pr";
            this.but_com_pr.Size = new System.Drawing.Size(34, 23);
            this.but_com_pr.TabIndex = 12;
            this.but_com_pr.Text = "▲";
            this.but_com_pr.UseVisualStyleBackColor = true;
            this.but_com_pr.Click += new System.EventHandler(this.but_com_pr_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // but_com_del
            // 
            this.but_com_del.Location = new System.Drawing.Point(144, 226);
            this.but_com_del.Name = "but_com_del";
            this.but_com_del.Size = new System.Drawing.Size(97, 23);
            this.but_com_del.TabIndex = 14;
            this.but_com_del.Text = "Delete Comment";
            this.but_com_del.UseVisualStyleBackColor = true;
            this.but_com_del.Click += new System.EventHandler(this.but_com_del_Click);
            // 
            // Form_TD_Comm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 261);
            this.Controls.Add(this.but_com_del);
            this.Controls.Add(this.but_com_next);
            this.Controls.Add(this.but_com_pr);
            this.Controls.Add(this.but_td_del);
            this.Controls.Add(this.textBox_comm);
            this.Controls.Add(this.but_td_next);
            this.Controls.Add(this.but_td_pr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lab_val);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lab_name);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(350, 300);
            this.MinimumSize = new System.Drawing.Size(350, 300);
            this.Name = "Form_TD_Comm";
            this.Text = "Technical depths";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lab_name;
        private System.Windows.Forms.Label lab_val;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button but_td_pr;
        private System.Windows.Forms.Button but_td_next;
        private System.Windows.Forms.TextBox textBox_comm;
        private System.Windows.Forms.Button but_td_del;
        private System.Windows.Forms.Button but_com_next;
        private System.Windows.Forms.Button but_com_pr;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button but_com_del;
    }
}