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
    public partial class answerQuestion : Form
    {
        public string _id = "";
        public string correct_answer = "";

        public answerQuestion()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void answerQuestion_Load(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password='';database=csharp");

            MySqlDataAdapter adapter;

            DataTable table = new DataTable();

            adapter = new MySqlDataAdapter("SELECT * FROM question WHERE _id='" + this._id + "'", connection);
            adapter.Fill(table);

            foreach (DataRow item in table.Rows)
            {
                this.label5.Text = item[3].ToString();
            }

            table.Clear();

            this.getOptions();
        }

        public void getOptions()
        {
            MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password='';database=csharp");

            MySqlDataAdapter adapter;

            DataTable table = new DataTable();
            adapter = new MySqlDataAdapter("SELECT * FROM options WHERE question_id='" + this._id + "'", connection);
            adapter.Fill(table);
            int count = 1;

            foreach (DataRow item in table.Rows)
            {
                if (item[3].ToString() == "True")
                {
                    this.correct_answer = item[2].ToString();
                }

                if (count == 1)
                {
                    this.radioButton1.Text = item[2].ToString();
                }
                else if (count == 2)
                {
                    this.radioButton2.Text = item[2].ToString();
                }
                else if (count == 3)
                {
                    this.radioButton3.Text = item[2].ToString();
                }
                else if (count == 4)
                {
                    this.radioButton4.Text = item[2].ToString();
                }

                count += 1;
            }

            table.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked == false && this.radioButton2.Checked == false && this.radioButton3.Checked == false && this.radioButton4.Checked == false)
            {
                MessageBox.Show("Invalid Entry: Make sure to pick an option");
            }
            else 
            {

                if (this.radioButton1.Checked == true)
                {
                    if (this.radioButton1.Text == this.correct_answer)
                    {
                        successForm successObj = new successForm();
                        this.Hide();
                        successObj.Show();
                    }
                    else {
                        failedForm failedObj = new failedForm();
                        this.Hide();
                        failedObj.Show();
                    }
                }
                else if (this.radioButton2.Checked == true)
                {
                    if (this.radioButton2.Text == this.correct_answer)
                    {
                        successForm successObj = new successForm();
                        this.Hide();
                        successObj.Show();
                    }
                    else
                    {
                        failedForm failedObj = new failedForm();
                        this.Hide();
                        failedObj.Show();
                    }
                }
                else if (this.radioButton3.Checked == true)
                {
                    if (this.radioButton3.Text == this.correct_answer)
                    {
                        successForm successObj = new successForm();
                        this.Hide();
                        successObj.Show();
                    }
                    else
                    {
                        failedForm failedObj = new failedForm();
                        this.Hide();
                        failedObj.Show();
                    }
                }
                else if (this.radioButton4.Checked == true)
                {
                    if (this.radioButton4.Text == this.correct_answer)
                    {
                        successForm successObj = new successForm();
                        this.Hide();
                        successObj.Show();
                    }
                    else
                    {
                        failedForm failedObj = new failedForm();
                        this.Hide();
                        failedObj.Show();
                    }
                }
            }
        }
    }
}
