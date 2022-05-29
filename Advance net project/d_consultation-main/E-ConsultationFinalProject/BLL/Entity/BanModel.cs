using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class BanModel
    {
        public int ban_id { get; set; }
        public string ban_reason { get; set; }
        public Nullable<System.DateTime> ban_duration { get; set; }
        public Nullable<System.DateTime> ban_time { get; set; }
        public Nullable<int> u_id { get; set; }

        public virtual userModel user { get; set; }
    }
}
