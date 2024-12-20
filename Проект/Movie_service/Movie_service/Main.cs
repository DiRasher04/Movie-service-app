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

        public void CreateItems()
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            UserState userState = new UserState();
            userState.CheckState();
            button4.Visible = false;
            button2.Visible = false;
            if (userState.userState == UserState.States.AvtorizedAdministrator)
            {
                button4.Visible = true;
                button2.Visible = true;
            }
            else if (userState.userState == UserState.States.AvtorizedContentPartner)
            {
                button2.Visible = true;
            }
            ConnectionDB connectionDB = new ConnectionDB();
            dataGridView1.DataSource = connectionDB.SelectDB("SELECT * FROM public.\"Content\"");
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AllUsers allusersForm = new AllUsers();
            allusersForm.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyContent mycontentForm = new MyContent();
            mycontentForm.Show();
            Hide();
        }
    }
}
