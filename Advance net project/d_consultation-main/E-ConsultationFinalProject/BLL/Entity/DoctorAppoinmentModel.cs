using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class DoctorAppoinmentModel
    {
        public int app_id { get; set; }
        public Nullable<int> app_fee { get; set; }
        public string app_status { get; set; }
        public int schedule_id { get; set; }

        public virtual DoctorSheduleModel doctor_schedule { get; set; }
    }
}
