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
using System.IO;

namespace Delivery
{
    public partial class Vechicle_Mgt : Form
    {

        public string connString = "Server=localhost;Database=inventory;Uid=root;Password=;";

        public Vechicle_Mgt()
        {
            InitializeComponent();
        }

        private void LoadToDatagridview(DataGridView dgv, string q)
        {
            DataTable dt = new DataTable();
            MySqlConnection conn = new MySqlConnection(connString);

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
        private void txt_vName_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_vNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void txt_chasiNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_chasiNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_engNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_capacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_oilL_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_vName.Text == "" || txt_vNumber.Text == "" || txt_chasiNo.Text == "" || txt_engNo.Text == "" || txt_capacity.Text == "" || txt_oilL.Text == "" || txt_Cost.Text == "")
            {
                MessageBox.Show("Please do not keep fields empty");
            }
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {

                    string Query = null;
                    Query = "INSERT INTO vehicle (VehicleName,VehicleNumber,ChassisNumber,EngineNumber,Capacity,OilLeters,Cost)" +
                        "VALUES(@VehicleName,@VehicleNumber,@ChassisNumber,@EngineNumber,@Capacity,@OilLeters,@Cost)";


                    using (MySqlCommand cmd = new MySqlCommand(Query, conn))
                    {
                        cmd.Parameters.Add("@VehicleName", MySqlDbType.VarChar).Value = txt_vName.Text;
                        cmd.Parameters.Add("@VehicleNumber", MySqlDbType.VarChar).Value = txt_vNumber.Text;
                        cmd.Parameters.Add("@ChassisNumber", MySqlDbType.VarChar).Value = txt_chasiNo.Text;
                        cmd.Parameters.Add("@EngineNumber", MySqlDbType.VarChar).Value = txt_engNo.Text;
                        cmd.Parameters.Add("@Capacity", MySqlDbType.Int32).Value = txt_capacity.Text;
                        cmd.Parameters.Add("@OilLeters", MySqlDbType.Int32).Value = txt_oilL.Text;
                        cmd.Parameters.Add("@Cost", MySqlDbType.Int32).Value = txt_Cost.Text;



                        try
                        {
                            conn.Open();
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds).ToString();
                            MessageBox.Show("Vechicle Added Successfully");
                            LoadToDatagridview(dgvVechicle, "SELECT VehicleNumber ,Capacity,OilLeters  FROM vehicle");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }



            }
        }

        private void but_update_Click(object sender, EventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (txt_vName.Text == "" || txt_vNumber.Text == "" || txt_chasiNo.Text == "" || txt_engNo.Text == "" || txt_capacity.Text == "" || txt_oilL.Text == "")
            {
                MessageBox.Show("Please Select a  field to Delete", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filter = txt_search.Text;

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtSname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSname_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void labelSupID_Click(object sender, EventArgs e)
        {

        }

        private void txtsAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_Time_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ':'))
            {
                e.Handled = true;
            }
        }

        private void txtweightS_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtSnoTurn_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtweightS_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_Svnum_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_Cname_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txt_cAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_Ctime_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_cweight_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ':'))
            {
                e.Handled = true;
            }
        }

        private void txt_Ctime_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ':'))
            {
                e.Handled = true;
            }
        }

        private void txt_noofTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ':'))
            {
                e.Handled = true;
            }
        }

        private void txt_vnumberC_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_vnumberL_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_Lname_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_Laddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_interstRate_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_intialPay_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_vnumberSer_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_serAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_saveS_Click(object sender, EventArgs e)
        {
            if (txt_vName.Text == "" || txt_vNumber.Text == "" || txt_chasiNo.Text == "" || txt_engNo.Text == "" || txt_capacity.Text == "" || txt_oilL.Text == "")
            {
                MessageBox.Show("Please do not keep fields empty");
            }

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {

                    string Query = null;
                    Query = "INSERT INTO from_suppliers(SupplierName,SupplierAddress,StockWeight,NoOfTurn,VehicleNumber,Staffid)" +
                        "VALUES(@SupplierName,@SupplierAddress,@StockWeight,@NoOfTurn,@VehicleNumber,@Staffid);";


                    using (MySqlCommand cmd = new MySqlCommand(Query, conn))
                    {
                        cmd.Parameters.Add("@SupplierName", MySqlDbType.VarChar).Value = txtSname.Text;
                        cmd.Parameters.Add("@SupplierAddress", MySqlDbType.VarChar).Value = txtsAddress.Text;
                        cmd.Parameters.Add("@StockWeight", MySqlDbType.Int32).Value = Convert.ToInt32(txtweightS.Text);
                        cmd.Parameters.Add("@NoOfTurn", MySqlDbType.Int32).Value = Convert.ToInt32(txtSnoTurn.Text);
                        cmd.Parameters.Add("@VehicleNumber", MySqlDbType.VarChar).Value = txt_Svnum.Text;
                        cmd.Parameters.Add("@Staffid", MySqlDbType.Int32).Value = Convert.ToInt32(comboBoxStaffS.SelectedValue);


                        try
                        {
                            conn.Open();
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds).ToString();
                            MessageBox.Show("Suplier Added Successfully");
                            LoadToDatagridview(dgvSuppliers, "SELECT * FROM from_suppliers");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MessageBox.Show("e1");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("e2");
                }



            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you Sure You want clear fileds", "Clear", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txt_vName.Text = "";
            txt_vNumber.Text = "";
            txt_chasiNo.Text = "";
            txt_engNo.Text = "";
            txt_capacity.Text = "";
            txt_oilL.Text = "";



        }

        private void btn_clearS_Click(object sender, EventArgs e)
        {
            //txtSname.Text =="" || txtsAddress.Text =="" || txt_Time.Text=="" || txtweightS.Text=="" || txtSnoTurn.Text=="" || txt_Svnum.Text==""
            MessageBox.Show("Are you Sure You want clear fileds", "Clear", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtSname.Text = "";
            txtsAddress.Text = "";
            txt_Time.Text = "";
            txtweightS.Text = "";
            txtSnoTurn.Text = "";
            txt_Svnum.Text = "";







        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_saveL_Click(object sender, EventArgs e)
        {

        }

        private void buttnSave_Click(object sender, EventArgs e)
        {

        }



        private void btn_saveC_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_updateL_Click(object sender, EventArgs e)

        {
            using (MySqlCommand conn = new MySqlCommand(connString))
            {
                try
                {

                    string q = null;
                    q = "UPDATE leasing_details SET LeaserName=@LeaserName,LeaserAddress=@LeaserAddress,PhoneNumber=@PhoneNumber,Interestrate=@Interestrate,InitialPayement=@InitialPayement WHERE VehicleNumber=@VehicleNumber";
                    //using (MySqlCommand cmd = new MySqlCommand(q, conn)) { }
                    {




                    }
                }
                catch (Exception ex)
                {



                }

            }
        }

        private void btn_saveL_Click_1(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {

                    string Query = null;
                    Query = "INSERT INTO leasing_details(VehicleNumber,LeaserName,LeaserAddress,PhoneNumber,StartDate,EndDate,Interestrate,InitialPayement,Balance)" +
                        "VALUES(@VehicleNumber,@LeaserName,@LeaserAddress,@PhoneNumber,@StartDate,@EndDate,@Interestrate,@InitialPayement,@Balance);";

                    string VehicleNumber = comboBox1VechileNo.ToString();
                    using (MySqlCommand cmd = new MySqlCommand(Query, conn))
                    {
                        cmd.Parameters.Add("@VehicleNumber", MySqlDbType.VarChar).Value =(comboBox1VechileNo.Text);
                       // cmd.Parameters.Add("@Staffid", MySqlDbType.Int32).Value = Convert.ToInt32(comboBoxCustomer.SelectedIndex);

                        cmd.Parameters.Add("@LeaserName", MySqlDbType.VarChar).Value = txt_Lname.Text;
                        cmd.Parameters.Add("@LeaserAddress", MySqlDbType.VarChar).Value = txt_Laddress.Text;
                        cmd.Parameters.Add("@PhoneNumber", MySqlDbType.Int32).Value = txt_phoneNo.Text;
                        cmd.Parameters.Add("@StartDate", MySqlDbType.VarChar).Value = datePicLstart.Text;
                        cmd.Parameters.Add("@EndDate", MySqlDbType.VarChar).Value = datepicLend.Text;
                        //cmd.Parameters.Add("@EndDate", MySqlDbType.Int32).Value = Convert.ToInt32(comboBoxStaffS.SelectedValue);StartDate,EndDate//@StartDate,@EndDate,
                        cmd.Parameters.Add("@Interestrate", MySqlDbType.Int32).Value = txt_interstRate.Text;
                        cmd.Parameters.Add("@InitialPayement", MySqlDbType.Int32).Value = txt_intialPay.Text;
                        cmd.Parameters.Add("@Balance", MySqlDbType.Double).Value = text_balance.Text;


                        try
                        {
                            conn.Open();
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds).ToString();
                            MessageBox.Show("Leasing Details Added Successfully");
                            LoadToDatagridview(dgvLeasing, "SELECT * FROM leasing_details");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MessageBox.Show("e1");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("e2");
                }



            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            LoadToDatagridview(dgvVechicle, "SELECT VehicleNumber ,Capacity,OilLeters  FROM vehicle");
            LoadToDatagridview(dgvSuppliers, "SELECT * FROM from_suppliers");
            LoadToDatagridview(dgvLeasing, "SELECT * FROM leasing_details");
            LoadToDatagridview(dgvCustomer, "SELECT * FROM to_customers");
            LoadToDatagridview(dgvService, "SELECT * FROM service_details");
            LoadvechileNo();
            LoadDriver();
            LoadDriverSup();
        }

        private void buttnSave_Click_1(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {

                    string Query = null;
                    Query = "INSERT INTO service_details(VehicleNumber,ServiceType,ServiceDate,ServiceAmount,NextSerDate)" +
                                                 "VALUES(@VehicleNumber,@ServiceType,@ServiceDate,@ServiceAmount,@NextSerDate);";
                   // string VehicleNumber = comboBox1VechileNo.ToString();

                    using (MySqlCommand cmd = new MySqlCommand(Query, conn))
                    {
                        cmd.Parameters.Add("@VehicleNumber", MySqlDbType.VarChar).Value = txt_vnumberSer.Text;

                        cmd.Parameters.Add("@ServiceType", MySqlDbType.VarChar).Value =(comboBoxServiT.Text);
                        cmd.Parameters.Add("@ServiceDate", MySqlDbType.VarChar).Value = datePicService.Text;
                        cmd.Parameters.Add("@ServiceAmount", MySqlDbType.Int32).Value = txt_serAmount.Text;
                        cmd.Parameters.Add("@NextSerDate", MySqlDbType.VarChar).Value = datePickerNextServiceDate.Text;

                        //cmd.Parameters.Add("@StartDate", MySqlDbType.VarChar).Value = txt_Svnum.Text;
                        //cmd.Parameters.Add("@EndDate", MySqlDbType.Int32).Value = Convert.ToInt32(comboBoxStaffS.SelectedValue);StartDate,EndDate//@StartDate,@EndDate,



                        try
                        {
                            conn.Open();
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds).ToString();
                            MessageBox.Show("Service Details Added Successfully");
                            LoadToDatagridview(dgvService, "SELECT * FROM service_details");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MessageBox.Show("e1");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("e2");
                }



            }
        }

        private void btn_saveC_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {

                    string Query = null;
                    Query = "INSERT INTO to_customers(CustomerName,CustomerAddress,Date,Time,StockWeight,NoOfTurn,VehicleNumber,Staffid)" +
                        "VALUES(@CustomerName,@CustomerAddress,@Date,@Time,@StockWeight,@NoOfTurn,@VehicleNumber,@Staffid);";


                    using (MySqlCommand cmd = new MySqlCommand(Query, conn))
                    {
                        cmd.Parameters.Add("@CustomerName", MySqlDbType.VarChar).Value = txt_Cname.Text;
                        cmd.Parameters.Add("@CustomerAddress", MySqlDbType.VarChar).Value = txt_cAddress.Text;
                        cmd.Parameters.Add("@Date", MySqlDbType.VarChar).Value = datePicC.Text;
                        cmd.Parameters.Add("@Time", MySqlDbType.VarChar).Value = txt_Ctime.Text;
                        cmd.Parameters.Add("@StockWeight", MySqlDbType.Int32).Value = Convert.ToInt32(txt_cweight.Text);
                        cmd.Parameters.Add("@NoOfTurn", MySqlDbType.Int32).Value = Convert.ToInt32(txt_noofTc.Text);
                        cmd.Parameters.Add("@VehicleNumber", MySqlDbType.VarChar).Value = txt_vnumberC.Text;
                        cmd.Parameters.Add("@Staffid", MySqlDbType.Int32).Value = Convert.ToInt32(comboBoxCustomer.SelectedIndex);
                       // cmd.Parameters.Add("@ServiceType", MySqlDbType.VarChar).Value = Convert.ToInt32(comboBoxServiT.SelectedIndex);

                        try
                        {
                            conn.Open();
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds).ToString();
                            MessageBox.Show("Customer Delivery Details Added Successfully");
                            LoadToDatagridview(dgvCustomer, "SELECT * FROM to_customers");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MessageBox.Show("e1");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("e2");
                }



            }
        }

        private void but_update_Click_1(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {

                    string Query = null;
                    Query = "UPDATE vehicle SET VehicleNumber=@VehicleNumber,VehicleName=@VehicleName,Capacity=@Capacity,OilLeters=@OilLeters,Cost=@Cost WHERE VehicleNumber=@VehicleNumber";



                    using (MySqlCommand cmd = new MySqlCommand(Query, conn))
                    {
                        cmd.Parameters.Add("@VehicleName", MySqlDbType.VarChar).Value = txt_vName.Text;
                        cmd.Parameters.Add("@VehicleNumber", MySqlDbType.VarChar).Value = txt_vNumber.Text;
                        //cmd.Parameters.Add("@ChassisNumber", MySqlDbType.VarChar).Value = txt_chasiNo.Text;
                        //cmd.Parameters.Add("@EngineNumber", MySqlDbType.VarChar).Value = txt_engNo.Text;
                        cmd.Parameters.Add("@Capacity", MySqlDbType.Int32).Value = txt_capacity.Text;
                        cmd.Parameters.Add("@OilLeters", MySqlDbType.Int32).Value = txt_oilL.Text;
                        cmd.Parameters.Add("@Cost", MySqlDbType.Int32).Value = txt_Cost.Text;

                        int rows = 0;

                        try
                        {
                            conn.Open();
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds).ToString();

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Vechicle  Updated Successfully");
                            LoadToDatagridview(dgvVechicle, "SELECT VehicleNumber,Capacity,OilLeters,VehicleName,Cost FROM vehicle");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }



            }
        }

        private void btn_clear_Click_1(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you Sure You want clear fileds", "Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                txt_vName.Text = "";
                txt_vNumber.Text = "";
                txt_chasiNo.Text = "";
                txt_engNo.Text = "";
                txt_capacity.Text = "";
                txt_oilL.Text = "";
                txt_Cost.Text = "";
            }
        }

        private void btn_updateL_Click_1(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {

                    string Query = null;
                    Query = "UPDATE leasing_details SET VehicleNumber=@VehicleNumber,LeaserName=@LeaserName,LeaserAddress=@LeaserAddress,PhoneNumber=@PhoneNumber,Interestrate=@Interestrate WHERE 	LeaserID=@LeaserID";//StartDate=@StartDate,EndDate=@EndDate,



                    using (MySqlCommand cmd = new MySqlCommand(Query, conn))
                    {




                        {//cmd.Parameters.Add("@dob", MySqlDbType.Date).Value = datePic.Value;
                            cmd.Parameters.Add("@VehicleNumber", MySqlDbType.VarChar).Value = Convert.ToInt32(comboBox1VechileNo.SelectedIndex);
                            cmd.Parameters.Add("@LeaserName", MySqlDbType.VarChar).Value = txt_Lname.Text;
                            cmd.Parameters.Add("@LeaserAddress", MySqlDbType.VarChar).Value = txt_Laddress.Text;
                            cmd.Parameters.Add("@PhoneNumber", MySqlDbType.Int32).Value = txt_phoneNo.Text;
                            //cmd.Parameters.Add("@StartDate", MySqlDbType.VarChar).Value = datePicLstart.Value;
                            //cmd.Parameters.Add("@EndDate", MySqlDbType.VarChar).Value = datepicLend.Value;//StartDate,EndDate//@StartDate,@EndDate,
                            cmd.Parameters.Add("@Interestrate", MySqlDbType.Int32).Value = txt_interstRate.Text;
                            cmd.Parameters.Add("@InitialPayement", MySqlDbType.Int32).Value = txt_intialPay.Text;

                            int rows = 0;

                            try
                            {
                                conn.Open();
                                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                                DataSet ds = new DataSet();
                                da.Fill(ds).ToString();

                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Leasing Details   Updated Successfully");
                                LoadToDatagridview(dgvLeasing, "SELECT * FROM leasing_details");

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                MessageBox.Show("error 1");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    MessageBox.Show("error 2");
                }



            }
        }

        private void btn_deleteL_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                DialogResult confirm = MessageBox.Show("Do you want to Delete", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        string Query = null;
                        Query = "DELETE FROM leasing_details  WHERE			LeaserName='" + this.txt_Lname.Text + "';";
                        MySqlCommand cmd = new MySqlCommand(Query, conn);
                        MySqlDataReader reader;
                        conn.Open();
                        reader = cmd.ExecuteReader();
                        conn.Close();
                        LoadToDatagridview(dgvLeasing, "SELECT *  FROM leasing_details");
                        MessageBox.Show("Row Dleted");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }

        }

        private void btn_clearL_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you Sure You want clear fileds", "Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                comboBox1VechileNo.Text = "";
                txt_Lname.Text = "";
                txt_Laddress.Text = "";
                txt_phoneNo.Text = "";
                txt_interstRate.Text = "";
                txt_intialPay.Text = "";
                text_leasing.Text = "";
                text_balance.Text = "";


            }

        }

        private void btn_closeL_Click(object sender, EventArgs e)
        {

            var opt = MessageBox.Show("Are you sure you want to close?\nAny modifications to the user will not be saved", "Confirm Clsoe", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);


            if (opt == DialogResult.OK)

                this.Close();
        }

        private void btn_saveS_Click_1(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {

                    string Query = null;
                    Query = "INSERT INTO from_suppliers(SupplierName,SupplierAddress,Date,Time,StockWeight,NoOfTurn,VehicleNumber,Staffid)" +
                        "VALUES(@SupplierName,@SupplierAddress,@Date,@Time,@StockWeight,@NoOfTurn,@VehicleNumber,@Staffid);";


                    using (MySqlCommand cmd = new MySqlCommand(Query, conn))
                    {
                        cmd.Parameters.Add("@SupplierName", MySqlDbType.VarChar).Value = txtSname.Text;
                        cmd.Parameters.Add("@SupplierAddress", MySqlDbType.VarChar).Value = txtsAddress.Text;
                        cmd.Parameters.Add("@Date", MySqlDbType.VarChar).Value = datePicS.Text;
                        cmd.Parameters.Add("@Time", MySqlDbType.VarChar).Value = txt_Time.Text;
                        cmd.Parameters.Add("@StockWeight", MySqlDbType.Int32).Value = Convert.ToInt32(txtweightS.Text);
                        cmd.Parameters.Add("@NoOfTurn", MySqlDbType.Int32).Value = Convert.ToInt32(txtSnoTurn.Text);
                        cmd.Parameters.Add("@VehicleNumber", MySqlDbType.VarChar).Value = txt_Svnum.Text;
                        cmd.Parameters.Add("@Staffid", MySqlDbType.Int32).Value = Convert.ToInt32(comboBoxStaffS.SelectedIndex);
                      
                        try
                        {
                            conn.Open();
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds).ToString();
                            MessageBox.Show("Supplier Delivery Details Added Successfully");
                            LoadToDatagridview(dgvSuppliers, "SELECT * FROM from_suppliers");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MessageBox.Show("e1");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("e2");
                }



            }
        }
        public void LoadvechileNo()
        {

            MySqlConnection conn = new MySqlConnection(connString);

            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }


            string query = "select * from vehicle";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            try
            {
                var read = cmd.ExecuteReader();
                while (read.Read())
                    comboBox1VechileNo.Items.Add(read.GetString("VehicleNumber"));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }


        }
        public void LoadDriver()
        {

            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();


            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);


            }
            //"SELECT s.fName 'First Name', s.lname 'Last Name' FROM staff s, designation d WHERE s.desig = d.id AND d.id
            string query = "select  s.fName from staff s, designation d WHERE s.desig = d.id AND d.id=8";
            MySqlCommand cmd = new MySqlCommand(query,conn);
            try
            {

                var read = cmd.ExecuteReader();
                while (read.Read())
                    comboBoxCustomer.Items.Add(read.GetString("fName"));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }




        }
        public void LoadDriverSup()
        {

            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }
            //"SELECT s.fName 'First Name', s.lname 'Last Name' FROM staff s, designation d WHERE s.desig = d.id AND d.id
            string query = "select  s.fName from staff s, designation d WHERE s.desig = d.id AND d.id=8";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try
            {

                var read = cmd.ExecuteReader();
                while (read.Read())
                    comboBoxStaffS.Items.Add(read.GetString("fName"));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }




        }


        private void txt_vName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_vName_Validated(object sender, EventArgs e)
        {

        }

        private void txt_Cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvVechicle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //string VehicleNumber = dgvLeasing.SelectedCells[0].Value.ToString();
            string VehicleNumber = dgvVechicle.SelectedCells[0].Value.ToString();
            MySqlConnection conn = new MySqlConnection(connString);

            try
            {
                conn.Open();
                MySqlDataReader dr = null;
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM vehicle WHERE VehicleNumber =" + VehicleNumber + ";", conn);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {


                    txt_vName.Text = dr["VehicleName"].ToString();
                    txt_vNumber.Text = dr["VehicleNumber"].ToString();
                    txt_chasiNo.Text = dr["ChassisNumber"].ToString();
                    txt_engNo.Text = dr["EngineNumber"].ToString();
                    txt_capacity.Text = dr["Capacity"].ToString();
                    txt_oilL.Text = dr["OilLeters"].ToString();
                    txt_Cost.Text = dr["Cost"].ToString();


                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvLeasing_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connString);

            try
            {
                string LeaserID = dgvLeasing.SelectedCells[0].Value.ToString();
                conn.Open();
                MySqlDataReader dr = null;

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM leasing_details WHERE 	LeaserID =" + LeaserID + ";", conn);

                dr = cmd.ExecuteReader();
                try
                {
                    while (dr.Read())
                    {
                        //string year = dr["StartDate"].ToString().Substring(0, 4);
                        //string month = dr["StartDate"].ToString().Substring(5, 2);
                        //string day = dr["StartDate"].ToString().Substring(8, 2);
                        //string yeare = dr["EndDate"].ToString().Substring(0, 4);
                        //string monthe = dr["EndDate"].ToString().Substring(5, 2);
                        //string daye = dr["EndDate"].ToString().Substring(8, 2);

                        //lbl_id.Text = dr["id"].ToString();
                        // for leasing calulction purpose lbl_age.Text = (DateTime.Now.Year - Convert.ToInt32(year)).ToString();
                        //txtBoxLeaserid.Text = dr["	LeaserID"].ToString();
                        //cmd.Parameters.Add("@VehicleNumber", MySqlDbType.VarChar).Value =(comboBox1VechileNo.Text);
                        comboBox1VechileNo.Text = dr["VehicleNumber"].ToString();
                        txt_Lname.Text = dr["LeaserName"].ToString();
                        txt_Laddress.Text = dr["LeaserAddress"].ToString();
                        txt_phoneNo.Text = dr["PhoneNumber"].ToString();
                        //datePicLstart.Value = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
                        //datepicLend.Value = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));//
                        txt_interstRate.Text = dr["Interestrate"].ToString();
                        txt_intialPay.Text = dr["InitialPayement"].ToString();

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("error @ while ");

                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("error @ cell click");
            }
        }

        private void dgvLeasing_Click(object sender, EventArgs e)
        {

        }

        private void btn_updateS_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {

                    string Query = null;
                    Query = "UPDATE from_suppliers SET SupplierName = @SupplierName,SupplierAddress = @SupplierAddress,Date = @Date,Time=@Time,StockWeight = @StockWeight,NoOfTurn = @NoOfTurn,VehicleNumber = @VehicleNumber,Staffid = @Staffid WHERE VehicleNumber = @VehicleNumber";



                    using (MySqlCommand cmd = new MySqlCommand(Query, conn))
                    {
                        cmd.Parameters.Add("@SupplierName", MySqlDbType.VarChar).Value = txtSname.Text;
                        cmd.Parameters.Add("@SupplierAddress", MySqlDbType.VarChar).Value = txtsAddress.Text;
                        cmd.Parameters.Add("@Date", MySqlDbType.VarChar).Value = datePicS.Text;
                        cmd.Parameters.Add("@Time", MySqlDbType.VarChar).Value = txt_Time.Text;
                        cmd.Parameters.Add("@StockWeight", MySqlDbType.Int32).Value = Convert.ToInt32(txtweightS.Text);
                        cmd.Parameters.Add("@NoOfTurn", MySqlDbType.Int32).Value = Convert.ToInt32(txtSnoTurn.Text);
                        cmd.Parameters.Add("@VehicleNumber", MySqlDbType.VarChar).Value = txt_Svnum.Text;
                        cmd.Parameters.Add("@Staffid", MySqlDbType.Int32).Value = Convert.ToInt32(comboBoxStaffS.SelectedIndex);

                        int rows = 0;
                        try
                        {
                            conn.Open();
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds).ToString();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Supplier Delivery Details Updateed Successfully");
                            LoadToDatagridview(dgvSuppliers, "SELECT * FROM from_suppliers");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MessageBox.Show("e1");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("e2");
                }



            }
        }

        private void dgvService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //string VehicleNumber = dgvLeasing.SelectedCells[0].Value.ToString();
          
            MySqlConnection conn = new MySqlConnection(connString);

            try
            {
                string ServiceID = dgvService.SelectedCells[0].Value.ToString();
                conn.Open();
                MySqlDataReader dr = null;
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM service_details WHERE 	ServiceID=" + ServiceID + ";", conn);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    /*string year = dr["ServiceDate"].ToString().Substring(0, 4);
                    string month = dr["ServiceDate"].ToString().Substring(5, 2);
                    string day = dr["ServiceDate"].ToString().Substring(8, 2);
                   */
                    //comboBox1VechileNo.Text = dr["VehicleNumber"].ToString();

                    // label_serviceID.Text = dr["	ServiceID"].ToString();
                    // comboBox1VechileNo.Text = dr["VehicleNumber"].ToString();
                    txt_vnumberSer.Text = dr["VehicleNumber"].ToString();
                    comboBoxServiT.Text = dr["ServiceType"].ToString();
                    // datePicService.Value = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
                    txt_serAmount.Text = dr["ServiceAmount"].ToString();



                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttnUpdate_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {

                    string Query = null;
                    Query = "UPDATE service_details SET VehicleNumber=@VehicleNumber,ServiceType= @ServiceType,ServiceDate =@ServiceDate,ServiceAmount=@ServiceAmount WHERE VehicleNumber=@VehicleNumber";



                    using (MySqlCommand cmd = new MySqlCommand(Query, conn))
                    {
                        cmd.Parameters.Add("@VehicleNumber", MySqlDbType.VarChar).Value = txt_vnumberSer.Text;

                        cmd.Parameters.Add("@ServiceType", MySqlDbType.VarChar).Value = Convert.ToInt32(comboBoxServiT.SelectedIndex);
                        cmd.Parameters.Add("@ServiceDate", MySqlDbType.VarChar).Value = datePicService.Text;
                        cmd.Parameters.Add("@ServiceAmount", MySqlDbType.Int32).Value = txt_serAmount.Text;
                        

                        int rows = 0;

                        try
                        {
                            conn.Open();
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds).ToString();

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Service Details Updated Successfully");
                            LoadToDatagridview(dgvService, "SELECT * FROM service_details ");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }



            }
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string TripID = dgvCustomer.SelectedCells[0].Value.ToString();
            MySqlConnection conn = new MySqlConnection(connString);

            try
            {
                conn.Open();
                MySqlDataReader dr = null;
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM to_customers WHERE 	TripID =" + TripID + ";", conn);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    /*string year = dr["ServiceDate"].ToString().Substring(0, 4);
                    string month = dr["ServiceDate"].ToString().Substring(5, 2);
                    string day = dr["ServiceDate"].ToString().Substring(8, 2);
                   */

                   // cmd.Parameters.Add("@Staffid", MySqlDbType.Int32).Value = Convert.ToInt32(comboBoxCustomer.SelectedIndex);

                    txt_Cname.Text = dr["CustomerName"].ToString();
                    txt_cAddress.Text = dr["CustomerAddress"].ToString();
                    // datePicC.Value = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
                    // cmd.Parameters.Add("@Time", MySqlDbType.VarChar).Value = txt_Ctime.Text;
                    txt_Ctime.Text = dr["Time"].ToString();
                    txt_cweight.Text = dr["StockWeight"].ToString();
                    txt_noofTc.Text = dr["NoOfTurn"].ToString();
                    txt_vnumberC.Text = dr["VehicleNumber"].ToString();
                    comboBoxCustomer.Text = dr["Staffid"].ToString();



                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_updateC_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {

                    string Query = null;
                    Query = "UPDATE to_customers SET CustomerName=@CustomerName,CustomerAddress= @CustomerAddress,Date =@Date,Time=@Time,StockWeight=@StockWeight,NoOfTurn=@NoOfTurn,VehicleNumber=@VehicleNumber,Staffid=@Staffid WHERE VehicleNumber=@VehicleNumber";



                    using (MySqlCommand cmd = new MySqlCommand(Query, conn))
                    {
                        cmd.Parameters.Add("@CustomerName", MySqlDbType.VarChar).Value = txt_Cname.Text;
                        cmd.Parameters.Add("@CustomerAddress", MySqlDbType.VarChar).Value = txt_cAddress.Text;
                        cmd.Parameters.Add("@Date", MySqlDbType.VarChar).Value = datePicC.Text;
                        cmd.Parameters.Add("@Time", MySqlDbType.VarChar).Value = txt_Ctime.Text;
                        cmd.Parameters.Add("@StockWeight", MySqlDbType.Int32).Value = Convert.ToInt32(txt_cweight.Text);
                        cmd.Parameters.Add("@NoOfTurn", MySqlDbType.Int32).Value = Convert.ToInt32(txt_noofTc.Text);
                        cmd.Parameters.Add("@VehicleNumber", MySqlDbType.VarChar).Value = txt_vnumberC.Text;
                        cmd.Parameters.Add("@Staffid", MySqlDbType.Int32).Value = Convert.ToInt32(comboBoxCustomer.SelectedIndex);
                        
                        int rows = 0;

                        try
                        {
                            conn.Open();
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds).ToString();

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Customer Details Updated Successfully");
                            LoadToDatagridview(dgvCustomer, "SELECT * FROM to_customers ");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }



            }

        }

        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            string TripID = dgvSuppliers.SelectedCells[0].Value.ToString();
            MySqlConnection conn = new MySqlConnection(connString);

            try
            {
                conn.Open();
                MySqlDataReader dr = null;
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM from_suppliers WHERE TripID =" + TripID + ";", conn);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    /*string year = dr["ServiceDate"].ToString().Substring(0, 4);
                    string month = dr["ServiceDate"].ToString().Substring(5, 2);
                    string day = dr["ServiceDate"].ToString().Substring(8, 2);
                   */



                    txtSname.Text = dr["SupplierName"].ToString();
                    txtsAddress.Text = dr["SupplierAddress"].ToString();
                    // datePicS.Value = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
                    // cmd.Parameters.Add("@Time", MySqlDbType.VarChar).Value = txt_Time.Text;
                    txt_Time.Text = dr["Time"].ToString();
                    txtweightS.Text = dr["StockWeight"].ToString();
                    txtSnoTurn.Text = dr["NoOfTurn"].ToString();
                    txt_Svnum.Text = dr["VehicleNumber"].ToString();
                    comboBoxStaffS.Text = dr["Staffid"].ToString();



                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_delete_Click_1(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                DialogResult confirm = MessageBox.Show("Do you want to Delete", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        string Query = null;//                    query = "delete from manufactraw where rawMaterialID='" + text_ID.Text + "';";
                        Query = "DELETE FROM vehicle   WHERE	VehicleNumber='" + this.txt_vNumber.Text + "';";
                        MySqlCommand cmd = new MySqlCommand(Query, conn);
                        MySqlDataReader reader;
                        conn.Open();
                        reader = cmd.ExecuteReader();
                        conn.Close();


                        LoadToDatagridview(dgvVechicle, "SELECT *  FROM vehicle");
                        MessageBox.Show("Row Deleted");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }


            }
        }

        private void butnDelete_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                DialogResult confirm = MessageBox.Show("Do you want to Delete", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                {
                    if (confirm == DialogResult.Yes)
                    {
                        try
                        {
                            string Query = null;
                            Query = "DELETE FROM  service_details WHERE VehicleNumber='" + this.txt_vnumberSer.Text + "';";
                            MySqlCommand cmd = new MySqlCommand(Query, conn);
                            MySqlDataReader reader;
                            conn.Open();
                            reader = cmd.ExecuteReader();
                            conn.Close();
                            LoadToDatagridview(dgvService, "SELECT *  FROM service_details");
                            MessageBox.Show("Row Deleted");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }

                }
            }
        }

        private void butnClear_Click(object sender, EventArgs e)
        {

            DialogResult confirm = MessageBox.Show("Are you Sure You want clear fileds", "Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {   //cmd.Parameters.Add("@ServiceType", MySqlDbType.VarChar).Value =(comboBoxServiT.Text);
                //comboBoxServiT
                //comboBox1VechileNo.Text = "";
                txt_vnumberSer.Text = "";
                comboBoxServiT.Text = "";
                txt_serAmount.Text = "";
               



            }
        }

        private void btn_deleteC_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                DialogResult confirm = MessageBox.Show("Do you want to Delete", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        string Query = null;
                        Query = "DELETE FROM to_customers WHERE VehicleNumber='" + this.txt_vnumberC.Text + "';";
                        MySqlCommand cmd = new MySqlCommand(Query, conn);
                        MySqlDataReader reader;
                        conn.Open();
                        reader = cmd.ExecuteReader();
                        conn.Close();
                        LoadToDatagridview(dgvCustomer, "SELECT *  FROM to_customers");
                        MessageBox.Show("Row Deleted");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);




                    }
                }


            }
        }

        private void btn_clearC_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you Sure You want clear fileds", "Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {//cmd.Parameters.Add("@Staffid", MySqlDbType.Int32).Value = Convert.ToInt32(comboBoxCustomer.SelectedIndex);

                txt_Cname.Text = "";
                txt_cAddress.Text = "";
                txt_cweight.Text = "";
                txt_noofTc.Text = "";
                txt_vnumberC.Text = "";
                comboBoxCustomer.Text = "";
                txt_Ctime.Text = "";
            }
        }

        private void btn_deleteS_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                DialogResult confirm = MessageBox.Show("Do you want to Delete", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {

                        string Query = null;
                        Query = "DELETE FROM from_suppliers WHERE VehicleNumber='" + this.txt_Svnum.Text + "';";

                        MySqlCommand cmd = new MySqlCommand(Query, conn);
                        MySqlDataReader reader;
                        conn.Open();
                        reader = cmd.ExecuteReader();
                        conn.Close();
                        LoadToDatagridview(dgvSuppliers, "SELECT *  FROM from_suppliers");
                        MessageBox.Show("Row Deleted");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }

        private void btn_clearS_Click_1(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you Sure You want clear fileds", "Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {//cmd.Parameters.Add("@Staffid", MySqlDbType.Int32).Value = Convert.ToInt32(comboBoxStaffS.SelectedIndex);
                txtSname.Text = "";
                txtsAddress.Text="";
                txtweightS.Text = "";
                txtSnoTurn.Text = "";
                txt_Svnum.Text = "";
                comboBoxStaffS.Text = "";
                txt_Time.Text = "";
            }
        }

        private void txt_Lname_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_Laddress_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '/'))
            {
                e.Handled = true;
            }
        }

        private void txt_phoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_interstRate_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_intialPay_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_vnumberSer_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_serAmount_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_Cname_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_cAddress_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '/'))
            {
                e.Handled = true;
            }
        }

        private void txt_Ctime_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && (e.KeyChar != ':'))
            {
                e.Handled = true;
            }
        }

        private void txt_cweight_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_noofTc_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_vnumberC_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void txtSname_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tabControl1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtsAddress_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '/'))
            {
                e.Handled = true;
            }
        }

        private void txt_Time_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && (e.KeyChar != ':'))
            {
                e.Handled = true;
            }
        }

        private void txtweightS_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSnoTurn_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_Svnum_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            var opt = MessageBox.Show("Are you sure you want to close?\nAny modifications to the user will not be saved", "Confirm Clsoe", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);


            if (opt == DialogResult.OK)

                this.Close();

        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            string filter = txt_search.Text;
            // Loadtable(mdgv_production1, "SELECT batchNo,currentJob FROM `batch` WHERE batchNo like '%" + filter + "%'");

            LoadToDatagridview(dgvVechicle, "SELECT VehicleNumber,Capacity,Cost FROM vehicle WHERE 	VehicleNumber LIKE '%" + filter + "%'");
           


        }

        private void text_serachL_TextChanged(object sender, EventArgs e)
        {
            string filter = text_serachL.Text;
            LoadToDatagridview(dgvLeasing, "SELECT * FROM leasing_details WHERE 	VehicleNumber LIKE '%" + filter + "%'");
        }

        private void txt_serachSer_TextChanged(object sender, EventArgs e)
        {
            string filter = txt_serachSer.Text;
            LoadToDatagridview(dgvService, "SELECT * FROM service_details WHERE 	VehicleNumber LIKE '%" + filter + "%'");

        }

        private void txt_serachC_TextChanged(object sender, EventArgs e)
        {
            string filter = txt_serachC.Text;
            LoadToDatagridview(dgvCustomer, "SELECT * FROM to_customers WHERE 	CustomerName LIKE '%" + filter + "%'");

        }

        private void txt_searchS_TextChanged(object sender, EventArgs e)
        {
            string filter = txt_searchS.Text;
            LoadToDatagridview(dgvSuppliers, "SELECT * FROM from_suppliers WHERE 	SupplierName LIKE '%" + filter +"%'");
        }

        private void butnClose_Click(object sender, EventArgs e)
        {

            var opt = MessageBox.Show("Are you sure you want to close?\nAny modifications to the user will not be saved", "Confirm Clsoe", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);


            if (opt == DialogResult.OK)

                this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var opt = MessageBox.Show("Are you sure you want to close?\nAny modifications to the user will not be saved", "Confirm Clsoe", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);


            if (opt == DialogResult.OK)

                this.Close();
        }

        private void btn_closeS_Click(object sender, EventArgs e)
        {

            var opt = MessageBox.Show("Are you sure you want to close?\nAny modifications to the user will not be saved", "Confirm Clsoe", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);


            if (opt == DialogResult.OK)

                this.Close();
        }

        private void text_balance_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_interstRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void bttn_balance_Click(object sender, EventArgs e)
        {
            //variable diclarition
            int cost = 0;
            double intrestRate = 0, initialpay = 0, balance = 0;

            //read input from user
            cost = int.Parse(text_leasing.Text);
            intrestRate = double.Parse(txt_interstRate.Text);
            initialpay = double.Parse(txt_intialPay.Text);

            //do calculations
            double costrate = cost * (intrestRate / 100);
            balance = initialpay-costrate;

            //display result
            text_balance.Text = balance.ToString();




        }

        private void txt_Laddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string street = textBox_Street.Text;
            string city = textBox_City.Text;
            try
            {
                StringBuilder queryaddress = new StringBuilder();
                queryaddress.Append("http://maps.google.com/maps?q=");

                if (street != string.Empty) {
                    queryaddress.Append(street+","+"+");

                }
                if (city != string.Empty)
                {
                    queryaddress.Append(city + "," + "+");

                }

                webBrowser1.Navigate(queryaddress.ToString());
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString(),"Error");

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you Sure You want clear fileds", "Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                textBox_Street.Text = "";
                textBox_City.Text = "";
               

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            var opt = MessageBox.Show("Are you sure you want to close?", "Confirm Clsoe", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);


            if (opt == DialogResult.OK)

                this.Close();
        }


        // this.Close();
    }
    }



       
    
    



