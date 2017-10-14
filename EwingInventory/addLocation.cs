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
    public partial class addLocation : Form
    {
        static string myConnection = "Server=localhost;Database=inventory;Uid=root;Pwd=;";
        MySqlConnection con = new MySqlConnection(myConnection);
        MySqlCommand cmd;
        DataTable dt = new DataTable();
        MySqlDataAdapter adapter;

        public addLocation()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (NewLocation.Text == "")
            {
                MessageBox.Show(" Enter a Location and Countinue");
            }
            else
            {
                string sql = "INSERT INTO `location` (`location`) VALUES ('" + NewLocation.Text + "')";
                cmd = new MySqlCommand(sql, con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();


                    MessageBox.Show("Successfully Location Added");
                    this.Close();
                    StockManagement s = new StockManagement();
                    s.Show();


                }
                catch (Exception except)
                { MessageBox.Show(except.Message); }
            }
        }
    }
}
