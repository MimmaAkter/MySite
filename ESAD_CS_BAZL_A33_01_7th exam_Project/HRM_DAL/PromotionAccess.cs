using HRM_BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_DAL
{
   public class PromotionAccess
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader reader;
        string constr = ConfigurationManager.ConnectionStrings["hrm"].ConnectionString;

        public int insert(Promotions pro)
        {
            var result = 0;
            //DateTime dt1 = DateTime.Parse(pro.activedate);
            DateTime dt2 = DateTime.Parse((pro.pro_active).ToString());
            DateTime dt3 = DateTime.Parse((pro.activedate).ToString());


            con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("st_insert", con);
           
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@empid",pro.empid);
            cmd.Parameters.AddWithValue("@pro_type",pro.pro_type);
            cmd.Parameters.AddWithValue("@amount",pro.amount);
            cmd.Parameters.AddWithValue("@activedate",dt3);

            cmd.Parameters.AddWithValue("@pro_active",dt2);
            cmd.Parameters.AddWithValue("@Basics",pro.Basic);
            cmd.Parameters.AddWithValue("@HouseRent", pro.HouseRent);
            cmd.Parameters.AddWithValue("@Medicalmoney", pro.Medicalmoney);
            cmd.Parameters.AddWithValue("@Convences", pro.Convences);
            cmd.Parameters.AddWithValue("@taxes",pro.taxes);
            cmd.Parameters.AddWithValue("@Gross_Salary", pro.Gross_Salary);

           result= cmd.ExecuteNonQuery();
           con.Close();
           return result;
           
        }

        public Promotions Getpro(int id)
        {
            Promotions dpt = new Promotions();
            string constr = ConfigurationManager.ConnectionStrings["hrm"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            string sql = "Select * from promotion where ID=" + id;
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
                    dpt.empid = Int32.Parse(reader["ID"].ToString());
                    dpt.pro_type = reader["pro_type"].ToString();
                    dpt.amount = double.Parse(reader["amount"].ToString());

                    dpt.activedate = DateTime.Parse(reader["activedate"].ToString());
                    dpt.pro_active = DateTime.Parse(reader["pro_active"].ToString());

                    dpt.Basic = double.Parse(reader["Basics"].ToString());
                    dpt.HouseRent = double.Parse(reader["HouseRent"].ToString());
                    dpt.Medicalmoney = double.Parse(reader["Medicalmoney"].ToString());
                    dpt.Convences = double.Parse(reader["Convences"].ToString());
                    dpt.taxes = double.Parse(reader["taxes"].ToString());
                    dpt.Gross_Salary = double.Parse(reader["Gross_Salary"].ToString());
                }
            }
            cmd.Connection.Close();
            return dpt;
        }
        public int Update(Promotions pro)
        {

            Promotions dpt = new Promotions();
            string constr = ConfigurationManager.ConnectionStrings["hrm"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
               DateTime dt2 = DateTime.Parse((pro.pro_active).ToString());
            DateTime dt3 = DateTime.Parse((pro.activedate).ToString());
            var result = 0;

            con.Open();
            SqlCommand cmd = new SqlCommand("st_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", pro.id);
            
            cmd.Parameters.AddWithValue("@empid", pro.empid);
            cmd.Parameters.AddWithValue("@pro_type", pro.pro_type);
            cmd.Parameters.AddWithValue("@amount", pro.amount);
            cmd.Parameters.AddWithValue("@activedate", dt3);

            cmd.Parameters.AddWithValue("@pro_active", dt2);
            cmd.Parameters.AddWithValue("@Basics", pro.Basic);
            cmd.Parameters.AddWithValue("@HouseRent", pro.HouseRent);
            cmd.Parameters.AddWithValue("@Medicalmoney", pro.Medicalmoney);
            cmd.Parameters.AddWithValue("@Convences", pro.Convences);
            cmd.Parameters.AddWithValue("@taxes", pro.taxes);
            cmd.Parameters.AddWithValue("@Gross_Salary", pro.Gross_Salary);
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int Delete(Promotions dept)
        {

            var result = 0;
            Promotions dpt = new Promotions();
            string constr = ConfigurationManager.ConnectionStrings["hrm"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
                con.Open();
                cmd = new SqlCommand("st_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", dpt.id);
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
            
        }
    }
}
