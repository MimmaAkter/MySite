using HRM_BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HRM_DAL
{
    public class DivisionAccess
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader reader;
        string constr = ConfigurationManager.ConnectionStrings["hrm"].ConnectionString;

        public int Insert(Division Com)
        {
            var result = 0;
            con = new SqlConnection(constr);
            string sql = string.Format("Insert into Division(Name,Location,CID)values('{0}','{1}','{2}')", Com.Name, Com.Location,Com.CID);
            cmd = new SqlCommand(sql, con);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public List<Division> Display()
        {
            List<Division> lst = new List<Division>();

            con = new SqlConnection(constr);
            string sql = string.Format("select * from Division order by Name  asc");
            cmd = new SqlCommand(sql, con);
            con.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Division d = new Division();
                    d.Name = reader["Name"].ToString();
                    d.Location = reader["Location"].ToString();
                    d.ID = Int32.Parse(reader["ID"].ToString());
                    d.CID = Int32.Parse(reader["CID"].ToString());
                    lst.Add(d);
                }
            }
            con.Close();
            return lst;
        }

        public Division GetDivision(int id)
        {
            Division dpt = new Division();
            string constr = ConfigurationManager.ConnectionStrings["hrm"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            string sql = "Select * from Division where ID=" + id;
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
                    dpt.CID = Int32.Parse(reader["CID"].ToString());
                    dpt.Name = reader["Name"].ToString();
                    dpt.Location = reader["Location"].ToString();
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
            string sql = string.Format("Delete from Division where ID={0}", id);
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();

            result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return result;
        }

        public int Update(Division dpt)
        {
            var result = 0;
            string conStr = ConfigurationManager.ConnectionStrings["hrm"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            string sql = string.Format("Update Division set Name='{0}',Location='{1}',CID='{2}' where ID={3}",
                dpt.Name, dpt.Location,dpt.CID, dpt.ID);
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();

            result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return result;
        }
    }
}