using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BLL
{
    public class Promotions
    {
        public int empid { get; set; }
        public int id { get; set; }

        public string pro_type { get; set; }
        public double amount { get; set; }
        public DateTime activedate { get; set; }
        public DateTime pro_active { get; set; }
        public double Basic { get; set; }
        public double HouseRent { get; set; }
        public double Medicalmoney { get; set; }
        public double Convences { get; set; }
        public double taxes { get; set; }
        public double Gross_Salary { get; set; }
    }
}
