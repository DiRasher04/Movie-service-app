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
    public partial class AllUsers : Form
    {
        public AllUsers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main mainForm = new Main();
            mainForm.Show();
            Hide();
        }

        private void AllUsers_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AllUsers_Load(object sender, EventArgs e)
        {
            ConnectionDB connectionDB = new ConnectionDB();
            dataGridView1.DataSource = connectionDB.SelectDB("SELECT * FROM public.\"User\"");
            dataGridView2.DataSource = connectionDB.SelectDB("SELECT * FROM public.\"Administrator\"");
            dataGridView3.DataSource = connectionDB.SelectDB("SELECT * FROM public.\"ContentPartner\"");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Location = new Point(12, 58);
            dataGridView1.Width = 862;
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView1.Location = new Point(12,58);
            dataGridView1.Width = 280;
            dataGridView2.Visible = true;
            dataGridView2.Location = new Point(300, 58);
            dataGridView2.Width = 280;
            dataGridView3.Visible = true;
            dataGridView3.Location = new Point(592, 58);
            dataGridView3.Width = 280;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView2.Location = new Point(12, 58);
            dataGridView2.Width = 862;
            dataGridView2.Visible = true;
            dataGridView1.Visible = false;
            dataGridView3.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView3.Location = new Point(12, 58);
            dataGridView3.Width = 862;
            dataGridView3.Visible = true;
            dataGridView2.Visible = false;
            dataGridView1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //update
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //delete
        }
    }
}
