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
    public partial class payment : Form
    {

        static string myConnection = "Server=localhost;Database=inventory;Uid=root;Pwd=;";
       // MySqlConnection myconn = new MySqlConnection(MyConnection);
        MySqlCommand cmd;
        MySqlDataAdapter adapter;

       /* public static string MyConnection { get => myConnection; set => myConnection = value; }
        public static string MyConnection1 { get => myConnection; set => myConnection = value; }
        public static string MyConnection2 { get => myConnection; set => myConnection = value; }*/

        public payment()
        {
            InitializeComponent();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.MultiSelect = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage ho = new Homepage();
            ho.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sales_Order_frm so = new Sales_Order_frm();
            so.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void payment_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            TopMost = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
