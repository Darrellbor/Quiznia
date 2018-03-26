using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace quiznia
{
    public partial class failedForm : Form
    {
        public failedForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            questionBank questionObj = new questionBank();
            this.Hide();
            questionObj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            questionBank questionObj = new questionBank();
            this.Hide();
            questionObj.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 formObj = new Form1();
            this.Hide();
            formObj.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
