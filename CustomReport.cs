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
			
ID	NAME	DAYS	OT