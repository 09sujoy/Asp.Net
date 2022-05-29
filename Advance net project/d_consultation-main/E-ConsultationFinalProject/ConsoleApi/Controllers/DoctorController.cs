using BLL.Entity;
using BLL.Services;
using ConsoleApi.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ConsoleApi.Controllers
{
    [DoctorAccess]
    public class DoctorController : ApiController
    {
        //ok  shows all doctors of the system
        [Route("api/Doctor/Get")]
        public HttpResponseMessage Get()
        {
            var data = AllUserService.Get().Where(x=>x.u_category=="Doctor");
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "User Empty");
        }

        //ok  user add to the system

        [Route("api/Doctor/Add")]
        [HttpPost]
        public HttpResponseMessage Add(userModel u)
        {
            AllUserService.Add(u);
            return Request.CreateResponse("User Successsfully Added");
        }


        //ok  shows all doctors of the system

        [Route("api/Doctor/GetDoctor")]
        public HttpResponseMessage GetDoctor()
        {
            var data = DoctorInfoService.Get();

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }






     //ok

        [Route("api/Doctor/EditDoctor/{id}")]
        [HttpPost]
        public HttpResponseMessage EditDoctor(DoctorInfoModel model, int id)
        {
           DoctorInfoService.Edit(model, id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }




    //ok
       
        [Route("api/Doctor/Consultation_StatusChange/{id}")]
        [HttpPost]
        public HttpResponseMessage Consultation_StatusChange(ConsultationModel u, int id)
        {
            ConsultationService.EditConsultationStatus(u, id);
            return Request.CreateResponse("Successfuly Status Changed");
        }



    //ok
        [Route("api/Doctor/SearchPatient")]
        [HttpPost]
        public HttpResponseMessage SearchPatient(ConsultationModel model)
        {
            var data = ConsultationService.SearchPatient(model);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

//ok

//search shedule 
        [Route("api/Doctor/Searchshedule")]
        [HttpPost]
        public HttpResponseMessage Searchshedule(DoctorSheduleModel model)
        {
            var data = ConsultationService.Searchshedule(model);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //ok
        //search patient per day
        [Route("api/Doctor/SearchPatientperDay/{id}")]
        [HttpPost]
        public HttpResponseMessage SearchPatientperDay(Date_StatusModel obj,int id)
        {
            var data = ConsultationService.SearchPatientperDay(obj,id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }





        //write prescriptions

        [Route("api/Doctor/write_prescription/{id}")]
        [HttpPost]
        public HttpResponseMessage write_prescription(PrescriptionModel prescription,int id)
        {
           




            PrescriptionService.write_prescription(prescription,id);
            return Request.CreateResponse("presctiption added  Successsfully Added");


        }



        [Route("api/Doctor/prescription_history/{id}")]
        [HttpGet]
        public HttpResponseMessage prescription_history(int id)
        {





            var data = PrescriptionService.prescription_history(id);
            return Request.CreateResponse(data);


        }






    }
}
