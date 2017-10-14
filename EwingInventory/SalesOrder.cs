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
    public partial class Sales_Order_frm : Form
    {
        static string myConnection = "Server=localhost;Database=inventory;Uid=root;Pwd=;";
       // MySqlConnection myconn = new MySqlConnection(MyConnection);
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataSet ds;

      /*  public static string MyConnection { get => myConnection; set => myConnection = value; }
        public static string MyConnection1 { get => myConnection; set => myConnection = value; }*/

        public Sales_Order_frm()
        {
            InitializeComponent();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.MultiSelect = false;
        }

        private void Sales_Order_Load(object sender, EventArgs e)
        {
            
            /*   DataTable dt = new DataTable();
               dt.Columns.Add("Item Code");
               dt.Columns.Add("Description");
               dt.Columns.Add("unit Price");
               dt.Columns.Add("Qty");
               dt.Columns.Add("MRP");
               dt.Columns.Add("Disc");
               dt.Columns.Add("Total Cost");

             //  dt.Rows.Add();

               dataGridView1.DataSource = dt;

               DataTable dto = new DataTable();
               dto.Columns.Add("Invoice ID");
               dto.Rows.Add("1111");
               dto.Rows.Add("1111");
               dto.Rows.Add("1111");
               dto.Rows.Add("1111");
               dto.Rows.Add("1111");
               dto.Rows.Add("1111");
               dataGridView3.DataSource = dto;*/

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
               

        private void button4_Click(object sender, EventArgs e)
        {
 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            payment pay = new payment();
            pay.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage ho = new Homepage();
            ho.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OrderDetails_Enter(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
