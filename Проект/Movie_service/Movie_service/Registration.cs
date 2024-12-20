using System;
using System.Drawing;
using System.Windows.Forms;

namespace Movie_service
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }
        private bool IsFullUser()
        {
            if (textBox2.Text == textBox3.Text && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool IsFull()
        {
            if (textBox2.Text == textBox3.Text && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Registration_Load(object sender, EventArgs e)
        {
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            dateTimePicker1.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main mainForm = new Main();
            mainForm.Show();
            Hide();
        }

        private void Registration_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            dateTimePicker1.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            dateTimePicker1.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            dateTimePicker1.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;

        }

        public bool IsTruRegCodeAdmin(string regCode)
        {
            ConnectionDB db = new ConnectionDB();
            string tmp = regCode;
            if (db.SelectDB("SELECT * FROM public.\"RegistrationCode\" WHERE (role = 'admin' AND value = '" + tmp + "')").Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsTruRegCodePartner(string regCode)
        {
            ConnectionDB db = new ConnectionDB();
            string tmp = regCode;
            if (db.SelectDB("SELECT * FROM public.\"RegistrationCode\" WHERE (role = 'partner' AND value = '" + tmp + "')").Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteCode(string regCode)
        {
            ConnectionDB connectionDB = new ConnectionDB();
            connectionDB.InsertDB("DELETE FROM public.\"RegistrationCode\" WHERE value = '" + regCode + "'");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConnectionDB connectionDB = new ConnectionDB();
            string tmpLogin = textBox1.Text;
            if (!IsTruRegCodePartner(textBox7.Text) && !IsTruRegCodeAdmin(textBox7.Text))
            {
                label10.Visible = true;
                label10.Text = "Код регистрации не подходит";
                label10.ForeColor = Color.Red;
            }
            else if (connectionDB.SelectDB("SELECT login FROM public.\"Administrator\" WHERE login = '" + tmpLogin + "' UNION SELECT login FROM public.\"User\" WHERE login = '" + tmpLogin + "' UNION SELECT login FROM public.\"ContentPartner\" WHERE login = '" + tmpLogin + "'").Rows.Count != 0)
            {
                label10.Visible = true;
                label10.Text = "Учетная запись с таким логином уже существует!";
                label10.ForeColor = Color.Red;
            }
            else if (textBox2.Text != textBox3.Text)
            {
                label10.Visible = true;
                label10.Text = "Пароли не совпадают!";
                label10.ForeColor = Color.Red;

            }
            else
            {
                if (IsFullUser() && radioButton1.Checked)
                {
                    User user = new User();
                    user.Registration(textBox1.Text, textBox2.Text);
                    label10.Visible = true;
                    label10.Text = "Регистрация пользователя прошла успешно";
                    label10.ForeColor = Color.Blue;
                }
                else if (IsFull() && radioButton2.Checked && IsTruRegCodePartner(textBox7.Text))
                {
                    ContentPartner contentPartner = new ContentPartner();
                    contentPartner.Registration(textBox1.Text, textBox2.Text, textBox4.Text, textBox5.Text, textBox6.Text, dateTimePicker1.Value);
                    label10.Visible = true;
                    DeleteCode(textBox7.Text);
                    label10.Text = "Регистрация контент-партнера прошла успешно";
                    label10.ForeColor = Color.Blue;
                }
                else if (IsFull() && radioButton3.Checked && IsTruRegCodeAdmin(textBox7.Text))
                {
                    Administrator administrator = new Administrator();
                    administrator.Registration(textBox1.Text, textBox2.Text, textBox4.Text, textBox5.Text, textBox6.Text, dateTimePicker1.Value);
                    label10.Visible = true;
                    DeleteCode(textBox7.Text);
                    label10.Text = "Регистрация администратора прошла успешно";
                    label10.ForeColor = Color.Blue;
                }
                else
                {
                    label10.Text = "Заполните все поля!";
                    label10.ForeColor = Color.Red;
                    label10.Visible = true;
                }
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
