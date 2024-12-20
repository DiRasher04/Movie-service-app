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
    public partial class MyContent : Form
    {
        public MyContent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main mainForm = new Main();
            mainForm.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateContent createContentForm = new CreateContent();
            createContentForm.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DetailsMyContent detailsMyContentForm = new DetailsMyContent();
            detailsMyContentForm.Show();
            Hide();
        }

        private void MyContent_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }
    }
}
