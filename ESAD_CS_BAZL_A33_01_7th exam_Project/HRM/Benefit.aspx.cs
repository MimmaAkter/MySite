using HRM_DAL;
using HRM_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace HRM
{
    public partial class Benefit_WebForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["hrm"].ConnectionString);
        //SqlCommand cmd;
     
        protected void Page_Load(object sender, EventArgs e)
        {
            //Loadgrid();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            Benefit b = new Benefit();
            b.Benefit_Type = TextBox1.Text;
            if (new BenefitAccess().Insert(b) > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Successful')", true);
               // new BenefitAccess().Display();
                GridView1.DataSourceID = SqlDataSource1.ID;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Failed')", true);
            }

            
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlDataAdapter da = new SqlDataAdapter("sp_searchBenefit", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Benefit_ID", id);
            HiddenField1.Value = id.ToString();
            DataTable dt = new DataTable();
            da.Fill(dt);
            TextBox1.Text = dt.Rows[0]["Benefit_Type"].ToString();
            btnsave.Enabled = false;
            //Benefit b = new Benefit();
            //b.Benefit_Type = 
               // TextBox1.Text = dt.Rows[0]["Benefit_Type"].ToString();
            //if (new BenefitAccess().Search(b)>0)
            //{
            //    b.Benefit_Type = TextBox1.Text;
            //    new BenefitAccess().Display();
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Failed')", true);
            //}
            
            con.Close();
           
            
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlCommand cmd = new SqlCommand("sp_deleteBenefit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Benefit_ID", id);
            Benefit b = new Benefit();
            b.Benefit_ID = id;
            b.Benefit_Type = TextBox1.Text;
            if (new BenefitAccess().Delete(b) == b.Benefit_ID)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Successful')", true);
                GridView1.DataSourceID = SqlDataSource1.ID;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Failed')", true);
            }
            cmd.ExecuteNonQuery();
            con.Close();
           
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(HiddenField1.Value);
            //if (con.State == ConnectionState.Closed)
            //    con.Open();
            //SqlCommand cmd = new SqlCommand("sp_updateBenefit", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Benefit_ID", id);
            //cmd.Parameters.AddWithValue("@Benefit_Type", TextBox1.Text);
            Benefit b = new Benefit();
            b.Benefit_ID = id;
            b.Benefit_Type = TextBox1.Text;
            if (new BenefitAccess().Update(b)>=0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Successful')", true);
              //  new BenefitAccess().Display();
                GridView1.DataSourceID = SqlDataSource1.ID;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Failed')", true);
            }
            //cmd.ExecuteNonQuery();
            //con.Close();
        }

        //protected void btnsearch_Click(object sender, EventArgs e)
        //{
        //    Benefit b = new Benefit();
        //    int id = b.Benefit_ID;
        //    id = int.Parse(TextBox2.Text.ToString());
        //    if (new BenefitAccess().Search(b) == id)
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Successful')", true);
        //        new BenefitAccess().Display();
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Failed')", true);
        //    }
        //}

        //protected void btndelete_Click(object sender, EventArgs e)
        //{
        //    Benefit b = new Benefit();
        //    int id = b.Benefit_ID;
        //    id = int.Parse(TextBox2.Text.ToString());
        //    if (new BenefitAccess().Delete(b) == id)
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Successful')", true);
        //        new BenefitAccess().Display();
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Failed')", true);
        //    }
        //}
        //public void Loadgrid()
        //{
        //    if (con.State == ConnectionState.Closed)
        //        con.Open();
        //    SqlDataAdapter da = new SqlDataAdapter("sp_displayBenefit", con);
        //    da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();
        //    GridView1.DataSource = dt;
        //    GridView1.DataBind();
            
        //}

        
    }
}