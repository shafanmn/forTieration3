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
using System.Drawing.Imaging;

namespace EwingInventory
{
    public partial class form_ManufactMgt : Form
    {
        public Homepage home = new Homepage();
        private string currentUser;
        string query;
        public form_ManufactMgt()
        {
            InitializeComponent();

        }

        public form_ManufactMgt(string currentUser)
        {
            this.currentUser = currentUser;
            InitializeComponent();
        }

        MySqlConnection conn = new MySqlConnection("datasource=localhost; port=3306; initial Catalog='inventory'; username=root; password=;convert zero datetime=True");
        MySqlCommand command;

        static string logoPath;

        private void Loadtable(DataGridView dgv, string q)
        {
            DataTable dt = new DataTable();
            //MySqlConnection conn = new MySqlConnection(home.connString);
            MySqlConnection conn = new MySqlConnection("datasource=localhost; port=3306; initial Catalog='inventory'; username=root; password=;convert zero datetime=True");
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            MySqlCommand cmd = new MySqlCommand(q, conn);

            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);
                BindingSource bs = new BindingSource();

                bs.DataSource = dt;
                dgv.DataSource = bs;
                da.Update(dt);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }

        }

        public void executeMyQuery(string q)
        {
            try
            {
                conn.Open();
                command = new MySqlCommand(q, conn);

                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("Query Executed");
                else
                    MessageBox.Show("Query Not Executed");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        //public void LoadJobName() {
            
        //   MySqlConnection conn = new MySqlConnection(query);
        //    try
        //    {

        //        conn.Open();

        //    }
        //    catch (Exception e) {
        //        MessageBox.Show(e.Message);
        //    }

        //    string queryj = "select * from jobs";
        //    MySqlCommand command = new MySqlCommand(queryj, conn);
        //    try
        //    {
        //        var read = command.ExecuteReader();
        //        while (read.Read())
        //            //textBoxjob.Items.Add(read.GetString("jobName"));


        //    }
        //    catch (Exception e) {
        //        MessageBox.Show(e.Message);
        //    }
       

       //}

        private void ManufactMgt_Load(object sender, EventArgs e)
        {
            if (currentUser != "JAJE")
            {
                //tab_manufact.TabPages.Remove(tabPage1_RawMaterial);
                //tab_manufact.TabPages.Remove(tabPage2_Production);
                //tab_manufact.TabPages.Remove(tabPage3_JobSchedule);
            }
            //else
            //    tab_manufact.TabPages.Remove(tabPage4_Monitor);

            //this.RowHeadersVisible = false;
            //this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            //this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //this.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //this.AllowUserToResizeRows = false;
            //this.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            //this.BackgroundColor = Color.White;
            //this.AllowUserToAddRows = false;
            
            string w = Screen.FromControl(home).WorkingArea.Width.ToString();
            this.Location = new Point((Convert.ToInt32(w) - this.Width) / 2, 120);
            FormBorderStyle = FormBorderStyle.FixedSingle;

            Loadtable(mdgv_manufactraw, "SELECT rawMaterialID 'ID', rawMaterialName 'NAME', availableNow 'In Stock', reorderLevel 'Reorder Level', orderAmount 'Order QTY', toOrder 'To Order' FROM `manufactraw`");
            Loadtable(mdgv_manufactraw1, "SELECT rawMaterialID 'ID', rawMaterialName 'NAME' FROM `manufactraw` where reorderLevel>availableNow");

            Loadtable(mdgv_manufactraw5, "SELECT jobId 'ID', jobName 'NAME', description 'Description', duration 'Duration', noOfEmp 'No Of Emp', DATE_FORMAT(startingDate,\"%Y-%m-%d\")  'Starting Date', status 'Status' FROM `jobs`");
            Loadtable(mdgv_manufactraw6, "SELECT empId 'ID', type 'Job Type',noOfEmp 'No Of Emp' FROM `manemp`");

            Loadtable(mdgv_production2, "SELECT batchNo 'Barch No', currentJob 'Job', noOfEmp 'No Of Employees', workingHrs 'Working Hrs', costPerUnit 'Cost Per Unit', units 'No Of Units', total 'Total Costs' FROM `batch`");
            Loadtable(mdgv_production1, "SELECT batchNo 'Barch No', currentJob 'Job' FROM `batch`");

            Loadtable(dataGridViewMonitor, "SELECT itemNo 'Item No', itemName 'Item Name', totQty 'Total Qty', DATE_FORMAT(deliverDate,\"%Y-%m-%d\") 'Deliver Date', deliverStatus 'Status' from `manufactitem`");
          
            //var read = command.ExecuteReader();
            //logoPath = read.GetString("image");
            //img.ImageLocation = logoPath;


            //dateTimePickersdate.Format = DateTimePickerFormat.Custom;
            //dateTimePickersdate.CustomFormat = "yyyyMMdd";
            //dateTimePickersdate.Value.ToShortDateString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (!textBoxbatchno.Text.Equals(""))
            {
                var opt = MessageBox.Show("Are you sure you want to close?\nAny modifications to the user will not be saved", "Confirm Clsoe", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (opt == DialogResult.OK)
                    this.Close();
            }
            else
                this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (!text_ID.Text.Equals(""))
            {
                var opt = MessageBox.Show("Are you sure you want to close?\nAny modifications to the user will not be saved", "Confirm Clsoe", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (opt == DialogResult.OK)
                    this.Close();
            }
            else
                this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!text_ID.Text.Equals(""))
            {
                var opt = MessageBox.Show("Are you sure you want to Proceed Order?", "Confirm Order", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (opt == DialogResult.OK)
                {
                    int x = Convert.ToInt32(text_stock.Text) + Convert.ToInt32(text_OA.Text);
                    Update(text_ID.Text, text_name.Text, Convert.ToString(x), text_ROL.Text, text_OA.Text, comboBoxtoorder.Text);
                    MessageBox.Show(text_name.Text + "  " + text_OA.Text + "  Ordered Successfully");
                }
            }
            else
                this.clearTxts();

        }



        private void mdgv_manufactraw_MouseClick(object sender, MouseEventArgs e)
        {
            MySqlDataReader dr = null;

            text_ID.Text = mdgv_manufactraw.CurrentRow.Cells[0].Value.ToString();
            text_name.Text = mdgv_manufactraw.CurrentRow.Cells[1].Value.ToString();
            text_stock.Text = mdgv_manufactraw.CurrentRow.Cells[2].Value.ToString();
            text_ROL.Text = mdgv_manufactraw.CurrentRow.Cells[3].Value.ToString();
            text_OA.Text = mdgv_manufactraw.CurrentRow.Cells[4].Value.ToString();
            comboBoxtoorder.Text = mdgv_manufactraw.CurrentRow.Cells[5].Value.ToString();
            //comboBoxtoorder.SelectedItem = comboBoxtoorder.Items.IndexOf(dr["toOrder"].ToString());


            //int limit = Convert.ToInt32(text_ROL.Text);
            //var availableQuantity = Convert.ToInt32(text_stock.Text);
            //if (availableQuantity < limit)
            //{
            //    MessageBox.Show("Not enough !");
            //}

            //string id = mdgv_manufactraw1.SelectedCells[0].Value.ToString();
            ////btn_clear.Enabled = true;
            ////btn_save.Enabled = true;

            //MySqlConnection conn = new MySqlConnection(home.connString);

            //try
            //{
            //    conn.Open();
            //    MySqlDataReader dr = null;
            //    MySqlCommand cmd = new MySqlCommand("SELECT * FROM manufactraw WHERE rawMaterialID = " + id + ";", conn);

            //    dr = cmd.ExecuteReader();

            //    while (dr.Read())
            //    {
            //        text_ID.Text = dr["rawMaterialID"].ToString();
            //        text_name.Text = dr["rawMaterialName"].ToString();
            //        text_stock.Text = dr["availableNow"].ToString();
            //        text_ROL.Text = dr["reorderLevel"].ToString();
            //        text_OA.Text = dr["orderAmount"].ToString();
            //        comboBoxtoorder.Text = dr["toOrder"].ToString();

            //        //cmb_access.SelectedItem = cmb_access.Items.IndexOf(dr["access"].ToString());

            //    }
            //    conn.Close();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void mdgv_manufactraw1_MouseClick(object sender, MouseEventArgs e)
        {
            text_ID.Text = mdgv_manufactraw1.CurrentRow.Cells[0].Value.ToString();

            MySqlConnection conn = new MySqlConnection(home.connString);

            try
            {
                conn.Open();
                MySqlDataReader dr = null;
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM manufactraw WHERE rawMaterialID =" + text_ID.Text + ";", conn);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    text_name.Text = dr["rawMaterialName"].ToString();
                    text_stock.Text = dr["availableNow"].ToString();
                    text_ROL.Text = dr["reorderLevel"].ToString();
                    text_OA.Text = dr["orderAmount"].ToString();
                    comboBoxtoorder.Text = dr["toOrder"].ToString();
                   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }           
        }

        private void mdgv_production2_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxbatchno.Text = mdgv_production2.CurrentRow.Cells[0].Value.ToString();
            textBoxjob.Text = mdgv_production2.CurrentRow.Cells[1].Value.ToString();
            textBoxnoofemp.Text = mdgv_production2.CurrentRow.Cells[2].Value.ToString();
            textBoxworkinghrs.Text = mdgv_production2.CurrentRow.Cells[3].Value.ToString();
            textBoxcostperunit.Text = mdgv_production2.CurrentRow.Cells[4].Value.ToString();
            textBoxnoofunits.Text = mdgv_production2.CurrentRow.Cells[5].Value.ToString();
            textBoxtotcost.Text = mdgv_production2.CurrentRow.Cells[6].Value.ToString();
        }

        private void mdgv_production1_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxbatchno.Text = mdgv_production1.CurrentRow.Cells[0].Value.ToString();

            MySqlConnection conn = new MySqlConnection(home.connString);

            try
            {
                conn.Open();
                MySqlDataReader dr = null;
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM batch WHERE  batchNo = " + textBoxbatchno.Text + ";", conn);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    textBoxjob.Text = dr["currentJob"].ToString();
                    textBoxnoofemp.Text = dr["noOfEmp"].ToString();
                    textBoxworkinghrs.Text = dr["workingHrs"].ToString();
                    textBoxcostperunit.Text = dr["costPerUnit"].ToString();
                    textBoxnoofunits.Text = dr["units"].ToString();
                    textBoxtotcost.Text = dr["total"].ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            //textBoxjob.Text = mdgv_production1.CurrentRow.Cells[1].Value.ToString();
            //textBoxnoofemp.Text = "";
            //textBoxworkinghrs.Text = "";
            //textBoxnoofunits.Text = "";
            //textBoxcostperunit.Text = "";
            //textBoxtotcost.Text = "";
        }

        private void mdgv_manufactraw5_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxjobid.Text = mdgv_manufactraw5.CurrentRow.Cells[0].Value.ToString();

            //Get Details from DataGridView
            string[] date = mdgv_manufactraw5.CurrentRow.Cells[5].Value.ToString().Split(' ');
            string[] dt = date[0].ToString().Split('-');
                        
            textBoxjobtitle.Text = mdgv_manufactraw5.CurrentRow.Cells[1].Value.ToString();
            textBoxdesc.Text = mdgv_manufactraw5.CurrentRow.Cells[2].Value.ToString();
            textBoxdura.Text = mdgv_manufactraw5.CurrentRow.Cells[3].Value.ToString();
            textBoxempass.Text = mdgv_manufactraw5.CurrentRow.Cells[4].Value.ToString();
            dateTimePickersdate.Value = new DateTime(Convert.ToInt32(dt[0]), Convert.ToInt32(dt[1]), Convert.ToInt32(dt[2]));
            comboBoxenable.Text = mdgv_manufactraw5.CurrentRow.Cells[6].Value.ToString();


            //MySqlConnection conn = new MySqlConnection(home.connString);

            //try
            //{
            //    conn.Open();
            //    MySqlDataReader dr = null;
            //    MySqlCommand cmd = new MySqlCommand("SELECT * FROM jobs WHERE jobid =" + textBoxjobid.Text + ";", conn);

            //    dr = cmd.ExecuteReader();

            //    while (dr.Read())
            //    {

            //        textBoxjobtitle.Text = dr["jobName"].ToString();
            //        textBoxdesc.Text = dr["description"].ToString();
            //        textBoxdura.Text = dr["duration"].ToString();
            //        textBoxempass.Text = dr["noOfEmp"].ToString();
            //        dateTimePickersdate.Value = new DateTime(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]));
            //        comboBoxenable.Text = dr["status"].ToString();

            //        //dateTimePickersdate.MinDate = DateTime.Now;
            //        //dateTimePickersdate.MaxDate = DateTime.Now;
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    conn.Close();
            //}
        }


        private void mdgv_manufactraw6_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxempid.Text = mdgv_manufactraw6.CurrentRow.Cells[0].Value.ToString();
            textBoxtype.Text = mdgv_manufactraw6.CurrentRow.Cells[1].Value.ToString();
            textBoxempno.Text = mdgv_manufactraw6.CurrentRow.Cells[2].Value.ToString();
        }
        public void clearTxts()
        {
            text_ID.Text = "";
            text_name.Text = "";
            text_stock.Text = "";
            text_ROL.Text = "";
            text_OA.Text = "";
            comboBoxtoorder.Text = "";

            textBoxbatchno.Text = "";
            textBoxjob.Text = "";
            textBoxnoofemp.Text = "";
            textBoxworkinghrs.Text = "";
            textBoxnoofunits.Text = "";
            textBoxcostperunit.Text = "";
            textBoxtotcost.Text = "";

            textBoxjobid.Text = "";
            textBoxjobtitle.Text = "";
            textBoxdesc.Text = "";
            textBoxdura.Text = "";
            textBoxempass.Text = "";

            textBoxempid.Text = "";
            textBoxempno.Text = "";
            textBoxtype.Text = "";

            textBoxitemNo.Text = "";
            textBoxitemName.Text = "";
            textBoxtotqty.Text = "";
            img.Text = "";
        }
        private void add(string id, string nam, string an, string ro, string oa, string to)
        {
            if (text_ID.Text != "" && text_name.Text != "")
            {
                //SQL STMT
                string sql = "INSERT INTO manufactraw(rawMaterialID, rawMaterialName, availableNow, reorderLevel, orderAmount, toOrder) VALUES(@RawMaterialID,@RawMaterialName,@AvailableNow,@ReorderLevel,@OrderAmount,@ToOrder)";
                command = new MySqlCommand(sql, conn);
                //ADD PARAMETERS
                command.Parameters.AddWithValue("@RawMaterialID", id);
                command.Parameters.AddWithValue("@RawMaterialName", nam);
                command.Parameters.AddWithValue("@AvailableNow", an);
                command.Parameters.AddWithValue("@ReorderLevel", ro);
                command.Parameters.AddWithValue("@OrderAmount", oa);
                command.Parameters.AddWithValue("@ToOrder", to);
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
            //OPEN CON AND EXEC insert
            try
            {
                conn.Open();
                if (command.ExecuteNonQuery() > 0)
                {
                    clearTxts();
                    MessageBox.Show("Successfully Inserted");
                }
                conn.Close();
                //retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void buttonadd_Click(object sender, EventArgs e)
        {
            add(text_ID.Text, text_name.Text, text_stock.Text, text_ROL.Text, text_OA.Text, comboBoxtoorder.Text);            //string insertQuery = "INSERT INTO manufactraw (rawMaterialID, rawMaterialName, availableNow, reorderLevel, orderAmount, toOrder) VALUES('" + text_ID + "','"+ text_name + "','" + text_stock + "','" + text_ROL + "','" + text_OA + "','" + comboBoxtoorder + "',)";
            //executeMyQuery(insertQuery);
            Loadtable(mdgv_manufactraw, "SELECT rawMaterialID 'ID', rawMaterialName 'NAME', availableNow 'In Stock', reorderLevel 'Reorder Level', orderAmount 'Order QTY', toOrder 'To Order' FROM `manufactraw`");
            Loadtable(mdgv_manufactraw1, "SELECT rawMaterialID 'ID', rawMaterialName 'NAME' FROM `manufactraw` WHERE reorderLevel>availableNow");
        }

        private void padd(string a, string b, string c, string d, string e, string f, string g)
        {
            if (textBoxbatchno.Text != "" && textBoxjob.Text != "")
            {
                //SQL STMT
                string sql = "INSERT INTO batch (batchNo, currentJob, noOfEmp, workingHrs, costPerUnit, units, total) VALUES(@A,@B,@C,@D,@E,@F,@G)";
                command = new MySqlCommand(sql, conn);
                //ADD PARAMETERS
                command.Parameters.AddWithValue("@A", a);
                command.Parameters.AddWithValue("@B", b);
                command.Parameters.AddWithValue("@C", c);
                command.Parameters.AddWithValue("@D", d);
                command.Parameters.AddWithValue("@E", e);
                command.Parameters.AddWithValue("@F", f);
                command.Parameters.AddWithValue("@G", g);

            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
            //OPEN CON AND EXEC insert
            try
            {
                conn.Open();
                if (command.ExecuteNonQuery() > 0)
                {
                    clearTxts();
                    MessageBox.Show("Successfully Inserted");
                }
                conn.Close();
                //retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void buttonpadd_Click(object sender, EventArgs e)
        {
            padd(textBoxbatchno.Text, textBoxjob.Text, textBoxnoofemp.Text, textBoxworkinghrs.Text, textBoxnoofunits.Text, textBoxcostperunit.Text, textBoxtotcost.Text); 
            Loadtable(mdgv_production2, "SELECT batchNo 'Barch No', currentJob 'Job', noOfEmp 'No Of Employees', workingHrs 'Working Hrs', costPerUnit 'Cost Per Unit', units 'No Of Units', total 'Total Costs' FROM `batch`");
            Loadtable(mdgv_production1, "SELECT batchNo 'Barch No', currentJob 'Job' FROM `batch`");
        }

        private void Jadd(string a, string b, string c, string d, string e, string f, string g)
        {
            if (textBoxjobid.Text != "" && textBoxjobtitle.Text != "")
            {
                //SQL STMT
                string sql = "INSERT INTO jobs (jobId, jobName, description , duration , noOfEmp , startingDate, status) VALUES(@A,@B,@C,@D,@E,@F,@G)";
                command = new MySqlCommand(sql, conn);
                //ADD PARAMETERS
                command.Parameters.AddWithValue("@A", a);
                command.Parameters.AddWithValue("@B", b);
                command.Parameters.AddWithValue("@C", c);
                command.Parameters.AddWithValue("@D", d);
                command.Parameters.AddWithValue("@E", e);

                //dateTimePickersdate.Format = DateTimePickerFormat.Custom;
                //dateTimePickersdate.CustomFormat = "MM dd yyyy";
                //dateTimePickersdate.Value.ToShortDateString();

                string[] date = dateTimePickersdate.ToString().Split(' ');
                string time = date[3];

                //MessageBox.Show(date[2]);
                //MessageBox.Show(date[3]);

                string[] x = date[2].Split('/');
                string year = x[2];
                string month = x[1];
                string day = x[0];

                //MessageBox.Show(x[0]);
                //MessageBox.Show(x[1]);
                //MessageBox.Show(x[2]);
                
                command.Parameters.Add("@F",MySqlDbType.VarChar).Value=dateTimePickersdate.Text;
                command.Parameters.AddWithValue("@G", g);

            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
            //OPEN CON AND EXEC insert
            try
            {
                conn.Open();
                if (command.ExecuteNonQuery() > 0)
                {
                    clearTxts();
                    MessageBox.Show("Successfully Inserted");
                }
                conn.Close();
                //retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void buttonjobadd_Click(object sender, EventArgs e)
        {       
            Jadd(textBoxjobid.Text, textBoxjobtitle.Text, textBoxdesc.Text, textBoxdura.Text, textBoxempass.Text, dateTimePickersdate.Text, comboBoxenable.Text);

            Loadtable(mdgv_manufactraw5, "SELECT jobId 'ID', jobName 'NAME', description 'Description', duration 'Duration', noOfEmp 'No Of Emp', startingDate  'Starting Date', status 'Status' FROM `jobs`");
        }

        private void Eadd(string a, string b, string c)
        {
            if (textBoxempid.Text != "" && textBoxtype.Text != "")
            {
                //SQL STMT
                string sql = "INSERT INTO manemp(empId, type, noOfEmp) VALUES(@A,@B,@C)";
                command = new MySqlCommand(sql, conn);
                //ADD PARAMETERS
                command.Parameters.AddWithValue("@A", a);
                command.Parameters.AddWithValue("@B", b);
                command.Parameters.AddWithValue("@C", c);

            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
            //OPEN CON AND EXEC insert
            try
            {
                conn.Open();
                if (command.ExecuteNonQuery() > 0)
                {
                    clearTxts();
                    MessageBox.Show("Successfully Inserted");
                }
                conn.Close();
                //retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void buttonempadd_Click(object sender, EventArgs e)
        {
            Eadd(textBoxempid.Text, textBoxtype.Text, textBoxempno.Text);
            Loadtable(mdgv_manufactraw6, "SELECT empId 'ID', type 'Job Type',noOfEmp 'No Of Emp' FROM `manemp`");

        }

        private void textBox_Msearch_TextChanged(object sender, EventArgs e)
        {
            string filter = textBox_Msearch.Text;
            Loadtable(mdgv_manufactraw1, "SELECT rawMaterialID,rawMaterialName FROM `manufactraw` WHERE reorderLevel>availableNow AND rawMaterialID like '%" + filter + "%'");
            Loadtable(mdgv_manufactraw, "SELECT * FROM `manufactraw` WHERE rawMaterialID like '%" + filter + "%'");

        }
        private void textBox_Msearch2_TextChanged(object sender, EventArgs e)
        {
            string filter = textBox_Msearch2.Text;
            Loadtable(mdgv_manufactraw1, "SELECT rawMaterialID,rawMaterialName FROM `manufactraw` WHERE reorderLevel>availableNow AND rawMaterialName like '%" + filter + "%'");
            Loadtable(mdgv_manufactraw, "SELECT * FROM `manufactraw` WHERE rawMaterialName like '%" + filter + "%'");
        }

        private void textBox_Psearch_TextChanged(object sender, EventArgs e)
        {
            string filter = textBox_Psearch.Text;
            Loadtable(mdgv_production1, "SELECT batchNo,currentJob FROM `batch` WHERE batchNo like '%" + filter + "%'");
            Loadtable(mdgv_production2, "SELECT * FROM `batch` WHERE batchNo like '" + filter + "%'");
        }

        private void textBox_Psearch2_TextChanged(object sender, EventArgs e)
        {
            string filter = textBox_Psearch2.Text;
            Loadtable(mdgv_production1, "SELECT batchNo,currentJob FROM `batch` WHERE currentJob like '%" + filter + "%'");
            Loadtable(mdgv_production2, "SELECT * FROM `batch` WHERE currentJob like '%" + filter + "%'");
        }

        private void textBox_Jsearch_TextChanged(object sender, EventArgs e)
        {
            string filter = textBox_Jsearch.Text;
            Loadtable(mdgv_manufactraw5, "SELECT jobId, jobName, description, duration, noOfEmp, startingDate, status FROM `jobs` WHERE jobId like '%" + filter + "%'");
            Loadtable(mdgv_manufactraw5, "SELECT jobId, jobName, description, duration, noOfEmp, startingDate, status FROM `jobs` WHERE jobName like '%" + filter + "%'");
        }

        private void textBox_Esearch_TextChanged(object sender, EventArgs e)
        {
            string filter = textBox_Esearch.Text;
            Loadtable(mdgv_manufactraw6, "SELECT empId, type,noOfEmp FROM `manemp` WHERE empId like '%" + filter + "%'");
            Loadtable(mdgv_manufactraw6, "SELECT empId, type,noOfEmp FROM `manemp` WHERE type like '%" + filter + "%'");
        }

        private void button_viewAll_Click(object sender, EventArgs e)
        {

        }

        private void Jupdate(string a, string b, string c, string d, string e, string f, string g)
        {
            if (textBoxjobid.Text != "" && textBoxjobtitle.Text != "")
            {
                //SQL STMT
                string sql = "update jobs set jobName=@B, description=@C , duration=@D , noOfEmp=@E , startingDate=@F, status=@G WHERE jobId=@A";
                command = new MySqlCommand(sql, conn);
                
                //ADD PARAMETERS
                command.Parameters.AddWithValue("@A", a);
                command.Parameters.AddWithValue("@B", b);
                command.Parameters.AddWithValue("@C", c);
                command.Parameters.AddWithValue("@D", d);
                command.Parameters.AddWithValue("@E", e);
                command.Parameters.Add("@F", MySqlDbType.VarChar).Value = dateTimePickersdate.Text;
                command.Parameters.AddWithValue("@G", g);

            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
            //OPEN CON AND EXEC insert
            try
            {
                conn.Open();
                if (command.ExecuteNonQuery() > 0)
                {
                    clearTxts();
                    MessageBox.Show("Successfully Updated");
                }
                conn.Close();
                //retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void buttonjobupdate_Click(object sender, EventArgs e)
        {
            Jupdate(textBoxjobid.Text, textBoxjobtitle.Text, textBoxdesc.Text, textBoxdura.Text, textBoxempass.Text, dateTimePickersdate.Text, comboBoxenable.Text);

            Loadtable(mdgv_manufactraw5, "SELECT jobId 'ID', jobName 'NAME', description 'Description', duration 'Duration', noOfEmp 'No Of Emp', startingDate  'Starting Date', status 'Status' FROM `jobs`");
        }

        private void Update(string id, string nam, string an, string ro, string oa, string to)
        {
            if (text_ID.Text != "" && text_name.Text != "")
            {
                //SQL STMT
                string sql = "UPDATE manufactraw set rawMaterialName=@RawMaterialName, availableNow=@AvailableNow, reorderLevel=@ReorderLevel, orderAmount=@OrderAmount, toOrder=@ToOrder where rawMaterialID=@RawMaterialID ";
                command = new MySqlCommand(sql, conn);
                //ADD PARAMETERS
                command.Parameters.AddWithValue("@RawMaterialID", id);
                command.Parameters.AddWithValue("@RawMaterialName", nam);
                command.Parameters.AddWithValue("@AvailableNow", an);
                command.Parameters.AddWithValue("@ReorderLevel", ro);
                command.Parameters.AddWithValue("@OrderAmount", oa);
                command.Parameters.AddWithValue("@ToOrder", to);
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
            //OPEN CON AND EXEC insert
            try
            {
                conn.Open();
                if (command.ExecuteNonQuery() > 0)
                {
                    clearTxts();
                    MessageBox.Show("Successfully Updated");
                    Loadtable(mdgv_manufactraw, "SELECT rawMaterialID 'ID', rawMaterialName 'NAME', availableNow 'In Stock', reorderLevel 'Reorder Level', orderAmount 'Order QTY', toOrder 'To Order' FROM `manufactraw`");
                    Loadtable(mdgv_manufactraw1, "SELECT rawMaterialID 'ID', rawMaterialName 'NAME' FROM `manufactraw` WHERE reorderLevel>availableNow");

                }
                conn.Close();
                //retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void buttonupdate_Click(object sender, EventArgs e)
        {
            Update(text_ID.Text, text_name.Text, text_stock.Text, text_ROL.Text, text_OA.Text, comboBoxtoorder.Text);

       }

        private void buttondelete_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Do you want to Delete", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    query = "delete from manufactraw where rawMaterialID='" + text_ID.Text + "';";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader;
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    conn.Close();

                    clearTxts(); //clears the textbox after deleting

                    Loadtable(mdgv_manufactraw, "SELECT rawMaterialID 'ID', rawMaterialName 'NAME', availableNow 'In Stock', reorderLevel 'Reorder Level', orderAmount 'Order QTY', toOrder 'To Order' FROM `manufactraw`");
                    Loadtable(mdgv_manufactraw1, "SELECT rawMaterialID 'ID', rawMaterialName 'NAME' FROM `manufactraw` WHERE reorderLevel>availableNow");

                    MessageBox.Show("Row Deleted");  //query will be executed and data deleted
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }

            }
        }

        private void buttonpdel_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Do you want to Delete", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    query = "delete from batch where batchNo='" + textBoxbatchno.Text + "';";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader;
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    conn.Close();

                    clearTxts(); //clears the textbox after deleting

                    Loadtable(mdgv_production2, "SELECT batchNo 'Barch No', currentJob 'Job', noOfEmp 'No Of Employees', workingHrs 'Working Hrs', costPerUnit 'Cost Per Unit', units 'No Of Units', total 'Total Costs' FROM `batch`");
                    Loadtable(mdgv_production1, "SELECT batchNo 'Barch No', currentJob 'Job' FROM `batch`");

                    MessageBox.Show("Row Deleted");  //query will be executed and data deleted
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }

            }
        }

        private void buttonjobdel_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Do you want to Delete", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    query = "delete from jobs where jobId='" + textBoxjobid.Text + "';";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader;
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    conn.Close();

                    clearTxts(); //clears the textbox after deleting

                    Loadtable(mdgv_manufactraw5, "SELECT jobId 'ID', jobName 'NAME', description 'Description', duration 'Duration', noOfEmp 'No Of Emp', startingDate  'Starting Date', status 'Status' FROM `jobs`");

                    MessageBox.Show("Row Deleted");  //query will be executed and data deleted
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }

            }
        }

        private void buttonempdel_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Do you want to Delete", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    query = "delete from manemp where empId='" + textBoxempid.Text + "';";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader;
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    conn.Close();

                    clearTxts(); //clears the textbox after deleting

                    Loadtable(mdgv_manufactraw6, "SELECT empId 'ID', type 'Job Type',noOfEmp 'No Of Emp' FROM `manemp`");

                    MessageBox.Show("Row Deleted");  //query will be executed and data deleted
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //DialogResult confirm = MessageBox.Show("Do you want to Delete", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if (confirm == DialogResult.Yes)
            //{
            //    try
            //    {
            //        query = "delete from manufactraw where rawMaterialID='" + text_ID.Text + "';";
            //        MySqlCommand cmd = new MySqlCommand(query, conn);
            //        MySqlDataReader reader;
            //        conn.Open();
            //        reader = cmd.ExecuteReader();
            //        conn.Close();

            //        clearTxts(); //clears the textbox after deleting

            //        Loadtable(mdgv_manufactraw, "SELECT rawMaterialID 'ID', rawMaterialName 'NAME', availableNow 'In Stock', reorderLevel 'Reorder Level', orderAmount 'Order QTY', toOrder 'To Order' FROM `manufactraw`");
            //        Loadtable(mdgv_manufactraw1, "SELECT rawMaterialID 'ID', rawMaterialName 'NAME' FROM `manufactraw`");

            //        MessageBox.Show("Row Deleted");  //query will be executed and data deleted
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //        conn.Close();
            //    }

            //}
        }

        private void textBox_Fsearch_TextChanged(object sender, EventArgs e)
        {
            string filter = textBoxFsearch.Text;
            Loadtable(dataGridViewMonitor, "SELECT * from `manufactitem` WHERE itemName like '%" + filter + "%'");
        }

        private void textBox_Fsearch2_TextChanged(object sender, EventArgs e)
        {
            string filter = textBoxFsearch2.Text;
            Loadtable(dataGridViewMonitor, "SELECT * from `manufactitem` WHERE itemNo like '%" + filter + "%'");
        }

        private void dataGridViewMonitor_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxitemNo.Text = dataGridViewMonitor.CurrentRow.Cells[0].Value.ToString();
            MySqlConnection conn = new MySqlConnection(home.connString);

            try
            {
                conn.Open();
                MySqlDataReader dr = null;
                MySqlCommand cmd = new MySqlCommand("SELECT *,DATE_FORMAT(deliverDate,\"%Y-%m-%d\") AS 'dFormat' FROM manufactitem WHERE itemNo =" + textBoxitemNo.Text + ";", conn);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string[] a = dr["dFormat"].ToString().Split('-');
                    string year = a[0];
                    string month = a[1];
                    string day = a[2];

                    textBoxitemName.Text = dr["itemName"].ToString();

                    //Byte[] img = (Byte[])dataGridViewMonitor.CurrentRow.Cells["itemimage"].Value;

                    //MemoryStream ms = new MemoryStream(img);

                    //img.Image = Image.FromStream(ms);

                    //img.Text = dr["image"].ToString();

                    textBoxtotqty.Text = dr["totQty"].ToString();
                    datePickerdeliverdate.Value = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
                    comboBoxdeliverstatus.Text = dr["deliverStatus"].ToString();

                    if (!comboBoxdeliverstatus.Text.Equals("Delivered"))
                    {
                        textBoxitemNo.Enabled = false;
                        textBoxitemName.Enabled = false;
                        textBoxtotqty.Enabled = false;
                        datePickerdeliverdate.Enabled = false;
                        //comboBoxdeliverstatus.Enabled = false;
                    }
                  

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void pUpdate(string a, string b, string c, string d, string e, string f, string g)
        {
            if (textBoxbatchno.Text != "" && textBoxjob.Text != "")
            {
                //SQL STMT   
                string sql = "UPDATE batch set currentJob=@B, noOfEmp=@C, workingHrs=@D, costPerUnit=@E, units=@F, total=@G WHERE batchNo=@A";
                command = new MySqlCommand(sql, conn);
                //ADD PARAMETERS
                command.Parameters.AddWithValue("@A", a);
                command.Parameters.AddWithValue("@B", b);
                command.Parameters.AddWithValue("@C", c);
                command.Parameters.AddWithValue("@D", d);
                command.Parameters.AddWithValue("@E", e);
                command.Parameters.AddWithValue("@F", f);
                command.Parameters.AddWithValue("@G", g);

            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
            //OPEN CON AND EXEC insert
            try
            {
                conn.Open();
                if (command.ExecuteNonQuery() > 0)
                {
                    clearTxts();
                    MessageBox.Show("Successfully Inserted");
                }
                conn.Close();
                //retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void buttonpup_Click(object sender, EventArgs e)
        {
            pUpdate(textBoxbatchno.Text, textBoxjob.Text, textBoxnoofemp.Text, textBoxworkinghrs.Text, textBoxnoofunits.Text, textBoxcostperunit.Text, textBoxtotcost.Text);
            Loadtable(mdgv_production2, "SELECT batchNo 'Barch No', currentJob 'Job', noOfEmp 'No Of Employees', workingHrs 'Working Hrs', costPerUnit 'Cost Per Unit', units 'No Of Units', total 'Total Costs' FROM `batch`");
            Loadtable(mdgv_production1, "SELECT batchNo 'Barch No', currentJob 'Job' FROM `batch`");
        }


        private void Eupdate(string a, string b, string c)
        {
            if (textBoxempid.Text != "" && textBoxtype.Text != "")
            {
                //SQL STMT
                string sql = "update manemp set type=@B, noOfEmp=@c where empId=@A";
                command = new MySqlCommand(sql, conn);
                //ADD PARAMETERS
                command.Parameters.AddWithValue("@A", a);
                command.Parameters.AddWithValue("@B", b);
                command.Parameters.AddWithValue("@C", c);

            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
            //OPEN CON AND EXEC insert
            try
            {
                conn.Open();
                if (command.ExecuteNonQuery() > 0)
                {
                    clearTxts();
                    MessageBox.Show("Successfully Inserted");
                }
                conn.Close();
                //retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void buttonempup_Click(object sender, EventArgs e)
        {
            Eupdate(textBoxempid.Text, textBoxtype.Text, textBoxempno.Text);
            Loadtable(mdgv_manufactraw6, "SELECT empId 'ID', type 'Job Type',noOfEmp 'No Of Emp' FROM `manemp`");
        }

        private void Iadd(string a, string b, string d, string e, string f)
        {
            //MemoryStream ms = new MemoryStream();
            //img.Image.Save(ms, img.Image.RawFormat);
            //byte[] img = ms.ToArray();

            if (textBoxitemNo.Text != "" && textBoxitemName.Text != "")
            {
                //SQL STMT
                string sql = "INSERT INTO manufactitem (itemNo, itemName, totQty, deliverDate, deliverStatus) VALUES(@A,@B,@D,@E,@F)";
                command = new MySqlCommand(sql, conn);
                //ADD PARAMETERS
                //dateTimePickersdate.Format = DateTimePickerFormat.Custom;
                //dateTimePickersdate.CustomFormat = "MM dd yyyy";
                //dateTimePickersdate.Value.ToShortDateString();

                string[] date = dateTimePickersdate.ToString().Split(' ');
                string time = date[3];

                //MessageBox.Show(date[2]);
                //MessageBox.Show(date[3]);

                string[] x = date[2].Split('/');
                string year = x[2];
                string month = x[1];
                string day = x[0];

                //MessageBox.Show(x[0]);
                //MessageBox.Show(x[1]);
                //MessageBox.Show(x[2]);

                command.Parameters.AddWithValue("@A", a);
                command.Parameters.AddWithValue("@B", b);

                command.Parameters.AddWithValue("@D", d);
                command.Parameters.Add("@E", MySqlDbType.VarChar).Value = datePickerdeliverdate.Text;
                command.Parameters.AddWithValue("@F", f);
                              
                //command.Parameters.Add("@image", MySqlDbType.MediumBlob).Value = img;
                //command.Parameters.Add("@image", MySqlDbType.VarChar).Value = logoPath;
                
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
            //OPEN CON AND EXEC insert
            try
            {
                conn.Open();
                if (command.ExecuteNonQuery() > 0)
                {
                    clearTxts();
                    MessageBox.Show("Successfully Inserted");
                }
                conn.Close();
                //retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            Iadd(textBoxitemNo.Text, textBoxitemName.Text, textBoxtotqty.Text, datePickerdeliverdate.Text, comboBoxdeliverstatus.Text);
            Loadtable(dataGridViewMonitor, "SELECT itemNo 'Item No', itemName 'Item Name', totQty 'Total Qty', deliverDate 'Deliver Date', deliverStatus 'Status' from `manufactitem`");
        }

        private void Iupdate(string a, string b, string d, string e, string f)
        {
            if (textBoxitemNo.Text != "" && textBoxitemName.Text != "")
            {
                //SQL STMT
                string sql = "UPDATE manufactitem set itemName=@B, totQty=@D, deliverDate=@E, deliverStatus=@F where itemNo=@A ";
                command = new MySqlCommand(sql, conn);
                //ADD PARAMETERS
                command.Parameters.AddWithValue("@A", a);
                command.Parameters.AddWithValue("@B", b);
                //command.Parameters.Add("@image", MySqlDbType.VarChar).Value = logoPath;
                command.Parameters.AddWithValue("@D", d);
                string[] date = dateTimePickersdate.ToString().Split(' ');
                string time = date[3];

                //MessageBox.Show(date[2]);
                //MessageBox.Show(date[3]);

                string[] x = date[2].Split('/');
                string year = x[2];
                string month = x[1];
                string day = x[0];

                //MessageBox.Show(x[0]);
                //MessageBox.Show(x[1]);
                //MessageBox.Show(x[2]);

                command.Parameters.Add("@E", MySqlDbType.VarChar).Value = datePickerdeliverdate.Text;
                command.Parameters.AddWithValue("@F", f);
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
            //OPEN CON AND EXEC insert
            try
            {
                conn.Open();
                if (command.ExecuteNonQuery() > 0)
                {
                    clearTxts();
                    MessageBox.Show("Successfully Inserted");
                }
                conn.Close();
                //retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Iupdate(textBoxitemNo.Text, textBoxitemName.Text, textBoxtotqty.Text, datePickerdeliverdate.Text, comboBoxdeliverstatus.Text);
            Loadtable(dataGridViewMonitor, "SELECT itemNo 'Item No', itemName 'Item Name', totQty 'Total Qty', deliverDate 'Deliver Date', deliverStatus 'Status' from `manufactitem`");
        }

        private void textBoxcostperunit_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxnoofunits.Text.Equals("") && !textBoxcostperunit.Text.Equals(""))
            {
                int x = Convert.ToInt32(textBoxnoofunits.Text) * Convert.ToInt32(textBoxcostperunit.Text);
                textBoxtotcost.Text = Convert.ToString(x);
            }                   
        }

        private void textBoxnoofunits_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxnoofunits.Text.Equals("") && !textBoxcostperunit.Text.Equals(""))
            {
                int x = Convert.ToInt32(textBoxnoofunits.Text) * Convert.ToInt32(textBoxcostperunit.Text);
                textBoxtotcost.Text = Convert.ToString(x);
            }
        }

        private void textBoxtotcost_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxnoofunits.Text.Equals("") && !textBoxtotcost.Text.Equals(""))
            {
                int x = Convert.ToInt32(textBoxtotcost.Text) / Convert.ToInt32(textBoxnoofunits.Text);
                textBoxcostperunit.Text = Convert.ToString(x);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                img.Image = new Bitmap(ofd.FileName);
                logoPath = ofd.FileName;
            }
        }

        //private void jobs()
        //{           
        //        conn.Open();
        //        var query = "SELECT jobId FROM job";
        //        using (var command = new MySqlCommand(query, conn))
        //        {
        //            using (var reader = command.ExecuteReader())
        //            {
        //                //Iterate through the rows and add it to the combobox's items
        //                while (reader.Read())
        //                {
        //                    textBoxjob.Items.Add(reader.GetString("jobId"));
        //                }
        //            }
        //        }
            
        //}

        //Load customer details using the ID
        private void LoadjobDetailsByjobName(int jn)
        {
            {
                conn.Open();
                var query = "SELECT * FROM job WHERE jobId = @A";
                using (var command = new MySqlCommand(query, conn))
                {
                    //Always use SQL parameters to avoid SQL injection and it automatically escapes characters
                    command.Parameters.AddWithValue("@A", jn);
                    using (var reader = command.ExecuteReader())
                    {
                        //No customer found by supplied ID
                        if (!reader.HasRows)
                            return;

                        textBoxjob.Text = reader.GetInt32("jobId").ToString();
                        //textBoxjob.Text = reader.GetString("jobName");
                    }
                }
            }
        }

        //Pass the selected ID in the combobox to the customer details loader method 
       
        //private void textBoxjob_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    jobs();
        //    var jn = Convert.ToInt32(textBoxjob.Text);
        //    LoadjobDetailsByjobName(jn);

        //}

        //private void textBoxjob_TextChanged(object sender, EventArgs e)
        //{
        //    string filter = textBoxjob.Text;
        //    filter = "SELECT jobName FROM `jobs` WHERE jobName like '%" + filter + "%'";
        //    filter = "SELECT jobName FROM `jobs` WHERE jobId like '%" + filter + "%'";
        //}
    }
}
