using HRM_BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HRM_DAL
{
   public class DesigAccess
   {
       string constr = ConfigurationManager.ConnectionStrings["hrm"].ConnectionString;
       SqlConnection con;
       SqlCommand cmd;
       SqlDataReader reader;

       public int Save(Designation Desig)
       {
           
            con = new SqlConnection(constr);
           string sql = string.Format("Insert into Designation(DesName)values('{0}')", Desig.DesName);
            cmd = new SqlCommand(sql, con);
           con.Open();
           return cmd.ExecuteNonQuery();
           
       }
       public List<Designation> Display()
       {
           List<Designation> lst = new List<Designation>();
           con = new SqlConnection(constr);
           string sql = string.Format("select * from  Designation");
           cmd = new SqlCommand(sql, con);
           con.Open();
           reader = cmd.ExecuteReader();
           if(reader.HasRows)
           {
               while(reader.Read())
               {
                   Designation desig = new Designation();
                   desig.DesId =Int32.Parse(reader["DesId"].ToString());
                   desig.DesName = reader["DesName"].ToString();
                   lst.Add(desig);
               }
           }
           con.Close();
           return lst;
       }
       public Designation EditingData(int id)
       {
           Designation desig = new Designation();
           
           con = new SqlConnection(constr);
           string sql = "Select * from Designation Where DesId="+id ;
           cmd = new SqlCommand(sql, con);
           cmd.CommandType = System.Data.CommandType.Text;
           con.Open();
           reader = cmd.ExecuteReader();
           if (reader.HasRows)
           {
               while (reader.Read())
               {
                   
                   desig.DesId = Int32.Parse(reader["DesId"].ToString());
                   desig.DesName = reader["DesName"].ToString();
                   
               }
           }
           con.Close();
           return desig;
       }
       public int DeleteData(int id)
       {
           con = new SqlConnection(constr);
           string sql = string.Format("Delete from Designation where DesId={0}", id);
           cmd = new SqlCommand(sql, con);
          
           con.Open();
           if(cmd.ExecuteNonQuery()>0)
           {
               con.Close();
               return 1;
           }
          else
           {
               con.Close();
               return 0;
           }
       }
       public int Update(Designation desig)

       {
           con = new SqlConnection(constr);
           string sql = string.Format("Update Designation set DesName='{0}' where DesId={1}",desig.DesName, desig.DesId);
           cmd = new SqlCommand(sql, con);
           con.Open();
         int r= cmd.ExecuteNonQuery();
           con.Close();
           return r;
       }
    }
}
