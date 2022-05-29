using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class PrescriptionModel
    {
        public int pres_id { get; set; }
        public string pres_medicine { get; set; }
        public string pres_test { get; set; }
        public string pres_advice { get; set; }
        public Nullable<int> u_id { get; set; }
        public int p_id { get; set; }

        public virtual userModel user { get; set; }
        public virtual PatientModel patient { get; set; }
    }
}
