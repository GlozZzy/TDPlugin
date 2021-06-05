
namespace TDPlugin.Forms
{
    partial class Form_DBinfo
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
            this.tb_host = new System.Windows.Forms.TextBox();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_un = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_ps = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_change_current_connection = new System.Windows.Forms.Button();
            this.button_get_current_connection = new System.Windows.Forms.Button();
            this.tb_namebd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(62, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host";
            // 
            // tb_host
            // 
            this.tb_host.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_host.Location = new System.Drawing.Point(116, 12);
            this.tb_host.Name = "tb_host";
            this.tb_host.Size = new System.Drawing.Size(164, 29);
            this.tb_host.TabIndex = 1;
            // 
            // tb_port
            // 
            this.tb_port.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_port.Location = new System.Drawing.Point(116, 46);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(164, 29);
            this.tb_port.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(67, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // tb_un
            // 
            this.tb_un.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_un.Location = new System.Drawing.Point(116, 81);
            this.tb_un.Name = "tb_un";
            this.tb_un.Size = new System.Drawing.Size(164, 29);
            this.tb_un.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(13, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Username";
            // 
            // tb_ps
            // 
            this.tb_ps.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_ps.Location = new System.Drawing.Point(116, 116);
            this.tb_ps.Name = "tb_ps";
            this.tb_ps.Size = new System.Drawing.Size(164, 29);
            this.tb_ps.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(18, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password";
            // 
            // button_change_current_connection
            // 
            this.button_change_current_connection.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_change_current_connection.Location = new System.Drawing.Point(55, 240);
            this.button_change_current_connection.Name = "button_change_current_connection";
            this.button_change_current_connection.Size = new System.Drawing.Size(206, 39);
            this.button_change_current_connection.TabIndex = 7;
            this.button_change_current_connection.Text = "Change connection";
            this.button_change_current_connection.UseVisualStyleBackColor = true;
            this.button_change_current_connection.Click += new System.EventHandler(this.button_change_current_connection_Click);
            // 
            // button_get_current_connection
            // 
            this.button_get_current_connection.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_get_current_connection.Location = new System.Drawing.Point(55, 195);
            this.button_get_current_connection.Name = "button_get_current_connection";
            this.button_get_current_connection.Size = new System.Drawing.Size(206, 39);
            this.button_get_current_connection.TabIndex = 6;
            this.button_get_current_connection.Text = "Current connection";
            this.button_get_current_connection.UseVisualStyleBackColor = true;
            this.button_get_current_connection.Click += new System.EventHandler(this.button_get_current_connection_Click);
            // 
            // tb_namebd
            // 
            this.tb_namebd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_namebd.Location = new System.Drawing.Point(116, 151);
            this.tb_namebd.Name = "tb_namebd";
            this.tb_namebd.Size = new System.Drawing.Size(164, 29);
            this.tb_namebd.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(19, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "Name DB";
            // 
            // Form_DBinfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 296);
            this.Controls.Add(this.tb_namebd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_get_current_connection);
            this.Controls.Add(this.button_change_current_connection);
            this.Controls.Add(this.tb_ps);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_un);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_host);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(315, 335);
            this.MinimumSize = new System.Drawing.Size(315, 335);
            this.Name = "Form_DBinfo";
            this.Text = "Change current DB";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_host;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_un;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_ps;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_change_current_connection;
        private System.Windows.Forms.Button button_get_current_connection;
        private System.Windows.Forms.TextBox tb_namebd;
        private System.Windows.Forms.Label label5;
    }
}