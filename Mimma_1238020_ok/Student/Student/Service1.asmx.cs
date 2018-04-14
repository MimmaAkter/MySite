using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Student.Model;
using System.Configuration;
using System.Data.SqlClient;

namespace Student
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public int Insert(Student_Info stu_info)
        {
            int Inserteddate=0;
            try
            {
                string config = ConfigurationManager.ConnectionStrings["Studentdb"].ConnectionString;
                SqlConnection connection = new SqlConnection(config);
                string sql = string.Format("insert into Student_Info (Name,Registration_No,Exam, Sesson,Board,Contact_No)values('{0}','{1}','{2}','{3}','{4}','{5}')"
                    , stu_info.Name, stu_info.Registration_No, stu_info.Exam, stu_info.Sesson, stu_info.Board, stu_info.Contact_No);
                SqlCommand command = new SqlCommand(sql, connection);
                command.Connection.Open();
                Inserteddate = command.ExecuteNonQuery();
                connection.Close();
               
            }
            
            catch(Exception exp)
            {

            }
            return Inserteddate;
            
        }
        [WebMethod]
        public int Update (Student_Info stu_info, string r_id)
        {
            int Updateddata = 0;
            try
            {
                string config = ConfigurationManager.ConnectionStrings["Studentdb"].ConnectionString;
                SqlConnection connection = new SqlConnection(config);
                string sql = string.Format("update Student_Info set Name = '{0}',  Exam='{1}', Sesson='{2}', Board='{3}', Contact_No='{4}' where Registration_No ='{6}'"
                    , stu_info.Name, stu_info.Exam, stu_info.Sesson, stu_info.Board, stu_info.Contact_No, stu_info.Registration_No, r_id);
                SqlCommand command = new SqlCommand(sql, connection);
                command.Connection.Open();
                Updateddata = command.ExecuteNonQuery();
                connection.Close();
                
            }
            catch(Exception exp)
            {

            }
            return Updateddata;
        }
        [WebMethod]
        public Student_Info Search (string r_id)
        {
            Student_Info stu_info = new Student_Info();
            try
            {
                string config = ConfigurationManager.ConnectionStrings["Studentdb"].ConnectionString;
                SqlConnection connection = new SqlConnection(config);
                string sql = string.Format("select*from Student_Info where Registration_No='{0}'", r_id);
                SqlCommand command = new SqlCommand(sql, connection);
                command.Connection.Open();
                SqlDataReader Sreacheddata = command.ExecuteReader();
                if(Sreacheddata.HasRows)
                {
                    while(Sreacheddata.Read())
                    {
                        stu_info.Name = Sreacheddata["Name"].ToString();
                        stu_info.Registration_No = Sreacheddata["Registration_No"].ToString();
                        stu_info.Exam = Sreacheddata["Exam"].ToString();
                        stu_info.Sesson = Sreacheddata["Sesson"].ToString();
                        stu_info.Board = Sreacheddata["Board"].ToString();
                        stu_info.Contact_No = Sreacheddata["Contact_No"].ToString();
                    }
                }
                connection.Close();
            }
            catch(Exception exp)
            {

            }
            
            return stu_info;
        }
        [WebMethod]
        public int Delete (string r_id)
        {
            int Deleteddata = 0;
            try
            {
                string config = ConfigurationManager.ConnectionStrings["Studentdb"].ConnectionString;
                SqlConnection connection = new SqlConnection(config);
                string sql = string.Format("delete from Student_Info where Registration_No='{0}'", r_id);
                SqlCommand command = new SqlCommand(sql, connection);
                command.Connection.Open();
                Deleteddata = command.ExecuteNonQuery();
                connection.Close();
            }
            catch(Exception exp)
            {

            }
            return Deleteddata;
        }

        
    }
}