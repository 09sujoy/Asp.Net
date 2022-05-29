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
    [PatientAccess]
    public class PatientController : ApiController
    {
        [Route("api/Patient/GetDoctor")]
        [HttpGet]
        public HttpResponseMessage GetDoctor()
        {
            var data = DoctorInfoService.Get().Where(x=>x.user.u_status != "Banned");
            foreach(var d in data)
            {
                d.user.u_address = "";
                d.user.u_email = "";
                d.user.u_password = "";
                d.user.u_phone = 0;
                d.user.u_username = "";
                d.user.u_nid = 0;
                d.user.u_status = "";
                
          
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/Patient/GetDoctorSheduleForPatient/{id}")]
        [HttpGet]
        public HttpResponseMessage GetDoctorSheduleForPatient(int id)
        {
            var data = doctor_schedule_service.GetDoctorSheduleForPatient(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Patient/GetDoctorAppoinment/{id}")]
        [HttpGet]
        public HttpResponseMessage GetDoctorAppoinment(int id)
        {
            var data = DoctorAppoinmentService.GetDoctorAppoinmentForPatient(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Patient/AddConsultation")]
        [HttpPost]
        public HttpResponseMessage AddConsultation(PatientModel p)
        {
            PatientService.Add(p);
            return Request.CreateResponse(HttpStatusCode.OK,"Successfuly Consultation Created");
        }

        [Route("api/Patient/DeleteConsultation/{id}")]
        [HttpPost]
        public HttpResponseMessage DeleteConsultation(int id)
        {
            PatientService.DeletePatientCon(id);

            return Request.CreateResponse("Successfuly Consultation Removed");

        }


      /*  [Route("api/Patient/GetConsultation")]
        [HttpGet]
        public HttpResponseMessage GetConsultation()
        {
            var data = PatientService.Get();

            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
      */
        [Route("api/Patient/GetPrescription/{id}")]
        [HttpGet]
        public HttpResponseMessage GetPrescription(int id)
        {
          var data=   PrescriptionService.GetPrescription(id);

            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
    }
}
