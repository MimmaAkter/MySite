using HRM_BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class transferAccess
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader reader;
        
        public int insert(transferhistory type )
        {
            var result = 0;
            string constr = ConfigurationManager.ConnectionStrings["hrm"].ConnectionString;
            con = new SqlConnection(constr);
            string sql = string.Format("Insert into Transfer_info(EmpID,OldDepartment,NewDepartment,OldDivision, NewDivision,OldSection,NewSection,TransferActiveDate,TransferDate,Remark,StatusState) values ({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')"
                ,type.EmpID,type.OldDepartment,type.NewDepartment,type.OldDivision,type.NewDivision,type.OldSection,type.NewSection,type.TransferActiveDate,type.TransferDate,type.Remark,type.StatusState);
                
              
               
            cmd = new SqlCommand(sql, con);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

    }
}
