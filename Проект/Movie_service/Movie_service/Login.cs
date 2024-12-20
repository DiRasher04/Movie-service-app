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
            ConnectionDB connectionDB = new ConnectionDB();
            string tmpLogin = textBox1.Text;
            if (connectionDB.SelectDB("SELECT role FROM public.\"User\" WHERE login = '" + tmpLogin + "' UNION SELECT role FROM public.\"Administrator\" WHERE login = '" + tmpLogin + "' UNION SELECT role FROM public.\"ContentPartner\" WHERE login = '" + tmpLogin + "'").Rows[0]["role"].ToString() == "user")
            {
                User user = new User();
                user.Entry(textBox1.Text, textBox2.Text);
                Profile profileForm = new Profile();
                profileForm.Show();
                Hide();
            }
            else if (connectionDB.SelectDB("SELECT role FROM public.\"User\" WHERE login = '" + tmpLogin + "' UNION SELECT role FROM public.\"Administrator\" WHERE login = '" + tmpLogin + "' UNION SELECT role FROM public.\"ContentPartner\" WHERE login = '" + tmpLogin + "'").Rows[0]["role"].ToString() == "administrator")
            {
                Administrator administrator = new Administrator();
                administrator.Entry(textBox1.Text, textBox2.Text);
                Profile profileForm = new Profile();
                profileForm.Show();
                Hide();
            }
            else if (connectionDB.SelectDB("SELECT role FROM public.\"User\" WHERE login = '" + tmpLogin + "' UNION SELECT role FROM public.\"Administrator\" WHERE login = '" + tmpLogin + "' UNION SELECT role FROM public.\"ContentPartner\" WHERE login = '" + tmpLogin + "'").Rows[0]["role"].ToString() == "contentpartner")
            {
                ContentPartner contentPartner = new ContentPartner();
                contentPartner.Entry(textBox1.Text, textBox2.Text);
                Profile profileForm = new Profile();
                profileForm.Show();
                Hide();
            }
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
