using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using EwingInventory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace Supplier
{
    public partial class sup : Form
    {
        static string myConnection = "Server=localhost;Database=inventory;Uid=root;Pwd=;";
        MySqlConnection con = new MySqlConnection(myConnection);
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        DataTable dtt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        public void refresh()
        {
            {
               
                dataGridView1.ColumnCount = 6;
                dataGridView1.Columns[0].Name = "SupplierName";
                dataGridView1.Columns[1].Name = "Nic";
                dataGridView1.Columns[2].Name = "Phone";
                dataGridView1.Columns[3].Name = "Fax";
                dataGridView1.Columns[4].Name = "E-mail";
                dataGridView1.Columns[5].Name = "sid";


                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
                dataGridView1.Rows.Clear();
                string sql = "select * from supplier";
                cmd = new MySqlCommand(sql, con);

                try
                {
                    con.Open();
                    adapter = new MySqlDataAdapter(sql, con);
                    adapter.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        populate121(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
                    }

                    con.Close();
                    dt.Rows.Clear();
                }
                catch (Exception exception)
                { MessageBox.Show(exception.Message); }
                



                dataGridView2.ColumnCount = 2;
                dataGridView2.Columns[0].Name = "itemCode";
                dataGridView2.Columns[1].Name = "Description";


                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView2.MultiSelect = false;
                dataGridView2.Rows.Clear();
                string sssql = "select itemCode,Discription from item where itemCode in (select ItemCode from oitems ) ";
                cmd = new MySqlCommand(sssql, con);

                try
                {
                    con.Open();
                    adapter = new MySqlDataAdapter(sssql, con);
                    adapter.Fill(dt2);

                    foreach (DataRow row in dt2.Rows)
                    {
                        populate122(row[0].ToString(), row[1].ToString());
                    }

                    con.Close();
                    dt2.Rows.Clear();
                }
                catch (Exception exception)
                { MessageBox.Show(exception.Message); }














                //loading payment History

                paymentHis.ColumnCount = 6; //
                paymentHis.Columns[0].Name = "Name";
                paymentHis.Columns[1].Name = "Total";
                paymentHis.Columns[2].Name = "Payment Amount";
                paymentHis.Columns[3].Name = "Payment Method";
                paymentHis.Columns[4].Name = "Balance";
                paymentHis.Columns[5].Name = "date";
                paymentHis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                paymentHis.MultiSelect = false;
                paymentHis.Rows.Clear();
                sql = "select sname,total,pamount,pmethod,balance,date from orders";
                cmd = new MySqlCommand(sql, con);

                try
                {
                    con.Open();
                    adapter = new MySqlDataAdapter(sql, con);
                    adapter.Fill(dtt);

                    foreach (DataRow row in dtt.Rows)
                    {
                        populate1(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
                    }

                    con.Close();
                    dtt.Rows.Clear();
                }
                catch (Exception exception)
                { MessageBox.Show(exception.Message); con.Close(); }



                //load the item code to combo box in purchase order
                /////////////////////////////////////////////////////////////////////

                cmd = con.CreateCommand();
                cmd.CommandText = "Select Discription from item";
                try
                {
                    con.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    ItemDescription.Items.Clear();
                    while (reader.Read())
                    {
                        ItemDescription.Items.Add(reader[("Discription")]);

                    }
                    con.Close();
                }
                catch (Exception e)
                { MessageBox.Show(e.Message); }




                //load the supplier name to combo box in purchase order 
                cmd = con.CreateCommand();
                cmd.CommandText = "Select Name from supplier";
                try
                {
                    con.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    textBox1.Items.Clear();
                    while (reader.Read())
                    {
                        textBox1.Items.Add(reader[("Name")]);

                    }
                    con.Close();
                }
                catch (Exception e)
                { MessageBox.Show(e.Message); }




            }
        }
        public sup()
        {
     
            ////////////////////////////////////////////////////////////////////////////
            {   
                InitializeComponent();
                dataGridView1.ColumnCount = 6;
                dataGridView1.Columns[0].Name = "SupplierName";
                dataGridView1.Columns[1].Name = "Nic";
                dataGridView1.Columns[2].Name = "Phone";
                dataGridView1.Columns[3].Name = "Fax";
                dataGridView1.Columns[4].Name = "E-mail";
                dataGridView1.Columns[5].Name = "sid";


                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
                dataGridView1.Rows.Clear();
                string sql = "select * from supplier";
                cmd = new MySqlCommand(sql, con);

                try
                {
                    con.Open();
                    adapter = new MySqlDataAdapter(sql, con);
                    adapter.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        populate121(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
                    }

                    con.Close();
                    dt.Rows.Clear();
                }
                catch (Exception exception)
                { MessageBox.Show(exception.Message); }
                payM.Items.Add("Card");
                payM.Items.Add("Cheque");
                payM.Items.Add("Cash");



                dataGridView2.ColumnCount = 2;
                dataGridView2.Columns[0].Name = "itemCode";
                dataGridView2.Columns[1].Name = "Description";
          

                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView2.MultiSelect = false;
                dataGridView2.Rows.Clear();
                string sssql = "select itemCode,Discription from item where itemCode in (select ItemCode from oitems ) ";
                cmd = new MySqlCommand(sssql, con);

                try
                {
                    con.Open();
                    adapter = new MySqlDataAdapter(sssql, con);
                    adapter.Fill(dt2);

                    foreach (DataRow row in dt2.Rows)
                    {
                        populate122(row[0].ToString(), row[1].ToString());
                    }

                    con.Close();
                    dt2.Rows.Clear();
                }
                catch (Exception exception)
                { MessageBox.Show(exception.Message); }














                //loading payment History

                paymentHis.ColumnCount = 6; //
                paymentHis.Columns[0].Name = "Name";
                paymentHis.Columns[1].Name = "Total";
                paymentHis.Columns[2].Name = "Payment Amount";
                paymentHis.Columns[3].Name = "Payment Method";
                paymentHis.Columns[4].Name = "Balance";
                paymentHis.Columns[5].Name = "date";
                paymentHis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                paymentHis.MultiSelect = false;
                paymentHis.Rows.Clear();
                 sql = "select sname,total,pamount,pmethod,balance,date from orders";
                cmd = new MySqlCommand(sql, con);

                try
                {
                    con.Open();
                    adapter = new MySqlDataAdapter(sql, con);
                    adapter.Fill(dtt);

                    foreach (DataRow row in dtt.Rows)
                    {
                        populate1(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString() ,row[5].ToString());
                    }

                    con.Close();
                    dtt.Rows.Clear();
                }
                catch (Exception exception)
                { MessageBox.Show(exception.Message); con.Close(); }

               

                //load the item code to combo box in purchase order
                /////////////////////////////////////////////////////////////////////

                cmd = con.CreateCommand();
                cmd.CommandText = "Select Discription from item";
                try
                {
                    con.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    ItemDescription.Items.Clear();
                    while (reader.Read())
                    {
                        ItemDescription.Items.Add(reader[("Discription")]);

                    }
                    con.Close();
                }
                catch (Exception e)
                { MessageBox.Show(e.Message); }




                //load the supplier name to combo box in purchase order 
                cmd = con.CreateCommand();
                cmd.CommandText = "Select Name from supplier";
                try
                {
                    con.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    textBox1.Items.Clear();
                    while (reader.Read())
                    {
                        textBox1.Items.Add(reader[("Name")]);

                    }
                    con.Close();
                }
                catch (Exception e)
                { MessageBox.Show(e.Message); }




            }


            








        }



     
        private void populate1(string Name, string Total, string Payment_Amount, string Payment_Method, string Balance, string date)
        {
            paymentHis.Rows.Add(Name, Total, Payment_Amount, Payment_Method, Balance,date);
        }

        




        private void button2_Click(object sender, EventArgs e) // pop out of update sup in sup manipulation
        {
        }

        private void button3_Click(object sender, EventArgs e) //pop out of delete sup in sup manipulation
        {
            string sql = "DELETE from supplier where Nic='" + Snic.Text + "'";
            cmd = new MySqlCommand(sql, con);
            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.DeleteCommand = con.CreateCommand();
                adapter.DeleteCommand.CommandText = sql;

                if (MessageBox.Show("Sure you want to delete ?", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (cmd.ExecuteNonQuery() > 0)
                    { MessageBox.Show("Successfully deleted!");
                        
                        }

                }
                con.Close();
            }
            catch (Exception a)
            { MessageBox.Show("Connection Error!"); }
            refresh();
        }

        private void button10_Click(object sender, EventArgs e) //pop out of view sup list in sup manipulation
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {   //nic validation
            string str = Snic.Text;
            if ((str.Count(char.IsDigit) == 9) && (str.EndsWith("V", StringComparison.OrdinalIgnoreCase)))
            {
                //email validation
                if (!Regex.IsMatch(email.Text, @"^[a-z,A-Z]{1,10}((-|.)\w+)*@\w+.\w{3}$"))


                {
                    MessageBox.Show("Please enter a valid email address");
                    email.Text = "";
                }
                else
                {
                    //inserting values to the database
                    string sql = "INSERT INTO `supplier` (`Name`,`Nic`,`Phone`,`fax`,`email`) VALUES ('" + supName.Text + "','" + Snic.Text + "','" + sphone.Text + "','" + fax.Text + "','" + email.Text + "')";
                    cmd = new MySqlCommand(sql, con);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show(" New Supplier Added Successfully");

                        con.Close();

                    }
                    catch (Exception except)
                    { MessageBox.Show("Input correct data to All fields"); con.Close(); }

                    // clear text as soon as it is finsh submitting
                    supName.Text = "";
                    Snic.Text = "";
                    sphone.Text = "";
                    fax.Text = "";
                    email.Text = "";
                }
            }
            else {
                MessageBox.Show("Invalid NIC");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
        public static int balance;
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && pamount.Text == "" && payM.Text == "")
            { MessageBox.Show("Input Values To all Fields"); }
            else
            {
                MySqlCommand cmdd;
                string baln = "";
                //get the remaining balance
                //string queryy = " Select balance from orders where sname like'" + textBox1.Text + "' ";
                string queryy = "select balance from orders  where sname like '" + textBox1.Text + "' ORDER BY date DESC";
                int bll;
                con.Open();
                cmdd = new MySqlCommand(queryy, con);
                if (cmdd.ExecuteScalar() == null)
                {
                    bll = 0;
                }
                else
                {

                    baln = cmdd.ExecuteScalar().ToString();
                    bll = System.Convert.ToInt32(baln);
                }


                con.Close();


                //get the total
                int total = 0;
                string tot = "";
                for (int i = 0; i < purorder.Rows.Count; i++)
                {
                    if (purorder.Rows[i].Cells["quantity"].Value == null && purorder.Rows[i].Cells["ItemDescription"].Value == null)
                    {
                    }
                    else
                    {
                        string quan = purorder.Rows[i].Cells["quantity"].Value.ToString();
                        int q = Int32.Parse(quan);
                        string upr = purorder.Rows[i].Cells["UnitPrice"].Value.ToString();
                        int up = Int32.Parse(upr);
                        total = total + (q * up);
                    }
                }
                tot = total + tot;
                this.tot.Text = tot;

                //get the balance

                if (pamount.Text == "")
                {

                }
                else
                {

                    balance = (total - (Int32.Parse(pamount.Text))) + bll;
                }


                MySqlCommand cmd;
                //insert data to order table
                string sql = "INSERT INTO `orders` (`sname`,`total`,`pamount`,`pmethod`,`balance`,`date`) VALUES ('" + textBox1.Text + "','" + tot + "','" + pamount.Text + "','" + payM.Text + "','" + balance + "',CURRENT_TIMESTAMP)";
                cmd = new MySqlCommand(sql, con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
                catch (Exception except)
                {
                    MessageBox.Show(except.Message);
                }

                //get the order no

                string query = " Select ono from orders where sname like'" + textBox1.Text + "' and total like'" + total + "' and pamount like'" + pamount.Text + "' and pamount like'" + pamount.Text + "' and balance like'" + balance + "'";
                string ono = "";
                con.Open();
                cmd = new MySqlCommand(query, con);
                ono = cmd.ExecuteScalar().ToString();


                con.Close();
                int orderno = System.Convert.ToInt32(ono);



                //sending values to database from data grid
                for (int i = 0; i < purorder.Rows.Count-1; i++)

                {
                    if (purorder.Rows[i].Cells["ItemDescription"].Value == null)
                    {

                    }
                    else
                    {
                        //get the item code
                        query = " Select itemCode from item where discription like'" + purorder.Rows[i].Cells["ItemDescription"].Value + "'";
                        string icode = "";
                        con.Open();
                        cmd = new MySqlCommand(query, con);
                        icode = cmd.ExecuteScalar().ToString();
                        int ic = 0;
                        ic = System.Convert.ToInt32(icode);

                        con.Close();
                        //string sql = "insert into test values(" +dataGridView1.Rows[i].Cells["ItemCode"].Value+ "," + dataGridView1.Rows[i].Cells["Quantity"].Value + "," + dataGridView1.Rows[i].Cells["UnitPrice"].Value + "," + dataGridView1.Rows[i].Cells["SubTotal"].Value + "";
                        sql = "INSERT INTO `oitems` (`ItemCode`,`Quantity`,`UnitPrice`,`ono`) VALUES ('" + ic + "','" + purorder.Rows[i].Cells["Quantity"].Value + "','" + purorder.Rows[i].Cells["UnitPrice"].Value + "','" + ono + "')";
                    }
                    try
                    {
                        con.Open();
                        using (MySqlCommand comm = new MySqlCommand(sql, con))
                        { comm.ExecuteNonQuery(); }
                        con.Close();
                    }
                    catch (Exception de)
                    { MessageBox.Show(de.Message); }

                }

                //UPDATE THE STOCK
                for (int i = 0; i < purorder.Rows.Count; i++)

                {
                    if (purorder.Rows[i].Cells["ItemDescription"].Value == null)
                    {

                    }
                    else
                    {
                        //get the item code
                        query = " Select itemCode from item where discription like'" + purorder.Rows[i].Cells["ItemDescription"].Value + "'";
                        string icode = "";
                        con.Open();
                        cmd = new MySqlCommand(query, con);
                        icode = cmd.ExecuteScalar().ToString();
                        int ic = 0;
                        ic = System.Convert.ToInt32(icode);

                        con.Close();
                        //string sql = "insert into test values(" +dataGridView1.Rows[i].Cells["ItemCode"].Value+ "," + dataGridView1.Rows[i].Cells["Quantity"].Value + "," + dataGridView1.Rows[i].Cells["UnitPrice"].Value + "," + dataGridView1.Rows[i].Cells["SubTotal"].Value + "";
                        sql = "update stock set quantity='" + purorder.Rows[i].Cells["Quantity"].Value + "' where itemCodes='" + ic + "'";
                    }
                    try
                    {
                        con.Open();
                        using (MySqlCommand comm = new MySqlCommand(sql, con))
                        { comm.ExecuteNonQuery(); }
                        con.Close();
                    }
                    catch (Exception de)
                    { MessageBox.Show(de.Message); }

                }
                MessageBox.Show("Order Successfull !");
                refresh();


            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            supName.Text = "";
            tot.Text = "";
            pamount.Text = "";
            payM.Text = "";
            panel1.Visible = false;
            panel2.Visible = false;
            refresh();
            purorder.Rows.Clear();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void populate2(string ItemCode, string Quantity)
        {
           
        }


        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void paymentHis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            {
                if (MessageBox.Show("Are You Sure To Exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void supName_TextChanged(object sender, EventArgs e)
        {

        }

        private void sup_Load(object sender, EventArgs e)
        {
            //Homepage home = new Homepage();
            //string w = (Screen.FromControl(home).WorkingArea.Width.ToString());
            //this.Location = new Point((Convert.ToInt32(w) - this.Width) / 2, 120);
            //FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void supName_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void fax_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void Save_Click(object sender, EventArgs e)
        {
            //validate fax
            int s;
            if (!(fax.Text.Length == 10 && int.TryParse(fax.Text, out s)))
            {
                refresh();
                label15.Show();
                label8.Visible = false;
                label9.Visible = false;
                label14.Visible = false;
               
            }
            else
            {
                //validate phone number
                int n;
                if (!(sphone.Text.Length == 10 && int.TryParse(sphone.Text, out n)))
                {
                    refresh();
                    label14.Show();
                    label8.Visible = false;
                    label9.Visible = false;
                   
                    label15.Visible = false;
                }
                else
                {

                    //validate e-mail

                    if (!(Regex.IsMatch(email.Text, @"^[a-z,A-Z]{1,10}((-|.)\w+)*@\w+.\w{3}$") && email.Text.EndsWith(".com")))
                    {
                        refresh();
                        label9.Show();
                        label8.Visible = false;
                        
                        label14.Visible = false;
                        label15.Visible = false;
                    }
                    else
                    {
                        //Validate NIC No
                        if (   !(Snic.Text.Count(char.IsDigit) == 10) && !(Snic.Text.EndsWith("V", StringComparison.OrdinalIgnoreCase)))
                        {
                            refresh();
                            label8.Show();
                            
                            label9.Visible = false;
                            label14.Visible = false;
                            label15.Visible = false;
                        }
                        else
                        {
                            label8.Visible = false;
                            label9.Visible = false;
                            label14.Visible = false;
                            label15.Visible = false;
                            string query = "select * from supplier where sid='" + sid.Text + "';";
                            MySqlCommand cmd = new MySqlCommand(query, con);
                            MySqlDataReader reader;
                            con.Open();         //open1
                            reader = cmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                //close open1
                                con.Close();
                                //update

                                DialogResult confirm = MessageBox.Show("Do you want to update supplier ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (confirm == DialogResult.Yes)
                                {

                                    //update

                                    string sql = "update supplier set Name='" + supName.Text + "',Nic='" + Snic.Text + "',Phone='" + sphone.Text + "',Fax ='" + fax.Text + "',email='" + email.Text + "' where sid='" + sid.Text + "' ";
                                    cmd = new MySqlCommand(sql, con);

                                    try
                                    {
                                        con.Open();
                                        adapter = new MySqlDataAdapter(cmd);
                                        adapter.UpdateCommand = con.CreateCommand();
                                        adapter.UpdateCommand.CommandText = sql;

                                        if (adapter.UpdateCommand.ExecuteNonQuery() > 0)
                                        {
                                            MessageBox.Show("Successfully Updated!");
                                           
                                        }
                                        con.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Input correct data to fields!");
                                        MessageBox.Show(ex.Message);
                                        con.Close();
                                    }




                                }

                            }
                            else
                            {
                                con.Close();        //close open1

                                //insert
                                DialogResult confirm = MessageBox.Show("Do you want to add supplier ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (confirm == DialogResult.Yes)
                                {



                                    //inserting values to the database
                                    string sql = "INSERT INTO `supplier` (`Name`,`Nic`,`Phone`,`fax`,`email`) VALUES ('" + supName.Text + "','" + Snic.Text + "','" + sphone.Text + "','" + fax.Text + "','" + email.Text + "')";
                                    cmd = new MySqlCommand(sql, con);
                                    try
                                    {
                                        con.Open();
                                        cmd.ExecuteNonQuery();

                                        MessageBox.Show(" New Supplier Added Successfully");

                                        con.Close();

                                    }
                                    catch (Exception except)
                                    { MessageBox.Show("Input correct data to All fields"); con.Close(); }




                                }
                            }


                            //empty the textBoxes
                            sid.Text = "";
                            supName.Text = "";
                            Snic.Text = "";
                            sphone.Text = "";
                            fax.Text = "";
                            email.Text = "";
                            refresh();
                        }
                    }
                }
            }
            refresh();
        }
       
        private void populate121(string SupplierName, string Nic, string Phone, string Fax, string E_mail, string sid)
        {
            dataGridView1.Rows.Add(SupplierName, Nic, Phone, Fax, E_mail, sid);
        }
        private void populate122(string itemCode, string Description)
        {
            dataGridView2.Rows.Add(itemCode,Description );
        }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedRows[0].Cells[0].Value == null && dataGridView1.SelectedRows[0].Cells[1].Value == null && dataGridView1.SelectedRows[0].Cells[2].Value == null && dataGridView1.SelectedRows[0].Cells[3].Value == null && dataGridView1.SelectedRows[0].Cells[4].Value == null && dataGridView1.SelectedRows[0].Cells[5].Value == null)
            {
           
            }
            else
            {
                supName.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                Snic.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                sphone.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                fax.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                email.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                sid.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                label8.Visible = false;
                label9.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Show();
            //get the total
            int total = 0;
            string tot = "";
            for (int i = 0; i < purorder.Rows.Count; i++)
            {
                if (purorder.Rows[i].Cells["quantity"].Value == null && purorder.Rows[i].Cells["ItemDescription"].Value == null)
                {
                }
                else
                {
                    string quan = purorder.Rows[i].Cells["quantity"].Value.ToString();
                    int q = Int32.Parse(quan);
                    string upr = purorder.Rows[i].Cells["UnitPrice"].Value.ToString();
                    int up = Int32.Parse(upr);
                    total = total + (q * up);
                }
            }
            tot = total + tot;
            this.tot.Text = tot;
        }

        private void Snic_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void pamount_TextChanged(object sender, EventArgs e)
        {
            int s;

            if (!(int.TryParse(pamount.Text, out s)))
            { label17.Show(); }
            else
            { label17.Visible = false; }
        }

        private void fax_TextChanged(object sender, EventArgs e)
        {
            int s;

            if (!(sphone.Text.Length == 10 && (int.TryParse(fax.Text, out s))))
            { label15.Show(); }
            else
            { label15.Visible = false; }
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                string x = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                string query = "select orders.sname from orders,oitems where orders.ono=oitems.ono and oitems.ItemCode='" + x + "' order by oitems.UnitPrice";
                string cs;
                con.Open();
                cmd = new MySqlCommand(query, con);
                cs = cmd.ExecuteScalar().ToString();
                string queryy = "select oitems.UnitPrice from orders,oitems where orders.ono=oitems.ono and oitems.ItemCode='" + x + "' order by oitems.UnitPrice";
                string csu;
               
                cmd = new MySqlCommand(queryy, con);
                csu = cmd.ExecuteScalar().ToString();

                MessageBox.Show("Supplier Name : "+cs+"  Unit Price : "+csu,"Ceapest supplier for this Item");
                con.Close();
            }
            catch (NullReferenceException eeee)
            { MessageBox.Show("Haven't buy this Item from any supplier yet");
                con.Close();
            }



        }

        private void more_Click(object sender, EventArgs e)
        {
            more m = new Supplier.more();
            m.Show();
        }
        
        private void button2_Click_1(object sender, EventArgs e)
        {
            sid.Text = "";
            supName.Text = "";
            Snic.Text = "";
            sphone.Text = "";
            fax.Text = "";
            email.Text = "";
        }

        private void sphone_TextChanged(object sender, EventArgs e)
        {
            int s;

            if (!(sphone.Text.Length == 10 && (int.TryParse(sphone.Text, out s))))
            { label14.Show(); }
            else
            { label14.Visible = false; }
        }

        private void email_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
   
}

