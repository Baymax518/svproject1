using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace svproject1
{
    public partial class searchform3 : Form
    {

        SqlConnection CON = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Baymax\Documents\Study\Sem-6\Dot Net\project\svproject1\svproject1\finaldb.mdf;Integrated Security = True");
      SqlCommand cmd = new SqlCommand();
        
        public searchform3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            aasthaincome f1 = new aasthaincome();
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            CON.Open();

            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from Aasthaincometb where ReceiverName='" + textBox1.Text + "'", CON);

            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            CON.Close();
        }

        private void searchform3_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
