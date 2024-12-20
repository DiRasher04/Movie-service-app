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
            UserState userState = new UserState();
            userState.CheckState();
            if (userState.ParseToString() == "AvtorizedUser")
            {
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                dateTimePicker1.Visible = false;

                button7.Visible = false;

                button10.Visible = false;
                ConnectionDB connectionDB = new ConnectionDB();
                connectionDB.SelectDB("");
                
            }
            else if (userState.ParseToString() == "AvtorizedAdministrator")
            {
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                dateTimePicker1.Visible = true;

                button7.Visible = true;

                button10.Visible = true;
            }
            else if (userState.ParseToString() == "AvtorizedContentPartner")
            {
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label9.Visible = true;
                dateTimePicker1.Visible = true;

            }
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string tmp = textBox7.Text;
            ConnectionDB db = new ConnectionDB();
            db.InsertDB("INSERT INTO public.\"RegistrationCode\" VALUES ('admin','" + tmp + "')");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string tmp = textBox8.Text;
            ConnectionDB db = new ConnectionDB();
            db.InsertDB("INSERT INTO public.\"RegistrationCode\" VALUES ('partner','" + tmp + "')");
        }
    }
}
