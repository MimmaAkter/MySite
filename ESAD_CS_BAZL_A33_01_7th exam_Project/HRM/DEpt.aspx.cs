using HRM_BLL;
using HRM_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRM
{
    public partial class DEpt : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try{
            Dept d = new Dept();
            d.Name = txtName.Text;

            if (new DeptAccess().Insert(d) > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Successfully Inserted')", true);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Failed to Insert')", true);
            }
            GridView1.DataSourceID = ObjectDataSource1.ID;
            Clear();
            }
            catch(Exception Ex){
                lblMsg.Text = Ex.Message;
            }
        }

        private void Clear()
        {
            txtName.Text = "";
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try{
            Dept dpt = new Dept();
            dpt.Name = txtName.Text;
            dpt.ID = Int32.Parse(hdnID.Value);
            DeptAccess manager = new DeptAccess();
            if (manager.Update(dpt) > 0)
            {
                GridView1.DataSourceID = ObjectDataSource1.ID;
                btnupdate.Visible = false;
                lblMsg.Text = "Successfully Updated";
            }
            else
            {
                lblMsg.Text = "Update Failed";
            }
            GridView1.DataSourceID = ObjectDataSource1.ID;
            Clear();
            }
            catch(Exception Ex){
                lblMsg.Text=Ex.Message;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try{
            if(e.CommandName=="e")
            {
                GetEditData(e.CommandArgument.ToString());

            }
            else if (e.CommandName == "d")
            {
                DeleteData(e.CommandArgument.ToString());
            }
            }
            catch(Exception Ex){
                 lblMsg.Text=Ex.Message;
            }
        }

        private void DeleteData(string p)
        {
            try
            {
                if (new DeptAccess().Delete(Int32.Parse(p)) > 0)
                {
                    lblMsg.Text = "Successfully Deleted";
                }
                else
                {
                    lblMsg.Text = "Delete failed";
                }
                GridView1.DataSourceID = ObjectDataSource1.ID;
                Clear();
            }
            catch (Exception Ex)
            {
                lblMsg.Text = Ex.Message;
            }
        }

        private void GetEditData(object p)
        {
            try
            {
                Dept lst = new DeptAccess().GetDept(Int32.Parse(p.ToString()));
                txtName.Text = lst.Name;
                hdnID.Value = lst.ID.ToString();
                btnsave.Visible = false;
                btnupdate.Visible = true;
            }
            catch (Exception Ex)
            {
                lblMsg.Text = Ex.Message;
            }
        }
    

    
    }
}
