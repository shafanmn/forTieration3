using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EwingInventory
{
    public partial class returnmgt : Form
    {
        Homepage home = new Homepage();
        public returnmgt()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void returnmgt_Load(object sender, EventArgs e)
        {
            string w = Screen.FromControl(home).WorkingArea.Width.ToString();
            this.Location = new Point((Convert.ToInt32(w) - this.Width) / 2, 120);
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void txtcid_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtcid.Text == "")
                {
                    MessageBox.Show("CustomerID is not entered");

                }
                else
                {
                    string cid = txtcid.Text;
                    if ((cid.Trim().Length != 3))
                    {
                        MessageBox.Show("CustomerID should have 3 characters ");
                        txtcid.Text = "";
                    }
                    else
                        txtname.Focus();
                }
            }
        }


        private void btnclose_Click(object sender, EventArgs e)
        {

            DialogResult confirm = MessageBox.Show("Do you want to close", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}