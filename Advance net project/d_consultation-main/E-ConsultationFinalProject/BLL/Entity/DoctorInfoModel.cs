using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class DoctorInfoModel
    {
        public int did { get; set; }
        public Nullable<int> d_govid { get; set; }
        public string d_degree { get; set; }
        public string d_speciality { get; set; }
        public Nullable<int> u_id { get; set; }

        public virtual userModel user { get; set; }
    }
}
