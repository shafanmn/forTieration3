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
    public partial class AddItem : Form
    {
        
        private string tableValue1;
        private Customer_Management cm;
        //public Customer_Management cm = new Customer_Management();
        String query;
        MySqlConnection cnn = new MySqlConnection("Server=localhost;Database=inventory;Uid=root;Pwd=;");
        DataTable dt2 = new DataTable();
        DataTable dt13 = new DataTable();

        public AddItem()
        {

            InitializeComponent();
        }
        public AddItem(Customer_Management cs1 )
        {
            
            
            cm = cs1;
            InitializeComponent();
        }
        public void gettableValue(string tb)
        {

            tableValue1 = tb;

        }
     /*   public AddItem(string tb)
        {
            InitializeComponent();
            this.tableValue1 =tb;
           
            MessageBox.Show("tableValue1" + tableValue1);
            MessageBox.Show("tb" + tb);
            
        }*/

        private void AddItem_Load(object sender, EventArgs e)
        {
            /*  WindowState = FormWindowState.Maximized;
              TopMost = false;
              AddItem.Size = new Size(300, 300);
              this.Location = new Point((Convert.ToInt32(w) - this.Width) / 2, 120);
              FormBorderStyle = FormBorderStyle.FixedSingle;*/

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {

            int stock = 0;
            double disc = 0;
            double totcost = 0;
            string icode = txtitems.Text;
            int qty = Convert.ToInt32(txtqtys.Text);
            string invoiceNo = cm.txtinvoice1.Text;

           

            query = "select quantity from stock where itemCodes='" + icode + "';";
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            MySqlDataReader reader;
            cnn.Open();         //open1
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                stock = Convert.ToInt32(reader[0].ToString());
            }
            cnn.Close();

            //calculate quantity disc and total cost
            query = "select MRP,sellingPrice from item where itemCode='" + icode + "';";
            cmd = new MySqlCommand(query, cnn);

            cnn.Open();         //open1
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (qty > 24)
                {
                    disc = Convert.ToDouble(reader[0].ToString()) * 35 / 100 * (qty - 12);
                }
                totcost = qty * Convert.ToDouble(reader[1].ToString());

            }
            cnn.Close();
            
            //stock calculation
            if ( tableValue1=="0")
            {



                if (qty > cm.additemstartqty)
                {

                    //if extra added qty is greater than stock show error msg
                    if ((qty - cm.additemstartqty) <= stock)
                    {
                       // MessageBox.Show("stockg" + stock + "qty" + qty + "extra" + (cm.additemstartqty - qty));

                        DialogResult confirm = MessageBox.Show("Do you want to update Order Details", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (confirm == DialogResult.Yes)
                        {
                            cnn.Open();
                            query = "update stock set quantity='" + (stock - (qty - cm.additemstartqty)) + "' where itemCodes='" + icode + "';";
                            cmd = new MySqlCommand(query, cnn);
                            reader = cmd.ExecuteReader(); // query will be executed and data updated to the db
                            cnn.Close(); 

                            cnn.Open();
                            query = " update orderdetails set qty='" + qty + "',disc='" + disc + "',totcost='" + totcost + "' where invoiceNo='" + invoiceNo + "' and itemNo='" + icode + "'; ";
                             cmd = new MySqlCommand(query, cnn);
                            
                            reader = cmd.ExecuteReader(); // query will be executed and data saved to the db
                            cnn.Close();

                            this.Close();
                        }

                        while (cm.InvoiceNotable.Rows.Count > 1)
                        {
                            cm.InvoiceNotable.Rows.RemoveAt(0);
                        }

                        cm.InvoiceNotable.DataSource = null;
                        cm.InvoiceNotable.Rows.Clear();
                        cm.InvoiceNotable.Refresh();
                        cnn.Open();
                        MySqlDataAdapter adp = new MySqlDataAdapter("select i.Discription as Description,s.quantity as StockQty from item i,stock s where i.itemCode=s.itemCodes ; ", cnn);
                        adp.Fill(dt13);
                        cm.InvoiceNotable.DataSource = dt13;
                        this.cm.InvoiceNotable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        adp.Dispose();
                        cnn.Close();

                        while (cm.itemtable.Rows.Count > 1)
                        {
                            cm.itemtable.Rows.RemoveAt(0);


                        }

                        //Display added and updated data also in table     

                        cm.itemtable.DataSource = null;
                        cm.itemtable.Rows.Clear();
                        cm.itemtable.Refresh();
                        cnn.Open();
                         adp = new MySqlDataAdapter("select i.itemCode as ItemCode,i.Discription as Description,i.sellingPrice as WholesalePrice,i.MRP,o.qty as Qty,o.disc as Disc,o.totcost as TotalCost from item i,orderdetails o where i.itemCode=o.ItemNo and  invoiceNo='" + invoiceNo + "';", cnn);
                        adp.Fill(dt2);
                        cm.itemtable.DataSource = dt2;
                        this.cm.itemtable.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        adp.Dispose();
                        cnn.Close();
                    }
                    else {
                       // MessageBox.Show("stockg" + stock + "qty" + qty + "extra" + (cm.additemstartqty - qty));

                        MessageBox.Show("The stock available is " + stock);
                        txtqtys.Text = "";
                    }
                }
                else
                {
                  //  MessageBox.Show("stock"+stock+"qty"+qty+"extra"+ (cm.additemstartqty - qty));
                    

                    DialogResult confirm = MessageBox.Show("Do you want to update Order Details", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        cnn.Open();
                        query = "update stock set quantity='" + (stock + (cm.additemstartqty - qty)) + "' where itemCodes='" + icode + "';";
                        cmd = new MySqlCommand(query, cnn);
                        reader = cmd.ExecuteReader(); // query will be executed and data updated to the db
                        cnn.Close();

                        cnn.Open();
                        query = " update orderdetails set qty='" + qty + "',disc='" + disc + "',totcost='" + totcost + "' where invoiceNo='" + invoiceNo + "' and itemNo='" + icode + "'; ";
                        cmd = new MySqlCommand(query, cnn);

                        reader = cmd.ExecuteReader(); // query will be executed and data saved to the db
                        cnn.Close();

                        this.Close();

                    }

                    while (cm.InvoiceNotable.Rows.Count > 1)
                    {
                        cm.InvoiceNotable.Rows.RemoveAt(0);
                    }

                    cm.InvoiceNotable.DataSource = null;
                    cm.InvoiceNotable.Rows.Clear();
                    cm.InvoiceNotable.Refresh();
                    cnn.Open();
                    MySqlDataAdapter adp = new MySqlDataAdapter("select i.Discription as Description,s.quantity as StockQty from item i,stock s where i.itemCode=s.itemCodes ; ", cnn);
                    adp.Fill(dt13);
                    cm.InvoiceNotable.DataSource = dt13;
                    this.cm.InvoiceNotable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    adp.Dispose();
                    cnn.Close();

                    while (cm.itemtable.Rows.Count > 1)
                    {
                        cm.itemtable.Rows.RemoveAt(0);


                    }

                    //Display added and updated data also in table     

                    cm.itemtable.DataSource = null;
                    cm.itemtable.Rows.Clear();
                    cm.itemtable.Refresh();
                    cnn.Open();
                     adp = new MySqlDataAdapter("select i.itemCode as ItemCode,i.Discription as Description,i.sellingPrice as WholesalePrice,i.MRP,o.qty as Qty,o.disc as Disc,o.totcost as TotalCost from item i,orderdetails o where i.itemCode=o.ItemNo and  invoiceNo='" + invoiceNo + "';", cnn);
                    adp.Fill(dt2);
                    cm.itemtable.DataSource = dt2;
                    this.cm.itemtable.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    adp.Dispose();
                    cnn.Close();
                }
            }



            else {



                query = "select * from orderdetails where ItemNo='" + icode + "' and  invoiceNo='" + invoiceNo + "';";
                MySqlCommand cmd1 = new MySqlCommand(query, cnn);
                MySqlDataReader reader1;
                cnn.Open();         //open1
                reader1 = cmd1.ExecuteReader();

                if (reader1.HasRows && tableValue1=="1")
                {
                    cnn.Close();        //close open1

                    MessageBox.Show("Items are already added");
                    this.Close();

                }
                else
                {
                  

                    cnn.Close();        //close open1
                  
                    if ((qty > stock) && (tableValue1=="1"))
                    {

                        

                        MessageBox.Show("The stock available is " + stock);
                        txtqtys.Text = "";
                    }
                    else if ((qty <= stock )&& (tableValue1=="1"))
                   {
                        //  MessageBox.Show("stock" + stock + "qty" + qty + "tableval" + cm.tableValue1);
                        //insert
                       

                        DialogResult confirm = MessageBox.Show("Do you want to add Order Details", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (confirm == DialogResult.Yes)
                        {

                            cnn.Open();
                            query = "insert into orderdetails (invoiceNo,ItemNo,qty,disc,totcost) values('" + invoiceNo + "','" + icode + "','" + qty + "','" + disc + "','" + totcost + "'); ";
                            cmd1 = new MySqlCommand(query, cnn);
                            reader1 = cmd1.ExecuteReader(); // query will be executed and data saved to the db
                            cnn.Close();

                            //remove all the rows of table
                            while (cm.itemtable.Rows.Count > 1)
                            {
                                cm.itemtable.Rows.RemoveAt(0);


                            }

                            //Display added and updated data also in table     

                            cm.itemtable.DataSource = null;
                            cm.itemtable.Rows.Clear();
                            cm.itemtable.Refresh();
                            cnn.Open();
                            MySqlDataAdapter adp = new MySqlDataAdapter("select i.itemCode as ItemCode,i.Discription as Description,i.sellingPrice as WholesalePrice,i.MRP,o.qty as Qty,o.disc as Disc,o.totcost as TotalCost from item i,orderdetails o where i.itemCode=o.ItemNo and  invoiceNo='" + invoiceNo + "';", cnn);
                            adp.Fill(dt2);
                            cm.itemtable.DataSource = dt2;
                            this.cm.itemtable.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            adp.Dispose();
                            cnn.Close();
                            //display updated qty in invoice table
                            while (cm.InvoiceNotable.Rows.Count > 1)
                            {
                                cm.InvoiceNotable.Rows.RemoveAt(0);
                            }

                            //Display added and updated data also in table     

                            cm.InvoiceNotable.DataSource = null;
                            cm.InvoiceNotable.Rows.Clear();
                            cm.InvoiceNotable.Refresh();
                            cnn.Open();
                            adp = new MySqlDataAdapter("select i.Discription as Description,s.quantity as StockQty from item i,stock s where i.itemCode=s.itemCodes ; ", cnn);
                            adp.Fill(dt13);
                            cm.InvoiceNotable.DataSource = dt13;
                            this.cm.InvoiceNotable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            adp.Dispose();
                            cnn.Close();
                            MessageBox.Show("Order Details are added");


                            cnn.Open();
                            query = "update stock set quantity='" + (stock - qty) + "' where itemCodes='" + icode + "';";
                            cmd = new MySqlCommand(query, cnn);
                            reader = cmd.ExecuteReader(); // query will be executed and data updated to the db
                            cnn.Close();

                            this.Close();

                        }

                       }

                    }




              }
            
       

            cm.Show();

        }

        private void txtitems_TextChanged(object sender, EventArgs e)
        {  
        }

        private void btncancel_Click(object sender, EventArgs e)
        {

            DialogResult confirm = MessageBox.Show("Do you want to close", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {


                this.Close();
            }

        }

        private void txtqtys_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtqtys.Text)>=0)
            {
                // if cid is not available can't add order details
                if (cm.txtcid1.Text.Equals(""))
                {
                    MessageBox.Show("CID should be selected");
                    cm.tabcontrol_CustMgt.SelectTab(cm.cst_tab);
                }
                else
                {
                    txtqtys.Focus();
                }
            }
            else
            {
                MessageBox.Show("Quantity should be greater than or equal to zero");
            }
        }
    }
}
