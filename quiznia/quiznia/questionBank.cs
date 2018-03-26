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
    public partial class questionBank : Form
    {
        public string _id = "";

        public questionBank()
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

        private void questionBank_Load(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password='';database=csharp");

            MySqlDataAdapter adapter;

            DataTable table = new DataTable();

            adapter = new MySqlDataAdapter("SELECT * FROM question", connection);
            adapter.Fill(table);
            dataGridView1.Rows.Clear();

             

            foreach (DataRow item in table.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[3].ToString();
            }

            table.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
            {
                MessageBox.Show("Invalid Entry: Field cannot be empty!");
            }
            else {
                answerQuestion answerObj = new answerQuestion();
                answerObj._id = this.textBox1.Text;
                this.Hide();
                answerObj.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            newQuestion questionObj = new newQuestion();
            questionObj._id = this._id;
            this.Hide();
            questionObj.Show();
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
