using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BUGTracker_optimised
{
    public partial class Form2 : Form
    {
        MySqlConnection sqlConn = new MySqlConnection();
        MySqlCommand sqlCmd = new MySqlCommand();
        DataTable sqlDt = new DataTable();
        String sqlQuery;
        MySqlDataAdapter DtA = new MySqlDataAdapter();
        MySqlDataReader sqlRd;

        DataSet DS = new DataSet();

        String server = "localhost";
        String username = "root";
        String password = "";
        String database = "bugs";

        public Form2()
        {
            InitializeComponent();
        }

        private void upLoadData()
        {

            string servernameulet;
            string usernameulet;
            string databasenameulet;
            string passwordulet;
            servernameulet = this.label5servername.Text;
            databasenameulet = this.label4databasename.Text;
            usernameulet = this.label5username.Text;
            passwordulet = this.label6parola.Text;

            sqlConn.ConnectionString = "server=" + servernameulet + ";" + "user id=" + usernameulet + ";" + "password=" + passwordulet + ";" + "database=" + databasenameulet;

            sqlConn.Open();
            sqlCmd.Connection = sqlConn;

            sqlCmd.CommandText = "SELECT * FROM bugs.tracker";

            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlConn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string servernameulet;
            string usernameulet;
            string databasenameulet;
            string passwordulet;
            servernameulet = this.label5servername.Text;
            databasenameulet = this.label4databasename.Text;
            usernameulet = this.label5username.Text;
            passwordulet = this.label6parola.Text;


            string textulet = textBox1.Text;
            sqlConn.ConnectionString = "server=" + servernameulet + ";" + "user id=" + usernameulet + ";" + "password=" + passwordulet + ";" + "database=" + databasenameulet;

            try
            {
                sqlConn.Open();
                sqlQuery = "insert into bugs.tracker (ID, Bug)" + "values('" + textBox2.Text + "', '" + textBox1.Text + "')";

                MessageBox.Show("Database Conectat\nID-ul: " + textBox2.Text + " a lansat BUG-ul\n" + textulet, "Bug Tracker");

                sqlCmd = new MySqlCommand(sqlQuery, sqlConn);
                sqlRd = sqlCmd.ExecuteReader();

                sqlConn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConn.Close();
            }
            upLoadData();
        }

        private void label4databasename_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            try
            {
                iExit = MessageBox.Show("Confirm you want to return", "Bug Tracker", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (iExit == DialogResult.Yes)
                {
                    this.Close();

                    Form1 f1 = new Form1();
                    f1.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost/databasebug/datab.php");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            upLoadData();
        }
    }
}
