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
    public partial class Form1 : Form
    {
        SqlConnection CON = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Baymax\Documents\Study\Sem-6\Dot Net\project\svproject1\svproject1\finaldb.mdf;Integrated Security = True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adapt;
        
        
        public Form1()
        {
            InitializeComponent();
           
            Displaydata();
            radioButton1.Checked = true;
            defaultsrno();
            Displaydata();
            cleardata();



        }

        
       
        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          //  this.TopMost = true;

            this.WindowState = FormWindowState.Maximized;
        }

        //INSERT QUERY
        private void button1_Click(object sender, EventArgs e)
        {
            String del = "";
            cmd = new SqlCommand("insert into RecordBookTable(/*/*Srno*/,*/SenderName,ReceiverName,AWBno,Destination,StateCode,Weight,NoOfBox,Service,TrackingNo,Delivered,DateOfDelivery,ExpectedDateOfDelivery,Note) values(/*@srno,*/@sendername,@recievername,@awbno,@destination,@statecode,@weight,@noofbox,@service,@trackingno,@delivered,@dateofdelivery,@expecteddateofdelivery,@note)", CON); 
                CON.Open();

            if(radioButton1.Checked==true)
            { del = "NO"; }
            else
            { del = "YES"; }

         //   cmd.Parameters.AddWithValue("@srno",textBox1.Text);
            cmd.Parameters.AddWithValue("@sendername",textBox2.Text);
            cmd.Parameters.AddWithValue("@recievername",textBox3.Text);
            cmd.Parameters.AddWithValue("@awbno",textBox4.Text);
            cmd.Parameters.AddWithValue("@destination",textBox7.Text);
            cmd.Parameters.AddWithValue("@statecode",textBox8.Text);
            cmd.Parameters.AddWithValue("@weight",textBox9.Text);
            cmd.Parameters.AddWithValue("@noofbox",textBox10.Text);
            cmd.Parameters.AddWithValue("@service",comboBox1.Text);
            cmd.Parameters.AddWithValue("@trackingno",textBox12.Text);
            cmd.Parameters.AddWithValue("@delivered",del);
            cmd.Parameters.AddWithValue("@dateofdelivery",textBox5.Text);
            cmd.Parameters.AddWithValue("@expecteddateofdelivery",textBox6.Text);
            cmd.Parameters.AddWithValue("@note",richTextBox1.Text);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Saved Successfully!!!!!!!");
            CON.Close();
            Displaydata();
            cleardata();
            defaultsrno();




        }



      //UPDATE BUTTON

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to UPDATE data?", "Update", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {
                String del = "";
                cmd = new SqlCommand("update RecordBookTable set SenderName=@sendername,ReceiverName=@recievername,AWBno=@awbno,Destination=@destination,StateCode=@statecode,Weight=@weight,NoOfBox=@noofbox,Service=@service,TrackingNo=@trackingno,Delivered=@delivered,DateOfDelivery=@dateofdelivery,ExpectedDateOfDelivery=@expecteddateofdelivery,Note=@note where Srno=@srno", CON);
                CON.Open();
                if (radioButton1.Checked == true)
                { del = "NO"; }
                else
                { del = "YES"; }

                cmd.Parameters.AddWithValue("@srno", textBox1.Text);
                cmd.Parameters.AddWithValue("@sendername", textBox2.Text);
                cmd.Parameters.AddWithValue("@recievername", textBox3.Text);
                cmd.Parameters.AddWithValue("@awbno", textBox4.Text);
                cmd.Parameters.AddWithValue("@destination", textBox7.Text);
                cmd.Parameters.AddWithValue("@statecode", textBox8.Text);
                cmd.Parameters.AddWithValue("@weight", textBox9.Text);
                cmd.Parameters.AddWithValue("@noofbox", textBox10.Text);
                cmd.Parameters.AddWithValue("@service", comboBox1.Text);
                cmd.Parameters.AddWithValue("@trackingno", textBox12.Text);
                cmd.Parameters.AddWithValue("@delivered", del);
                cmd.Parameters.AddWithValue("@dateofdelivery", textBox5.Text);
                cmd.Parameters.AddWithValue("@expecteddateofdelivery", textBox6.Text);
                cmd.Parameters.AddWithValue("@note", richTextBox1.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("data updated!!");
                CON.Close();
                Displaydata();
                cleardata();
                defaultsrno();
            }
        }

       //DISPLAY DATA
        private void Displaydata()
        {
            CON.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from RecordBookTable", CON);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            CON.Close();
        }

        public void cleardata()
        {
          //  textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
           // comboBox1.
            textBox12.Clear();
         
            richTextBox1.Clear();
        }

        public void defaultsrno()
        {
            cmd = new SqlCommand("select MAX(Srno) from RecordBookTable", CON);
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to DELETE data?", "Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {
                cmd = new SqlCommand("delete RecordBookTable where AWBno=@awbno", CON);
                CON.Open();
                cmd.Parameters.AddWithValue("@awbno", textBox4.Text);
                cmd.ExecuteNonQuery();
                CON.Close();
                MessageBox.Show("Record Deleted successfully!!!");
                Displaydata();
                cleardata();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CON.Open();

            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from RecordBookTable where SenderName='"+textBox2.Text+"'",CON);
       
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            CON.Close();



        }

      
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            aasthaselect fs = new aasthaselect();
            fs.ShowDialog();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            searchform1 sf1 = new searchform1();
            sf1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox12.Text);
            if (comboBox1.Text == "OM")
            {
                try
                {
                    System.Diagnostics.Process.Start("http://omlogistics.co.in/");
                }
                catch { }
            }

            else if(comboBox1.Text=="BombinoKU")
            {

                try
                {
                    System.Diagnostics.Process.Start("http://www.bombinoexp.com/");
                }
                catch { }
               
            }
            else if (comboBox1.Text == "BombinoQA")
            {

                try
                {
                    System.Diagnostics.Process.Start("http://www.bombinoexp.com/");
                }
                catch { }

            }
            else if (comboBox1.Text == "TPLECO")
            {

                try
                {
                    System.Diagnostics.Process.Start("http://tplindia.com/");
                }
                catch { }

            }
            else if (comboBox1.Text == "TPLPRE")
            {

                try
                {
                    System.Diagnostics.Process.Start("http://tplindia.com/");
                }
                catch { }

            }
            else if (comboBox1.Text == "Atlantic")
            {

                try
                {
                    System.Diagnostics.Process.Start("http://www.atlanticcourier.net/");
                }
                catch { }

            }
            else if (comboBox1.Text == "Pacific")
            {

                try
                {
                    System.Diagnostics.Process.Start("http://www.pacificcourier.net/");
                }
                catch { }

            }
            else if (comboBox1.Text == "Differed")
            {

                try
                {
                    System.Diagnostics.Process.Start("http://www.asthacourier.com/");
                }
                catch { }

            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select * from RecordBookTable where Srno='" + textBox1.Text + "'", CON);
            CON.Open();

            SqlDataReader dr1 = cmd.ExecuteReader();
            if (dr1.Read())
            {

                textBox2.Text = dr1.GetValue(1).ToString();
                comboBox1.Text = dr1.GetValue(8).ToString();
                textBox3.Text = dr1.GetValue(2).ToString();
                textBox4.Text = dr1.GetValue(3).ToString();
                textBox5.Text = dr1.GetValue(11).ToString();
                textBox6.Text = dr1.GetValue(12).ToString();
                textBox7.Text = dr1.GetValue(4).ToString();
                textBox8.Text = dr1.GetValue(5).ToString();
                textBox9.Text = dr1.GetValue(6).ToString();
                textBox10.Text = dr1.GetValue(7).ToString();
                textBox12.Text = dr1.GetValue(9).ToString();
                richTextBox1.Text = dr1.GetValue(13).ToString();
                var del = dr1.GetValue(10).ToString();
                if(del=="NO")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }

            }
            CON.Close();
        }
    }
}
