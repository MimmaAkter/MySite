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
    public partial class Division1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                Division d = new Division();
                d.Name = txtName.Text;
                d.Location = txtLocation.Text;
                d.CID = int.Parse(DropDownList1.SelectedValue);
                if (new DivisionAccess().Insert(d) > 0)
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
            catch (Exception ex)
            {
                Response.Write(@"<script language='javascript'>alert('The following errors have occurred: \n" + ex + " .');</script>");
            }
        }

        private void Clear()
        {
            txtName.Text = "";
            txtLocation.Text = "";
            DropDownList1.SelectedIndex = -1;
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                Division dpt = new Division();
                dpt.Name = txtName.Text;
                dpt.Location = txtLocation.Text;
                dpt.ID = Int32.Parse(hdnID.Value);
                dpt.CID = Int32.Parse(DropDownList1.SelectedValue.ToString());
                DivisionAccess manager = new DivisionAccess();
                if (manager.Update(dpt) > 0)
                {
                    GridView1.DataSourceID = ObjectDataSource1.ID;
                    btnupdate.Visible = false;
                    lblMsg.Text = "success";
                }
                else
                {
                    lblMsg.Text = "Failed";
                }
                GridView1.DataSourceID = ObjectDataSource1.ID;
                Clear();
            }
            catch (Exception ex)
            {
                Response.Write(@"<script language='javascript'>alert('The following errors have occurred: \n" + ex + " .');</script>");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "e")
            {
                GetEditData(e.CommandArgument.ToString());

            }
            else if (e.CommandName == "d")
            {
                DeleteData(e.CommandArgument.ToString());
            }
        }

        private void DeleteData(string p)
        {
            try
            {
                if (new DivisionAccess().Delete(Int32.Parse(p)) > 0)
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
            catch (Exception ex)
            {
                Response.Write(@"<script language='javascript'>alert('The following errors have occurred: \n" + ex + " .');</script>");
            }
        }

        private void GetEditData(object p)
        {
            try
            {
                Division lst = new DivisionAccess().GetDivision(Int32.Parse(p.ToString()));
                txtName.Text = lst.Name;
                txtLocation.Text = lst.Location;
                hdnID.Value = lst.ID.ToString();
                btnsave.Visible = false;
                btnupdate.Visible = true;
            }
            catch (Exception ex)
            {
                Response.Write(@"<script language='javascript'>alert('The following errors have occurred: \n" + ex + " .');</script>");
            }
        }

        protected void txtLocation_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) && string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                btnsave.Enabled = false;
                btnupdate.Enabled = false;
            }
            else
            {

                btnsave.Enabled = true;
                btnupdate.Enabled = true;
            }
           
        }
    }
}