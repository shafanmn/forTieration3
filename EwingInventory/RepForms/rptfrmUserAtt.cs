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

namespace EwingInventory.RepForms
{
    public partial class rptfrmUserAtt : Form
    {
        string cuid = "";
        public static Homepage home = new Homepage();
        MySqlConnection conn = new MySqlConnection(home.connString);

        public rptfrmUserAtt(string uid)
        {
            this.cuid = uid;
            InitializeComponent();
        }

        private void rptfrmUserAtt_Load(object sender, EventArgs e)
        {
            this.Text = "Staff Id " + cuid + " Attendance Report";

            string q = "SELECT * FROM attendance WHERE sId=@sid ORDER BY date DESC;";
            MySqlDataAdapter da = new MySqlDataAdapter(q, conn);
            da.SelectCommand.Parameters.Add("@sid", MySqlDbType.Int32).Value = Convert.ToInt32(cuid);
            DataTable dt = new DataTable();

            try
            {
                conn.Open();
                da.Fill(dt);

                Reports.crUserAtt cpt = new Reports.crUserAtt();
                cpt.Database.Tables["attendance"].SetDataSource(dt);

                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.ReportSource = cpt;


            }   catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
                    
        }
    }
}
