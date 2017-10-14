using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Supplier
{
    public partial class more : Form
    {
        static string myConnection = "Server=localhost;Database=inventory;Uid=root;Pwd=;";
        MySqlConnection con = new MySqlConnection(myConnection);
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        public more()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 9;
            dataGridView1.Columns[0].Name = "SupplierName";
            dataGridView1.Columns[1].Name = "total";
            dataGridView1.Columns[2].Name = "Amount paid";
            dataGridView1.Columns[3].Name = "Payment Method";
            dataGridView1.Columns[4].Name = "balance";
            dataGridView1.Columns[5].Name = "date";
            dataGridView1.Columns[6].Name = "ItemCode";
            dataGridView1.Columns[7].Name = "Quantity";
            dataGridView1.Columns[8].Name = "UnitPrice";


            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.Rows.Clear();
            string sql = "select orders.sname,orders.total,orders.pamount,orders.pmethod,orders.balance,orders.date,oitems.ItemCode,oitems.Quantity,oitems.UnitPrice from orders ,oitems where orders.ono=oitems.ono";
            cmd = new MySqlCommand(sql, con);

            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(sql, con);
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    populate121(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString());
                }

                con.Close();
                dt.Rows.Clear();
            }
            catch (Exception exception)
            { MessageBox.Show(exception.Message); }
        }

        private void more_Load(object sender, EventArgs e)
        {

        }
        private void populate121(string SupplierName, string total, string ap, string pm, string bl, string date,string ic, string q, string up)
        {
            dataGridView1.Rows.Add(SupplierName, total, ap, pm, bl, date,ic,q,up);
        }
    }
}
