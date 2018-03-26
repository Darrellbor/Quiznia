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
    public partial class aboutForm : Form
    {
        public aboutForm()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 formObj = new Form1();
            this.Hide();
            formObj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            signUpForm signUpObj = new signUpForm();
            this.Hide();
            signUpObj.Show();
        }
    }
}
