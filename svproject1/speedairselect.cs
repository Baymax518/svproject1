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
    public partial class speedairselect : Form
    {
        public speedairselect()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SpeedairRecordBook spa = new SpeedairRecordBook();
            spa.ShowDialog();
        }

        private void speedairselect_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            formselect f1 = new formselect();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            speedairincome f1 = new speedairincome();
            f1.Show();
        }
    }
}
