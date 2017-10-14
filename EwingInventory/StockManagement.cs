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
    public partial class StockManagement : Form
    {
        static string myConnection = "Server=localhost;Database=inventory;Uid=root;Pwd=;";
        MySqlConnection con = new MySqlConnection(myConnection);
        MySqlCommand cmd;
        DataTable dt = new DataTable();
        DataTable dtt = new DataTable();
        MySqlDataAdapter adapter;



        //populates
        private void populate03(string itemCode, string ReOrder_Level, string Discription)
        {

            reordergrid.Rows.Add(itemCode, ReOrder_Level, Discription);
        }
        private void populate05(string itemcode, string Location, string sellingPrice, string MRP, string Discription, string quantity)
        {

            InventorydataGridView.Rows.Add(itemcode, Location, sellingPrice, MRP, Discription, quantity);
        }
        private void populate100(string itemcode, string Location, string sellingPrice, string MRP, string Discription)
        {

            updatesitems.Rows.Add(itemcode, Location, sellingPrice, MRP, Discription);
        }

        private void populate101(string Date, string discription, string itemCode, string NewQuantity, string PreviousQuantity, string quantityLost, string reason, string Location)
        {

            ViewSadjustment.Rows.Add(Date, discription, itemCode, NewQuantity, PreviousQuantity, quantityLost, reason, Location);
        }


        //Homepage home = new Homepage();
        public StockManagement()
        {
            InitializeComponent();
            //stock adjustment table


            ViewSadjustment.ColumnCount = 8;
            ViewSadjustment.Columns[0].Name = "Date";
            ViewSadjustment.Columns[1].Name = "Discription";
            ViewSadjustment.Columns[2].Name = "itemCode";
            ViewSadjustment.Columns[3].Name = "NewQuantity";
            ViewSadjustment.Columns[4].Name = "PreviousQuantity";
            ViewSadjustment.Columns[5].Name = "quantityLost";
            ViewSadjustment.Columns[6].Name = "reason";
            ViewSadjustment.Columns[7].Name = "Location";
            ViewSadjustment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ViewSadjustment.MultiSelect = false;
            ViewSadjustment.Rows.Clear();

            string sql = "select stockadjustments.Date,item.Discription,stockadjustments.itemCode,stockadjustments.NewQuantity,stockadjustments.PreviousQuantity,stockadjustments.quantityLost,stockadjustments.reason,stockadjustments.Location from stockadjustments,item  where stockadjustments.itemCode=item.itemCode";
            cmd = new MySqlCommand(sql, con);
            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(sql, con);
                adapter.Fill(dtt);

                foreach (DataRow row in dtt.Rows)
                {
                    populate101(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString());
                }

                con.Close();
                dtt.Rows.Clear();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }


            //data grid updates
            updatesitems.ColumnCount = 5;
            updatesitems.Columns[0].Name = "itemCode";
            updatesitems.Columns[1].Name = "Location";
            updatesitems.Columns[2].Name = "sellingPrice";
            updatesitems.Columns[3].Name = "MRP";
            updatesitems.Columns[4].Name = "Discription";

            //
            updatesitems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            updatesitems.MultiSelect = false;
            updatesitems.Rows.Clear();

            sql = "select itemCode,Location,sellingPrice,MRP,Discription from item";
            cmd = new MySqlCommand(sql, con);

            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(sql, con);
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    populate100(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                }

                con.Close();
                dt.Rows.Clear();
            }
            catch (Exception exception)
            { MessageBox.Show(exception.Message); }
            //view Inventory grid
            InventorydataGridView.ColumnCount = 6;
            InventorydataGridView.Columns[0].Name = "itemCode";
            InventorydataGridView.Columns[1].Name = "Location";
            InventorydataGridView.Columns[2].Name = "sellingPrice";
            InventorydataGridView.Columns[3].Name = "MRP";
            InventorydataGridView.Columns[4].Name = "Discription";
            InventorydataGridView.Columns[5].Name = "quantity";


            InventorydataGridView.Columns[0].Width = 115;
            InventorydataGridView.Columns[1].Width = 115;
            InventorydataGridView.Columns[2].Width = 115;
            InventorydataGridView.Columns[3].Width = 115;
            InventorydataGridView.Columns[4].Width = 115;
            InventorydataGridView.Columns[5].Width = 115;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill;

            InventorydataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            InventorydataGridView.MultiSelect = false;
            InventorydataGridView.Rows.Clear();

            sql = "select itemCode,Location,sellingPrice,MRP,Discription,quantity from item,stock where item.itemCode=stock.itemCodes and stock.quantity > 0 ";
            cmd = new MySqlCommand(sql, con);

            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(sql, con);
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    populate05(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
                }

                con.Close();
                dt.Rows.Clear();
            }
            catch (Exception exception)
            { MessageBox.Show(exception.Message); }


            //load ReOrderLevelGrid
            DataTable dtx = new DataTable();
            cmd = con.CreateCommand();
            cmd.CommandText = "Select itemCode from item";
            try
            {
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                reordercbox.Items.Clear();
                while (reader.Read())
                {
                    reordercbox.Items.Add(reader["itemCode"]);

                }
                con.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }

            //Load table
            reordergrid.ColumnCount = 3;
            reordergrid.Columns[2].Name = "itemCode";
            reordergrid.Columns[1].Name = "ReOrder_Level";
            reordergrid.Columns[0].Name = "Discription";

            reordergrid.Columns[0].Width = 180;
            reordergrid.Columns[1].Width = 180;


            //
            reordergrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            reordergrid.MultiSelect = false;
            reordergrid.Rows.Clear();

            string mmsql = "select item.itemCode , reorderlevel.reOrderPoint , item.Discription from reorderlevel,item where reorderlevel.itemCode=item.itemCode";
            cmd = new MySqlCommand(mmsql, con);

            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(mmsql, con);
                adapter.Fill(dtx);

                foreach (DataRow row in dtx.Rows)
                {
                    populate03(row[2].ToString(), row[1].ToString(), row[0].ToString());
                }

                con.Close();
                dtx.Rows.Clear();
            }
            catch (Exception exception)
            { MessageBox.Show(exception.Message); }

            //load stock adjustment tab
            cmd = con.CreateCommand();
            cmd.CommandText = "Select Discription from item";
            try
            {
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                sacbox.Items.Clear();
                while (reader.Read())
                {
                    sacbox.Items.Add(reader["Discription"]);

                }
                con.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }


            //

            //load location to combo box1 
            cmd = con.CreateCommand();
            cmd.CommandText = "Select location from location";
            try
            {
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                LO.Items.Clear();
                while (reader.Read())
                {
                    LO.Items.Add(reader["location"]);

                }
                con.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }
            LO.Items.Add("Add New Location");
        }

        private void itcode_TextChanged(object sender, EventArgs e)
        {
            int s;

            if (!(int.TryParse(itcode.Text, out s)))
            { label18.Show(); }
            else
            { label18.Visible = false; }
        }

        private void SP_TextChanged(object sender, EventArgs e)
        {
            int s;

            if (!(int.TryParse(SP.Text, out s)))
            { label21.Show(); }
            else
            { label21.Visible = false; }
        }

        private void MR_TextChanged(object sender, EventArgs e)
        {
            int s;

            if (!(int.TryParse(MR.Text, out s)))
            { label23.Show(); }
            else
            { label23.Visible = false; }
        }

        private void itemSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            updatesitems.ColumnCount = 5;
            updatesitems.Columns[0].Name = "itemCode";
            updatesitems.Columns[1].Name = "Location";
            updatesitems.Columns[2].Name = "sellingPrice";
            updatesitems.Columns[3].Name = "MRP";
            updatesitems.Columns[4].Name = "Discription";


            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill;

            updatesitems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            updatesitems.MultiSelect = false;
            updatesitems.Rows.Clear();

            string sql = "select itemCode,Location,sellingPrice,MRP,Discription from item where item.itemCode like '%" + itemSearch.Text + "%' OR item.Location like '%" + itemSearch.Text + "%' OR item.sellingPrice like '%" + itemSearch.Text + "%' OR item.MRP like '%" + itemSearch.Text + "%' OR item.Discription like '%" + itemSearch.Text + "%' ";
            cmd = new MySqlCommand(sql, con);

            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(sql, con);
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    populate100(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                }

                con.Close();
                dt.Rows.Clear();
            }
            catch (Exception exception)
            { MessageBox.Show(exception.Message); }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (itcode.Text == "" && MR.Text == "" && LO.Text == "" && SP.Text == "" && Descr.Text == "")
            {
                MessageBox.Show("Enter Values to All Fields !");

            }
            else
            {
                string query = "select * from item where itemCode='" + itcode.Text + "';";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader;
                con.Open();         //open1
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    //close open1
                    con.Close();
                    //update

                    DialogResult confirm = MessageBox.Show("Do you want to update Item ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {

                        //update
                        string sql = "update item set Location='" + LO.Text + "',sellingPrice='" + SP.Text + "',MRP='" + MR.Text + "',Discription='" + Descr.Text + "' where itemCode='" + itcode.Text + "'";
                        cmd = new MySqlCommand(sql, con);

                        try
                        {
                            con.Open();
                            adapter = new MySqlDataAdapter(cmd);
                            adapter.UpdateCommand = con.CreateCommand();
                            adapter.UpdateCommand.CommandText = sql;

                            if (adapter.UpdateCommand.ExecuteNonQuery() > 0)

                            { MessageBox.Show("Successfully Updated !"); }
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            con.Close();
                            MessageBox.Show(ex.Message);
                            MessageBox.Show("Please Input correct data to correct fields");

                        }



                        //reload the tabel
                        updatesitems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        updatesitems.MultiSelect = false;
                        updatesitems.Rows.Clear();

                        string msql = "select itemCode,Location,sellingPrice,MRP,Discription from item";
                        cmd = new MySqlCommand(msql, con);

                        try
                        {
                            con.Open();
                            adapter = new MySqlDataAdapter(msql, con);
                            adapter.Fill(dt);

                            foreach (DataRow row in dt.Rows)
                            {
                                populate100(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                            }

                            con.Close();
                            dt.Rows.Clear();
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message);


                        }


                        refresh();

                    }

                }
                else
                {
                    con.Close();        //close open1

                    //insert
                    DialogResult confirm = MessageBox.Show("Do you want to add Item ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {


                        //add to item table 
                        string sql = "INSERT INTO `item` (`itemCode`,`Location`,`sellingPrice`,`MRP`,`Discription`) VALUES ('" + itcode.Text + "','" + LO.Text + "','" + SP.Text + "','" + MR.Text + "','" + Descr.Text + "')";
                        cmd = new MySqlCommand(sql, con);
                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Successfully Item Added");

                            con.Close();

                        }
                        catch (Exception except)
                        {
                            con.Close();
                        }


                        int x = 0;
                        //add to reorder table
                        sql = "INSERT INTO `reorderlevel` (`itemCode`,`reOrderPoint`) VALUES ('" + itcode.Text + "','" + x + "')";
                        cmd = new MySqlCommand(sql, con);
                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();


                            con.Close();

                        }
                        catch (Exception except)
                        {

                            con.Close();
                        }
                        //add to stock table

                        sql = "INSERT INTO `stock` (`quantity`,`itemCodes`) VALUES ('" + x + "','" + itcode.Text + "')";
                        cmd = new MySqlCommand(sql, con);
                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();


                            con.Close();

                        }
                        catch (Exception except)
                        {
                            MessageBox.Show("Please Input correct data to correct fields"); //,"Errer", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)

                            con.Close();
                        }


                        refresh();

                    }
                }

                refresh();
                //empty the textBoxes
                itcode.Text = "";
                LO.Text = "";
                SP.Text = "";
                MR.Text = "";
                Descr.Text = "";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string sql = "DELETE from item where itemCode='" + itcode.Text + "'";
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
                    {
                        MessageBox.Show("Successfully deleted!");
                    }

                }
                con.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show("Connection Error!");
                MessageBox.Show(a.Message);
            }

            // delete from the stock

            sql = "DELETE from stock where itemCodes='" + itcode.Text + "'";
            cmd = new MySqlCommand(sql, con);
            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.DeleteCommand = con.CreateCommand();
                adapter.DeleteCommand.CommandText = sql;
                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show("Connection Error!");
                MessageBox.Show(a.Message);
            }
            // delete from the reorder level

            sql = "DELETE from reorderlevel where itemCode='" + itcode.Text + "'";
            cmd = new MySqlCommand(sql, con);
            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.DeleteCommand = con.CreateCommand();
                adapter.DeleteCommand.CommandText = sql;
                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show("Connection Error!");
                MessageBox.Show(a.Message);
            }
            refresh();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            itcode.Text = "";
            LO.Text = "";
            SP.Text = "";
            MR.Text = "";
            Descr.Text = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Do you want to close", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {


                this.Close();
            }
        }

        private void updatesitems_MouseClick(object sender, MouseEventArgs e)
        {
            itcode.Text = updatesitems.SelectedRows[0].Cells[0].Value.ToString();
            LO.Text = updatesitems.SelectedRows[0].Cells[1].Value.ToString();
            SP.Text = updatesitems.SelectedRows[0].Cells[2].Value.ToString();
            MR.Text = updatesitems.SelectedRows[0].Cells[3].Value.ToString();
            Descr.Text = updatesitems.SelectedRows[0].Cells[4].Value.ToString();


          
        }
        ///////////////////////////////**************************************************
        //*********************************************************************************//
        public void refresh()
        {
            ViewSadjustment.ColumnCount = 8;
            ViewSadjustment.Columns[0].Name = "Date";
            ViewSadjustment.Columns[1].Name = "Discription";
            ViewSadjustment.Columns[2].Name = "itemCode";
            ViewSadjustment.Columns[3].Name = "NewQuantity";
            ViewSadjustment.Columns[4].Name = "PreviousQuantity";
            ViewSadjustment.Columns[5].Name = "quantityLost";
            ViewSadjustment.Columns[6].Name = "reason";
            ViewSadjustment.Columns[7].Name = "Location";
            ViewSadjustment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ViewSadjustment.MultiSelect = false;
            ViewSadjustment.Rows.Clear();

            string sql = "select stockadjustments.Date,item.Discription,stockadjustments.itemCode,stockadjustments.NewQuantity,stockadjustments.PreviousQuantity,stockadjustments.quantityLost,stockadjustments.reason,stockadjustments.Location from stockadjustments,item  where stockadjustments.itemCode=item.itemCode";
            cmd = new MySqlCommand(sql, con);
            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(sql, con);
                adapter.Fill(dtt);

                foreach (DataRow row in dtt.Rows)
                {
                    populate101(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString());
                }

                con.Close();
                dtt.Rows.Clear();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }



            //data grid updates
            updatesitems.ColumnCount = 5;
            updatesitems.Columns[0].Name = "itemCode";
            updatesitems.Columns[1].Name = "Location";
            updatesitems.Columns[2].Name = "sellingPrice";
            updatesitems.Columns[3].Name = "MRP";
            updatesitems.Columns[4].Name = "Discription";

            //
            updatesitems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            updatesitems.MultiSelect = false;
            updatesitems.Rows.Clear();

            sql = "select itemCode,Location,sellingPrice,MRP,Discription from item";
            cmd = new MySqlCommand(sql, con);

            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(sql, con);
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    populate100(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                }

                con.Close();
                dt.Rows.Clear();
            }
            catch (Exception exception)
            { MessageBox.Show(exception.Message); }
            //view Inventory grid
            InventorydataGridView.ColumnCount = 6;
            InventorydataGridView.Columns[0].Name = "itemCode";
            InventorydataGridView.Columns[1].Name = "Location";
            InventorydataGridView.Columns[2].Name = "sellingPrice";
            InventorydataGridView.Columns[3].Name = "MRP";
            InventorydataGridView.Columns[4].Name = "Discription";
            InventorydataGridView.Columns[5].Name = "quantity";


            InventorydataGridView.Columns[0].Width = 115;
            InventorydataGridView.Columns[1].Width = 115;
            InventorydataGridView.Columns[2].Width = 115;
            InventorydataGridView.Columns[3].Width = 115;
            InventorydataGridView.Columns[4].Width = 115;
            InventorydataGridView.Columns[5].Width = 115;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill;

            InventorydataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            InventorydataGridView.MultiSelect = false;
            InventorydataGridView.Rows.Clear();

            sql = "select itemCode,Location,sellingPrice,MRP,Discription,quantity from item,stock where item.itemCode=stock.itemCodes and stock.quantity > 0 ";
            cmd = new MySqlCommand(sql, con);

            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(sql, con);
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    populate05(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
                }

                con.Close();
                dt.Rows.Clear();
            }
            catch (Exception exception)
            { MessageBox.Show(exception.Message); }


            //load ReOrderLevelGrid
            DataTable dtx = new DataTable();
            cmd = con.CreateCommand();
            cmd.CommandText = "Select itemCode from item";
            try
            {
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                reordercbox.Items.Clear();
                while (reader.Read())
                {
                    reordercbox.Items.Add(reader["itemCode"]);

                }
                con.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }

            //Load table
            reordergrid.ColumnCount = 3;
            reordergrid.Columns[2].Name = "itemCode";
            reordergrid.Columns[1].Name = "ReOrder_Level";
            reordergrid.Columns[0].Name = "Discription";

            reordergrid.Columns[0].Width = 180;
            reordergrid.Columns[1].Width = 180;


            //
            reordergrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            reordergrid.MultiSelect = false;
            reordergrid.Rows.Clear();

            string mmsql = "select item.itemCode , reorderlevel.reOrderPoint , item.Discription from reorderlevel,item where reorderlevel.itemCode=item.itemCode";
            cmd = new MySqlCommand(mmsql, con);

            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(mmsql, con);
                adapter.Fill(dtx);

                foreach (DataRow row in dtx.Rows)
                {
                    populate03(row[2].ToString(), row[1].ToString(), row[0].ToString());
                }

                con.Close();
                dtx.Rows.Clear();
            }
            catch (Exception exception)
            { MessageBox.Show(exception.Message); }

            //load stock adjustment tab
            cmd = con.CreateCommand();
            cmd.CommandText = "Select Discription from item";
            try
            {
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                sacbox.Items.Clear();
                while (reader.Read())
                {
                    sacbox.Items.Add(reader["Discription"]);

                }
                con.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }


            //

            //load location to combo box1 
            cmd = con.CreateCommand();
            cmd.CommandText = "Select location from location";
            try
            {
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                LO.Items.Clear();
                while (reader.Read())
                {
                    LO.Items.Add(reader["location"]);

                }
                con.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }

        }

        private void Nquantity_TextChanged(object sender, EventArgs e)
        {
            int s;

            if (!(int.TryParse(Nquantity.Text, out s)))
            { label11.Show(); }
            else
            { label11.Visible = false; }
        }

        private void Adjust_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Do you want to Adjust Stock ? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                if (string.IsNullOrWhiteSpace(sacbox.Text) && string.IsNullOrWhiteSpace(Nquantity.Text))

                { MessageBox.Show("Input correct data to all fields"); }
                else
              if (!Nquantity.Text.All(char.IsDigit)) { MessageBox.Show("Input Numeric Values for New Qty Field"); }
                else
                {




                    cmd = con.CreateCommand();
                    cmd.CommandText = "Select Discription from item";
                    try
                    {
                        con.Open();
                        MySqlDataReader reader = cmd.ExecuteReader();
                        sacbox.Items.Clear();
                        while (reader.Read())
                        {
                            sacbox.Items.Add(reader["Discription"]);

                        }
                        con.Close();
                    }
                    catch (Exception exx)
                    {
                        con.Close();
                        MessageBox.Show("Please Input correct data to correct fields");

                    }



                    //




                    //Insert data to stock adjustment table



                    //get the location
                    string asquery = " Select Location from item where discription like'" + sacbox.Text + "'";
                    string lloc = "";
                    con.Open();
                    cmd = new MySqlCommand(asquery, con);
                    lloc = cmd.ExecuteScalar().ToString();
                    con.Close();
                    //get the item code
                    string squery = " Select itemCode from item where discription like'" + sacbox.Text + "'";
                    string icode = "";
                    con.Open();
                    cmd = new MySqlCommand(squery, con);
                    icode = cmd.ExecuteScalar().ToString();
                    int ic = 0;
                    ic = System.Convert.ToInt32(icode);



                    //get the curent qty
                    string query = " Select quantity from stock where itemCodes like'" + ic + "'";
                    string qty;

                    cmd = new MySqlCommand(query, con);
                    qty = cmd.ExecuteScalar().ToString();
                    con.Close();
                    int cq = System.Convert.ToInt32(qty);
                    //get the new qty
                    int nq = System.Convert.ToInt32(Nquantity.Text);
                    //get the qty lost
                    int lq = cq - nq;

                    //add to item table 
                    string sql = "INSERT INTO `stockadjustments` (`Date`,`itemCode`,`NewQuantity`,`PreviousQuantity`,`quantityLost`,reason,Location) VALUES (CURRENT_TIMESTAMP,'" + ic + "','" + nq + "','" + cq + "','" + lq + "','" + reason.Text + "','" + lloc + "')";
                    cmd = new MySqlCommand(sql, con);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Successfully Stock Adjust Added");

                        con.Close();

                    }
                    catch (Exception except)
                    {
                        MessageBox.Show(except.Message);
                        con.Close();


                    }

                    //update the stock table

                    sql = "update stock set quantity='" + nq + "' where itemCodes='" + ic + "'";
                    cmd = new MySqlCommand(sql, con);

                    try
                    {
                        con.Open();
                        adapter = new MySqlDataAdapter(cmd);
                        adapter.UpdateCommand = con.CreateCommand();
                        adapter.UpdateCommand.CommandText = sql;

                        if (adapter.UpdateCommand.ExecuteNonQuery() > 0)

                        { }
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        MessageBox.Show("Please Input correct data to correct fields");

                    }
                    //empty the textBoxes
                    sacbox.Text = "";

                    Nquantity.Text = "";
                    reason.Text = "";

                }
                refresh();
            }
        }

        private void set_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Do you want to set reOrder Level ? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                DataTable dtx = new DataTable();
                string mmsql = "update reorderlevel set reOrderPoint='" + reoderpoint.Text + "' where itemCode ='" + reordercbox.Text + "'";
                cmd = new MySqlCommand(mmsql, con);

                try
                {
                    con.Open();
                    adapter = new MySqlDataAdapter(cmd);
                    adapter.UpdateCommand = con.CreateCommand();
                    adapter.UpdateCommand.CommandText = mmsql;

                    if (adapter.UpdateCommand.ExecuteNonQuery() > 0)

                    { MessageBox.Show("Successfully Updated !"); }
                    con.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Please Input correct data to correct fields");
                    con.Close();
                }
                //load table
                reordergrid.ColumnCount = 2;
                reordergrid.Columns[0].Name = "itemCode";
                reordergrid.Columns[1].Name = "ReOrder_Level";


                //
                reordergrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                reordergrid.MultiSelect = false;
                reordergrid.Rows.Clear();

                string msql = "select * from reorderlevel";
                cmd = new MySqlCommand(mmsql, con);



                refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Do you want to set default reOrder Level ? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                DataTable dtx = new DataTable();

                string mmsql = "UPDATE `reorderlevel` SET `reOrderPoint`= '" + textBox1.Text + "' ";
                cmd = new MySqlCommand(mmsql, con);

                try
                {
                    con.Open();
                    adapter = new MySqlDataAdapter(cmd);
                    adapter.UpdateCommand = con.CreateCommand();
                    adapter.UpdateCommand.CommandText = mmsql;

                    if (adapter.UpdateCommand.ExecuteNonQuery() > 0)

                    { MessageBox.Show("Successfully Updated !"); }
                    con.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Please Input correct data to correct fields");
                    con.Close();
                }
                //load table
                reordergrid.ColumnCount = 2;
                reordergrid.Columns[0].Name = "itemCode";
                reordergrid.Columns[1].Name = "ReOrder_Level";


                //
                reordergrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                reordergrid.MultiSelect = false;
                reordergrid.Rows.Clear();

                string msql = "select * from reorderlevel";
                cmd = new MySqlCommand(mmsql, con);
                refresh();
            }
        }

        private void reordergrid_MouseClick(object sender, MouseEventArgs e)
        {
            reordercbox.Text = reordergrid.SelectedRows[0].Cells[2].Value.ToString();
            reoderpoint.Text = reordergrid.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void vSearch_Click(object sender, EventArgs e)
        {
            InventorydataGridView.ColumnCount = 6;
            InventorydataGridView.Columns[0].Name = "itemCode";
            InventorydataGridView.Columns[1].Name = "Location";
            InventorydataGridView.Columns[2].Name = "sellingPrice";
            InventorydataGridView.Columns[3].Name = "MRP";
            InventorydataGridView.Columns[4].Name = "Discription";
            InventorydataGridView.Columns[5].Name = "quantity";

            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill;

            InventorydataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            InventorydataGridView.MultiSelect = false;
            InventorydataGridView.Rows.Clear();

            string sql = "select itemCode,Location,sellingPrice,MRP,Discription,quantity from item,stock where item.itemCode=stock.itemCodes  and (item.itemCode like '%" + vsearchtext.Text + "%' OR item.Location like '%" + vsearchtext.Text + "%' OR item.sellingPrice like '%" + vsearchtext.Text + "%' OR item.MRP like '%" + vsearchtext.Text + "%' OR item.Discription like '%" + vsearchtext.Text + "%' )";
            cmd = new MySqlCommand(sql, con);

            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(sql, con);
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    populate05(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
                }

                con.Close();
                dt.Rows.Clear();
            }
            catch (Exception exception)
            { MessageBox.Show(exception.Message); }
        }

        private void reoderpoint_TextChanged(object sender, EventArgs e)
        {
            int s;

            if (!(int.TryParse(reoderpoint.Text, out s)))
            { label12.Show(); }
            else
            { label12.Visible = false; }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int s;

            if (!(int.TryParse(textBox1.Text, out s)))
            { label24.Show(); }
            else
            { label24.Visible = false; }
        }

        private void LO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LO.Text.Equals("Add New Location"))
            {
                this.Close();
                addLocation ad = new addLocation();
              ad.Show();

            }
        }

        private void StockManagement_Load(object sender, EventArgs e)
        {

        }
    }
}
