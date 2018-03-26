using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace quiznia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            signUpForm signUpObj = new signUpForm();
            this.Hide();
            signUpObj.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            aboutForm aboutObj = new aboutForm();
            this.Hide();
            aboutObj.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "" || this.textBox2.Text == "")
            {
                MessageBox.Show("Invalid Entry: Fields cannot be empty!");
            }
            else
            {
                MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password='';database=csharp");

                MySqlDataAdapter adapter;

                DataTable table = new DataTable();

                adapter = new MySqlDataAdapter("SELECT * FROM users WHERE email='" + textBox1.Text + "' AND password= sha1('" + textBox2.Text + "')", connection);
                adapter.Fill(table);

                if (table.Rows.Count <= 0)
                {
                    MessageBox.Show("Error: Invalid email/password!");
                }
                else
                {
                    MessageBox.Show("Login Successful!");
                    questionBank bankObj = new questionBank();
                    foreach(DataRow item in table.Rows) {
                        bankObj._id = item[0].ToString();
                    }
                    this.Hide();
                    bankObj.Show();
                }

                table.Clear();
            }
        }
    }
}
