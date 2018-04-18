using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM_BLL;
using System.Data.SqlClient;
using System.Configuration;

namespace HRM_DAL
{
  public  class Attendaccess
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader reader;
        string constr = ConfigurationManager.ConnectionStrings["hrm"].ConnectionString;
       public int Insert(attend1 att)
        {
            var result = 0;
            con = new SqlConnection(constr);
            string sql = string.Format("insert into attendence(InTime,outTime,InTime_Lanch,OutTime_Lanch,Attend_Date,Statuss)values('{0}','{1}','{2}','{3}','{4}','{5}')",
                att.InTime, att.OutTime,att.InTime_Lanch,att.OutTime_Lanch, att.Attend_Time,att.Statuss);
            cmd = new SqlCommand(sql, con);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
       public List<attend1> Display()
       {
           List<attend1> lst = new List<attend1>();
           con = new SqlConnection(constr);
           string sql = string.Format("select * from attendence");
              
           cmd = new SqlCommand(sql, con);
           con.Open();
           reader = cmd.ExecuteReader();
           if (reader.HasRows)
           {
               while(reader.Read())
               {
                   attend1 d = new attend1();
                   d.InTime = DateTime.Parse(reader["InTime"].ToString());
                   d.OutTime = DateTime.Parse(reader["OutTime"].ToString());
                   d.InTime_Lanch = DateTime.Parse(reader["InTime_Lanch"].ToString());
                   d.OutTime_Lanch = DateTime.Parse(reader["OutTime_Lanch"].ToString());
                   d.Attend_Time = DateTime.Parse(reader["Attend_Time"].ToString());
                   d.Statuss = reader["Statuss"].ToString();
               }
           }
           con.Close();
           return lst;
          
       }
    }
}
