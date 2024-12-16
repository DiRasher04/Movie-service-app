using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Movie_service
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void Profile_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            UserState userState = new UserState();
            userState.Exit();
            Login loginForm = new Login();
            loginForm.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main mainForm = new Main();
            mainForm.Show();
            Hide();
        }
    }
}
