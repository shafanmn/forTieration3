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

namespace EwingInventory
{
    
    public partial class Customer_Management : Form
    {
        public int additemstartqty,additemstartqty1;
        int pno11, pno22,qty;
        double cashDisc, specDisc, qtyDisc, totDisc, netCost;
        string cid, name, address1, address2, email, enteredBy,query,invoiceNo,currDate,dueDate,itemCode,seller,remark, contentValue,contentValue1c, contentValue1s, contentValue2, contentValuep, contentValuei;
        public Homepage home = new Homepage();

        MySqlConnection cnn = new MySqlConnection("Server=localhost;Database=inventory;Uid=root;Pwd=;");
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();
        DataTable dt5 = new DataTable();
        DataTable dt6 = new DataTable();
        DataTable dt7 = new DataTable();
        DataTable dt8 = new DataTable();
        DataTable dt9 = new DataTable();
        DataTable dt10 = new DataTable();
        DataTable dt11 = new DataTable();
        DataTable dt12 = new DataTable();
        DataTable dt16 = new DataTable();








        public Customer_Management()
        {
            InitializeComponent();

            txtentered.Text = Homepage.currentUser1;
            txtdate1.Text = DateTime.Now.ToString("dd/MM/yyyy");  //get current date
            EnteredBy2.Text = Homepage.currentUser1;
            txtpmtDate.Text= DateTime.Now.ToString("dd/MM/yyyy");  //get current date

            custTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            custTable.MultiSelect = false;

            InvoiceNotable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            InvoiceNotable.MultiSelect = false;

            itemtable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            itemtable.MultiSelect = false;

            pmtIDtable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            pmtIDtable.MultiSelect = false;

            dettable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dettable.MultiSelect = false;

            custnametable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            custnametable.MultiSelect = false;

            cnn.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter("select cid as CID,name as Name,pno1 as PhoneNo1,pno2 as PhoneNo2,address1 as Address1,address2 as Address2,Email,EnteredBy from customer order by  cid asc", cnn);
            adp.Fill(dt);
            custTable.DataSource = dt;
            this.custTable.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            adp.Dispose();
            cnn.Close();

            
            
            cnn.Open();
            adp= new MySqlDataAdapter("select CID ,showRoomLocation ,address as DeliveryAddress,phoneNo as PhoneNo from deliverydetails", cnn);
            adp.Fill(dt1);
            dettable.DataSource = dt1;
            this.dettable.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dettable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            adp.Dispose();
            cnn.Close();

            generateCustID();
            invoiceNumber();
            DueDateCalc();
            paymentId_generation();
        }

        private void DueDateCalc()
        {
           
            DateTime startDate = DateTime.ParseExact(txtdate1.Text, "dd/MM/yyyy", null);
            DateTime expiryDate = startDate.AddDays(90);
            if (DateTime.Now > expiryDate)
            {
            
                MessageBox.Show("Invoice Expired");
            }
            txtdue.Text = expiryDate.ToString("dd/MM/yyyy");

        }
        private void generateCustID()
        {

            query = "select * from customer ;";
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            MySqlDataReader reader;
            cnn.Open();         //open1
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                cnn.Close();
               
                query = "select cid from customer order by cid desc limit 1;";
                cmd = new MySqlCommand(query, cnn);
                cnn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if ((Convert.ToInt32(reader[0].ToString()) + 1) > 9)
                        txtcid.Text = Convert.ToString(Convert.ToInt32(reader[0].ToString()) + 1).PadLeft(3, '0');  // myString.padLeft(2,'0')
                    else
                    {
                        txtcid.Text = Convert.ToString(Convert.ToInt32(reader[0].ToString()) + 1).PadLeft(3, '0');  // myString.padLeft(3,'0')
                    }
                }
                 cnn.Close();

                }

            
            else
            {
                cnn.Close();
                txtcid.Text = "001";

            }
        }
        private void invoiceNumber()
        {

            query = "select invoiceNo from invoice ;";
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            MySqlDataReader reader;
            cnn.Open();         //open1
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                cnn.Close();

                query = "select invoiceNo from invoice order by invoiceNo desc limit 1;";
                cmd = new MySqlCommand(query, cnn);
                cnn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string s = reader[0].ToString().Substring(3);

                    if ((Convert.ToInt32(s) + 1) > 9)

                        txtinvoice1.Text = "INV"+Convert.ToString(Convert.ToInt32(Convert.ToInt32(s)+ 1)).PadLeft(7, '0');  // myString.padLeft(7,'0')
                    else
                        txtinvoice1.Text = "INV" + Convert.ToString(Convert.ToInt32(Convert.ToInt32(s) + 1)).PadLeft(8, '0');  // myString.padLeft(8,'0')

                }
                cnn.Close();

            }


            else
            {
                cnn.Close();
                txtinvoice1.Text = "INV00000001";

            }

            //item table
            string inNo = txtinvoice1.Text;
            cnn.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter("select i.itemCode as ItemCode,i.Discription as Description,i.sellingPrice as WholesalePrice,i.MRP,o.qty as Qty,o.disc as Disc,o.totcost as TotalCost from item i,orderdetails o where   i.itemCode=o.ItemNo and  invoiceNo='" + inNo + "'; ", cnn);
            adp.Fill(dt2);
            itemtable.DataSource = dt2;
            // this.custTable.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
             adp.Dispose();
            cnn.Close();
        }
        public void paymentId_generation()
        {
            
            query = "select paymentid from payment where paymentid <> '0' and paymentid <> 'PMT00000000' ;";
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            MySqlDataReader reader;
            cnn.Open();         //open1
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
               
                cnn.Close();

                query = "select paymentid from payment where paymentid <> '0' order by paymentid desc limit 1;";
                cmd = new MySqlCommand(query, cnn);
                cnn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string s = reader[0].ToString().Substring(3);

                  
                     if ((Convert.ToInt32(s) + 1) > 9)

                    txtpmtid.Text = "PMT" + Convert.ToString(Convert.ToInt32(Convert.ToInt32(s) + 1)).PadLeft(7, '0');  // myString.padLeft(7,'0')
                      else
                    txtpmtid.Text = "PMT" + Convert.ToString(Convert.ToInt32(Convert.ToInt32(s) + 1)).PadLeft(8, '0');  // myString.padLeft(8,'0')

                }
                cnn.Close();

            }


            else
            {
               
                cnn.Close();
                txtpmtid.Text = "PMT00000001";

            }

           


        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtemail_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtname_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtaddress_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtname_KeyDown_1(object sender, KeyEventArgs e)
        {
            name = txtname.Text;

            if (e.KeyValue == 13)
            {
                if (txtname.Text == "")
                {
                    MessageBox.Show("Customer name is not entered");

                }
                else
                {
                    int i = 0;
                    while (i < name.Length)
                    {
                        if ((name[i] >= 65 && name[i] <= 90) || (name[i] >= 97 && name[i] <= 122)||name[i]==46)
                        {
                            i++;

                        }

                        else
                        {
                            MessageBox.Show("Customer name should have only characters");
                            txtname.Text = "";
                            break;
                        }

                        txtpno1.Focus();
                    }
                   
                }
            }
        }

        private void txtpno1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtpno1.Text.Equals(""))
                {
                    MessageBox.Show("Telephone Number is not Entered ");

                }
                else
                {

                    try
                    {
                        string pno1 = txtpno1.Text;

                        pno11 = Convert.ToInt32(txtpno1.Text);
                        if (pno1.Length == 10)
                        {
                            txtpno2.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Telephone Number should have 10 Numbers ");
                        }

                    }
                    catch (System.FormatException)
                    {

                        MessageBox.Show("Telephone Number Should be Numeric");
                        txtpno1.Text = "";

                    }
                }
            }

        }

        private void txtpno2_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtpno2.Text.Equals(""))
                {
                    MessageBox.Show("Telephone Number is not Entered ");

                }
                else
                {

                    try
                    {
                        string pno2 = txtpno2.Text;

                        pno22 = Convert.ToInt32(txtpno2.Text);

                        if (pno2.Length == 10)
                        {
                            if (pno11 == pno22)
                            {
                                MessageBox.Show("Telephone No1 and Telephone No2 should be different");
                            }
                            else
                                txtaddress1.Focus();

                        }
                        else
                        {
                            MessageBox.Show("Telephone Number should have 10 Numbers ");

                            txtpno2.Text = "";
                        }

                    }
                    catch (System.FormatException)
                    {

                        MessageBox.Show("Telephone Number Should be Numeric");


                    }
                }
            }

        }

        private void txtaddress2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                address2 = txtaddress1.Text;
                if (address2.Equals(""))
                {
                    MessageBox.Show("Address is not Entered ");

                }
                else
                {
                    txtemail.Focus();
                }
            }
        }

        private void txtaddress1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                address1 = txtaddress1.Text;
                if (address1.Equals(""))
                {
                    MessageBox.Show("Address is not Entered ");

                }
                else
                {
                    txtaddress2.Focus();
                }
            }
        }

        private void txtemail_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                email = txtemail.Text;
                if (email.Equals(""))
                {
                    MessageBox.Show("Email is not Entered ");

                }
                else
                {
                    int i = 0;
                    while (i < email.Length)
                    {
                        if ((email[i] >= 65 && email[i] <= 90) || (email[i] >= 97 && email[i] <= 122) || email[i] == 46 || email[i] == 64 || (email[i]>=48 || email[i]<=57))
                        {
                            i++;

                        }

                        else
                        {
                            MessageBox.Show("Email is incorrect");
                            txtemail.Text = "";
                            break;
                        }
                        txtentered.Focus();
                    }

                }
            }
        }

        private void txtentered_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtaddress1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            DialogResult confirm = MessageBox.Show("Do you want to Delete customer", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                query = "delete from customer where cid='" + contentValue + "';";
                MySqlCommand cmd = new MySqlCommand(query, cnn);
                MySqlDataReader reader;
                cnn.Open();
                reader = cmd.ExecuteReader();
                cnn.Close();

                //remove all the rows of table
                while (custTable.Rows.Count > 1)
                {
                    custTable.Rows.RemoveAt(0);
                }

                //fill the table with updated records of customer
                cnn.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter("select * from customer", cnn);


                adp.Fill(dt16);
                custTable.DataSource = dt16;
                this.custTable.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                adp.Dispose();
                cnn.Close();


                MessageBox.Show("Customer has been deleted");  //query will be executed and data deleted

                
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
             
             txtname.Text ="";
             txtaddress1.Text ="";
             txtaddress2.Text ="";
             txtpno1.Text ="";
             txtpno2.Text ="";
             txtemail.Text ="";

            generateCustID();

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void custsearch_KeyDown(object sender, KeyEventArgs e)
        {
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
           String invoiceNo = txtinvoice1.Text;
            String cid = txtcid1.Text;
            String invdate = txtdate1.Text;
            String remark = txtremark.Text;
            String paytype = cmbpaytype.Text;
            String specDisc = txtspecDisc.Text;
            String qtydisc = txtqtyDisc.Text;
            String cashdisc = txtcashDisc.Text;
            String totcost = txttotalCost1.Text;
            String totdisc = txttotalDisc1.Text;
            String netcost = txtnetCost1.Text;
            String seller = txtSeller1.Text;
            String duedate = txtdue.Text;
            String delto = cmbdeliverto.Text;
            String totqty = txttotqty1.Text;
            DateTime DelDate = Convert.ToDateTime(expDelDate.Text);

            query = "select * from invoice where cid='" + cid + "' and invoiceNo='"+ invoiceNo + "';";
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            MySqlDataReader reader;
            cnn.Open();         //open1
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                cnn.Close();        //close open1

                //update

                DialogResult confirm = MessageBox.Show("Do you want to update invoice details", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {

                    cnn.Open();
                    query = "select * from payment where paymentid='0' ;";
                    cmd = new MySqlCommand(query, cnn);
                    reader = cmd.ExecuteReader(); // query will be executed and data updated to the db
                   

                    //if payment made for invoice it can't be updated
                    if (reader.HasRows)
                    {
                        cnn.Close();
                        cnn.Open();
                        query = "update invoice set cid='" + cid + "',invoiceNo='" + invoiceNo + "',cashDisc='" + cashdisc + "',qtyDisc='" + qtydisc + "',specDisc='" + specDisc + "',totCost='" + totcost + "',netCost='" + netcost + "',seller='" + seller + "',totQty='" + totqty + "',deliveryTo='" + delto + "',deliverDate='" + DelDate + "',remark='" + remark + "',createdDate='" + invdate + "',createdBy='" + Homepage.currentUser1 + "',dueDate='" + duedate + "' where cid='" + cid + "' and invoiceNo='" + invoiceNo + "';";
                        cmd = new MySqlCommand(query, cnn);
                        reader = cmd.ExecuteReader(); // query will be executed and data updated to the db
                        cnn.Close();
                        

                        MessageBox.Show("Invoice Details are updated");
                    }
                    else
                    {
                        cnn.Close();
                        MessageBox.Show("Already payments made for the Invoice.Invoice Details can't be updated  ");

                    }
                }

            }
            else
            {
                cnn.Close();        //close open1

                //insert
                DialogResult confirm = MessageBox.Show("Do you want to add invoice Details", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {

                    cnn.Open();
                    query = "insert into invoice (cid,invoiceNo,cashDisc,qtyDisc,specDisc,totCost,netCost,seller,totQty,deliveryTo,deliverDate,remark,createdDate,createdBy,dueDate ) values('" + cid + "','" + invoiceNo + "','" + cashdisc + "','" + qtydisc + "','" + specDisc + "','" + totcost + "','" + netcost + "','" + seller + "','" + totqty + "','" + delto + "','" + DelDate + "','" + remark + "','" + invdate + "','" + Homepage.currentUser1 + "','" + duedate + "' ) ";
                    cmd = new MySqlCommand(query, cnn);
                    reader = cmd.ExecuteReader(); // query will be executed and data saved to the db
                    cnn.Close();

                    cnn.Open();
                    query = "insert into payment (paymentid,cid,invoiceNo,date1,EnteredBy,type,payingAmt,OutstandingAmt,drawnDate,checkNo,refNo,depositeTo) values ( '0','" + cid + "','" + invoiceNo + "','0','" + Homepage.currentUser1 + "','" + paytype + "','0','" + netcost + "','0','0','0','0' );";
                    cmd = new MySqlCommand(query, cnn);
                    reader = cmd.ExecuteReader(); // query will be executed and data updated to the db
                    cnn.Close();

                    MessageBox.Show("Invoice Details are added");

                    txtcid3.Text = cid;
                    //redirect to delivery tab

                    if (paytype.Equals("Immediate"))
                    {
                        tabcontrol_CustMgt.SelectTab(tabpmt);
                        cmbpmtmethod.SelectedValue = "Immediate";
                    }


                }



            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            txtremark.Text = "";
           cmbpaytype.ResetText();
            txtspecDisc.Text = "0";
            txtqtyDisc.Text = "";
            txtcashDisc.Text = "";
            txttotalCost1.Text = "";
            txttotalDisc1.Text = "";
            txtnetCost1.Text = "";
            txtSeller1.Text = "";
            txtdue.Text = "";
            cmbdeliverto.ResetText();
            txttotqty1.Text ="";
            expDelDate.Value = DateTime.Now;

            query = "select invoiceNo as InvoiceNo, createdDate as InvoiceDate from invoice where cid ='" + txtcid1.Text + "' order by  invoiceNo asc;";
            cnn.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter(query, cnn);
            adp.Fill(dt12);
            InvoiceNotable.DataSource = dt12;
            this.InvoiceNotable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            adp.Dispose();
            cnn.Close();

            invoiceNumber();



        }

        private void button15_Click(object sender, EventArgs e)
        {

            DialogResult confirm = MessageBox.Show("Do you want to close", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {


                this.Close();
            }

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Do you want to Delete Delivery Details", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                query = "delete from deliverydetails where CID='" + contentValue1c + "' and showRoomLocation='"+ contentValue1s + "';";
                MySqlCommand cmd = new MySqlCommand(query, cnn);
                MySqlDataReader reader;
                cnn.Open();
                reader = cmd.ExecuteReader();
                cnn.Close();

                //remove all the rows of table
                while (dettable.Rows.Count > 1)
                {
                    dettable.Rows.RemoveAt(0);
                }

                //fill the table with updated records of customer
                cnn.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter("select CID ,showRoomLocation ,address as DeliveryAddress,phoneNo as PhoneNo from deliverydetails", cnn);


                adp.Fill(dt1);
                dettable.DataSource = dt1;
                this.dettable.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dettable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                adp.Dispose();
                cnn.Close();


                MessageBox.Show("Delivery Details has been deleted");  //query will be executed and data deleted
            }

            }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow Datarow in custTable.Rows)
            {
                if (Datarow.Cells[0].Value != null && Datarow.Cells[1].Value != null)
                {
                    contentValue = custTable.SelectedCells[0].Value.ToString();
                   // MessageBox.Show(contentValue);
                   //MessageBox.Show(custTable.SelectedCells[0].Value.ToString());

                }


            }

            query = "select cid as CID,name as Name,pno1 as PhoneNo1,pno2 as PhoneNo2,address1 as Address1,address2 as Address2,Email,EnteredBy   from customer where cid='" + contentValue + "';"; ;
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            MySqlDataReader reader;
            cnn.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                txtcid.Text =reader[0].ToString();
                txtname.Text = reader[1].ToString();
                txtaddress1.Text = reader[4].ToString();
                txtaddress2.Text = reader[5].ToString();
                txtpno1.Text = reader[2].ToString();
                txtpno2.Text = reader[3].ToString();
                txtemail.Text = reader[6].ToString();
                txtentered.Text = reader[7].ToString();
                txtcid1.Text= reader[0].ToString();
                txtciddel.Text= reader[0].ToString();

                

             

            }

            cnn.Close();

            // refresh invoiceNo
            invoiceNumber();
            txtsearchinvoice1.Text = "";
            itemname.Text = "";

            //Display show room location in combo box
             query = "select showRoomLocation from deliverydetails where CID='" + contentValue + "'";
             cmd = new MySqlCommand(query, cnn);
             
            cnn.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                cmbdeliverto.Items.Add(reader[0].ToString()); 
            }

            cnn.Close();

            //display customer's invoice details in invoiceNo table 

            //remove all the rows of table
            while (InvoiceNotable.Rows.Count > 1)
            {
                InvoiceNotable.Rows.RemoveAt(0);
            }


            query = "select invoiceNo as InvoiceNo, createdDate as InvoiceDate from invoice where cid like '%" + contentValue + "%' order by  invoiceNo asc;";
            cnn.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter(query, cnn);
            adp.Fill(dt7);
            InvoiceNotable.DataSource = dt7;
            this.InvoiceNotable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            adp.Dispose();
            cnn.Close();

            //remove all from item table
        /*    while (itemtable.Rows.Count > 1)
            {
                itemtable.Rows.RemoveAt(0);
            }


           */

        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Do you want to close", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {

                
                    this.Close();
            }
           

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            string cname = txtcustpmtdet.Text;
            //remove all the rows of table
            while (pmtIDtable.Rows.Count > 1)
            {
                pmtIDtable.Rows.RemoveAt(0);
            }

            //search customer
            query = "select cid as CID,name as Name from customer where name like '%" + cname + "%';";
            cnn.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter(query, cnn);
            adp.Fill(dt4);
            pmtIDtable.DataSource = dt4;
            this.pmtIDtable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            adp.Dispose();
            cnn.Close();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

          

       }

        private void pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnclose3_Click(object sender, EventArgs e)
        {

            DialogResult confirm = MessageBox.Show("Do you want to close", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {


                this.Close();
            }

        }

        private void custTable_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void InvoiceNotable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }
        private void txtentered_TextChanged(object sender, EventArgs e)
        {

        }

        private void itemtable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string a = null;

            //get row itemcode when a row clicked
            if (itemtable.SelectedCells.Count > 0)
            {
                int selectedrowindex = itemtable.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = itemtable.Rows[selectedrowindex];

                a = Convert.ToString(selectedRow.Cells[0].Value);


            }
            query = "select i.itemCode ,o.qty from item i,orderdetails o where i.itemcode=o.ItemNo and itemCode='" + a + "';"; 
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            MySqlDataReader reader;
            cnn.Open();
            reader = cmd.ExecuteReader();
            AddItem ad = new AddItem(this);
            while (reader.Read())
            {

                ad.txtitems.Text = reader[0].ToString();
                ad.txtqtys.Text = reader[1].ToString();



            }
            ad.ShowDialog();
            cnn.Close();
            /* // display order details in item form
             foreach (DataGridViewRow Datarow in itemtable.Rows)
             {
                 if (Datarow.Cells[0].Value != null && Datarow.Cells[1].Value != null && Datarow.Cells[2].Value != null && Datarow.Cells[3].Value != null 
                     && Datarow.Cells[4].Value != null && Datarow.Cells[5].Value != null && Datarow.Cells[6].Value != null)
                 {
                     contentValue2 = itemtable.SelectedCells[0].Value.ToString();

                     //MessageBox.Show(custTable.SelectedCells[0].Value.ToString());

                 }


             }

             query = "select i.itemCode ,o.qty from item i,orderdetails o where i.itemcode=o.ItemNo and itemCode='" + contentValue2 + "';"; ;
             MySqlCommand cmd = new MySqlCommand(query, cnn);
             MySqlDataReader reader;
             cnn.Open();
             reader = cmd.ExecuteReader();
             AddItem ad = new AddItem(this);
             while (reader.Read())
             {

                 ad.txtitems.Text=reader[0].ToString();
                 ad.txtqtys.Text = reader[1].ToString();



             }
             ad.ShowDialog();
             cnn.Close();*/


        }

        private void itemtable_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void cmbpaytype_SelectedIndexChanged(object sender, EventArgs e)
        {
           string invNo = txtinvoice1.Text;
           
            string paytype = cmbpaytype.SelectedItem.ToString();
            double cashdisc = 0,qtydisc=0,totalCost=0,specdisc=0;

            if (Convert.ToDouble(txtspecDisc.Text) > 0)
            {
                specdisc = Convert.ToDouble(txtspecDisc.Text);
            }

            query = "select sum(totcost),sum(disc),sum(qty)  from orderdetails where invoiceNo='" + invNo + "' ;"; 
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            MySqlDataReader reader;
            cnn.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                totalCost = Convert.ToDouble(reader[0].ToString());
                if (paytype.Equals("Immediate"))
                {

                    cashdisc = totalCost * 2.0 / 100;
                    txtcashDisc.Text = cashdisc.ToString();
                }
                else
                
                    txtcashDisc.Text = "0";

                    txtqtyDisc.Text = reader[1].ToString();
                    qtydisc = Convert.ToDouble(reader[1].ToString());

                    txttotqty1.Text = reader[2].ToString();
                    txttotalCost1.Text = reader[0].ToString();
                
            }
           
            cnn.Close();

            txttotalDisc1.Text = (cashdisc + qtydisc+specdisc).ToString();
            txtnetCost1.Text =( totalCost - (cashdisc + qtydisc+specdisc)).ToString();

         
        }

        private void txtspecPer_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtspecPer_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyValue == 13)
            {
                double specdiscper = Convert.ToDouble(txtspecPer.Text);
                double netcost=0,totcost=0,specdisc=0,totdisc=0;

                string invNo = txtinvoice1.Text;
                query = "select sum(totcost)  from orderdetails where invoiceNo='" + invNo + "' ;"; 
                MySqlCommand cmd = new MySqlCommand(query, cnn);
                MySqlDataReader reader;
                cnn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    totcost = Convert.ToDouble(reader[0].ToString());
                    specdisc = totcost * specdiscper / 100;
                    txtspecDisc.Text = specdisc.ToString();

                }
                cnn.Close();


                totdisc = Convert.ToDouble(txttotalDisc1.Text);
                netcost = Convert.ToDouble(txtnetCost1.Text);

                txttotalDisc1.Text=(totdisc + specdisc).ToString();

                netcost = netcost - specdisc;
                txtnetCost1.Text = netcost.ToString();
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            string pmtid = txtpmtid.Text;
            string totos = lbloutamt.Text;
            string enteredby = EnteredBy2.Text;
            string paymethod = cmbpmtmethod.Text;
            string refno = txtrefNo.Text;
            string checkno = txtcheckNo.Text;
            DateTime tpdrawndate1 = Convert.ToDateTime(tpdrawndate.Text);
            string pmtdate=txtpmtDate.Text;
            string depto=cmbdepto.Text;
            double due = 0, payingamt=0;
            string invoiceno =null;
            
            DialogResult confirm = MessageBox.Show("Do you want to Save changes", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                //get values from datagrid and update database
                for (int rows = 0; rows < pmtTable.Rows.Count-1; rows++)
            {
                
                for (int col = 0; col < pmtTable.Rows[rows].Cells.Count; col++)
                {
                    
                    if (col == 0)
                    {
                        
                       invoiceno = this.pmtTable.Rows[rows].Cells[col].Value.ToString();
                       

                    }
                    else if(col==2)
                    {
                         due= Convert.ToDouble(this.pmtTable.Rows[rows].Cells[col].Value.ToString());
                    }
                    else if(col==3)
                    {
                         payingamt=Convert.ToDouble( this.pmtTable.Rows[rows].Cells[col].Value.ToString());
                        if (payingamt == due)
                        {
                            due = 0;
                        }
                        else
                        {
                            due = due - payingamt;
                        }
                    }

                        cnn.Open();
                        query = "update payment set paymentid='"+ pmtid + "', OutstandingAmt='" + due + "',payingAmt='" + payingamt + "', date1='"+pmtdate+"',EnteredBy='"+Homepage.currentUser1+"',drawnDate='"+tpdrawndate1+ "',checkNo='" + checkno + "',refNo='" + refno + "',depositeTo='" + depto + "' where invoiceNo='" + invoiceno + "';";
                        MySqlCommand cmd = new MySqlCommand(query, cnn);
                        MySqlDataReader reader = cmd.ExecuteReader(); // query will be executed and data updated to the db
                        cnn.Close();

                    }



              
                   
                }



            }
        }

        private void pmtTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void itemtable_Click(object sender, EventArgs e)
        {
            string a = null;

            //get row itemcode when a row clicked
            if (itemtable.SelectedCells.Count > 0)
            {
                int selectedrowindex = itemtable.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = itemtable.Rows[selectedrowindex];

                a = Convert.ToString(selectedRow.Cells[0].Value);


            }
            query = "select i.itemCode ,o.qty from item i,orderdetails o where i.itemcode=o.ItemNo and itemCode='" + a + "';";
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            MySqlDataReader reader;
            cnn.Open();
            reader = cmd.ExecuteReader();
            AddItem ad = new AddItem(this);
            while (reader.Read())
            {

                ad.txtitems.Text = reader[0].ToString();
                ad.txtqtys.Text = reader[1].ToString();
                additemstartqty = Convert.ToInt32(reader[1].ToString());


            }
            ad.gettableValue("0");

            // AddItem ad1 = new AddItem("0");
            ad.ShowDialog();
            
            
           // additemstartqty = Convert.ToInt32(this.itemtable.SelectedRows[0].Cells[5].Value);//get current sellected row cell value
         
            cnn.Close();

        }

        private void pmtIDtable_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void pmtIDtable_Click(object sender, EventArgs e)
        {
            int cid = 0;

            foreach (DataGridViewRow Datarow in pmtIDtable.Rows)
            {
               
                    if (Datarow.Cells[0].Value != null && Datarow.Cells[1].Value != null)
                {
                    try
                    {
                        contentValuep = pmtIDtable.SelectedCells[0].Value.ToString();

                   


                        //if contentValue is CustomerID
                        cid = Convert.ToInt32(contentValuep);
                        cnn.Open();
                        MySqlDataAdapter adp = new MySqlDataAdapter("select paymentid as PaymentID,date1 as PmtDate,sum(OutstandingAmt) as TotalOutStandingAmt  from payment where cid='" + contentValuep + "' GROUP BY paymentid,date1;", cnn);
                        adp.Fill(dt5);
                        pmtIDtable.DataSource = dt5;
                        this.pmtIDtable.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.pmtIDtable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.pmtIDtable.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        adp.Dispose();
                        cnn.Close();

                        txtcid3.Text = contentValuep;

                        //invoice payment table
                        //remove all the rows in table and display data
                        while (pmtTable.Rows.Count > 1)
                        {
                            pmtTable.Rows.RemoveAt(0);
                        }

                        pmtTable.DataSource = null;
                        pmtTable.Rows.Clear();
                        pmtTable.Refresh();

                        cnn.Open();
                        adp = new MySqlDataAdapter("select i.invoiceNo as InvoiceNo,i.createdDate as InvoiceDate ,p.OutstandingAmt as AmtDue,p.payingAmt as PayingAmt from payment p,invoice i where   i.invoiceNo=p.invoiceNo and  p.cid='" + contentValuep + "'  and p.outstandingAmt>0; ", cnn);
                        adp.Fill(dt3);
                        pmtTable.DataSource = dt3;


                        this.pmtTable.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.pmtTable.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.pmtTable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.pmtTable.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        adp.Dispose();
                        cnn.Close();

                        for (int rows = 0; rows < pmtTable.Rows.Count - 1; rows++)
                        {
                            this.pmtTable.Rows[rows].Cells[3].Value = 0;

                        }

                        //display total outstanding amount in tOS lable
                        query = "select sum(OutstandingAmt) from payment where cid='" + contentValuep + "' GROUP BY '" + contentValuep + "';";
                        MySqlCommand cmd = new MySqlCommand(query, cnn);
                        MySqlDataReader reader;
                        cnn.Open();
                        reader = cmd.ExecuteReader();
                        AddItem ad = new AddItem(this);
                        while (reader.Read())
                        {
                            lbloutamt.Text = (Convert.ToDouble(reader[0].ToString())).ToString();


                        }
                        cnn.Close();

                        // pmtIDtable.ClearSelection();
                        pmtIDtable.Rows[0].Selected = false;
                       

                    }
                  
                    catch (FormatException ee)
                    {
                        pmtIDtable.ClearSelection();
                     
                        //clear combo box
                        cmbpmtmethod.ResetText();
                        cmbdepto.ResetText();


                        txtpmtid.Text = contentValuep;
                        query = "select EnteredBy,type,sum(payingAmt),sum(OutstandingAmt),drawnDate,checkNo,refNo,depositeTo from payment where paymentid='" + contentValuep + "' GROUP by paymentid,EnteredBy,type,drawnDate,checkNo,refNo,depositeTo;";
                        MySqlCommand cmd = new MySqlCommand(query, cnn);
                        MySqlDataReader reader;
                        cnn.Open();
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            txtpmtamt.Text = reader[2].ToString();
                            lbloutamt.Text = reader[3].ToString();
                            EnteredBy2.Text = reader[0].ToString();
                            txtrefNo.Text = reader[6].ToString();
                            txtcheckNo.Text = reader[5].ToString();
                            tpdrawndate.Value = Convert.ToDateTime(reader[4].ToString());
                            cmbpmtmethod.SelectedText = (reader[1].ToString());
                            cmbdepto.SelectedText = (reader[7].ToString());
                        }
                        cnn.Close();

                        //remove all the rows in table and display data
                        while (pmtTable.Rows.Count > 1)
                        {
                            pmtTable.Rows.RemoveAt(0);
                        }

                        pmtTable.DataSource = null;
                        pmtTable.Rows.Clear();
                        pmtTable.Refresh();

                        cnn.Open();
                        MySqlDataAdapter adp = new MySqlDataAdapter("select i.invoiceNo as InvoiceNo,i.createdDate as InvoiceDate ,p.OutstandingAmt as AmtDue,p.payingAmt as PayingAmt from payment p,invoice i where   i.invoiceNo=p.invoiceNo and  p.cid='" + contentValuep + "'  ; ", cnn);
                        adp.Fill(dt6);
                        pmtTable.DataSource = dt6;


                        this.pmtTable.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.pmtTable.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.pmtTable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.pmtTable.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        adp.Dispose();
                        cnn.Close();

                    }
                    catch (ArgumentOutOfRangeException ee)
                    {

                        txtpmtamt.Focus();
                    }
                }
                
            }



        }

        private void txtpmtamt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                double amt = Convert.ToDouble(txtpmtamt.Text);
                string cid = txtcid3.Text;

                query = "select sum(OutstandingAmt) from payment where cid='" + cid + "' group by cid ;";
                MySqlCommand cmd = new MySqlCommand(query, cnn);
                MySqlDataReader reader;
                cnn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lbloutamt.Text = (Convert.ToDouble(reader[0].ToString()) - amt).ToString();
                }
                cnn.Close();


               for (int rows = 0; rows < pmtTable.Rows.Count - 1; rows++)
                {
                    double invOSamt = Convert.ToDouble(this.pmtTable.Rows[rows].Cells[2].Value);
                    if (amt >invOSamt)
                    {
                        this.pmtTable.Rows[rows].Cells[3].Value = invOSamt;
                        amt = amt - invOSamt;

                    }
                    else
                    {
                        this.pmtTable.Rows[rows].Cells[3].Value=amt;
                    }

                }
            }
            }

        private void txtpmtamt_Enter(object sender, EventArgs e)
        {
            
          

           
        }

        private void itemname_TextChanged(object sender, EventArgs e)
        {
            string itemName = itemname.Text;
            //remove all the rows of table
            while (InvoiceNotable.Rows.Count > 1)
            {
                InvoiceNotable.Rows.RemoveAt(0);
            }

            //search customer
            query = "select i.Discription as Description,s.quantity as StockQty from item i,stock s where i.itemCode=s.itemCodes and i.discription like '%" + itemName + "%';";
            cnn.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter(query, cnn);
            adp.Fill(dt9);
            InvoiceNotable.DataSource = dt9;
            this.InvoiceNotable.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            adp.Dispose();
            cnn.Close();
        }

        private void expDelDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbdeliverto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string cname = txtdelsearch.Text;
            //remove all the rows of table
            while (custnametable.Rows.Count > 1)
            {
                custnametable.Rows.RemoveAt(0);
            }

            //search customer
            query = "select name as Name,cid as CID from customer where name like '%" + cname + "%';";
            cnn.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter(query, cnn);
            adp.Fill(dt11);
            custnametable.DataSource = dt11;
            this.custnametable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            adp.Dispose();
            cnn.Close();
        }

        private void InvoiceNotable_Click(object sender, EventArgs e)
        {
            int icode = 0;
            string itemcode = null;


            contentValuei = InvoiceNotable.SelectedCells[0].Value.ToString();

           


                

                query = "select itemCode from item where Discription='" + contentValuei + "';";
                MySqlCommand cmd2 = new MySqlCommand(query, cnn);
                cnn.Open();
                MySqlDataReader reader5;
                reader5 = cmd2.ExecuteReader();
                if (reader5.HasRows)
                {
                    while (reader5.Read())
                    {
                        itemcode = reader5[0].ToString();

                    }

                    cnn.Close();

                    AddItem ai = new AddItem(this);
                ai.txtitems.Text = itemcode;
                // AddItem ad1 = new AddItem("1");
                ai.gettableValue("1");
                ai.ShowDialog();
               
                //   additemstartqty1 = Convert.ToInt32(reader[1].ToString());

            }
                else {
                cnn.Close();

                //display invoice details
                InvoiceNotable.ClearSelection();

                //clear combo box
                cmbdeliverto.ResetText();
                cmbpaytype.ResetText();


                txtinvoice1.Text = contentValuei;
                query = "select i.cid,i.cashDisc,i.qtyDisc,i.specDisc,i.totCost,i.netCost,i.seller,i.totQty,i.deliveryto,i.deliverDate,i.remark,i.createdDate,i.dueDate,p.type from invoice i,payment p where p.invoiceNo=i.invoiceNo and i.invoiceNo='" + contentValuei + "';";
                 cmd2 = new MySqlCommand(query, cnn);
                cnn.Open();

                MySqlDataReader reader1;
                reader1 = cmd2.ExecuteReader();

                while (reader1.Read())
                {
                    txtcid1.Text = reader1[0].ToString();
                    txtdate1.Text = reader1[11].ToString();
                    txtremark.Text = reader1[10].ToString();
                    cmbpaytype.SelectedText = reader1[13].ToString();
                    txtspecDisc.Text = reader1[3].ToString();
                    txtqtyDisc.Text = reader1[2].ToString();
                    txtcashDisc.Text = reader1[1].ToString();
                    txttotalCost1.Text = reader1[4].ToString();
                    txttotalDisc1.Text = (Convert.ToDouble(reader1[3].ToString()) + Convert.ToDouble(reader1[2].ToString()) + Convert.ToDouble(reader1[1].ToString())).ToString();
                    txtnetCost1.Text = reader1[5].ToString();
                    txtSeller1.Text = reader1[6].ToString();
                    txtdue.Text = reader1[12].ToString();
                    cmbdeliverto.SelectedText = reader1[8].ToString();
                    txttotqty1.Text = reader1[7].ToString();
                    expDelDate.Value = Convert.ToDateTime(reader1[9].ToString());



                }
                cnn.Close();

                while (itemtable.Rows.Count > 1)
                {
                    itemtable.Rows.RemoveAt(0);
                }

                itemtable.DataSource = null;
                itemtable.Rows.Clear();
                itemtable.Refresh();
                cnn.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter("select i.itemCode as ItemCode,i.Discription as Description,i.sellingPrice as WholesalePrice,i.MRP,o.qty as Qty,o.disc as Disc,o.totcost as TotalCost from item i,orderdetails o where   i.itemCode=o.ItemNo and  invoiceNo='" + contentValuei + "'; ", cnn);
                adp.Fill(dt10);
                itemtable.DataSource = dt10;
                itemtable.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                adp.Dispose();
                cnn.Close();
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            string invno=txtinvoice1.Text;
            query = "select * from payment  where invoiceNo='" + invno + "' and paymentid='0';";
            MySqlCommand cmd2 = new MySqlCommand(query, cnn);
            cnn.Open();

            MySqlDataReader reader1;
            reader1 = cmd2.ExecuteReader();

            if (reader1.HasRows)
            {
                cnn.Close();
               DialogResult confirm = MessageBox.Show("Do you want to cancel the order", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    //delete invoice from payment table
                    query = "delete from payment    where invoiceNo='" + invno + "'  ;";
                    MySqlCommand cmd = new MySqlCommand(query, cnn);
                    MySqlDataReader reader;
                    cnn.Open();
                    reader = cmd.ExecuteReader();
                    cnn.Close();

                   //delete invoice from orderdetails table
                   query = "delete from orderdetails where invoiceNo='" + invno + "';";
                    MySqlCommand cmd3 = new MySqlCommand(query, cnn);
                    cnn.Open();
                    MySqlDataReader reader3;
                    reader3 = cmd3.ExecuteReader();
                    cnn.Close();

                    //delete from invoice table
                    query = "delete from invoice where invoiceNo='" + invno + "';";
                    cmd = new MySqlCommand(query, cnn);
                    cnn.Open();
                     reader = cmd.ExecuteReader();
                    cnn.Close();
                    
                    MessageBox.Show("Order has been canceled");

                }
                
               
            }
            else
            {
                MessageBox.Show("Can't cancel the order. Paymets has been done");

            }
        

      }

        private void button10_Click(object sender, EventArgs e)
        {


            
            lbloutamt.Text = "";
            cmbpmtmethod.ResetText();
            txtcid3.Text = "";
            txtrefNo.Text = "";
            txtcheckNo.Text = "";
            cmbdepto.ResetText();

            tpdrawndate.Value = DateTime.Now;
            while (pmtTable.Rows.Count > 1)
            {
                pmtTable.Rows.RemoveAt(0);
            }


            paymentId_generation();



        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void pmtTable_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string search=cmbsby.Text;

            if (search.Equals( "Invoice No"))
            {
                txtsearchinvoice1.Enabled = true;
                itemname.Enabled = false;
            }
            else if(search.Equals("Item Name"))
            {
                itemname.Enabled = true;
                txtsearchinvoice1.Enabled = false;

            }
        }

        private void pmtIDtable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {

           
        
           

        }

        private void button19_Click(object sender, EventArgs e)
        {
            //if delivery details are not in table add delivery details. else update delivery details

            cid = txtciddel.Text;
            String SRoomloc = SRoomLoc.Text;
            String deladdress = txtdeladd.Text;
            String delpno = txtdelpno.Text;
           

            query = "select * from deliverydetails where CID='" + cid + "' and showRoomLocation='" + SRoomloc + "' ;";
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            MySqlDataReader reader;
            cnn.Open();         //open1
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                cnn.Close();        //close open1

                //update

                DialogResult confirm = MessageBox.Show("Do you want to update Delivery Details", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    cnn.Open();
                    query = "update deliverydetails set CID='" + cid + "',showRoomLocation='" + SRoomloc + "',address='" + deladdress+ "',phoneNo='" +delpno + "' where cid='" + cid + "'and showRoomLocation='" + SRoomloc + "';";
                    cmd = new MySqlCommand(query, cnn);
                    reader = cmd.ExecuteReader(); // query will be executed and data updated to the db
                    cnn.Close();
                    //remove all the rows of table
                    while (dettable.Rows.Count > 1)
                    {
                        dettable.Rows.RemoveAt(0);
                    }

                    //Display added and updated data also in table     

                    dettable.DataSource = null;
                    dettable.Rows.Clear();
                    dettable.Refresh();
                    cnn.Open();
                    MySqlDataAdapter adp = new MySqlDataAdapter("select CID ,showRoomLocation ,address as DeliveryAddress,phoneNo as PhoneNo from deliverydetails", cnn);
                    adp.Fill(dt1);
                    dettable.DataSource = dt1;
                    this.dettable.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dettable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    adp.Dispose();
                    cnn.Close();
                    MessageBox.Show("Delivery Details are updated");

                }

            }
            else
            {
                cnn.Close();        //close open1

                //insert
                DialogResult confirm = MessageBox.Show("Do you want to add Delivery Details", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {

                    cnn.Open();
                    query = "insert into deliverydetails (CID,showRoomLocation,address,phoneNo) values('" + cid + "','" + SRoomloc + "','" + deladdress + "','" + delpno + "'); ";
                    cmd = new MySqlCommand(query, cnn);
                    reader = cmd.ExecuteReader(); // query will be executed and data saved to the db
                    cnn.Close();

                    //remove all the rows of table
                    while (dettable.Rows.Count > 1)
                    {
                        dettable.Rows.RemoveAt(0);
                    }

                    //Display added and updated data also in table     

                    dettable.DataSource = null;
                    dettable.Rows.Clear();
                    dettable.Refresh();
                    cnn.Open();
                    MySqlDataAdapter adp = new MySqlDataAdapter("select CID ,showRoomLocation ,address as DeliveryAddress,phoneNo as PhoneNo from deliverydetails", cnn);
                    adp.Fill(dt1);
                    dettable.DataSource = dt1;
                    this.dettable.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dettable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    adp.Dispose();
                    cnn.Close();
                    MessageBox.Show("Delivery Details are added");

                    confirm = MessageBox.Show("Do you want to add Payment Details", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        txtcid1.Text=txtciddel.Text;
                        //redirect to delivery tab
                        tabcontrol_CustMgt.SelectTab(tab_salesorder);

                    }





                }



            }

        }

        private void dettable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            foreach (DataGridViewRow Datarow in dettable.Rows)
            {
                if (Datarow.Cells[0].Value != null && Datarow.Cells[1].Value != null)
                {
                    contentValue1c = dettable.SelectedCells[0].Value.ToString();
                    contentValue1s = dettable.SelectedCells[1].Value.ToString();
                 //MessageBox.Show(contentValue1s);
                    //MessageBox.Show(custTable.SelectedCells[0].Value.ToString());

                }


            }

            query = "select CID,showRoomLocation,address,phoneNo   from deliverydetails where CID='" + contentValue1c + "' and showRoomLocation='" + contentValue1s + "';"; ;
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            MySqlDataReader reader;
            cnn.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                txtciddel.Text = reader[0].ToString();
                SRoomLoc.Text = reader[1].ToString();
                txtdeladd.Text = reader[2].ToString();
                txtdelpno.Text = reader[3].ToString();




            }

            cnn.Close();
        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
          
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void invsearch_Click(object sender, EventArgs e)
        {
            string invoiceNo1 = txtsearchinvoice1.Text;
            //remove all the rows of table
            while (itemtable.Rows.Count > 1)
            {
                itemtable.Rows.RemoveAt(0);
            }

            //search invoice
            query = "select o.itemNo,i.description,i.sellingPrice,o.qty,o.totDisc,o.netCost from order o,item i where o.itemNo=i.itemNo and invoiceNo like '" + invoiceNo1 + "%';";
            cnn.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter(query, cnn);
            adp.Fill(dt);
            itemtable.DataSource = dt;
            this.itemtable.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            adp.Dispose();
            cnn.Close();
        }

        private void txtinvoice1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsearchinvoice1_TextChanged(object sender, EventArgs e)
        {
            string inv = txtsearchinvoice1.Text;
            string cid = txtcid1.Text;

            //if cid ="" search from all invoices else search only cid's invoice
            if (cid.Equals(""))
            {
                //remove all the rows of table
                while (InvoiceNotable.Rows.Count > 1)
                {
                    InvoiceNotable.Rows.RemoveAt(0);
                }

                //search customer
                query = "select invoiceNo as InvoiceNo,createdDate as InvoiceDate from invoice where invoiceNo like '%" + inv + "%';";
                cnn.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter(query, cnn);
                adp.Fill(dt8);
                InvoiceNotable.DataSource = dt8;
                this.InvoiceNotable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                adp.Dispose();
                cnn.Close();
            }
            else
            {

                while (InvoiceNotable.Rows.Count > 1)
                {
                    InvoiceNotable.Rows.RemoveAt(0);
                }

                //search customer
                query = "select invoiceNo as InvoiceNo,createdDate as InvoiceDate from invoice where invoiceNo like '%" + inv + "%' and cid='"+cid+"';";
                cnn.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter(query, cnn);
                adp.Fill(dt8);
                InvoiceNotable.DataSource = dt8;
                this.InvoiceNotable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                adp.Dispose();
                cnn.Close();



            }
        }

        private void button9_Click_2(object sender, EventArgs e)
        {
            invoiceNo = txtinvoice1.Text;
            //itemCode = txtItemCode1.Text;
            //qty = Convert.ToInt32(txtqty1.Text);
            cid = txtcid1.Text;
            cashDisc = Convert.ToDouble(txtcashDisc.Text);
            specDisc = Convert.ToDouble(txtspecDisc.Text);
            qtyDisc = Convert.ToDouble(txtqtyDisc.Text);




            DialogResult confirm = MessageBox.Show("Do you want to add item", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                query = "insert into order (invoiceNo,ItemNo,cid,qty,cashDisc,specDisc,qtyDisc,totDisc,netCost,Date,seller,DueDate,remark) values('" + cid + "','" + name + "','" + pno11 + "','" + pno22 + "','" + address1 + "','" + address2 + "','" + email + "','" + enteredBy + "'); ";
                MySqlCommand cmd = new MySqlCommand(query, cnn);
                MySqlDataReader reader;
                cnn.Open();
                reader = cmd.ExecuteReader();
                cnn.Close();
            }
        }

        private void txtqty1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtItemCode1_KeyDown(object sender, KeyEventArgs e)
        {
            //itemCode = txtItemCode1.Text;
            //txtqty1.Focus();
        }

        private void custsearch_TextChanged(object sender, EventArgs e)
        {
            string sname = custsearch.Text;
            //remove all the rows of table
            while (custTable.Rows.Count > 1)
            {
                custTable.Rows.RemoveAt(0);
            }

            //search customer
            query = "select cid as CID,name as Name,pno1 as PhoneNo1,pno2 as PhoneNo2,address1 as Address1,address2 as Address2,Email,EnteredBy from customer where name like '%" + sname + "%';";
            cnn.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter(query, cnn);
            adp.Fill(dt);
            custTable.DataSource = dt;
            this.custTable.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            adp.Dispose();
            cnn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sname = custsearch.Text;
            //remove all the rows of table
            while (custTable.Rows.Count > 1)
            {
                custTable.Rows.RemoveAt(0);
            }

            //search customer
            query = "select * from customer where name like '" + sname + "%';";
            cnn.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter(query, cnn);
            adp.Fill(dt);
            custTable.DataSource = dt;
            this.custTable.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            adp.Dispose();
            cnn.Close();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
           //if cid is not in table add customer. else update customer

            cid = txtcid.Text;
            name = txtname.Text;
            address1 = txtaddress1.Text;
            address2 = txtaddress2.Text;
            pno11 = Convert.ToInt32(txtpno1.Text);
            pno22 = Convert.ToInt32(txtpno2.Text);
            email = txtemail.Text;
            enteredBy = txtentered.Text;

            query = "select * from customer where cid='"+cid+"';";
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            MySqlDataReader reader;
            cnn.Open();         //open1
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                cnn.Close();        //close open1
               
                //update
                
                DialogResult confirm = MessageBox.Show("Do you want to update customer", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    cnn.Open();
                    query = "update customer set name='" + name + "',pno1='" + pno11 + "',pno2='" + pno22 + "',address1='" + address1 + "',address2='" + address2 + "',Email='" + email + "',EnteredBy='" + enteredBy + "' where cid='" + cid + "';";
                    cmd = new MySqlCommand(query, cnn);
                    reader = cmd.ExecuteReader(); // query will be executed and data updated to the db
                    cnn.Close();
                    //remove all the rows of table
                    while (custTable.Rows.Count > 1)
                    {
                        custTable.Rows.RemoveAt(0);
                    }

                    //Display added and updated data also in table     

                    custTable.DataSource = null;
                    custTable.Rows.Clear();
                    custTable.Refresh();
                    cnn.Open();
                    MySqlDataAdapter adp = new MySqlDataAdapter("select * from customer", cnn);
                    adp.Fill(dt);
                    custTable.DataSource = dt;
                    this.custTable.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    adp.Dispose();
                    cnn.Close();
                    MessageBox.Show("Customer Details are updated");
                 
                }
               
            }
            else
            {
                cnn.Close();        //close open1
                
                //insert
                DialogResult confirm = MessageBox.Show("Do you want to add customer", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {

                    cnn.Open();
                    query = "insert into customer (cid,name,pno1,pno2,address1,address2,Email,EnteredBy) values('" + cid + "','" + name + "','" + pno11 + "','" + pno22 + "','" + address1 + "','" + address2 + "','" + email + "','" + enteredBy + "'); ";
                    cmd = new MySqlCommand(query, cnn);
                    reader = cmd.ExecuteReader(); // query will be executed and data saved to the db
                    cnn.Close();
                    
                    //remove all the rows of table
                    while (custTable.Rows.Count > 1)
                    {
                        custTable.Rows.RemoveAt(0);
                    }

                    //Display added and updated data also in table     

                    custTable.DataSource = null;
                    custTable.Rows.Clear();
                    custTable.Refresh();
                    cnn.Open();
                    MySqlDataAdapter adp = new MySqlDataAdapter("select * from customer", cnn);
                    adp.Fill(dt);
                    custTable.DataSource = dt;
                    this.custTable.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    adp.Dispose();
                    cnn.Close();
                    MessageBox.Show("Customer Details are added");

                    txtciddel.Text = cid;

                     confirm = MessageBox.Show("Do you want to add Delivery Details", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {

                        //redirect to delivery tab
                        tabcontrol_CustMgt.SelectTab(tab_Delivery);

                    }

                }

                
                 
            }

           
         }

        private void txtpno1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtpno2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Customer_Management_Load(object sender, EventArgs e)
        {

            string w = Screen.FromControl(home).WorkingArea.Width.ToString();
            this.Location = new Point((Convert.ToInt32(w) - this.Width) / 2, 120);
            FormBorderStyle = FormBorderStyle.FixedSingle;


            

        }

        private void txtcid_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcid_KeyDown(object sender, KeyEventArgs e)
        {
            

            if (e.KeyValue == 13)
            {
                if (txtcid.Text == "")
                {
                    MessageBox.Show("CustomerID is not entered");

                }
                else
                {
                    cid = txtcid.Text;
                    if ((cid.Trim().Length != 3))
                    {
                        MessageBox.Show("CustomerID should have 3 characters ");
                        txtcid.Text = "";
                    }
                    else
                        txtname.Focus();
                }
            }
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
