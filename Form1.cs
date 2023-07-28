using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Enabled = false;
            QuestionsForms Frm = new QuestionsForms();
            Frm.Show();
        }

        private void maskedTextBox1_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(maskedTextBox1.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(maskedTextBox1, "This is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(maskedTextBox1, "");
            }
        }

        private void maskedTextBox2_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(maskedTextBox2.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(maskedTextBox2, "This is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(maskedTextBox2, "");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Focus();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Please check with your admin", "Message Box",
                MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }
    }
}
