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
        HandlerClass Hclass;

        public Form_Mark()
        {
            InitializeComponent();
            Hclass = new HandlerClass();

            var BDinfo = Hclass.get_dbinfo();
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
                var result = Hclass.mark_bad_code(filename.Text, markname.Text, comment.Text, (int)numericUpDownFrom.Value, (int)numericUpDownTo.Value);
                if (result)
                {
                    comment.Text = "";
                    MessageBox.Show("For the convenience of using this plugin, add comments like \n{// start name_issue ...bad code... //end name_issue} " +
                        "to the corresponding code", "Successfully added");
                }
                else MessageBox.Show("Some problems with db connection", "Error");
            }
        }       
    }
}
