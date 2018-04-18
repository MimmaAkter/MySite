using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRM
{
    public partial class Grade : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data source=.; Initial catalog=dbHrmEsad; 
            Integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                btndelete.Enabled = false;
               
            }
            fillgridview();
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            delete();
        }
        public void delete()
        {
            hfgradeID.Value = "";
            txtgrade.Text = txtsalary.Text = "";
            lblsuccessmsg.Text = lblerrormsg.Text = "";
            btnsave.Text = "Save";
            btndelete.Enabled = false;
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("spcreateorupdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID",(hfgradeID.Value==""?0:Convert.ToInt32(hfgradeID.Value)));
            cmd.Parameters.AddWithValue("@GradeName", txtgrade.Text.Trim());
             cmd.Parameters.AddWithValue("@GradeSalary", txtsalary.Text.Trim());
            try { 

            if ( cmd.ExecuteNonQuery()>0)
            {
                con.Close();
                string ID = hfgradeID.Value;
                delete();
                fillgridview();
                lblsuccessmsg.Text = "Saved Successfully";
             }
            else
            {
                lblsuccessmsg.Text = "Save failed";
            }
             }
            catch (Exception ex)
            {
                lblerrormsg.Text = ex.Message;
               
            }             

        }
        void fillgridview()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlDataAdapter da = new SqlDataAdapter("spviewall", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvgrade.DataSource = dt;
            gvgrade.DataBind();
        }

        protected void linkview_Click(object sender, EventArgs e)
        {
            try
            {

                int ID = Convert.ToInt32((sender as LinkButton).CommandArgument);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlDataAdapter da = new SqlDataAdapter("spviewbyid", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@ID", ID);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                hfgradeID.Value = ID.ToString();
                txtgrade.Text = dt.Rows[0]["GradeName"].ToString();
                txtsalary.Text = dt.Rows[0]["GradeSalary"].ToString();
                btnsave.Text = "Update";
                btndelete.Enabled = true;
            }
            catch(Exception ex)
            {
                lblsuccessmsg.Text = ex.Message;
            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
          
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("spdeletebyid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID",Convert.ToInt32(hfgradeID.Value));

            try
            {
                if (cmd.ExecuteNonQuery() > 0)
                {
                    con.Close();
                    delete();
                    fillgridview();
                    lblsuccessmsg.Text = "Delete Successfully";
                }
                else
                {
                    lblsuccessmsg.Text = "Delete failed";
                }
            
            }
            catch(Exception ex)
            {
                lblerrormsg.Text = ex.Message;
            }
           
        }

       

        
    }
}