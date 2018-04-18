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
    public partial class AttendenceReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            showreport();
           // ReportViewer1.Visible = false;
        }

        private void showreport()
        {
            ReportViewer1.Reset();
            DataTable dt = GetData(Int32.Parse(TextBox1.Text));
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.ReportPath = "AttendenceReport.rdlc";
            ReportParameter[] param = new ReportParameter[]{
                new ReportParameter("id",TextBox1.Text),
                new ReportParameter("Attend_StartDate",txtsdate.Text),
                new ReportParameter("Attend_EndDate",txtedate.Text)
            };
            ReportViewer1.LocalReport.SetParameters(param);
            ReportViewer1.LocalReport.Refresh();
        }

        private DataTable GetData(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["hrm"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_displayAttendence", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = TextBox1.Text;
                cmd.Parameters.Add("@Attend_StartDate", SqlDbType.Date).Value = txtsdate.Text;
                cmd.Parameters.Add("@Attend_EndDate", SqlDbType.Date).Value = txtedate.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

            }
            return dt;
        }
    }
}