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
    public partial class DesigPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Designation desig = new Designation();
                desig.DesName = txtName.Text;
                if (new DesigAccess().Save(desig) > 0)
                {
                    GridView1.DataSourceID = ObjectDataSource1.ID;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Successfully saved')", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Save failed')", true);
                }
                ClearControl();
            }
            catch(Exception Ex)
            {
                lbMsg.Text = Ex.Message;
            }
            
   
        }

        private void ClearControl()
        {
            txtName.Text = "";
            hdnId.Value = "";
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edt")
                {
                    EditData(e.CommandArgument);
                }
                else if (e.CommandName == "Del")
                {
                    DeleteData(e.CommandArgument.ToString());
                }
            }
            catch (Exception Ex)
            {
                lbMsg.Text = Ex.Message;
            }
            
        }

        private void DeleteData(string p)
        {
            try{
                if (new DesigAccess().DeleteData(Int32.Parse(p)) > 0)
                {
                    GridView1.DataSourceID = ObjectDataSource1.ID;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Successfully Deleted')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Delete failed')", true);
                }
            }
            
            catch(Exception Ex)
            {
                lbMsg.Text = Ex.Message;
            }
        }

        private void EditData(object p)
        {
            try
            {
                Designation lst = new DesigAccess().EditingData(Int32.Parse(p.ToString()));
                txtName.Text = lst.DesName;
                hdnId.Value = lst.DesId.ToString();
                btnSave.Visible = false;
                btnUpdate.Visible = true;
            }

            catch (Exception Ex)
            {
                lbMsg.Text = Ex.Message;
            }
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Designation desig = new Designation();
                desig.DesName = txtName.Text;
                desig.DesId = Int32.Parse(hdnId.Value);
                DesigAccess desAcc = new DesigAccess();
                if (desAcc.Update(desig) > 0)
                {
                    GridView1.DataSourceID = ObjectDataSource1.ID;
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                    lbMsg.Text = "Success";
                }
                else
                {
                    lbMsg.Text = "Failed";
                }
                ClearControl();
            }

            catch (Exception Ex)
            {
                lbMsg.Text = Ex.Message;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearControl();
            lbMsg.Text = "";
        }

       
    }
}