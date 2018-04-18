
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
    public partial class Emplyee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button3.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {

           
            Emp em = new Emp();
            em.name = TextBox1.Text;
            em.father_name = TextBox2.Text;
            em.mother_name = TextBox3.Text;
            em.dob = TextBox4.Text;
            em.Gender = TextBox5.Text;
            em.nationality = TextBox6.Text;
            em.maritual_status= TextBox7.Text;
            em.Religion= TextBox8.Text;
            em.mobile= TextBox9.Text;
            em.email= TextBox10.Text;
            em.home_phone= TextBox11.Text;
            em.present_address= TextBox12.Text;
            em.parmanent_address= TextBox13.Text;
            em.Gross_Salary =double.Parse((TextBox15.Text).ToString());
            
            em.deptid = int.Parse((DropDownList1.SelectedValue).ToString());
            em.degid = int.Parse((DropDownList2.SelectedValue).ToString());
            em.secid = int.Parse((DropDownList3.SelectedValue).ToString());
            em.Divid = int.Parse((DropDownList5.SelectedValue).ToString()) ;

            if (new EmpAccess().Insert(em) > 0)
            {
                Label1.Text = "Save successfully";
                //GridView1.DataSourceID = ObjectDataSource1.ID;
                clearControl();
            }
            else
            {
                Label1.Text = "Save failed";

            }
                 }
            catch (Exception ex)
            {
                Label2.Text = ex.Message;
            }
          
        }

        private void clearControl()
        {
            TextBox1.Text="";
             TextBox2.Text="";
            TextBox3.Text="";
             TextBox4.Text="";
            TextBox5.Text="";
             TextBox6.Text="";
             TextBox7.Text="";
            TextBox8.Text="";
            TextBox9.Text="";
            TextBox10.Text="";
            TextBox11.Text="";
            TextBox12.Text="";
             TextBox13.Text="";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            try
            {

           
            
            int id = Int32.Parse((DropDownList4.SelectedValue).ToString());

            Emp lst = new EmpAccess().Getemp(id);
            TextBox1.Text = lst.name;
            TextBox2.Text = lst.father_name;
            TextBox3.Text = lst.mother_name;
            TextBox4.Text = lst.dob;
            TextBox5.Text = lst.Gender;
            TextBox6.Text = lst.nationality;
            TextBox7.Text = lst.maritual_status;
            TextBox8.Text = lst.Religion;
            TextBox9.Text = lst.mobile;
            TextBox10.Text = lst.email;
            TextBox11.Text = lst.home_phone;
            TextBox12.Text = lst.present_address;
            TextBox13.Text = lst.parmanent_address;
            TextBox15.Text = lst.Gross_Salary.ToString();
            DropDownList1.SelectedValue = lst.deptid.ToString();
            DropDownList2.SelectedValue = lst.degid.ToString();
            DropDownList3.SelectedValue = lst.secid.ToString();
            DropDownList5.SelectedValue = lst.Divid.ToString();
            HiddenField1.Value = id.ToString();
            Button3.Visible = true;
            }
            catch (Exception ex)
            {
                Label2.Text = ex.Message;
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try { 
            int id = Int32.Parse(HiddenField1.Value);
            Emp emp = new Emp();
            emp.name = TextBox1.Text;
            emp.father_name = TextBox2.Text;
            emp.mother_name = TextBox3.Text;
            emp.dob = TextBox4.Text;
            emp.Gender = TextBox5.Text;
            emp.nationality = TextBox6.Text;
            emp.maritual_status = TextBox7.Text;
            emp.Religion = TextBox8.Text;
            emp.mobile = TextBox9.Text;
            emp.email = TextBox10.Text;
            emp.home_phone = TextBox11.Text;
            emp.present_address = TextBox12.Text;
            emp.parmanent_address = TextBox13.Text;
            emp.Gross_Salary = double.Parse(TextBox15.Text);

            emp.deptid = Int32.Parse(DropDownList1.SelectedValue);
            emp.degid = Int32.Parse(DropDownList2.SelectedValue);
            emp.secid = Int32.Parse(DropDownList3.SelectedValue);
            emp.Divid = Int32.Parse(DropDownList5.SelectedValue);
            if (new EmpAccess().Update(emp,id) > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Succesfully Saved')", true);
                //GridView1.DataSourceID = ObjectDataSource1.ID;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Saved Failed')", true);

            }
            }
            catch (Exception ex)
            {
                Label2.Text = ex.Message;
                Label2.Visible = false;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            try
            {

            
            
            int id =Int32.Parse((DropDownList5.SelectedValue).ToString());
        
           if(new EmpAccess().Delete(id)>0)
           {
               ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Succesfully Deleted')", true);
               //GridView1.DataSourceID = ObjectDataSource1.ID;

           }
            else
           {
               ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Delete Fail')", true);

           }
            }
            catch (Exception ex)
            {
                Label2.Text = ex.Message;
            }
        
        }


       
    }
}