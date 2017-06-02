using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace svproject1
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "sv_int" && textBox2.Text == "keval2809")
            {
                this.Hide();
                formselect fs = new formselect();
                fs.ShowDialog();

            }

            else if (textBox1.Text == "sv_int" && textBox2.Text == "ravi2208")
            {
                this.Hide();
                formselect fs = new formselect();
                fs.ShowDialog();

            }

            else
                MessageBox.Show("Enter Valid Username and Password");
        }

        private void button2_Click(object sender, EventArgs e)
        {
/*            LoginPage log = new LoginPage();
            this.Close();
            log.Show();*/
            if(MessageBox.Show("Are you sure you want to EXIT Programme?","Exit",MessageBoxButtons.OKCancel)==DialogResult.OK)

            {
                Application.Exit();
            }
                       }
    }
}
