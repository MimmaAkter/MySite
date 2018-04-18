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
    public class DeptAccess
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader reader;
        string constr = ConfigurationManager.ConnectionStrings["hrm"].ConnectionString;

        public int Insert(Dept dept)
        {
            var result = 0;
            con = new SqlConnection(constr);
            string sql = string.Format("Insert into Department(Name)values('{0}')", dept.Name);
            cmd = new SqlCommand(sql, con);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public List<Dept> Display()
        {
            List<Dept> lst = new List<Dept>();

            con = new SqlConnection(constr);
            string sql = string.Format("select * from Department order by Name  asc");
            cmd = new SqlCommand(sql, con);
            con.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Dept d = new Dept();
                    d.Name = reader["Name"].ToString();
                    d.ID = Int32.Parse(reader["ID"].ToString());
                    lst.Add(d);
                }
            }
            con.Close();
            return lst;
        }

        public Dept GetDept(int id)
        {
            Dept dpt = new Dept();
            string constr = ConfigurationManager.ConnectionStrings["hrm"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            string sql = "Select * from Department where ID=" + id;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    dpt.ID = Int32.Parse(reader["ID"].ToString());
                    dpt.Name = reader["Name"].ToString();
                }
            }
            cmd.Connection.Close();
            return dpt;
        }

        public int Delete(int id)
        {
            var result = 0;
            string constr = ConfigurationManager.ConnectionStrings["hrm"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            string sql = string.Format("Delete from Department where ID={0}", id);
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();

            result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return result;
        }

        public int Update(Dept dpt)
        {
            var result = 0;
            string conStr = ConfigurationManager.ConnectionStrings["hrm"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            string sql = string.Format("Update Department set Name='{0}' where ID={1}",
                dpt.Name,dpt.ID);
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();

            result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return result;
        }
    }
}
