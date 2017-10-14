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
    public partial class payment_history : Form
    {
        static string myConnection = "Server=localhost;Database=inventory;Uid=root;Pwd=;";
        MySqlConnection con = new MySqlConnection(myConnection);
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        public payment_history()
        {
            InitializeComponent();
            paymentHis.ColumnCount = 6;
            paymentHis.Columns[0].Name = "Name";
            paymentHis.Columns[1].Name = "Total";
            paymentHis.Columns[2].Name = "Payment Amount";
            paymentHis.Columns[3].Name = "Payment Method";
            paymentHis.Columns[4].Name = "Balance";
            




            paymentHis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            paymentHis.MultiSelect = false;
            paymentHis.Rows.Clear();
            string sql = "select * from orders";
            cmd = new MySqlCommand(sql, con);

            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(sql, con);
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                }

                con.Close();
                dt.Rows.Clear();
            }
            catch (Exception exception)
            { MessageBox.Show(exception.Message); }

        }

        private void populate(string Name, string Total, string Payment_Amount, string Payment_Method, string Balance)
        {
            paymentHis.Rows.Add(Name,Total,Payment_Amount,Payment_Method,Balance);
        }


        private void payment_history_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
