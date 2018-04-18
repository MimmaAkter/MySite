
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRM_BLL;
using HRM_DAL;

namespace HRM
{
    public partial class Section : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            sec d = new sec();
            d.Name = TextBox1.Text;
            if (new sceAccess().Insert(d) > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Succesfully Saved')", true);
                this.GridView1.DataSourceID = SqlDataSource1.ID;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Saved Fail')", true);

            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                GetEditData(e.CommandArgument);
            }
            else if (e.CommandName == "Delete")
            {
                DeleteData(e.CommandArgument.ToString());
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void GetEditData(object p)

        {
           
            sec lst = new sceAccess().Getsec(Int32.Parse(p.ToString()));
            TextBox1.Text = lst.Name;
        }
        private void DeleteData(string p)
        {
            if (new sceAccess().Delete(Int32.Parse(p)) > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Succesfully Deleted')", true);
                this.GridView1.DataSourceID = SqlDataSource1.ID;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Delete fail')", true);

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(HiddenField1.Value);
            sec se = new sec();
            se.Name = TextBox1.Text;
            sceAccess manager = new sceAccess();
            if (manager.Update(se,id) > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Succesfully updated')", true);
                this.GridView1.DataSourceID = SqlDataSource1.ID;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Succesfully updated')", true);

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            sec lst = new sceAccess().Getsec(id);
            TextBox1.Text = lst.Name;
            HiddenField1.Value = id.ToString();
            Button1.Visible = false;
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
             int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
             if (new sceAccess().Delete(id) > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Succesfully Deleted')", true);
                this.GridView1.DataSourceID = SqlDataSource1.ID;
              
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Delete fail')", true);

            }
            
           
        }
    }
}