
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




    public class ConsultationService
    {
        public static List<ConsultationModel> Get()
        {
            List<ConsultationModel> data = new List<ConsultationModel>();

            var consultations = DataAccessFactory.ConsultationDataAccess().Get().Where(x => x.isdeleted == 0);

            foreach (var u in consultations)
            {
                data.Add(new ConsultationModel()
                {
                    p_id = u.p_id,
                    p_sickness_reason = u.p_sickness_reason,
                    p_diagnostics_info = u.p_diagnostics_info,
                    consultation_status = u.status,
                    isdeleted = u.isdeleted,

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





        public static void Edit(ConsultationModel u, int id)
        {
            patient d = new patient()
            {
                p_id = u.p_id,
                p_sickness_reason = u.p_sickness_reason,
                p_diagnostics_info = u.p_diagnostics_info,
                u_id = u.u_id,
                app_id = u.app_id,
                isdeleted = u.isdeleted,
                status = "accepting"



            };
            DataAccessFactory.ConsultationDataAccess().Edit(d);

        }



        public static void EditConsultationStatus(ConsultationModel u, int id)
        {
            patient data = new patient()
            {
                status = u.consultation_status,
                p_id = id
            };
            DataAccessFactory.ConsultationDataAccess().EditStatus(data);
        }






        public static List<ConsultationModel> SearchPatient(ConsultationModel model)

        {

            if (model.consultation_status == null) model.consultation_status = "";

            var patient = DataAccessFactory.ConsultationDataAccess().Get().Where(x => (x.status.Contains(model.consultation_status)));
            List<ConsultationModel> data = new List<ConsultationModel>();
            foreach (var u in patient)
            {
                data.Add(new ConsultationModel()
                {



                    p_id = u.p_id,
                    p_sickness_reason = u.p_sickness_reason,
                    p_diagnostics_info = u.p_diagnostics_info,
                    u_id = u.u_id,
                    app_id = u.app_id,
                    isdeleted = u.isdeleted,
                    consultation_status = u.status



                });
            }
            return data;
        }



        //search shedule 

        public static List<DoctorSheduleModel> Searchshedule(DoctorSheduleModel model)

        {


            //  if (model.consultation_status == null) model.consultation_status = "";
            var day = DataAccessFactory.DoctorSheduleDataAccess().Get().Where(x => x.schedule_day.ToString().Contains(model.schedule_day.ToString())).ToList();

            List<DoctorSheduleModel> data = new List<DoctorSheduleModel>();
            foreach (var u in day)
            {
                data.Add(new DoctorSheduleModel()
                {


                    /*
                                        p_id = u.p_id,
                                        p_sickness_reason = u.p_sickness_reason,
                                        p_diagnostics_info = u.p_diagnostics_info,
                                        u_id = u.u_id,
                                        app_id = u.app_id,
                                        isdeleted = u.isdeleted,
                                        consultation_status = u.consultation_status
                    */


                    schedule_id = u.schedule_id,

                    schedule_day = u.schedule_day,
                    schedule_starting_time = u.schedule_starting_time,
                    schedule_ending_time = u.schedule_ending_time,
                    did = u.did,
                    //   "doctor_info": null
                    doctor_info = new DoctorInfoModel()
                    {
                        did = u.doctor_info.did,
                        d_degree = u.doctor_info.d_degree,
                        d_govid = u.doctor_info.d_govid,
                        d_speciality = u.doctor_info.d_speciality,
                        user = new userModel()
                        {
                            u_name = u.doctor_info.user.u_name,
                            u_username = u.doctor_info.user.u_username,

                            u_address = u.doctor_info.user.u_address,
                            u_email = u.doctor_info.user.u_email,
                            u_phone = u.doctor_info.user.u_phone,
                            u_nid = u.doctor_info.user.u_nid,
                            u_category = u.doctor_info.user.u_category,
                            u_status = u.doctor_info.user.u_status,
                            isdeleted = u.doctor_info.user.isdeleted
                        }
                    }

                });
            }
            return data;
        }








        public static List<PatientModel> SearchPatientperDay(Date_StatusModel ds, int id)

        {
            ConsultationModel obj;
            DoctorSheduleModel model;

            //  if (model.consultation_status == null) model.consultation_status = "";


            //var day = DataAccessFactory.DoctorSheduleDataAccess().Get().Where(x => x.schedule_day.ToString().Contains(ds.schedule_day.ToString())).ToList();

            //var patients = DataAccessFactory.ConsultationDataAccess().Get().Where(x => x.status.Contains(ds.consultation_status)).ToList();

            var patient_shedule = DataAccessFactory.PatientDataAccess().Get().Where(x => x.doc_appoinment.doctor_schedule.schedule_day.ToString().Contains(ds.schedule_day.ToString())).ToList(); ;


            //var user = DataAccessFactory.DoctorSheduleDataAccess().Get().Where(x => (x.u_status.Contains(model.u_status)) && x.u_category.Contains(model.u_category));


            List<PatientModel> data = new List<PatientModel>();
            foreach (var u in patient_shedule)
            {
                if (u.doc_appoinment.doctor_schedule.did.Equals(id) && u.status.Equals(ds.consultation_status))
                {
                    data.Add(new PatientModel()
                    {



                        p_id = u.p_id,
                        p_sickness_reason = u.p_sickness_reason,
                        p_diagnostics_info = u.p_diagnostics_info,
                        u_id = u.u_id,
                        app_id = u.app_id,
                        //   isdeleted = u.isdeleted,
                        status = u.status,
                        user = new userModel()
                        {
                            u_name = u.user.u_name,
                            u_username = u.user.u_username,

                            u_address = u.user.u_address,
                            u_email = u.user.u_email,
                            u_phone = u.user.u_phone,
                            u_nid = u.user.u_nid,
                            u_category = u.user.u_category,
                            u_status = u.user.u_status,
                            isdeleted = u.user.isdeleted
                        }



                    });

                }

            }
            return data;
        }








        /*
          public static List<ConsultationModel> GetRequestedDoctor()
          {
              List<ConsultationModel> data = new List<ConsultationModel>();
              var user = DataAccessFactory.DoctorInfoDataAccess().Get().Where(x => x.isdeleted == 0 && (x.user.u_status == "Pending" || x.user.u_status == "Requested"));
              foreach (var u in user)
              {
                  data.Add(new ConsultationModel()
                  {
                      d_govid = u.d_govid,
                      d_degree = u.d_degree,
                      d_speciality = u.d_speciality,
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

                      }

                  });
              }
              return data;

          }


          */
    }
}