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
    public class doctor_schedule_service
    {
        public static List<DoctorSheduleModel> GetSchedule()
        {
            var schedule = DataAccessFactory.DoctorSheduleDataAccess().Get();
            List<DoctorSheduleModel> data = new List<DoctorSheduleModel>();
            foreach (var s in schedule)
            {
                data.Add(new DoctorSheduleModel()
                {
                    doctor_info = new DoctorInfoModel()
                    {
                       user=new userModel()
                       {
                           u_username=s.doctor_info.user.u_name
                       }
                    },
                    schedule_day = s.schedule_day,
                    schedule_starting_time = s.schedule_starting_time,
                    schedule_ending_time = s.schedule_ending_time
                }) ; 
            }
            return data;
        }

        public static DoctorSheduleModel GetSchedule(int id)
        {
            var data = DataAccessFactory.DoctorSheduleDataAccess().Get(id);
            DoctorSheduleModel model = new DoctorSheduleModel()
            {
                schedule_day = data.schedule_day,
                schedule_starting_time = data.schedule_starting_time,
                schedule_ending_time = data.schedule_ending_time,
                doctor_info = new DoctorInfoModel()
                {
                    user = new userModel()
                    {
                        u_username = data.doctor_info.user.u_name
                    }
                }
                
            };
            return model;
        }

        public static void AddSchedule(DoctorSheduleModel ds)
        {
            doctor_schedule data = new doctor_schedule()
            {
                schedule_day = ds.schedule_day,
                schedule_starting_time = ds.schedule_starting_time,
                schedule_ending_time = ds.schedule_ending_time
            };
            DataAccessFactory.DoctorSheduleDataAccess().Add(data);
        }
        public static void Editschedule(DoctorSheduleModel ds, int id)
        {
            doctor_schedule data = new doctor_schedule()
            {
                schedule_day = ds.schedule_day,
                schedule_starting_time = ds.schedule_starting_time,
                schedule_ending_time = ds.schedule_ending_time,
                schedule_id = id
            };
            DataAccessFactory.DoctorSheduleDataAccess().Edit(data);
        }
        public static void DeleteSchedule(int id)
        {
            doctor_schedule ds = new doctor_schedule()
            {
                isdeleted = 1,
                schedule_id = id
            };
            DataAccessFactory.DoctorSheduleDataAccess().Delete(id);
        }

        public static List<DoctorSheduleModel> GetDoctorSheduleForPatient(int id)
        {
            var user = DataAccessFactory.DoctorSheduleDataAccess().Get().Where(x=>x.doctor_info.user.u_id == id);
            List<DoctorSheduleModel> data = new List<DoctorSheduleModel>();
            foreach (var u in user)
            {
                data.Add(new DoctorSheduleModel()
                {
                    did = u.did,
                   schedule_id = u.schedule_id,
                    schedule_day = u.schedule_day,
                    schedule_starting_time = u.schedule_starting_time,
                    schedule_ending_time = u.schedule_ending_time
                });
            }
            return data;
        }


    }
}
