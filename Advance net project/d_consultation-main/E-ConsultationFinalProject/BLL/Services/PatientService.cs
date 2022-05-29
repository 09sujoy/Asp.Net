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

    public class PatientService
    {
        public static List<PatientModel> Get()
        {
            List<PatientModel> data = new List<PatientModel>();
            var p = DataAccessFactory.PatientDataAccess().Get().Where(x=>x.isdeleted == 0);
            foreach(var u in p)
            {
                data.Add(new PatientModel()
                {
                    p_id = u.p_id,
                    p_sickness_reason = u.p_sickness_reason,
                    p_diagnostics_info = u.p_diagnostics_info,
                    user = new userModel()
                    {
                        u_name = u.user.u_name,
                        u_username = u.user.u_username,
                        u_password = u.user.u_password,
                        u_address = u.user.u_address,
                        u_email = u.user.u_email,
                        u_phone = u.user.u_phone,
                        u_nid = u.user.u_nid,
                        u_category = u.user.u_category,
                        u_status = u.user.u_status
                    },
                    doc_appoinment = new DoctorAppoinmentModel()
                    {
                        app_id = u.doc_appoinment.app_id,
                        app_fee = u.doc_appoinment.app_fee,
                        app_status = u.doc_appoinment.app_status,
                        doctor_schedule = new DoctorSheduleModel()
                        {
                            schedule_day = u.doc_appoinment.doctor_schedule.schedule_day,
                            schedule_starting_time = u.doc_appoinment.doctor_schedule.schedule_starting_time,
                            schedule_ending_time = u.doc_appoinment.doctor_schedule.schedule_ending_time,
                            doctor_info = new DoctorInfoModel()
                            {
                                did = u.doc_appoinment.doctor_schedule.doctor_info.did,
                                d_degree = u.doc_appoinment.doctor_schedule.doctor_info.d_degree,
                                d_govid = u.doc_appoinment.doctor_schedule.doctor_info.d_govid,
                                d_speciality = u.doc_appoinment.doctor_schedule.doctor_info.d_speciality,
                                user = new userModel()
                                {
                                    u_name = u.doc_appoinment.doctor_schedule.doctor_info.user.u_name,
                                    u_username = u.doc_appoinment.doctor_schedule.doctor_info.user.u_username,
                                    u_password = u.doc_appoinment.doctor_schedule.doctor_info.user.u_password,
                                    u_address = u.doc_appoinment.doctor_schedule.doctor_info.user.u_address,
                                    u_email = u.doc_appoinment.doctor_schedule.doctor_info.user.u_email,
                                    u_phone = u.doc_appoinment.doctor_schedule.doctor_info.user.u_phone,
                                    u_nid = u.doc_appoinment.doctor_schedule.doctor_info.user.u_nid,
                                    u_category = u.doc_appoinment.doctor_schedule.doctor_info.user.u_category,
                                    u_status = u.doc_appoinment.doctor_schedule.doctor_info.user.u_status
                                }
                            }
                        }
                    }
                    
                });
            }
            return data;

        }
        public static void DeletePatientCon(int id)
        {
            patient p = new patient()
            {
                isdeleted = 1,
               p_id = id
            };
            DataAccessFactory.PatientDataAccess().EditDelete(p);
        }
        public static void Add(PatientModel model)
        {
            patient p = new patient() { 
                p_sickness_reason = model.p_sickness_reason,
                p_diagnostics_info = model.p_diagnostics_info,
                u_id = model.u_id,
                app_id = model.app_id,
                isdeleted =0,
                status ="Pending"
            };
            DataAccessFactory.PatientDataAccess().Add(p);
        }
        
    }
}
