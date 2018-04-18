using HRM_BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HRM_DAL
{
    public class CompanyAccess
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader reader;
        string constr = ConfigurationManager.ConnectionStrings["hrm"].ConnectionString;

        public int Insert(Company Com)
        {
            var result = 0;
            con = new SqlConnection(constr);
            string sql = string.Format("Insert into Company(Name,Location)values('{0}','{1}')", Com.Name,Com.Location);
            cmd = new SqlCommand(sql, con);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public List<Company> Display()
        {
            List<Company> lst = new List<Company>();

            con = new SqlConnection(constr);
            string sql = string.Format("select * from Company order by Name  asc");
            cmd = new SqlCommand(sql, con);
            con.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Company d = new Company();
                    d.Name = reader["Name"].ToString();
                    d.Location = reader["Location"].ToString();
                    d.ID = Int32.Parse(reader["ID"].ToString());
                    lst.Add(d);
                }
            }
            con.Close();
            return lst;
        }

        public Company GetCompany(int id)
        {
            Company dpt = new Company();
            string constr = ConfigurationManager.ConnectionStrings["hrm"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            string sql = "Select * from Company where ID=" + id;
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
            string sql = string.Format("Delete from Company where ID={0}", id);
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();

            result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return result;
        }

        public int Update(Company dpt)
        {
            var result = 0;
            string conStr = ConfigurationManager.ConnectionStrings["hrm"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            string sql = string.Format("Update Company set Name='{0}',Location='{1}' where ID={2}",
                dpt.Name, dpt.Location, dpt.ID);
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();

            result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return result;
        }
    }
}