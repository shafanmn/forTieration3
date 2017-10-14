using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using EwingInventory;

namespace StockManagement
{
     
    public partial class ViewStockAdjustment : Form
    {
        Homepage home = new Homepage();
        static string myConnection = "Server=localhost;Database=inventory;Uid=root;Pwd=;";
        MySqlConnection myconn = new MySqlConnection(myConnection);
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        public ViewStockAdjustment()
        {
            InitializeComponent();

            ViewSadjustment.ColumnCount = 6;
            ViewSadjustment.Columns[0].Name = "Date";
            ViewSadjustment.Columns[1].Name = "itemCode";
            ViewSadjustment.Columns[2].Name = "NewQuantity";
            ViewSadjustment.Columns[3].Name = "PreviousQuantity";
            ViewSadjustment.Columns[4].Name = "quantityLost";
            ViewSadjustment.Columns[5].Name = "reason";
            ViewSadjustment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ViewSadjustment.MultiSelect = false;
            ViewSadjustment.Rows.Clear();

            string sql = "select * from stockadjustments  ";
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
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void populate(string Date, string itemCode, string NewQuantity, string PreviousQuantity, string quantityLost, string reason)
        {

            ViewSadjustment.Rows.Add(Date, itemCode, NewQuantity, PreviousQuantity, quantityLost, reason);
        }
        private void ViewStockAdjustment_Load(object sender, EventArgs e)
        {
           
            string w = Screen.FromControl(home).WorkingArea.Width.ToString();
            this.Location = new Point((Convert.ToInt32(w) - this.Width) / 2, 120);
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }
    }
}
