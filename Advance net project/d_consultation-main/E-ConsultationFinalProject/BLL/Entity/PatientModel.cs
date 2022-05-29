using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class PatientModel
    {
        public int p_id { get; set; }
        public string p_sickness_reason { get; set; }
        public string p_diagnostics_info { get; set; }
        public int u_id { get; set; }
        public Nullable<int> app_id { get; set; }
        public string status { get; set; }
        public virtual DoctorAppoinmentModel doc_appoinment { get; set; }
        public virtual userModel user { get; set; }
    }
}
