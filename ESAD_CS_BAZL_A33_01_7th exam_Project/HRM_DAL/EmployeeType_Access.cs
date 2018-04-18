using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using HRM_BLL;

namespace HRM_DAL
{
  public  class EmployeeType_Access
    {
        SqlCommand cmd;
        SqlConnection con; 
        SqlDataReader reader;
        string constr = ConfigurationManager.ConnectionStrings["hrm"].ConnectionString;

        public int insert(Employee_Type type)
        {
            var result = 0;
            con = new SqlConnection(constr);
            string sql = string.Format("Insert into Employee_Type(Employee_Types)values('{0}')", type.Employee_Types );
            cmd = new SqlCommand(sql, con);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

       
        public List<Employee_Type> Display()
        {
            List<Employee_Type> lst = new List<Employee_Type>();

            con = new SqlConnection(constr);
            string sql = string.Format("select * from Employee_Type order by Employee_Types  asc");
            cmd = new SqlCommand(sql, con);
            con.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Employee_Type d = new Employee_Type();
                    d.Employee_Types = reader["Employee_Types"].ToString();
                    d.EmployeeType_ID = int.Parse(reader["EmployeeType_ID"].ToString());
                    lst.Add(d);

                }
            }
            con.Close();
            return lst;
        }
    }
}
