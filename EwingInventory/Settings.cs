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
using System.ComponentModel.DataAnnotations;

namespace EwingInventory
{
    public partial class Settings : Form
    {
        static Homepage home = new Homepage();
        MySqlConnection conn = new MySqlConnection(home.connString);
        static string logoPath;
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            string w = Screen.FromControl(home).WorkingArea.Width.ToString();
            this.Location = new Point((Convert.ToInt32(w) - this.Width) / 2, 120);
            lbl_emailValid.Visible = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            LoadSystem();
              
            disableDesignations();
            LoadToDatagridview(dgv_Desig, "SELECT id 'CODE', name 'DESIGNATION' FROM designation WHERE id > 0;");
            dgv_Desig.Columns[0].Width = 25;
        }

        public void disableDesignations()
        {
            txt_desig.Enabled = false;
            udBsal.Enabled = false;
            udOt.Enabled = false;
            udLeave.Enabled = false;
            btn_save.Enabled = false;
        }

        public void enableDesignations()
        {
            txt_desig.Enabled = true;
            udBsal.Enabled = true;
            udOt.Enabled = true;
            udLeave.Enabled = true;
            btn_save.Enabled = true;
        }

        public void clearDesignations()
        {
            txt_desig.Text = "";
            udBsal.Value = 9500;
            udOt.Value = 250;
            udLeave.Value = 5;
        }
        
        public void LoadSystem()
        {
            string q = "SELECT * from settings;";

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(q, conn);
                var read = cmd.ExecuteReader();

                while (read.Read())
                {
                    string st = read.GetString("sTime");
                    string ot = read.GetString("oTime");
                    string ht = read.GetString("hTime");
                    logoPath = read.GetString("image");

                    set_name.Text = read.GetString("name");
                    set_addr.Text = read.GetString("address");
                    set_tele.Text = read.GetString("tele");
                    set_fax.Text = read.GetString("fax");
                    set_mail.Text = read.GetString("email");
                    time_st.Value = new DateTime(2017, 08, 26, Convert.ToInt32(st.Substring(0, 2)), Convert.ToInt32(st.Substring(2, 2)), 0);
                    time_off.Value = new DateTime(2017, 08, 26, Convert.ToInt32(ot.Substring(0, 2)), Convert.ToInt32(ot.Substring(2, 2)), 0);
                    time_half.Value = new DateTime(2017, 08, 26, Convert.ToInt32(ht.Substring(0, 2)), Convert.ToInt32(ht.Substring(2, 2)), 0);
                    set_logo.ImageLocation = logoPath;
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

        private void LoadToDatagridview(DataGridView dgv, string q)
        {
            DataTable dt = new DataTable();                        
            MySqlCommand cmd = new MySqlCommand(q, conn);

            try
            {
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);
                BindingSource bs = new BindingSource();

                bs.DataSource = dt;
                dgv.DataSource = bs;
                da.Update(dt);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
            finally
            {
                conn.Close();
            }

        }



        private void Settings_MouseClick(object sender, MouseEventArgs e)
        {
            this.Focus();
        }
        private void Settings_Click(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void btn_saveTimes_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txt_desig.Enabled == true)
            {
                var opt = MessageBox.Show("Are you sure you want to close?\nAny modifications you have made will not be saved", "Confirm Clsoe", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (opt == DialogResult.OK)
                    this.Close();
            }
            else
            {
                this.Close();
            }
        }
        
        private void dgv_Desig_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dgv_Desig.SelectedCells[0].Value.ToString();
            btn_save.Text = "Edit";
            btn_save.Enabled = true;

            try
            {
                conn.Open();
                MySqlDataReader dr = null;
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM designation WHERE id ="+ id +";", conn);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    txt_desig.Text = dr["name"].ToString();
                    udBsal.Value = Convert.ToDecimal(dr["bSal"]);
                    udOt.Value = Convert.ToDecimal(dr["otRate"]);
                    udLeave.Value = Convert.ToDecimal(dr["leaves"]);
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

            home.LoadToDatagridview(dataGridView1, "SELECT s.sId 'ID',CONCAT(s.fName,' ', s.lname) AS 'Name' FROM staff s, designation d WHERE s.desig = d.id AND d.id =" + id + ";");
            dataGridView1.Columns[0].Width = 25;
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            if (btn_new.Text == "New")
            {
                enableDesignations();
                clearDesignations();
                btn_new.Text = "Clear";
                btn_save.Enabled = false;
                btn_save.Text = "Add";
                dgv_Desig.Enabled = false;
                txt_desig.Focus();
            }
            else if (btn_new.Text == "Clear")
            {
                clearDesignations();
                btn_save.Enabled = false;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            var opt = DialogResult.Cancel;
            if (btn_save.Text == "Edit")
            {
                enableDesignations();
                dgv_Desig.Enabled = false;
                btn_new.Enabled = false;
                btn_save.Text = "Save";
            }
            else
            {

                opt = MessageBox.Show("Save Modifications?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (opt == DialogResult.OK)
                {
                    //Update Database
                    string id = dgv_Desig.SelectedCells[0].Value.ToString();

                    string q = null;
                    string op = null;
                    if (btn_new.Text == "New")
                    {
                        q = "UPDATE designation SET name=@name, bSal=@bSal, otRate=@otRate, leaves=@leaves WHERE id=" + id + ";";
                        op = "Modified ";
                    }
                    else
                    {
                        q = "INSERT INTO designation(name,bSal,otRate,leaves)" +
                            "VALUES(@name,@bSal,@otRate,@leaves)";
                        op = "Added ";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = txt_desig.Text;
                        cmd.Parameters.Add("@bSal", MySqlDbType.Double).Value = Convert.ToDouble(udBsal.Value);
                        cmd.Parameters.Add("@otRate", MySqlDbType.Double).Value = Convert.ToDouble(udOt.Value);
                        cmd.Parameters.Add("@leaves", MySqlDbType.Double).Value = Convert.ToDouble(udLeave.Value);

                        try
                        {
                            conn.Open();
                            int res = cmd.ExecuteNonQuery();
                            MessageBox.Show("Record " + op + "succesfully");

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

                    //Refersh Table
                    disableDesignations();
                    btn_new.Text = "New";
                    LoadToDatagridview(dgv_Desig, "SELECT id 'CODE', name 'DESIGNATION' FROM designation WHERE id > 0");
                    btn_new.Enabled = true;
                    dgv_Desig.Enabled = true;
                }
            }
        }

        private void txt_desig_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_desig.Text != "")
                btn_save.Enabled = true;
            else
                btn_save.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var op = DialogResult.Cancel;

            if (lbl_emailValid.Visible)
                MessageBox.Show("Please enter a valid email address");
            else
                op = MessageBox.Show("Do you want to save modifications?", "Warning", MessageBoxButtons.OKCancel);
                        
            if(op == DialogResult.OK)
            {
                string q = "UPDATE settings SET name=@name, address=@address, tele=@tele, fax=@fax, email=@email, sTime=@sTime, oTime=@oTime, hTime=@hTime, image=@image ;";


                using (MySqlCommand cmd = new MySqlCommand(q, conn))
                {
                    cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = set_name.Text;
                    cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = set_addr.Text;
                    cmd.Parameters.Add("@tele", MySqlDbType.VarChar).Value = set_tele.Text;
                    cmd.Parameters.Add("@fax", MySqlDbType.VarChar).Value = set_fax.Text;
                    cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = set_mail.Text;
                    cmd.Parameters.Add("@sTime", MySqlDbType.VarChar).Value = time_st.Value.ToString("HHmm");
                    cmd.Parameters.Add("@oTime", MySqlDbType.VarChar).Value = time_off.Value.ToString("HHmm");
                    cmd.Parameters.Add("@hTime", MySqlDbType.VarChar).Value = time_half.Value.ToString("HHmm");
                    cmd.Parameters.Add("@image", MySqlDbType.VarChar).Value = logoPath;

                    try
                    {
                        conn.Open();
                        int res = cmd.ExecuteNonQuery();
                        if (res == 1)
                            MessageBox.Show("Records Updated Successfully!");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {                        
                        conn.Close();
                    }
                    //Refresh Details
                    LoadSystem();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                set_logo.Image = new Bitmap(ofd.FileName);
                logoPath = ofd.FileName;
            }
        }

        private void set_tele_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(set_tele.Text, "[^0-9]"))
            {
                MessageBox.Show("Please input numbers only!");
                set_tele.Text = set_tele.Text.Remove(set_tele.Text.Length - 1);
                set_tele.SelectionStart = set_tele.Text.Length;
            }
        }

        private void set_fax_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(set_fax.Text, "[^0-9]"))
            {
                MessageBox.Show("Please input numbers only!");
                set_fax.Text = set_fax.Text.Remove(set_fax.Text.Length - 1);
            }
        }

        private void set_tele_MouseClick(object sender, MouseEventArgs e)
        {
            set_tele.SelectionStart = set_tele.Text.Length;
        }

        private void set_fax_MouseClick(object sender, MouseEventArgs e)
        {
            set_fax.SelectionStart = set_fax.Text.Length;
        }

        private void set_mail_MouseClick(object sender, MouseEventArgs e)
        {
            set_mail.SelectionStart = set_mail.Text.Length;
        }

        private void set_mail_TextChanged(object sender, EventArgs e)
        {
            if (!home.isValidEmail(set_mail.Text))
                lbl_emailValid.Visible = true;
            else
                lbl_emailValid.Visible = false;
        }
    }
}
