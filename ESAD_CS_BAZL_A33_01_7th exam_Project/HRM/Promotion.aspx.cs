using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRM_BLL;
using HRM_DAL;


namespace HRM
{
    public partial class Promotion : System.Web.UI.Page
    {
        
        SqlConnection con;
        
        string constr = ConfigurationManager.ConnectionStrings["hrm"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar1.Visible = false;
                Calendar2.Visible = false;

                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(constr);
            SqlDataAdapter da = new SqlDataAdapter("select s.Basics, s.HouseRent,s.Medical,s.Convences,s.Taxes,s.Gross_Salary from SalaryHistory s where EmpID="+TextBox1.Text+";", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Label1.Text = dt.Rows[0]["Basics"].ToString();
            Label2.Text = dt.Rows[0]["HouseRent"].ToString();
            Label3.Text = dt.Rows[0]["Medical"].ToString();
            Label4.Text = dt.Rows[0]["Convences"].ToString();
            Label5.Text = dt.Rows[0]["Taxes"].ToString();
            Label6.Text = dt.Rows[0]["Gross_Salary"].ToString();

            double previous = double.Parse(dt.Rows[0]["Gross_Salary"].ToString());
            HiddenField2.Value = previous.ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            double pp = double.Parse((HiddenField2.Value).ToString());
            double gross =double.Parse((TextBox2.Text).ToString());
            double gs = gross + pp;
            double basic = gs * .60;
            double hr = (gs * .60)*.60;
            double medical = (gs * .60) * .10;
            double con = (gs * .60) * .10;
            double tax = (gs * .60) * .10;
           

            TextBox3.Text = basic.ToString();
            TextBox4.Text = hr.ToString();
            TextBox5.Text = medical.ToString();
            TextBox6.Text = con.ToString();
            TextBox7.Text = tax.ToString();
            TextBox8.Text = gs.ToString();

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
        
            Promotions p = new Promotions();

            p.empid =Int32.Parse((TextBox1.Text).ToString());
            p.pro_type = DropDownList1.SelectedValue;
            p.amount = double.Parse((TextBox2.Text).ToString());
            p.activedate = DateTime.Parse((TextBox9.Text).ToString());
            p.pro_active = DateTime.Parse((TextBox10.Text).ToString()); ;
            p.Basic = double.Parse((TextBox3.Text).ToString());
            p.HouseRent = double.Parse((TextBox4.Text).ToString());
            p.Medicalmoney = double.Parse((TextBox5.Text).ToString());
            p.Convences = double.Parse((TextBox6.Text).ToString());
            p.taxes = double.Parse((TextBox7.Text).ToString());
            p.Gross_Salary = double.Parse((TextBox8.Text).ToString());
            if (new PromotionAccess().insert(p) > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Successfully Inserted')", true);
                GridView1.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Failed to Insert')", true);
            }
            
           

           
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(HiddenField1.Value);
            Promotions dpt = new Promotions();
            dpt.empid =Int32.Parse(TextBox1.Text);
            dpt.pro_type = DropDownList1.SelectedValue;
            dpt.amount = double.Parse(TextBox2.Text);

            dpt.activedate = DateTime.Parse(TextBox9.Text); 
            dpt.pro_active = DateTime.Parse(TextBox10.Text);
            dpt.id = id;

            dpt.Basic = double.Parse(TextBox3.Text);
            dpt.HouseRent = double.Parse(TextBox4.Text);
            dpt.Medicalmoney = double.Parse(TextBox5.Text);
            dpt.Convences = double.Parse(TextBox6.Text);
            dpt.taxes = double.Parse(TextBox7.Text);
            dpt.Gross_Salary = double.Parse(TextBox8.Text);
            PromotionAccess manager = new PromotionAccess();
            if (manager.Update(dpt) > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Successfully Updated')", true);
                GridView1.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Update Fail')", true);

            }
            //int id = Int32.Parse(TextBox1.Text.ToString());
            //Promotions lst = new PromotionAccess().Getpro(id);

           
            //TextBox2.Text=lst.amount.ToString();
            //TextBox3.Text=lst.Basic.ToString();
            //TextBox4.Text=lst.HouseRent.ToString();
            //TextBox5.Text=lst.Medicalmoney.ToString();
            //TextBox6.Text=lst.Convences.ToString();
            //TextBox7.Text=lst.taxes.ToString();
            //TextBox8.Text=lst.Gross_Salary.ToString();
            //TextBox9.Text=lst.activedate.ToString();
            //TextBox10.Text = lst.pro_active.ToString();
            //DropDownList1.SelectedValue = lst.pro_type.ToString();
            

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox9.Text = Calendar1.SelectedDate.ToString();
            Calendar1.Visible = false;
        }

        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
           
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Calendar2.Visible = true;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            TextBox10.Text = Calendar1.SelectedDate.ToString();
            Calendar2.Visible = false;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse((sender as LinkButton).CommandArgument);
            Promotions lst = new PromotionAccess().Getpro(id);
            con = new SqlConnection(constr);
            SqlDataAdapter da = new SqlDataAdapter("select s.Basics,s.EmpID, s.HouseRent,s.Medical,s.Convences,s.Taxes,s.Gross_Salary from SalaryHistory s where EmpID=" + id + ";", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Label1.Text = dt.Rows[0]["Basics"].ToString();
            Label2.Text = dt.Rows[0]["HouseRent"].ToString();
            Label3.Text = dt.Rows[0]["Medical"].ToString();
            Label4.Text = dt.Rows[0]["Convences"].ToString();
            Label5.Text = dt.Rows[0]["Taxes"].ToString();
            Label6.Text = dt.Rows[0]["Gross_Salary"].ToString();
            TextBox1.Text = dt.Rows[0]["EmpID"].ToString();

            double previous = double.Parse(dt.Rows[0]["Gross_Salary"].ToString());
            HiddenField2.Value = previous.ToString();
            TextBox1.Text = lst.empid.ToString();
            TextBox2.Text = lst.amount.ToString();
            TextBox3.Text = lst.Basic.ToString();
            TextBox4.Text = lst.HouseRent.ToString();
            TextBox5.Text = lst.Medicalmoney.ToString();
            TextBox6.Text = lst.Convences.ToString();
            TextBox7.Text = lst.taxes.ToString();
            TextBox8.Text = lst.Gross_Salary.ToString();
            TextBox9.Text = lst.activedate.ToString();
            TextBox10.Text = lst.pro_active.ToString();
            DropDownList1.SelectedValue = lst.pro_type.ToString();
            HiddenField1.Value = id.ToString();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse((sender as LinkButton).CommandArgument);
            Promotions dpt = new Promotions();
            dpt.id = id;

            if (new PromotionAccess().Delete(dpt) > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Successfully Deleted')", true);
                GridView1.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "alert('Failed to Delete')", true);
            }

           
           
        }
    }
}