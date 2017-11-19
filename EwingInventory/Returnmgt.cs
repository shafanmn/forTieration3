using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EwingInventory
{
    public partial class returnmgt : Form
    {
        static Homepage home = new Homepage();
        MySqlConnection conn = new MySqlConnection(home.connString);
        double st = 0.00;
        int soldqty = 0;
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
            btn_cal.Enabled = false;

            home.fillCombo(cmbRetDocNo,"SELECT dno FROM returns ORDER BY dno DESC","dno");

            MySqlCommand cmd = new MySqlCommand("SELECT dno FROM returns order by dno desc limit 1;", this.conn);
            try
            {
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    lbl_docnum.Text = "00"+(Convert.ToInt32(dr["dno"].ToString()) + 1).ToString();
                }
                else
                {
                    lbl_docnum.Text = "001";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            //Load Discount Table
            home.LoadToDatagridview(dataGridView2, "SELECT itemCode 'Code',description 'Description',qty 'Qty' FROM returnstock;");
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
            if (e.KeyCode == Keys.Enter)
            {
                string cid = txtcid.Text;

                string q = "SELECT name FROM customer WHERE cid = '" + cid + "';";

                MySqlCommand cmd = new MySqlCommand(q, this.conn);

                try
                {
                    conn.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read() != true)
                    {
                        MessageBox.Show("Invalid Customer Id!");
                        txtcid.Text = "";
                        txtname.Text = "";
                    }
                    else
                    {
                        txtname.Text = dr["name"].ToString();
                        txtname.Focus();
                        txt_itemcode.Enabled = true;
                        txt_quantity.Enabled = true;
                        dateTimePicker1.Enabled = true;
                        txt_remark.Enabled = true;
                        btn_clear.Enabled = true;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
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

        private void txt_itemcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string icode = txt_itemcode.Text;
                string cid = txtcid.Text;
                bool st = false;

                //Check if the product is sold to the customer
                MySqlCommand chkcmd = new MySqlCommand("SELECT o.ItemNo,SUM(o.qty) FROM invoice i, orderdetails o WHERE i.invoiceNo = o.invoiceNo AND i.cid = "+cid+" AND o.ItemNo = "+icode+" GROUP BY o.ItemNo;", conn);
                try
                {
                    conn.Open();
                    MySqlDataReader dr = chkcmd.ExecuteReader();

                    if (dr.Read() == true)
                    {
                        st = true;
                        soldqty = Convert.ToInt32(dr[1].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                //If the porduct has been sold
                if (st == true)
                {

                    //Get Product details
                    string q = "SELECT * FROM item WHERE itemCode = '" + icode + "';";
                    MySqlCommand cmd = new MySqlCommand(q, this.conn);

                    try
                    {
                        conn.Open();
                        MySqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read() != true)
                        {
                            MessageBox.Show("Invalid ItemCode!");
                            txt_itemcode.SelectAll();
                        }
                        else
                        {
                            txt_itemname.Text = dr["Discription"].ToString();
                            txt_price.Text = dr["sellingPrice"].ToString();
                            txt_quantity.Focus();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("The Item " + icode + " has not been sold to this customer!");
                    txt_itemcode.SelectAll();
                }
            }
        }

        private void txt_quantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double p = Convert.ToDouble(txt_price.Text);
                int i = Convert.ToInt32(txt_quantity.Text);

                if (i > soldqty)
                {
                    MessageBox.Show("Returned qty cannot be greater than sold qty!");
                    txt_quantity.SelectAll();
                }
                else
                {

                    dataGridView1.Rows.Add(txt_itemcode.Text, txt_itemname.Text, txt_price.Text, txt_quantity.Text, (p * i));
                    st += p * i;
                    lbl_subtotal.Text = st.ToString();

                    txt_quantity.Text = "";
                    txt_price.Text = "";
                    txt_itemname.Text = "";
                    txt_itemcode.Text = "";
                    txt_itemcode.Focus();
                    btn_apply.Enabled = true;
                }
            }
        }

        private void txtname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker1.Focus();
            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_remark.Focus();
            }
        }

        private void txt_remark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_itemcode.Focus();
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            int st = 1;
            DialogResult confirm = MessageBox.Show("Do you want to apply?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                string dno = lbl_docnum.Text;
                string date = dateTimePicker1.Value.ToShortDateString();
                string cid = txtcid.Text;
                string tot = lbl_subtotal.Text;

                //data to returns, payment(to be discussed)
                string q = "INSERT INTO returns(dno,cid,created,remarks,total) VALUES(@dno,@cid,@created,@remarks,@total)";
                MySqlCommand cmd = new MySqlCommand(q, conn);
                cmd.Parameters.Add("@dno", MySqlDbType.VarChar).Value = dno;
                cmd.Parameters.Add("@cid", MySqlDbType.VarChar).Value = cid;
                cmd.Parameters.Add("@created", MySqlDbType.VarChar).Value = date;
                cmd.Parameters.Add("@remarks", MySqlDbType.VarChar).Value = txt_remark.Text;
                cmd.Parameters.Add("@total", MySqlDbType.Double).Value = Convert.ToDouble(tot);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }


                //data to returndetails, returnstock, mainstock
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    string q2 = "INSERT INTO returndetails(dno,itemNo,qty,wsp,total) VALUES("+dno+","+ Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value) + ","+ Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value) + ","+ Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value) + ","+ Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) + ");";
                    string q3 = "INSERT INTO returnstock(itemCode,description,wsp,qty) VALUES("+ dataGridView1.Rows[i].Cells[0].Value.ToString() + ",'" + dataGridView1.Rows[i].Cells[1].Value.ToString() +"',"+ Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value) + ","+ Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value) + ");";
                    string q4 = "UPDATE stock SET quantity = (quantity + "+ Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value) + ") WHERE itemCodes = "+ Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value) + ";";
                    MySqlCommand cmd2 = new MySqlCommand(q2, conn);
                    MySqlCommand cmd3 = new MySqlCommand(q3, conn);
                    MySqlCommand cmd4 = new MySqlCommand(q4, conn);

                    try
                    {
                        conn.Open();
                        cmd2.ExecuteNonQuery();
                        cmd3.ExecuteNonQuery();
                        cmd4.ExecuteNonQuery();

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }

                MessageBox.Show("Return Details added successfully!");

                //clear fields & disable
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                txtcid.Clear();
                txtname.Clear();
                txt_remark.Clear();
                txt_itemcode.Clear();
                txt_quantity.Clear();

                txtcid.Enabled = false;
                txtname.Enabled = false;
                txt_remark.Enabled = false;
                txt_itemcode.Enabled = false;
                txt_quantity.Enabled = false;

                //Display report
                RepForms.rptfrm_ReturnDetails rpfrm = new RepForms.rptfrm_ReturnDetails(Convert.ToInt32(dno));
                rpfrm.Show();
       

            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string code = dataGridView2.SelectedCells[0].Value.ToString();

            string q = "SELECT * FROM returnstock WHERE itemCode =@code;";
            MySqlCommand cmd = new MySqlCommand(q, conn);
            cmd.Parameters.Add("@code", MySqlDbType.VarChar).Value = code;

            try
            {
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txt_desc.Text = dr[1].ToString();
                    txt_rtnqnt.Text = dr[5].ToString();
                    txt_wsamount.Text = dr[3].ToString();
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            txtcid.Clear();
            txtname.Clear();
            txt_remark.Clear();
            txt_itemcode.Clear();
            txt_quantity.Clear();

            btn_clear.Enabled = false;
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int dno = Convert.ToInt32(cmbRetDocNo.SelectedItem.ToString());
            //MessageBox.Show(dno.ToString());

            RepForms.rptfrm_ReturnDetails rt = new RepForms.rptfrm_ReturnDetails(dno);
            rt.Show();
        }

        private void discPer_ValueChanged(object sender, EventArgs e)
        {
            double dv = Convert.ToDouble(discPer.Value);
            if (dv == 0.0)
                btn_cal.Enabled = false;
            else
                btn_cal.Enabled = true;
        }

        private void btn_cal_Click(object sender, EventArgs e)
        {
            double dis = Convert.ToDouble(discPer.Value);
            double price = Convert.ToDouble(txt_wsamount.Text);

            double sp =(price - ((dis/100)*price));

            txt_spclprice.Text = sp.ToString();

        }
    }
}