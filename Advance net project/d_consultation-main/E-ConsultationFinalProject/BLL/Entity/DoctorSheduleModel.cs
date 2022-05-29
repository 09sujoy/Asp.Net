using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class DoctorSheduleModel
    {
        public int schedule_id { get; set; }
        public Nullable<System.DateTime> schedule_day { get; set; }
        public Nullable<System.TimeSpan> schedule_starting_time { get; set; }
        public Nullable<System.TimeSpan> schedule_ending_time { get; set; }
        public Nullable<int> did { get; set; }

       
        public virtual DoctorInfoModel doctor_info { get; set; }
    }
}
