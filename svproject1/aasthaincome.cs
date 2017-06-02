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
    public partial class aasthaincome : Form
    {
        SqlConnection CON = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Baymax\Documents\Study\Sem-6\Dot Net\project\svproject1\svproject1\finaldb.mdf;Integrated Security = True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adapt;
        public aasthaincome()
        {
            InitializeComponent();
            Displaydata();
            defaultsrno();
        }

        private void aasthaincome_Load(object sender, EventArgs e)
        {
         //   this.TopMost = true;

            this.WindowState = FormWindowState.Maximized;
        }
       

        //INSERT BUTTON
        private void button2_Click(object sender, EventArgs e)
        {
            CON.Open();
            calc();
            cmd = new SqlCommand("insert into Aasthaincometb(ReceiverName,Service,Weight,Amountforcustomer,Customerpaid,Payingtoservice,Perkgrs,Customerpaymentremaining,Income) values(@recievername,@servicec,@weight,@camount,@cpaid,@spaid,@perkg,@remaining,@income)", CON);


           
            cmd.Parameters.AddWithValue("@recievername", textBox2.Text);
            cmd.Parameters.AddWithValue("@servicec", comboBox1.Text);
            cmd.Parameters.AddWithValue("@weight", textBox3.Text);
            cmd.Parameters.AddWithValue("@camount", textBox4.Text);
            cmd.Parameters.AddWithValue("@cpaid", textBox5.Text);
            cmd.Parameters.AddWithValue("@spaid", textBox6.Text);
            cmd.Parameters.AddWithValue("@perkg", textBox7.Text);
            cmd.Parameters.AddWithValue("@remaining", textBox8.Text);
            cmd.Parameters.AddWithValue("@income", textBox9.Text);
            cmd.ExecuteNonQuery();

            CON.Close();
            Displaydata();
            MessageBox.Show("Saved Successfully!!!!!!!");
            cleardata();
             defaultsrno();
        }
        private void Displaydata()
        {
            CON.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from Aasthaincometb", CON);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            CON.Close();
        }
        //DEFAULT SRNO 

        public void defaultsrno()
        {
            cmd = new SqlCommand("select MAX(Srno) from Aasthaincometb", CON);
            CON.Open();

            SqlDataReader dr1 = cmd.ExecuteReader();
            if (dr1.Read())
            {
                var asrno = dr1.GetValue(0).ToString();
                var isrno = int.Parse(asrno);
                var fsrno = (isrno + 1);
                textBox1.Text = fsrno.ToString();
            }
            CON.Close();
        }

        //Calculated value
        public void calc()
        {
             var wei = textBox3.Text;
            var cusamo = textBox4.Text;
            var cupaid = textBox5.Text;
            var clipaid = textBox6.Text;
            var perkg = Convert.ToInt32(cusamo) / Convert.ToInt32(wei);
            var curemain = Convert.ToInt32(cusamo) - Convert.ToInt32(cupaid);
            var fincome = Convert.ToInt32(cusamo) - Convert.ToInt32(clipaid);
            textBox7.Text = perkg.ToString();
            textBox8.Text = curemain.ToString();
            textBox9.Text = fincome.ToString();
   
        }

        //UPDATE QUERY
        private void button3_Click(object sender, EventArgs e)
        {
        calc();
                cmd = new SqlCommand("update Aasthaincometb set ReceiverName=@rname,Service=@servicec,Weight=@weight,Amountforcustomer=@camount,Customerpaid=@cpaid,Payingtoservice=@spaid,Perkgrs=@perkg,Customerpaymentremaining=@remaining,Income=@income where Srno=@srno", CON);
          //  cmd = new SqlCommand("update Aasthaincometb set ReceiverName=@rname where Srno=@srno", CON);
            CON.Open();
            
            cmd.Parameters.AddWithValue("@srno", textBox1.Text);
            cmd.Parameters.AddWithValue("@rname", textBox2.Text);
            cmd.Parameters.AddWithValue("@servicec", comboBox1.Text);
            cmd.Parameters.AddWithValue("@weight", textBox3.Text);
            cmd.Parameters.AddWithValue("@camount", textBox4.Text);
            cmd.Parameters.AddWithValue("@cpaid", textBox5.Text);
            cmd.Parameters.AddWithValue("@spaid", textBox6.Text);
            cmd.Parameters.AddWithValue("@perkg", textBox7.Text);
            cmd.Parameters.AddWithValue("@remaining", textBox8.Text);
            cmd.Parameters.AddWithValue("@income", textBox9.Text);
            cmd.ExecuteNonQuery();

            CON.Close();
            Displaydata();
            MessageBox.Show("Saved Successfully!!!!!!!");
            //cleardata();
           // defaultsrno();
        }

        //DELETE BUTTON'
        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to DELETE data?", "Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {
                cmd = new SqlCommand("delete Aasthaincometb where Srno=@srno", CON);
                CON.Open();
                cmd.Parameters.AddWithValue("@srno", textBox1.Text);
                cmd.ExecuteNonQuery();
                CON.Close();
                MessageBox.Show("Record Deleted successfully!!!");
                Displaydata();
               // cleardata();
            }
        }

        //SEARCH BUTTON
        private void button5_Click(object sender, EventArgs e)
        {
            CON.Open();

            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from Aasthaincometb where ReceiverName='" + textBox2.Text + "'", CON);

            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            CON.Close();

        }

       
        //ROW CLICK EVENT

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
          //  MessageBox.Show("row clicked");
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                //do you staff.
                MessageBox.Show("row clicked");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("CEll Double_Click event calls");
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            textBox5.Text = row.Cells[1].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
          
            cmd = new SqlCommand("select * from Aasthaincometb where Srno='" + textBox1.Text + "'", CON);
            CON.Open();

            SqlDataReader dr1 = cmd.ExecuteReader();
            if (dr1.Read())
            {
               
                textBox2.Text = dr1.GetValue(1).ToString();
                comboBox1.Text=dr1.GetValue(2).ToString();
                textBox3.Text = dr1.GetValue(3).ToString();
                textBox4.Text = dr1.GetValue(4).ToString();
                textBox5.Text = dr1.GetValue(5).ToString();
                textBox6.Text = dr1.GetValue(6).ToString();


            }
            CON.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            aasthaselect f1 = new aasthaselect();
            f1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            searchform3 f1 = new searchform3();
            f1.Show();
            
        }

        void cleardata()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            comboBox1.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
