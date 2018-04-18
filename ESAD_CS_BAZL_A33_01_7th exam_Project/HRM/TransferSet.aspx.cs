using HRM_BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRM_DAL;

namespace HRM
{
    public partial class TransferSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btncalender_Click(object sender, EventArgs e)
        {
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;
            }
            else
            {
                
                Calendar1.Visible = true;
            }
            //Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

            txttransferactivedate.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
        }

        protected void btntransferdate_Click(object sender, EventArgs e)
        {
            if (Calendar2.Visible)
            {
                Calendar2.Visible = false;
            }
            else
            {

                Calendar2.Visible = true;
            }
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            txtransferdate.Text = Calendar2.SelectedDate.ToShortDateString();
            Calendar2.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void btnsaveall_Click(object sender, EventArgs e)
        {
            transferhistory d = new transferhistory();
            //d.TransferID = int.Parse(txttransferid.Text);
            d.EmpID = int.Parse(DRPemp.SelectedValue);
            d.OldDepartment = txtolddept.Text;
            //d.NewDepartment = txtnewdept.Text;
            d.OldDivision = txtolddiv.Text;
            //d.NewDivision = txtnewdev.Text;
            d.OldSection = txtoldsec.Text;
            //d.NewSection = txtnewsec.Text;
            d.TransferActiveDate = DateTime.Parse( Calendar1.SelectedDate.ToString());
            d.TransferDate = DateTime.Parse(Calendar2.SelectedDate.ToString());
            d.Remark = txtremark.Text;
            d.StatusState = txtstatusstate.Text;
            GridView1.DataSourceID = SqlDataSource1.ID;


            if (new transferAccess().insert(d) > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Suceesfully saved')", true);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Suceesfully saved')", true);

            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            //er.deptid = int.Parse(txtolddept.Text);
            //er.secid = int.Parse(txtoldsec.Text);
            sp_display employee = new EmpAccess().GetempData(Int32.Parse(DRPemp.SelectedValue.ToString()));
            if(employee.Id>0)
            {
                txtolddept.Text = employee.Department.ToString();
                txtoldsec.Text = employee.section.ToString();
               //txtoldsec.Text = employee.secid.ToString();

            }
           

        }

        
    }
}