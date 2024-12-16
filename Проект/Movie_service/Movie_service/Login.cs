using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Movie_service
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private bool IsFull()
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration registrationForm = new Registration();
            registrationForm.Show();
            Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Main mainForm = new Main();
            mainForm.Show();
            Hide();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Entry(textBox1.Text, textBox2.Text);
            Profile profileForm = new Profile();
            profileForm.Show();
            Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
