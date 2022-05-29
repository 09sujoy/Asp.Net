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
    public class AllUserService
    {
        public static List<userModel> Get()
        {
            var user = DataAccessFactory.AllUserDataAccess().Get().Where(x=>x.isdeleted==0);
            List<userModel> data = new List<userModel>();
            foreach (var u in user)
            {
                data.Add(new userModel()
                {
                    u_id = u.u_id,
                    u_name = u.u_name,
                    u_username = u.u_username,
                    u_password = u.u_password,
                    u_address = u.u_address,
                    u_email = u.u_email,
                    u_phone = u.u_phone,
                    u_nid = u.u_nid,
                    u_category = u.u_category,
                    u_status = u.u_status
                });
            }
            return data;
        }
        public static void Add(userModel u)
        {
            if(u.u_category == "Supervisor" || u.u_category == "Patient")
            {
                u.u_status = "Active";
            }
            else if(u.u_category == "Doctor")
            {
                u.u_status = "Pending";
            }
           
            user data = new user()
            {
                u_name = u.u_name,
                u_username = u.u_username,
                u_password = u.u_password,
                u_address = u.u_address,
                u_email = u.u_email,
                u_phone = u.u_phone,
                u_nid = u.u_nid,
                u_category = u.u_category,
                u_status = u.u_status,
                isdeleted = 0
                
            };
            DataAccessFactory.AllUserDataAccess().Add(data);
        }
        public static void EditUser(userModel u,int id)
        {
            user data = new user()
            {
                u_name = u.u_name,
                u_username = u.u_username,
                u_password = u.u_password,
                u_address = u.u_address,
                u_email = u.u_email,
                u_phone = u.u_phone,
                u_nid = u.u_nid,
                u_id = id
               
                
               
            };
            DataAccessFactory.AllUserDataAccess().Edit(data);
        }
        public static void EditUserStatus(userModel u, int id)
        {
            user data = new user()
            {
                u_status = u.u_status,
                u_id = id
            };
            DataAccessFactory.AllUserDataAccess().EditStatus(data);
        }

        public static void EditDelete(int id)
        {
            user data = new user()
            {
                isdeleted = 1,
                u_id = id
            };
            DataAccessFactory.AllUserDataAccess().EditDelete(data);
        }
        public static List<userModel> SearchUser(userModel model)
        {
            if (model.u_category == null) model.u_category = "";
            if (model.u_status == null) model.u_status = "";

            var user = DataAccessFactory.AllUserDataAccess().Get().Where(x => (x.u_status.Contains(model.u_status)) && x.u_category.Contains(model.u_category));
            List<userModel> data = new List<userModel>();
            foreach (var u in user)
            {
                data.Add(new userModel()
                {
                    u_id = u.u_id,
                    u_name = u.u_name,
                    u_username = u.u_username,
                    u_password = u.u_password,
                    u_address = u.u_address,
                    u_email = u.u_email,
                    u_phone = u.u_phone,
                    u_nid = u.u_nid,
                    u_category = u.u_category,
                    u_status = u.u_status
                });
            }
            return data;
        }
        public static void DeleteUser(int id)
        {
            user us = new user()
            { 
                isdeleted =1,
                u_id = id
            };
            DataAccessFactory.AllUserDataAccess().Edit(us);
        }

    }
}
