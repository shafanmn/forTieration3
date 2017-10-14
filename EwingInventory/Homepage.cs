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
using System.ComponentModel.DataAnnotations;
using StockManagement;
using Supplier;
using Delivery;
using Accounts;

namespace EwingInventory
{
    public partial class Homepage : Form
    {

        public static string currentUser1 = string.Empty;
        public string currentUser = "";
        public string currentUID = "";
        public string currentUserAccess = string.Empty;
        public string connString = "Server=localhost;Database=inventory;Uid=root;Password=;";
        public string selectedUser = "";

        public Homepage()
        {
           InitializeComponent();
        }
       

        public void toFront(Form f)
        {
            f.TopLevel = true;
            f.Show();
            f.Owner = this;
        }

        public void fillCombo(ComboBox c, string q, string field)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(q, conn);

            try
            {
                conn.Open();
                var read = cmd.ExecuteReader();
                while (read.Read())
                    c.Items.Add(read.GetString(field));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
            finally
            {
                conn.Close();
            }

        }

        public bool isValidEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }

        public void LoadToDatagridview(DataGridView dgv, string q)
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

        public bool isExist(string q)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(q,conn);
            bool r = false;

            try
            {
                conn.Open();
                var read = cmd.ExecuteReader();
                while (read.Read())
                    r = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return r;
        }

        public void chanfeDGVColor(DataGridView dgv, int columnId, string condGreen, string condOrange)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[columnId].Value.ToString() == condGreen)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (row.Cells[columnId].Value.ToString() == condOrange)
                {
                    row.DefaultCellStyle.BackColor = Color.Orange;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void Homepage_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            TopMost = false;
            groupBox1.Width = Screen.FromControl(this).WorkingArea.Width + 10;
            this.Text = currentUser + " Logged in at "+ DateTime.Now.ToString("hh:mm:ss tt");

            if (currentUser != "ADMIN")
                btn_settings.Visible = false;
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
                if (f.Name != "Homepage")
                    f.TopMost = false;

            var opt = MessageBox.Show("Are you sure you want to logoff?\nAll open forms will be closed", "Confirm Logoff", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (opt == DialogResult.OK)
            {
                //Collect all open forms
                List<Form> openforms = new List<Form>();
                foreach (Form f in Application.OpenForms)
                    openforms.Add(f);

                //close all open forms
                foreach (Form f in openforms)
                    if (f.Name != "frm_login")
                        f.Close();
                
                //Open login form
                frm_login login = new frm_login();
                login.Show();
            }
        }

        private void btn_users_Click(object sender, EventArgs e)
        {
            bool b = false;
            
            foreach (Form f in Application.OpenForms)
                if (f.Name == "frm_users")
                    b = true;
            if (!b)
            {
                frm_users userform = new frm_users();
                userform.currentUser = this.currentUser;
                userform.currentUID = this.currentUID;
                userform.currentUseraccess = this.currentUserAccess;
                toFront(userform);
            }

        }

        private void btn_system_Click(object sender, EventArgs e)
        {
            bool b = false;

            foreach (Form f in Application.OpenForms)
                if (f.Name == "Settings")
                    b = true;
            if (!b)
            {
                Settings frmset = new Settings();
                toFront(frmset);

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bool b = false;

            foreach (Form f in Application.OpenForms)
                if (f.Name == "StockManagement")
                    b = true;
            if (!b)
            {
                StockManagement st = new StockManagement();
                toFront(st);
                
            }
        }

        private void btn_supplier_Click(object sender, EventArgs e)
        {
            bool b = false;

            foreach (Form f in Application.OpenForms)
                if (f.Name == "sup")
                    b = true;
            if (!b)
            {
                sup supp = new sup();
                toFront(supp);
            }
            else
            {
                MessageBox.Show(Application.OpenForms.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool b = false;

            foreach (Form f in Application.OpenForms)
                if (f.Name == "form_ManufactMgt")
                    b = true;
            if (!b)
            {
                form_ManufactMgt manufat = new form_ManufactMgt();
                toFront(manufat);
            }
        }

        private void btn_customer_Click(object sender, EventArgs e)
        {
            bool b = false;

            foreach (Form f in Application.OpenForms)
                if (f.Name == "Customer_Management")
                    b = true;
            if (!b)
            {
                Customer_Management cust = new Customer_Management();
                
                toFront(cust);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            bool b = false;

            foreach (Form f in Application.OpenForms)
                if (f.Name == "returnmgt")
                    b = true;
            if (!b)
            {
                returnmgt retn = new returnmgt();
                toFront(retn);
            }
        }

        private void btn_vehicle_Click(object sender, EventArgs e)
        {
            bool b = false;

            foreach (Form f in Application.OpenForms)
                if (f.Name == "Vechicle_Mgt")
                    b = true;
            if (!b)
            {
                Vechicle_Mgt veh = new Vechicle_Mgt();
                toFront(veh);
            }
        }

        private void btn_finance_Click(object sender, EventArgs e)
        {
            bool b = false;

            foreach (Form f in Application.OpenForms)
                if (f.Name == "AccountFrm")
                    b = true;
            if (!b)
            {
                AccountFrm act = new AccountFrm();
                toFront(act);
            }
        }
    }
    
}
