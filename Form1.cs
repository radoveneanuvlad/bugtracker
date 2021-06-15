using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUGTracker_optimised
{
    public partial class Form1 : Form
    {
        string servername;
        string databasename;
        string username;
        string password;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            servername = this.textBoxSERVER.Text;
            databasename = this.textBoxDATABASE.Text;
            username = this.textBoxUSERNAME.Text;
            password = this.textBoxPASSWORD.Text;

            Form2 f2 = new Form2();

            f2.label5servername.Text = servername;
            f2.label4databasename.Text = databasename;
            f2.label5username.Text = username;
            f2.label6parola.Text = password;

            f2.Show();

            this.Hide();
        }
    }
}
