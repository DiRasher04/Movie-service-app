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
    public partial class Main : Form
    {
        public string state = null;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            UserState userState = new UserState();
            userState.CheckState();
            label2.Text = userState.ParseToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserState userState = new UserState();
            userState.CheckState();
            if (userState.ParseToString() == "NotAvtorized")
            {
                Login loginForm = new Login();
                loginForm.Show();
                Hide();
            }
            else if (userState.ParseToString() == "AvtorizedUser")
            {
                Profile profileForm = new Profile();
                profileForm.Show();
                Hide();
            }
            else if (userState.ParseToString() == "AvtorizedAdministrator")
            {
                Profile profileForm = new Profile();
                profileForm.Show();
                Hide();
            }
            else if (userState.ParseToString() == "AvtorizedContentPartner")
            {
                Profile profileForm = new Profile();
                profileForm.Show();
                Hide();
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Main_ForeColorChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            ConnectionDB connectionDB = new ConnectionDB();
            DataTable db = connectionDB.SelectDB("SELECT * FROM public.\"User\"\r\nORDER BY user_id ASC ");
            dataGridView1.DataSource = db;  
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            UserState userState = new UserState();
            userState.Exit();
        }
    }
}
