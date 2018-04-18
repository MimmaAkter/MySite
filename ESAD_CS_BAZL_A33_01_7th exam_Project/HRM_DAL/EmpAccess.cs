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
   public class EmpAccess
    {

        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader reader;
        string constr = ConfigurationManager.ConnectionStrings["hrm"].ConnectionString;
        public int Insert(Emp em)
        {
            
            

            
            
            var result = 0;
            con = new SqlConnection(constr);
            string sql = string.Format("Insert into emplyee(name,father_name,mother_name,dob,Gender,nationality,maritual_status,Religion,mobile,email,home_phone,present_address,parmanent_address,deptid,degid,Gross_Salary,secid,divid)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}',{13},{14},{15},{16},{17})",
                em.name, em.father_name, em.mother_name, em.dob, em.Gender, em.nationality, em.maritual_status, em.Religion, em.mobile, em.email, em.home_phone, em.parmanent_address, em.parmanent_address, em.deptid, em.degid,em.Gross_Salary, em.secid,em.Divid);
            //string sql = string.Format("Insert into emplyee1(name,father_name)values('{0}','{1}')",
            //    em.name, em.father_name);
            cmd = new SqlCommand(sql, con);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public Emp Getemp(int id)
        {
            Emp emp = new Emp();

            SqlConnection con = new SqlConnection(constr);
            string sql = "Select * from emplyee Where id="+id+"";
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
                    
                    emp.Id = Int32.Parse(reader["id"].ToString());
                    emp.name = reader["name"].ToString();
                    emp.father_name=reader["father_name"].ToString();
                    emp.mother_name = reader["mother_name"].ToString();
                    emp.dob = reader["dob"].ToString();
                    emp.Gender = reader["Gender"].ToString();
                    emp.nationality = reader["nationality"].ToString();
                    emp.maritual_status = reader["maritual_status"].ToString();
                    emp.Religion = reader["Religion"].ToString();
                    emp.mobile = reader["mobile"].ToString();
                    emp.email = reader["email"].ToString();
                    emp.home_phone = reader["home_phone"].ToString();
                    emp.present_address = reader["present_address"].ToString();
                    emp.parmanent_address = reader["parmanent_address"].ToString();
                    emp.Gross_Salary = double.Parse(reader["Gross_Salary"].ToString());
                    emp.deptid = Int32.Parse(reader["deptid"].ToString());
                    emp.degid = Int32.Parse(reader["degid"].ToString());
                    emp.secid = Int32.Parse(reader["secid"].ToString());
                    emp.Divid = Int32.Parse(reader["divid"].ToString());

                }
            }

            cmd.Connection.Close();
            return emp;
        }
        public int Update(Emp emp,int id)
        {
            var result = 0;
            SqlConnection con = new SqlConnection(constr);                                                                                                                                                                      // deptid,degid,Gross_Salary,secid,divid
            string sql = string.Format("Update emplyee set name='{0}',father_name='{1}',mother_name='{2}',dob='{3}',Gender='{4}',nationality='{5}',maritual_status='{6}',Religion='{7}',mobile='{8}',email='{9}',home_phone='{10}',present_address='{11}',parmanent_address='{12}',deptid={13},degid={14},Gross_Salary={15},secid={16},divid={17} where id=" + id + "",
                                                      emp.name,emp.father_name,emp.mother_name,emp.dob,emp.Gender,emp.nationality,emp.maritual_status,emp.Religion,emp.mobile,emp.email,emp.home_phone,emp.present_address,emp.parmanent_address,emp.deptid,emp.degid,emp.Gross_Salary,emp.secid,emp.Divid);
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;


        }
        public int Delete(int id)
        {
            
            SqlConnection con = new SqlConnection(constr);
            string sql = string.Format("Delete from emplyee  where id="+id+"");
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();


            int result= cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return result;

        }
        public sp_display GetempData(int id)
        {
            sp_display emp = new sp_display();

            SqlConnection con = new SqlConnection(constr);
            string sql = "sp_display";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    emp.Id = Int32.Parse(reader["id"].ToString());
                    emp.name = reader["name"].ToString();
                    emp.father_name = reader["father_name"].ToString();
                    emp.mother_name = reader["mother_name"].ToString();
                    emp.dob = reader["dob"].ToString();
                    emp.Gender = reader["Gender"].ToString();
                    emp.nationality = reader["nationality"].ToString();
                    emp.maritual_status = reader["maritual_status"].ToString();
                    emp.Religion = reader["Religion"].ToString();
                    emp.mobile = reader["mobile"].ToString();
                    emp.email = reader["email"].ToString();
                    emp.home_phone = reader["home_phone"].ToString();
                    emp.present_address = reader["present_address"].ToString();
                    emp.parmanent_address = reader["parmanent_address"].ToString();
                    
                    emp.deptid = Int32.Parse(reader["deptid"].ToString());
                    emp.degid = Int32.Parse(reader["degid"].ToString());
                    emp.secid = Int32.Parse(reader["secid"].ToString());
                    emp.section = (reader["section"].ToString());
                    emp.Department = reader["Department"].ToString();
                }
            }

            cmd.Connection.Close();
            return emp;
        }
        public List<Emp> GetData()
        {
            List<Emp> lstemp = new List<Emp>();

            SqlConnection con = new SqlConnection(constr);
            string sql = "Select * from emplyee order by Id Desc";
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
                    Emp emp = new Emp();
                    emp.Id = Int32.Parse(reader["id"].ToString());
                    emp.name = reader["name"].ToString();
                    emp.father_name = reader["father_name"].ToString();
                    emp.mother_name = reader["mother_name"].ToString();
                    emp.dob = reader["dob"].ToString();
                    emp.Gender = reader["Gender"].ToString();
                    emp.nationality = reader["nationality"].ToString();
                    emp.maritual_status = reader["maritual_status"].ToString();
                    emp.Religion = reader["Religion"].ToString();
                    emp.mobile = reader["mobile"].ToString();
                    emp.email = reader["email"].ToString();
                    emp.home_phone = reader["home_phone"].ToString();
                    emp.present_address = reader["present_address"].ToString();
                    emp.parmanent_address = reader["parmanent_address"].ToString();
                    emp.deptid = Int32.Parse(reader["deptid"].ToString());
                    emp.degid = Int32.Parse(reader["degid"].ToString());
                    emp.secid = Int32.Parse(reader["secid"].ToString());
                    lstemp.Add(emp);
                }
            }

            cmd.Connection.Close();
            return lstemp;
        }

    }
}
