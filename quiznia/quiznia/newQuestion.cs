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
    public partial class newQuestion : Form
    {
        public string _id = "";
        public string question_id = "";

        public newQuestion()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 formObj = new Form1();
            this.Hide();
            formObj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            questionBank questionObj = new questionBank();
            this.Hide();
            questionObj.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "" || this.textBox2.Text == "" || this.textBox3.Text == "" || this.textBox4.Text == "" || this.textBox5.Text == "" || this.textBox6.Text == "" || this.textBox7.Text == "")
            {
                MessageBox.Show("Invalid Entry: Field(s) cannot be empty!");
            }
            else 
            {
                string connectionString = "datasource=127.0.0.1;port=3306;username=root;password='';database=csharp";
                string query = "INSERT INTO question VALUES ('', '" + this._id + "', '" + this.textBox6.Text + "', '" + this.textBox7.Text + "', '" + this.textBox1.Text + "')";

                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;

                try
                {
                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();
                    this.textBox1.Text = "";
                    this.textBox6.Text = "";
                    this.textBox7.Text = "";

                    this.addOptions();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void addOptions() {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password='';database=csharp";

            MySqlDataAdapter adapter;

            DataTable table = new DataTable();

            adapter = new MySqlDataAdapter("SELECT * FROM question order by _id desc", connectionString);
            adapter.Fill(table);

            foreach (DataRow item in table.Rows)
            {
                this.question_id = item[0].ToString();
                break;
            }

            table.Clear();


            string query = "INSERT INTO options VALUES ('', '" + this.question_id + "', '" + this.textBox2.Text + "', '" + this.radioButton1.Checked + "'), ('', '" + this.question_id + "', '" + this.textBox3.Text + "', '" + this.radioButton2.Checked + "'), ('', '" + this.question_id + "', '" + this.textBox4.Text + "', '" + this.radioButton3.Checked + "'), ('', '" + this.question_id + "', '" + this.textBox5.Text + "', '" + this.radioButton4.Checked + "')";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox4.Text = "";
                this.textBox5.Text = "";

                questionBank questionObj = new questionBank();
                MessageBox.Show("Question Successfully Created!");
                this.Hide();
                questionObj.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myQuestions formObj = new myQuestions();
            formObj._id = this._id;
            this.Hide();
            formObj.Show();
        }
    }
}
