using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Diagnostics;

namespace HRM
{
    public partial class Attend : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection(@"data source=.;initial catalog=dbHrmEsad;integrated security=True;");
      
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
               
                btndelete.Enabled = false;
                DisplayRecord();
               
            }

        }

        private void DisplayRecord()
        {
            try
            {

          
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlad = new SqlDataAdapter("DisplayAlldat", sqlcon);
            sqlad.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtle = new DataTable();
            sqlad.Fill(dtle);
            sqlcon.Close();
            GridView1.DataSource = dtle;
            GridView1.DataBind();
                  }
            catch(Exception ec)
            {
                lblmess.Text = ec.Message;
            }
            //Clearr();
        }

        private void Clearr()
        {

            txttime.Value = txtouttime.Value = txtInTimeLanch.Value =
                txtouttimelan.Value = txtss.Text = txtattendence.Value = "";
            hiid.Value = "";
            //txtem.SelectedValue = "";
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try {

            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("insertdate", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@ID", (hiid.Value == "" ? 0 : Convert.ToInt32(hiid.Value)));
            sqlcmd.Parameters.AddWithValue("@EmpID", Convert.ToInt32(txtem.SelectedValue.Trim()));
            
            sqlcmd.Parameters.AddWithValue("@Intime", txttime.Value.Trim());
            sqlcmd.Parameters.AddWithValue("@OutTime", txtouttime.Value.Trim());

            sqlcmd.Parameters.AddWithValue("@InTime_Lanch", txtInTimeLanch.Value.Trim());
            sqlcmd.Parameters.AddWithValue("@OutTime_Lanch", txtouttimelan.Value.Trim());
             //- (DateTime.Parse(txtouttimelan.Value.Trim()) - DateTime.Parse(txtInTimeLanch.Value.Trim()))
            var total = ((DateTime.Parse(txtouttime.Value.Trim()) - DateTime.Parse(txttime.Value.Trim())) - (DateTime.Parse(txtouttimelan.Value.Trim()) - DateTime.Parse(txtInTimeLanch.Value.Trim()))).Hours.ToString();
            total += ":" + (DateTime.Parse(txtouttime.Value.Trim()) - DateTime.Parse(txttime.Value.Trim()) - (DateTime.Parse(txtouttimelan.Value.Trim()) - DateTime.Parse(txtInTimeLanch.Value.Trim()))).Minutes.ToString();
            total += ":" + ((DateTime.Parse(txtouttime.Value.Trim()) - DateTime.Parse(txttime.Value.Trim())) - (DateTime.Parse(txtouttimelan.Value.Trim()) - DateTime.Parse(txtInTimeLanch.Value.Trim()))).Seconds;
            //Debug.WriteLine(total);
            sqlcmd.Parameters.AddWithValue("@total",(total.ToString()));
            sqlcmd.Parameters.AddWithValue("@Attend_Date", txtattendence.Value.Trim());
            sqlcmd.Parameters.AddWithValue("@Statuss", txtss.Text.Trim());
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            Clearr();
            string contact = hiid.Value;
            if (contact == "")
                lblmess.Text = "Save successfully";
            else
                lblmess.Text = "Update successfully";
            btnsave.Text = "Save";
            DisplayRecord();
                
            }
            catch(Exception cs)
            {
                lblmess.Text = cs.Message;
            }
            

            //SqlCommand cmd;
            //SqlConnection con;
            //string constr = ConfigurationManager.ConnectionStrings["hrm"].ConnectionString;
            //con = new SqlConnection(constr);

//            for (int i = 0; i < GridView1.Rows.Count - 1; i++)
//            {
//                SqlCommand cmd = new SqlCommand(@"insert into attendence(InTime,outTime,InTime_Lanch,OutTime_Lanch,Attend_Date,Statuss)
//            values('" + GridView1.Rows[i].Cells[0] + "','" + GridView1.Rows[i].Cells[1] + "','" + GridView1.Rows[i].Cells[2] + "','" + GridView1.Rows[i].Cells[3] + "','" + GridView1.Rows[i].Cells[4] +
//                     "','" + GridView1.Rows[i].Cells[5] + "' )", sqlcon);
//                sqlcon.Open();
//                cmd.ExecuteNonQuery();
//                sqlcon.Close();
//            }

        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            Clearr();
        }

        protected void btnDelate_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand("Deletebyid", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@ID", Convert.ToInt32(hiid.Value));

                sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
                DisplayRecord();
                Clearr();


                btnsave.Text = "Save";
                lblmess.Text = "Delete Successfully";
            }
            catch(Exception ec)
            {
                lblmess.Text = ec.Message;
            }
            


        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {

           
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlad = new SqlDataAdapter("DisplaybyID", sqlcon);
            sqlad.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlad.SelectCommand.Parameters.AddWithValue("@ID", id);
            DataTable dtle = new DataTable();
            sqlad.Fill(dtle);
            sqlcon.Close();
            hiid.Value = id.ToString();
            //txtem.SelectedValue = dtle.Rows[0]["EmpID"].ToString();
            txttime.Value = dtle.Rows[0]["Intime"].ToString();
            txtouttime.Value = dtle.Rows[0]["OutTime"].ToString();
            txtInTimeLanch.Value = dtle.Rows[0]["InTime_Lanch"].ToString();

            txtouttimelan.Value = dtle.Rows[0]["OutTime_Lanch"].ToString();
            txtattendence.Value = dtle.Rows[0]["Attend_Date"].ToString();
            txtss.Text = dtle.Rows[0]["Statuss"].ToString();


            btnsave.Text = "Update";
            btndelete.Enabled = true;
            //btndelete.Enabled = true;
                 }
            catch (Exception ec)
            {
                lblmess.Text = ec.Message;
            }

        }

        protected void txtem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

       

    }
}