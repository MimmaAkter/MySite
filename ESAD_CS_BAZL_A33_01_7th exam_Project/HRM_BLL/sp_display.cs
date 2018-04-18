using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BLL
{
  public   class sp_display
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string father_name { get; set; }
        public string mother_name { get; set; }
        public string dob { get; set; }
        public string Gender { get; set; }
        public string nationality { get; set; }
        public string maritual_status { get; set; }
        public string Religion { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string home_phone { get; set; }
        public string present_address { get; set; }
        public string parmanent_address { get; set; }
        public int deptid { get; set; }
        public int degid { get; set; }
        public int secid { get; set; }
        public string  Department { get; set; }
        public string section { get; set; }
    }
}
