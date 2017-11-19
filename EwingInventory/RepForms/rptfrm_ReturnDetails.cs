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
    public partial class rptfrm_ReturnDetails : Form
    {

        public static Homepage home = new Homepage();
        MySqlConnection conn = new MySqlConnection(home.connString);

        int dno;

        public rptfrm_ReturnDetails(int d)
        {
            this.dno = d;
            InitializeComponent();
        }

        private void rptfrm_ReturnDetails_Load(object sender, EventArgs e)
        {
            string q1 = "SELECT rs.dno 'dno',rs.cid 'cid', rd.itemNo 'item', rd.wsp 'wsp', rd.qty 'qty', rd.total 'total',rs.remarks 'remarks', rt.description 'desp', rs.created 'date',cs.name 'cname', rs.total 'subtotal' "+
                "FROM returns rs, returnstock rt, returndetails rd, customer cs WHERE rs.dno = rd.dno AND rd.itemNo = rt.itemCode AND rs.dno ="+this.dno+" AND rs.cid = cs.cid;";

            MySqlDataAdapter da1 = new MySqlDataAdapter(q1, conn);

            DataTable dt1 = new DataTable();

            try
            {
                conn.Open();
                da1.Fill(dt1);

                Reports.crRetDetails cpt = new Reports.crRetDetails();
                cpt.Database.Tables["ret"].SetDataSource(dt1);

                crvRetDet.ReportSource = null;
                crvRetDet.ReportSource = cpt;


            }
            catch (Exception ex)
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
