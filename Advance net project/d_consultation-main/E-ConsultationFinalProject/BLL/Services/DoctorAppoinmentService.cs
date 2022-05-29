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
    public class DoctorAppoinmentService
    {
        public static DoctorAppoinmentModel GetDoctorAppoinmentForPatient(int id)
        {
            var data = DataAccessFactory.DoctorAppoinmentDataAccess().Get(id);
            DoctorAppoinmentModel model = new DoctorAppoinmentModel() {
                app_fee = data.app_fee,
                app_id = data.app_id,
                schedule_id = data.schedule_id,
               
            };
            return model;
            
        }
         public static DoctorAppoinmentModel GetSupervisorAppoinmentofPatient(int id)
        {
            var data = DataAccessFactory.DoctorAppoinmentDataAccess().Get(id);
            DoctorAppoinmentModel model = new DoctorAppoinmentModel() {
                app_fee = data.app_fee,
                doctor_schedule=new DoctorSheduleModel()
                {
                    schedule_day = data.doctor_schedule.schedule_day,
                    schedule_starting_time =data.doctor_schedule.schedule_starting_time,
                    schedule_ending_time=data.doctor_schedule.schedule_ending_time,
                    doctor_info= new DoctorInfoModel()
                    { 
                        d_speciality=data.doctor_schedule.doctor_info.d_speciality,
                        user=new userModel()
                        {
                            u_name=data.doctor_schedule.doctor_info.user.u_name
                        }
                    }
                }


            };
            return model;
            
        }
        public static List<DoctorAppoinmentModel> Getappointmentlistofpatient()
        {
            var appoin = DataAccessFactory.DoctorAppoinmentDataAccess().Get();
            List<DoctorAppoinmentModel> data = new List<DoctorAppoinmentModel>();
            foreach (var a in appoin)
            {
                data.Add(new DoctorAppoinmentModel()
                {
                    app_fee =a.app_fee,
                    doctor_schedule = new DoctorSheduleModel()
                    {
                        schedule_day = a.doctor_schedule.schedule_day,
                        schedule_starting_time = a.doctor_schedule.schedule_starting_time,
                        schedule_ending_time = a.doctor_schedule.schedule_ending_time,
                        doctor_info = new DoctorInfoModel()
                        {
                            d_speciality = a.doctor_schedule.doctor_info.d_speciality,
                            user = new userModel()
                            {
                                u_name = a.doctor_schedule.doctor_info.user.u_name
                            }
                        }
                    }
                });
            }
            return data;
        }
        public static void Addappointment(DoctorAppoinmentModel ds)
        {
            doc_appoinment data = new doc_appoinment()
            {
                app_fee = ds.app_fee,
                app_status = ds.app_status,
                schedule_id = ds.schedule_id,
                isdeleted = 0
            };
            DataAccessFactory.DoctorAppoinmentDataAccess().Add(data);
        }
        public static void Editappointment(DoctorAppoinmentModel ds, int id)
        {
            doc_appoinment data = new doc_appoinment()
            {
                app_fee = ds.app_fee,
                app_status=ds.app_status,
                app_id=id
            };
            DataAccessFactory.DoctorAppoinmentDataAccess().Edit(data);
        }
        public static void Deleteappointment(int id)
        {
            doc_appoinment ds = new doc_appoinment()
            {
                isdeleted = 1,
                app_id = id
            };
            DataAccessFactory.DoctorAppoinmentDataAccess().Delete(id);
        }
    }
}
