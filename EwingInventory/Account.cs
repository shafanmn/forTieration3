using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using EwingInventory;

namespace Accounts
{
    public partial class AccountFrm : Form
    {

        // MySqlDataAdapter adapter;
        DataTable dt;
        Homepage home = new Homepage();
        int r;
        

        
        public AccountFrm()
        {
            InitializeComponent();

            String conn = "Server=localhost;Database=inventory;Uid=root;Password=;";
            String query = "Select id,expenditureName,amount,description,accountType,chequeNo,drawnDate from inventory.monthlyexpenses";


            MySqlConnection connString;
            MySqlCommand mysqlcommand;
            MySqlDataAdapter dataadpter;
            connString = new MySqlConnection(conn);
            mysqlcommand = new MySqlCommand(query, connString);
            dataadpter = new MySqlDataAdapter();
            dataadpter.SelectCommand = mysqlcommand;
           dt = new DataTable();
            dataadpter.Fill(dt);
            dataGridView1.DataSource = dt;
            //mysqlcon.Open();


            //////////////////////////////////////////////////
           

          
            



        }

        public void refresh()
        {

            String conn = "Datasource=localhost;port=;username=root;password=;";
            String query = "Select id,expenditureName,amount,description,accountType,chequeNo,drawnDate from inventory.monthlyexpenses";


            MySqlConnection connString;
            MySqlCommand mysqlcommand;
            MySqlDataAdapter dataadpter;
            connString = new MySqlConnection(conn);
            mysqlcommand = new MySqlCommand(query, connString);
            dataadpter = new MySqlDataAdapter();
            dataadpter.SelectCommand = mysqlcommand;
            dt = new DataTable();
            dataadpter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public void Clear()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string w = Screen.FromControl(home).WorkingArea.Width.ToString();
            this.Location = new Point((Convert.ToInt32(w) - this.Width) / 2, 120);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            panel2.Visible = false;
           
            Clear();
           

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {



            if (comboBox2.SelectedItem == null || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Select a Option ");


            }

           
           else if ((comboBox2.SelectedIndex == 0) && (textBox2.Text.Equals("")||textBox3.Text.Equals("")|| textBox4.Text.Equals("") || dateTimePicker1.Text.Equals("")))
                {

                    MessageBox.Show("Fill out the fields ");

                }





            else if ((comboBox2.SelectedIndex == 1) && (textBox2.Text.Equals("") || textBox3.Text.Equals("")))
                {

                    MessageBox.Show("Fill out the fields ");

                }


            

            else
            {
                try
               {
                    
                    if(comboBox2.Text.Equals("Cheque"))
                    {
                       
                        
                        String exname = comboBox1.Text;
                        int amnt = int.Parse(textBox2.Text);
                        String des = textBox3.Text;
                        String acnttype = comboBox2.Text;
                        int chqno = int.Parse(textBox4.Text);
                       // DateTime dte = DateTime.Parse(dateTimePicker1.Text);

                        DateTime s1 = System.Convert.ToDateTime(dateTimePicker1.Text);
                        DateTime date = (s1);
                        String frmdt = date.ToString("dd/MM/yyyy");

                        DateTime s2 = System.Convert.ToDateTime(DateTime.Now.ToString());
                        DateTime date1 = (s2);
                        String edt = date1.ToString("dd/MM/yyyy");

                        String conn = "Datasource=localhost;port=;username=root;password=;";
                        String query = "insert into inventory.monthlyexpenses(expenditureName,amount,description,date,accountType,chequeNo,drawnDate,status) values('" + exname + "','" + amnt + "','" + des + "','" + edt + "','" + acnttype + "','" + chqno + "','" + frmdt + "',0)";
                        String query1 = "insert into inventory.bank(description,amount,date,status) values('" + des + "'," + amnt + ",'" + edt + "',0)";
                        //MessageBox.Show(query);
                        MySqlConnection connString;
                        MySqlCommand mysqlcommand;
                       
                        MySqlDataReader datareader;

                        connString = new MySqlConnection(conn);
                        mysqlcommand = new MySqlCommand(query, connString);
                        connString.Open();
                        datareader = mysqlcommand.ExecuteReader();
                        connString.Close();


                        mysqlcommand = new MySqlCommand(query1, connString);
                        connString.Open();
                        datareader = mysqlcommand.ExecuteReader();
                        connString.Close();



                        MessageBox.Show("Saved Successfully");
                        Clear();

                        refresh();



                    }

                   else if (comboBox2.Text.Equals("Cash"))
                    {

                       

                        DateTime s2 = System.Convert.ToDateTime(DateTime.Now.ToString());
                        DateTime date1 = (s2);
                        String edt = date1.ToString("dd/MM/yyyy");



                        String exname = comboBox1.Text;
                        double amnt = double.Parse(textBox2.Text);
                        String des = textBox3.Text;
                        String acnttype = comboBox2.Text;
                        int chqno = 0;
                        
                        String conn = "Datasource=localhost;port=;username=root;password=;";
                        String query = "insert into inventory.monthlyexpenses(expenditureName,amount,description,date,accountType,chequeNo,drawnDate,status) values('" + exname + "','" + amnt + "','" + des + "','" + edt + "','" + acnttype + "','" + chqno + "',0,0)";
                        String query1 = "INSERT INTO  inventory.cashinhand(Description, Amount, Date, Status) VALUES('" + des + "'," + amnt + ",'" + edt + "',0)";


                        MySqlConnection connString;
                        MySqlCommand mysqlcommand;
                      
                        MySqlDataReader datareader;

                        connString = new MySqlConnection(conn);
                        mysqlcommand = new MySqlCommand(query, connString);
                        connString.Open();
                        datareader = mysqlcommand.ExecuteReader();
                        connString.Close();

                        mysqlcommand = new MySqlCommand(query1, connString);
                        connString.Open();
                        datareader = mysqlcommand.ExecuteReader();
                        connString.Close();
                        MessageBox.Show("Saved Successfully");
                        Clear();

                        refresh();



                    }
                    else
                    {

                    }
                    


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error");
                }


            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label94_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            int id = (int)dataGridView1.Rows[r].Cells[0].Value;
            String name = dataGridView1.Rows[r].Cells[1].Value.ToString();
            double amount = (double)dataGridView1.Rows[r].Cells[2].Value;
            String description = dataGridView1.Rows[r].Cells[3].Value.ToString();
            String actype = dataGridView1.Rows[r].Cells[4].Value.ToString();
          int chqno = (int)dataGridView1.Rows[r].Cells[5].Value;
            //  String drdate = dataGridView1.Rows[r].Cells[6].Value.ToString();


            textBox22.Text = id + "";
            comboBox1.Text = name;
            comboBox2.Text = actype;
            textBox2.Text =amount + "";
            textBox3.Text = description;
            textBox4.Text = chqno+ "";
            //dateTimePicker1.

            if (actype.Equals("Cheque"))
            {
                panel2.Visible = true;
            }
            else
            {
                panel2.Visible = false;
                textBox4.Text =  "0";
              //  dateTimePicker1.Text = "0";
            }

            

        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                panel2.Visible = true;
            }
            else
            {
                panel2.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (comboBox2.SelectedItem == null || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Select a Option ");


            }


            else if ((comboBox2.SelectedIndex == 0) && (textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals("") || dateTimePicker1.Text.Equals("")))
            {

                MessageBox.Show("Fill out the fields ");

            }





            else if ((comboBox2.SelectedIndex == 1) && (textBox2.Text.Equals("") || textBox3.Text.Equals("")))
            {

                MessageBox.Show("Fill out the fields ");

            }




            else
            {
                try
                {

                    if (comboBox2.Text.Equals("Cheque"))
                    {
                        //MessageBox.Show("dddddd");
                        int id = int.Parse(textBox22.Text);
                        String exname = comboBox1.Text;
                        int amnt = int.Parse(textBox2.Text);
                        String des = textBox3.Text;
                        String acnttype = comboBox2.Text;
                        int chqno = int.Parse(textBox4.Text);
                        DateTime dte = DateTime.Parse(dateTimePicker1.Text);

                        DialogResult confirm = MessageBox.Show("Do you want to Update", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (confirm == DialogResult.Yes)
                        {

                            String conn = "Datasource=localhost;port=;username=root;password=;";
                            String query = "update inventory.monthlyexpenses set expenditureName = '" + exname + "',amount = " + amnt + ",description='" + des + "',accountType = '" + acnttype + "',chequeNo = " + chqno + ",drawnDate = '" + dte + "' where id=" + id + "";
                            // MessageBox.Show(query);
                            //String query1 = "update inventory.bank set description = '" + des + "',amount = " + amnt + ",where id=" + id + "";
                            MySqlConnection connString;
                            MySqlCommand mysqlcommand;

                            MySqlDataReader datareader;
                            connString = new MySqlConnection(conn);
                            mysqlcommand = new MySqlCommand(query, connString);
                            connString.Open();

                            datareader = mysqlcommand.ExecuteReader();
                            connString.Close();
                            MessageBox.Show("updated Successfully");


                            //mysqlcommand = new MySqlCommand(query1, mysqlcon);
                            //mysqlcon.Open();
                            //datareader = mysqlcommand.ExecuteReader();
                            //mysqlcon.Close();




                            Clear();

                            refresh();

                        }
                        else
                        {

                        }

                    }


                    else if (comboBox2.Text.Equals("Cash"))
                    {

                        //MessageBox.Show("fdgfgfgdf");
                        int id = int.Parse(textBox22.Text);
                        String exname = comboBox1.Text;
                        double amnt = double.Parse(textBox2.Text);
                        String des = textBox3.Text;
                        String acnttype = comboBox2.Text;
                        int chqno = 0;

                        String conn = "Datasource=localhost;port=;username=root;password=;";
                        String query = "update inventory.monthlyexpenses set expenditureName = '" + exname + "',amount = " + amnt + ",description='" + des + "',accountType = '" + acnttype + "' where id=" + id + "";
                        // String query1 = "INSERT INTO  inventory.cashinhand(Description, Amount, Date, Status) VALUES('" + des + "'," + amnt + ",'" + DateTime.Today.Date + "',0)";
                        //MessageBox.Show(query);

                        DialogResult confirm = MessageBox.Show("Do you want to Update", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (confirm == DialogResult.Yes)
                        {

                            MySqlConnection connString;
                            MySqlCommand mysqlcommand;

                            MySqlDataReader datareader;

                            connString = new MySqlConnection(conn);
                            mysqlcommand = new MySqlCommand(query, connString);
                            connString.Open();
                            datareader = mysqlcommand.ExecuteReader();
                            connString.Close();

                            // mysqlcommand = new MySqlCommand(query1, mysqlcon);
                            //mysqlcon.Open();
                            //datareader = mysqlcommand.ExecuteReader();
                            //mysqlcon.Close();
                            MessageBox.Show("Update Successfully");
                            Clear();

                            refresh();



                        }
                        else
                        {

                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error");
                }


            }

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            DateTime s2 = System.Convert.ToDateTime(dateTimePicker2.Text);
            DateTime date1 = (s2);
            String efrmdt = date1.ToString("dd/MM/yyyy");

            DateTime s1 = System.Convert.ToDateTime(dateTimePicker3.Text);
            DateTime date = (s1);
            String frmdt = date.ToString("dd/MM/yyyy");


            String conn = "Datasource=localhost;port=;username=root;password=;";
            String query = "Select SUM(netCost) as sales from inventory.invoice where createdDate BETWEEN '" + efrmdt + "' AND '" + frmdt + "'";


            MySqlConnection connString;
            MySqlCommand mysqlcommand;
            MySqlDataAdapter dataadpter;
            connString = new MySqlConnection(conn);
            mysqlcommand = new MySqlCommand(query, connString);
            dataadpter = new MySqlDataAdapter();
            dataadpter.SelectCommand = mysqlcommand;
            MySqlDataReader myReader = null;
            connString.Open();
            myReader = mysqlcommand.ExecuteReader();



            while (myReader.Read())
            {

                label39.Text = (myReader["sales"].ToString());


            }
            String sal = label39.Text;
            double sa = double.Parse(sal);
            String ret = label40.Text;
            double re = double.Parse(ret);
            double tot = 0;
            if (re == 0)
            {
                textBox5.Text = "" + sa;
            }
            else
            {
                 tot = sa - re;
                textBox5.Text = "" + tot;
            }
            //String ret = label40.Text;
            //double re = double.Parse(ret);
            tot = sa - re;
            textBox8.Text = "" + tot;
            connString.Close();




            String query1 = "Select SUM(amount) as salary from inventory.monthlyexpenses where date BETWEEN '" + efrmdt + "' AND '" + frmdt + "' AND expenditureName='Stationary'";
            //MessageBox.Show(query1);



            connString = new MySqlConnection(conn);
            mysqlcommand = new MySqlCommand(query1, connString);
            dataadpter = new MySqlDataAdapter();
            dataadpter.SelectCommand = mysqlcommand;

            connString.Open();
            myReader = mysqlcommand.ExecuteReader();


            //String sala = "";
            while (myReader.Read())
            {

                label50.Text = (myReader["salary"].ToString());


            }
            String sall = label50.Text;
            double s = double.Parse(sall);
           


            String query2 = "Select SUM(amount) as amt from inventory.monthlyexpenses where date BETWEEN '" + efrmdt + "' AND '" + frmdt + "' AND expenditureName='Electricity Bill'";
            // MessageBox.Show(query1);



            connString = new MySqlConnection(conn);
            mysqlcommand = new MySqlCommand(query2, connString);
            dataadpter = new MySqlDataAdapter();
            dataadpter.SelectCommand = mysqlcommand;

            connString.Open();
            myReader = mysqlcommand.ExecuteReader();


            //String sala = "";
            while (myReader.Read())
            {

                label51.Text = (myReader["amt"].ToString());


            }
            String am = label51.Text;
            double a = double.Parse(am);

            String query3 = "Select SUM(amount) as tamt from inventory.monthlyexpenses where date BETWEEN '" + efrmdt + "' AND '" + frmdt + "' AND expenditureName='Telephone Bill'";




            connString = new MySqlConnection(conn);
            mysqlcommand = new MySqlCommand(query3, connString);
            dataadpter = new MySqlDataAdapter();
            dataadpter.SelectCommand = mysqlcommand;

            connString.Open();
            myReader = mysqlcommand.ExecuteReader();


            //String sala = "";
            while (myReader.Read())
            {

                label53.Text = (myReader["tamt"].ToString());


            }
            String tam = label53.Text;
            double ta = double.Parse(tam);

            String la = label46.Text;
            double laa = double.Parse(la);


            String la1 = label47.Text;
            double laa1 = double.Parse(la1);

            double tott = laa + laa1;
            textBox9.Text=""+tott;


            double to = tot + tott;
            label66.Text = "" + to;


            double tota = a + s + ta;
            textBox10.Text = "" + tota;

            String ab = label55.Text;
            double b = double.Parse(ab);

            String cd = label56.Text;
            double c = double.Parse(cd);

            String ef = label57.Text;
            double eg = double.Parse(ef);

            String hi = label58.Text;
            double hh = double.Parse(hi);

            double jj = b + c + eg + hh;
            textBox11.Text = "" + jj;

            String kl = label60.Text;
            double kl1 = double.Parse(kl);

            String mn = label61.Text;
            double mn1 = double.Parse(mn);

            String op = label62.Text;
            double op1 = double.Parse(op);

            double qr = kl1 + mn1 + op1;
            textBox12.Text = "" + qr;

            double st = tota + jj + qr;
            label67.Text = "" + st;

            double uv = to - st;
            textBox13.Text = "" + uv;







            //String con1 = "Datasource=localhost;port=;username=root;password=;";
            //String query1 = "Select SUM(amount) as salary from inventory.monthlyexpenses where date BETWEEN '" + efrmdt + "' AND '" + frmdt + "' AND expenditureName='Stationary'";


            //MySqlConnection mysqlcon1;
            //MySqlCommand mysqlcommand1;
            //MySqlDataAdapter dataadpter1;
            //mysqlcon1 = new MySqlConnection(con1);
            //mysqlcommand1 = new MySqlCommand(query1, mysqlcon1);
            //dataadpter1 = new MySqlDataAdapter();
            //dataadpter1.SelectCommand = mysqlcommand1;
            //MySqlDataReader myReader1 = null;
            //mysqlcon1.Open();
            //myReader1 = mysqlcommand1.ExecuteReader();


            //String sala="";
            //while (myReader1.Read())
            //{

            //    sala= (myReader1["salary"].ToString());


            //}
            //label39.Text = sala;
            // double salary = double.Parse(sal);

            //String ret = label40.Text;
            //double re = double.Parse(ret);
            //if (re == 0)
            //{
            //    textBox5.Text = "" + sa;
            //}
            //else
            //{
            //    double tot = sa - re;
            //    textBox5.Text = "" + tot;
            //}


            //mysqlcon.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Select a Option ");


            }


            else if ((comboBox2.SelectedIndex == 0) && (textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals("") || dateTimePicker1.Text.Equals("")))
            {

                MessageBox.Show("Fill out the fields ");

            }





            else if ((comboBox2.SelectedIndex == 1) && (textBox2.Text.Equals("") || textBox3.Text.Equals("")))
            {

                MessageBox.Show("Fill out the fields ");

            }




            else
            {
                try
                {
                   
                    if (comboBox2.Text.Equals("Cheque"))
                    {
                        
                        int id = int.Parse(textBox22.Text);
                        String exname = comboBox1.Text;
                        int amnt = int.Parse(textBox2.Text);
                        String des = textBox3.Text;
                        String acnttype = comboBox2.Text;
                        int chqno = int.Parse(textBox4.Text);
                        DateTime dte = DateTime.Parse(dateTimePicker1.Text);

                        DialogResult confirm = MessageBox.Show("Do you want to Delete", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (confirm == DialogResult.Yes)
                        {

                            String conn = "Datasource=localhost;port=;username=root;password=;";
                            String query = "DELETE FROM  inventory.monthlyexpenses where id=" + id + "";
                           
                            //  String query1 = "insert into inventory.bank(description,amount,date,status) values('" + des + "'," + amnt + ",'" + DateTime.Today.Date + "',0)";
                            MySqlConnection connString;
                            MySqlCommand mysqlcommand;

                            MySqlDataReader datareader;
                            connString = new MySqlConnection(conn);
                            mysqlcommand = new MySqlCommand(query, connString);
                            connString.Open();

                            datareader = mysqlcommand.ExecuteReader();
                            connString.Close();
                            MessageBox.Show("Deleted Successfully");


                            // mysqlcommand = new MySqlCommand(query1, mysqlcon);
                            //mysqlcon.Open();
                            //datareader = mysqlcommand.ExecuteReader();
                            //mysqlcon.Close();




                            Clear();

                            refresh();
                        }
                        else
                        {

                        }


                    }


                    else if (comboBox2.Text.Equals("Cash"))
                    {

                        int id = int.Parse(textBox22.Text);
                        String exname = comboBox1.Text;
                        double amnt = double.Parse(textBox2.Text);
                        String des = textBox3.Text;
                        String acnttype = comboBox2.Text;
                        int chqno = 0;

                        DialogResult confirm = MessageBox.Show("Do you want to Delete", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (confirm == DialogResult.Yes)
                        {

                            String conn = "Datasource=localhost;port=;username=root;password=;";
                            String query = "DELETE FROM  inventory.monthlyexpenses where id=" + id + "";
                            // String query1 = "INSERT INTO  inventory.cashinhand(Description, Amount, Date, Status) VALUES('" + des + "'," + amnt + ",'" + DateTime.Today.Date + "',0)";


                            MySqlConnection connString;
                            MySqlCommand mysqlcommand;

                            MySqlDataReader datareader;

                            connString = new MySqlConnection(conn);
                            mysqlcommand = new MySqlCommand(query, connString);
                            connString.Open();
                            datareader = mysqlcommand.ExecuteReader();
                            connString.Close();
                            MessageBox.Show("Deleted Successfully");

                            // mysqlcommand = new MySqlCommand(query1, mysqlcon);
                            //mysqlcon.Open();
                            //datareader = mysqlcommand.ExecuteReader();
                            //mysqlcon.Close();
                            //MessageBox.Show("Save Data1");
                            Clear();

                            refresh();

                        }
                        else
                        {

                        }

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error");
                }


            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            String exp = textBox1.Text;
            MessageBox.Show(exp);
            String conn = "Datasource=localhost;port=;username=root;password=;";
            String query = "Select id,expenditureName,amount,description,accountType,chequeNo,drawnDate from inventory.monthlyexpenses where expenditureName = '" + exp + "'";
            //MessageBox.Show(query);

            MySqlConnection connString;
            MySqlCommand mysqlcommand;
            MySqlDataAdapter dataadpter;

            connString = new MySqlConnection(conn);
            mysqlcommand = new MySqlCommand(query, connString);
            dataadpter = new MySqlDataAdapter();
            dataadpter.SelectCommand = mysqlcommand;
           
          



            dt = new DataTable();
            dataadpter.Fill(dt);
            dataGridView1.DataSource = dt;
            connString.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Do you want to close", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

            DateTime s2 = System.Convert.ToDateTime(dateTimePicker2.Text);
            DateTime date1 = (s2);
            String efrmdt = date1.ToString("dd/MM/yyyy");

            DateTime s1 = System.Convert.ToDateTime(dateTimePicker3.Text);
            DateTime date = (s1);
            String frmdt = date.ToString("dd/MM/yyyy");

            String con1 = "Datasource=localhost;port=;username=root;password=;";
            String query1 = "Select SUM(amount) as salary from inventory.monthlyexpenses where date BETWEEN '" + efrmdt + "' AND '" + frmdt + "' ";
            MessageBox.Show(query1);


            MySqlConnection mysqlcon1;
            MySqlCommand mysqlcommand1;
            MySqlDataAdapter dataadpter1;
            mysqlcon1 = new MySqlConnection(con1);
            mysqlcommand1 = new MySqlCommand(query1, mysqlcon1);
            dataadpter1 = new MySqlDataAdapter();
            dataadpter1.SelectCommand = mysqlcommand1;
            MySqlDataReader myReader1;
            mysqlcon1.Open();
            myReader1 = mysqlcommand1.ExecuteReader();


            //String sala = "";
            while (myReader1.Read())
            {

                label39.Text = (myReader1["salary"].ToString());


            }
            //String sall = sala;

            //double sl = double.Parse(sall);
            //label39.Text = "" + sl;
        }
    }
}
