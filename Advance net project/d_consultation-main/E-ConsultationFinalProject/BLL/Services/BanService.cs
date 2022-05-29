using BLL.Entity;
using DAL;
using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BanService
    {
        public static List<BanModel> Get()
        {
            var data = DataAccessFactory.BanDataAccess().Get();
            List<BanModel> model = new List<BanModel>();
            foreach (var b in data)
            {
                model.Add(new BanModel()
                {
                    u_id = b.u_id,
                    ban_reason = b.ban_reason,
                    ban_duration = b.ban_duration,
                    ban_time = b.ban_time,
                    user = new userModel()
                    {
                        u_id = b.user.u_id,
                        u_name = b.user.u_name,
                        u_username = b.user.u_username,
                        u_password = b.user.u_password,
                        u_address = b.user.u_address,
                        u_email = b.user.u_email,
                        u_phone = b.user.u_phone,
                        u_nid = b.user.u_nid,
                        u_category = b.user.u_category,
                        u_status = b.user.u_status
                    }
                });
            }
            return model;
        }
        public static void Add(BanModel bm)
        {
            ban data = new ban()
            {
              ban_reason=bm.ban_reason,
              ban_time=bm.ban_time,
              ban_duration=bm.ban_duration,
              user=new user()
              {
                  u_username=bm.user.u_username
              }
            };
            DataAccessFactory.BanDataAccess().Add(data);
        }
        public static void Editban(BanModel bm, int id)
        {
            ban data = new ban()
            {
                ban_reason = bm.ban_reason,
                ban_time = bm.ban_time,
                ban_duration = bm.ban_duration,
                user = new user()
                {
                    u_username = bm.user.u_username
                }
            };
            DataAccessFactory.BanDataAccess().Edit(data);
        }
        public static void Deleteban(int id)
        {
            ban b = new ban()
            {
                ban_id = id
            };
            DataAccessFactory.BanDataAccess().Edit(b);
        }

    }
}
