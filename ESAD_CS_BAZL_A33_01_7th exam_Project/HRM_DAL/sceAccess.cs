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
    public class sceAccess
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader reader;
        string constr = ConfigurationManager.ConnectionStrings["hrm"].ConnectionString;
        public int Insert(sec se)
        {
            var result = 0;
            con = new SqlConnection(constr);
            string sql = string.Format("Insert into section(section_name)values('{0}')", se.Name);
            cmd = new SqlCommand(sql, con);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public List<sec> Display()
        {
            List<sec> lst = new List<sec>();

            con = new SqlConnection(constr);
            string sql = string.Format("select * from section order by section_name asc");
            cmd = new SqlCommand(sql, con);
            con.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    sec d = new sec();
                    d.Name = reader["section_name"].ToString();
                    d.Id = Int32.Parse(reader["id"].ToString());
                    lst.Add(d);
                }
            }
            con.Close();
            return lst;
        }
        public sec Getsec(int id)
        {
            sec se = new sec();

            SqlConnection con = new SqlConnection(constr);
            string sql = "Select * from section Where id=" + id;
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
                    //Students std = new Students();
                    se.Id = Int32.Parse(reader["id"].ToString());
                    se.Name = reader["section_name"].ToString();


                }
            }

            cmd.Connection.Close();
            return se;
        }

        public int Update(sec se, int id)
        {
            var result = 0;
            SqlConnection con = new SqlConnection(constr);
            string sql = string.Format("Update section set section_name='{0}' where id=" + id + "",
                se.Name);
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;


        }
        public int Delete(int id)
        {

            SqlConnection con = new SqlConnection(constr);
            string sql = string.Format("Delete from section  where id={0}", id);
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();


            return cmd.ExecuteNonQuery();
            cmd.Connection.Close();

        }
    }
}
