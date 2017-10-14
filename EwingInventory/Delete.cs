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
    public partial class Delete : Form
    {
        static string myConnection = "Server=localhost;Database=inventory;Uid=root;Pwd=;";
        MySqlConnection con = new MySqlConnection(myConnection);
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        public Delete()
        {
            InitializeComponent();
            cmd = con.CreateCommand();
            cmd.CommandText = "Select Nic from supplier";
            try
            {
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                dels.Items.Clear();
                while (reader.Read())
                {
                    dels.Items.Add(reader[("Nic")]);

                }
                con.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }
        
    }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "DELETE from supplier where Nic='" + dels.SelectedItem + "'";
            cmd = new MySqlCommand(sql, con);
            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.DeleteCommand = con.CreateCommand();
                adapter.DeleteCommand.CommandText = sql;

                if (MessageBox.Show("Sure you want to delete ?", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (cmd.ExecuteNonQuery() > 0)
                    { MessageBox.Show("Successfully deleted!"); }

                }
                con.Close();
            }
            catch (Exception a)
            { MessageBox.Show("Connection Error!"); }


            cmd = con.CreateCommand();
            cmd.CommandText = "Select Nic from supplier";
            try
            {
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                dels.Items.Clear();
                while (reader.Read())
                {
                    dels.Items.Add(reader[("Nic")]);

                }
                con.Close();
            }
            catch (Exception exx)
            { MessageBox.Show(exx.Message); }

            dels.Text = "";
        }
    }
}
