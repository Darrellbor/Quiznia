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
    public partial class signUpForm : Form
    {
        public signUpForm()
        {
            InitializeComponent();
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 formObj = new Form1();
            this.Hide();
            formObj.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            aboutForm aboutObj = new aboutForm();
            this.Hide();
            aboutObj.Show();
        }

        private void sidePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "" || this.textBox2.Text == "" || this.textBox3.Text == "" || this.textBox4.Text == "" || this.textBox5.Text == "")
            {
                MessageBox.Show("Invalid Entry: Fields cannot be empty!");
            }
            else if (this.textBox2.Text != this.textBox3.Text)
            {
                MessageBox.Show("Invalid Entry: Password fields do not match!");
            }
            else {
                string connectionString = "datasource=127.0.0.1;port=3306;username=root;password='';database=csharp";
                string query = "INSERT INTO users VALUES ('', '" + this.textBox4.Text + "', '" + this.textBox5.Text + "', '" + this.textBox1.Text + "', sha1('" + this.textBox2.Text + "'))";

                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;

                try {
                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();
                    this.textBox1.Text = "";
                    this.textBox2.Text = "";
                    this.textBox3.Text = "";
                    this.textBox4.Text = "";
                    this.textBox5.Text = "";

                    MessageBox.Show("Sign Up Successful!");
                    questionBank bankObj = new questionBank();
                    this.Hide();
                    bankObj.Show();
                } catch(Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
