using Microsoft.Reporting.WebForms;
//using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRM
{
    public partial class SalaryReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            showreport();
      
        }
        private void showreport()
        {
            ReportViewer2.Reset();
            DataTable dt = GetData(Int32.Parse(txtid.Text));
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            ReportViewer2.LocalReport.DataSources.Add(rds);
            ReportViewer2.LocalReport.ReportPath = "Report1.rdlc";
            ReportParameter[] param = new ReportParameter[]
            {
                new ReportParameter("id", txtid.Text),
                new ReportParameter("Dates",txtdt.Text)
            };
            ReportViewer2.LocalReport.SetParameters(param);
            ReportViewer2.LocalReport.Refresh();
        }

        private DataTable GetData(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["hrm"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_Display_Records", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("id", SqlDbType.Int).Value = txtid.Text;
                cmd.Parameters.Add("Dates", SqlDbType.Date).Value = txtdt.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}