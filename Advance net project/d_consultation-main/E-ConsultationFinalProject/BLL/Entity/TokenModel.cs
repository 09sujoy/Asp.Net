using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class TokenModel
    {
        public int Id { get; set; }
        public Nullable<int> u_id { get; set; }
        public string accesstoken { get; set; }
        public Nullable<System.DateTime> createdat { get; set; }
        public string expireat { get; set; }


    }
}
