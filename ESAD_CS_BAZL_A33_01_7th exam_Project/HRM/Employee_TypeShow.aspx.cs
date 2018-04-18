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
    public partial class Employee_TypeShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Employee_Type d = new Employee_Type();
            d.Employee_Types = TextBox1.Text;
            GridView1.DataSourceID = SqlDataSource2.ID;
    

            if (new EmployeeType_Access().insert(d)>0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Suceesfully saved')", true);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Suceesfully saved')", true);

            }
        }

       
    }
}