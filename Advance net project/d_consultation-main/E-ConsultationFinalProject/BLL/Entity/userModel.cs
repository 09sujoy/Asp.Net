using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class userModel
    {
        public int u_id { get; set; }
        public string u_name { get; set; }
        public string u_password { get; set; }
        public string u_username { get; set; }
        public string u_address { get; set; }
        public Nullable<int> u_phone { get; set; }
        public string u_email { get; set; }
        public Nullable<int> u_nid { get; set; }
        public string u_category { get; set; }
        public string u_status { get; set; }
        public Nullable<int> isdeleted { get; set; }
    }
}
