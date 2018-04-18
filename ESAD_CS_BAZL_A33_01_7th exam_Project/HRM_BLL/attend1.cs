using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BLL
{
   public class attend1
    {
        public int ID { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
        public DateTime InTime_Lanch { get; set; }
        public DateTime OutTime_Lanch { get; set; }
        public DateTime Attend_Time { get; set; }
        public string Statuss { get; set; }
        public DateTime TotalHours { get; set; }
    }
}
