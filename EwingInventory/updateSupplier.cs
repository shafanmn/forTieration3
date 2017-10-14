using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
namespace Supplier
{
    public partial class updateSupplier : Form
    {
        static string myConnection = "Server=localhost;Database=inventory;Uid=root;Pwd=;";
        MySqlConnection myconn = new MySqlConnection(myConnection);
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();

        public updateSupplier()
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
            cmd = new MySqlCommand(sql, myconn);

            try
            {
                myconn.Open();
                adapter = new MySqlDataAdapter(sql, myconn);
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
                }

                myconn.Close();
                dt.Rows.Clear();
            }
            catch (Exception exception)
            { MessageBox.Show(exception.Message); }
        }

        private void populate(string SupplierName, string Nic, string Phone, string Fax, string E_mail,string sid)
        {
            dataGridView1.Rows.Add(SupplierName, Nic, Phone, Fax, E_mail,sid);
        }


        private void button6_Click(object sender, EventArgs e)
        {

        }

  

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }



        private void button8_Click(object sender, EventArgs e)
        {
            if ((sname.Text.Length == 0) || (nic.Text.Length == 0) || (fax.Text.Length == 0) || (phone.Text.Length == 0) ||
             (email.Text.Length == 0))
            { MessageBox.Show(" Please input to all Fields"); }


            else if (!Regex.IsMatch(email.Text, @"^[a-z,A-Z]{1,10}((-|.)\w+)*@\w+.\w{3}$"))
            {
                MessageBox.Show("Please enter a valid email address");
                email.Text = "";
            }
            else
            {
                string sql = "update supplier set Name='" + sname.Text + "',Nic='" + nic.Text + "',Phone='" + phone.Text + "',Fax ='" + fax.Text + "',email='" + email.Text + "' where sid='" + sid.Text + "' ";
                cmd = new MySqlCommand(sql, myconn);

                try
                {
                    myconn.Open();
                    adapter = new MySqlDataAdapter(cmd);
                    adapter.UpdateCommand = myconn.CreateCommand();
                    adapter.UpdateCommand.CommandText = sql;

                    if (adapter.UpdateCommand.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Successfully Updated!");
                    }
                    myconn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Input correct data to fields!");
                    myconn.Close();
                }

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
                string mysql = "select * from supplier";
                cmd = new MySqlCommand(mysql, myconn);

                try
                {
                    myconn.Open();
                    adapter = new MySqlDataAdapter(mysql, myconn);
                    adapter.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
                    }

                    myconn.Close();
                    dt.Rows.Clear();
                }
                catch (Exception exception)
                { MessageBox.Show(exception.Message); }

                sid.Text = "";
                sname.Text = "";
                nic.Text = "";
                phone.Text = "";
                fax.Text = "";
                email.Text = "";


            }
        }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            sname.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            nic.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            phone.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            fax.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            email.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            sid.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void updateSupplier_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void sname_TextChanged(object sender, EventArgs e)
        {
           
            
        }

        private void sname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar))
            { e.Handled = true; }

            else
            { e.Handled = false; }
        }

        private void phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || (phone.Text.Length < 0 || phone.Text.Length > 11))
            { e.Handled = true; }

            else
            { e.Handled = false; }
        }

        private void fax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || (fax.Text.Length < 0 || fax.Text.Length > 11))
            { e.Handled = true; }

            else
            { e.Handled = false; }
        }
    }
}

        

        
    

