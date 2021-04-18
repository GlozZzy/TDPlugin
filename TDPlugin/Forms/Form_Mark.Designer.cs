
namespace TDPlugin.Forms
{
    partial class Form_Mark
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.num_val = new System.Windows.Forms.NumericUpDown();
            this.namemarkTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.commentTB = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_val)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Your comment";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name mark";
            // 
            // num_val
            // 
            this.num_val.Location = new System.Drawing.Point(85, 53);
            this.num_val.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.num_val.Name = "num_val";
            this.num_val.Size = new System.Drawing.Size(57, 20);
            this.num_val.TabIndex = 5;
            // 
            // namemarkTB
            // 
            this.namemarkTB.Location = new System.Drawing.Point(85, 26);
            this.namemarkTB.Name = "namemarkTB";
            this.namemarkTB.Size = new System.Drawing.Size(153, 20);
            this.namemarkTB.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Value";
            // 
            // commentTB
            // 
            this.commentTB.Location = new System.Drawing.Point(89, 82);
            this.commentTB.Multiline = true;
            this.commentTB.Name = "commentTB";
            this.commentTB.Size = new System.Drawing.Size(153, 138);
            this.commentTB.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(167, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Accept";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_Mark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.commentTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.num_val);
            this.Controls.Add(this.namemarkTB);
            this.MaximumSize = new System.Drawing.Size(280, 300);
            this.MinimumSize = new System.Drawing.Size(280, 300);
            this.Name = "Form_Mark";
            this.Text = "Mark bad code";
            ((System.ComponentModel.ISupportInitialize)(this.num_val)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown num_val;
        private System.Windows.Forms.TextBox namemarkTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox commentTB;
        private System.Windows.Forms.Button button1;
    }
}