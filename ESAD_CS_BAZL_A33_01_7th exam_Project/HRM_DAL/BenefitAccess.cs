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
    public class BenefitAccess
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["hrm"].ConnectionString);
        SqlCommand cmd;
        SqlDataReader reader;
        public int Insert(Benefit benefit)
        {
            var result = 0;
            if(con.State==ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("sp_insertBenefit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Benefit_Type", benefit.Benefit_Type.Trim());
           result= cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public List<Benefit> Display()
        {
            List<Benefit> Benefit_List = new List<Benefit>();
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("sp_displayBenefit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Benefit b = new Benefit();
                    b.Benefit_ID =Int32.Parse( reader["Benefit_ID"].ToString());
                    b.Benefit_Type = reader["Benefit_Type"].ToString();
                    Benefit_List.Add(b);
                }
            }
            con.Close();
            return Benefit_List;
        }
        //public int Search(Benefit benefit)
        //{
            //var result = 0;
            //if (con.State == ConnectionState.Closed)
            //    con.Open();
            //cmd = new SqlCommand("sp_searchBenefit", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Benefit_ID", benefit.Benefit_ID);
            //reader = cmd.ExecuteReader();
            //if (reader.HasRows)
            //{
            //    while (reader.Read())
            //    {
            //        Benefit b = new Benefit();
            //        b.Benefit_ID = Int32.Parse(reader["Benefit_ID"].ToString());
            //        b.Benefit_Type = reader["Benefit_Type"].ToString();
            //    }

            //}
            //con.Close();
            //return result;
            //var result = 0;
            //if (con.State == ConnectionState.Closed)
            //    con.Open();
            //SqlDataAdapter da = new SqlDataAdapter("sp_searchBenefit", con);
            //da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //da.SelectCommand.Parameters.AddWithValue("@Benefit_ID", benefit.Benefit_ID);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //benefit.Benefit_ID =int.Parse( dt.Rows[0]["Benefit_ID"].ToString());
            //benefit.Benefit_Type = dt.Rows[0]["Benefit_Type"].ToString();
        //    con.Close();
            
        //    return result;
        //}
        public int Update(Benefit benefit)
        {
            var result = 0;
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("sp_updateBenefit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Benefit_ID", benefit.Benefit_ID);
            cmd.Parameters.AddWithValue("@Benefit_Type", benefit.Benefit_Type);
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int Delete(Benefit benefit)
        {
            var result = 0;
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("sp_deleteBenefit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Benefit_ID", benefit.Benefit_ID);
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        
        
    }
}
