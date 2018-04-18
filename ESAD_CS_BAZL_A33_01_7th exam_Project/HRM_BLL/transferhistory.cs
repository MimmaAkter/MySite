using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BLL
{
   public class transferhistory
    {
       public int TransferID { get; set; }
       public int EmpID { get; set; }
       public string OldDepartment { get; set; }

       public string NewDepartment { get; set; }
       public string OldDivision { get; set; }
       public string NewDivision { get; set; }
       public string OldSection { get; set; }
       public string NewSection { get; set; }
       public DateTime TransferActiveDate { get; set; }
       public DateTime TransferDate { get; set; }
       public string Remark { get; set; }
       public string StatusState { get; set; }




    }
}
