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
    public partial class Company1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (string.IsNullOrWhiteSpace(txtName.Text) && string.IsNullOrWhiteSpace(txtLocation.Text))
            //{
            //    btnupdate.Enabled = false;
            //}
            //else
            //{

            //    btnupdate.Enabled = true;
            //}
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                Company d = new Company();
                d.Name = txtName.Text;
                d.Location = txtLocation.Text;

                if (new CompanyAccess().Insert(d) > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Successfully Inserted')", true);
                    btnupdate.Visible = true;
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
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try 
            {
                Company dpt = new Company();
                dpt.Name = txtName.Text;
                dpt.Location = txtLocation.Text;
                dpt.ID = Int32.Parse(hdnID.Value);
                CompanyAccess manager = new CompanyAccess();

                if (manager.Update(dpt) > 0)
                {
                    GridView1.DataSourceID = ObjectDataSource1.ID;
                    btnupdate.Visible = false;
                    btnsave.Visible = true;
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
                if (new CompanyAccess().Delete(Int32.Parse(p)) > 0)
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
                Company lst = new CompanyAccess().GetCompany(Int32.Parse(p.ToString()));
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

        protected void txtLocation_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}