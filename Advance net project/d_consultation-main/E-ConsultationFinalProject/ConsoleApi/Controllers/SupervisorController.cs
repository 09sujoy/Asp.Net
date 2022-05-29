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
    [SupervisorAccess]
    public class SupervisorController : ApiController
    {
        [Route("api/Supervisor/GetSchedule")]
        
        public HttpResponseMessage GetSchedule()
        {
            var data = doctor_schedule_service.GetSchedule();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Supervisor/GetSchedule/{id}")]

        public HttpResponseMessage GetSchedule(int id)
        {
            var data = doctor_schedule_service.GetSchedule(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/Supervisor/AddSchedule")]
        [HttpPost]
        public HttpResponseMessage AddSchedule(DoctorSheduleModel ds)
        {
            doctor_schedule_service.AddSchedule(ds);
            return Request.CreateResponse("Schedule Successsfully Added");
        }
        [Route("api/Admin/EditSchedule/{id}")]
        [HttpPost]
        public HttpResponseMessage EditSchedule(DoctorSheduleModel model, int id)
        {
            doctor_schedule_service.Editschedule(model, id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [Route("api/Supervisor/DeleteSchedule/{id}")]
        [HttpPost]
        public HttpResponseMessage DeleteSchedule(int id)
        {
            doctor_schedule_service.DeleteSchedule(id);
            return Request.CreateResponse("Successfuly User Deleted");
        }
        [Route("api/Supervisor/CheckConsultation")]
        [HttpGet]
        public HttpResponseMessage CheckConsultation()
        {
            var data = PatientService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Supervisor/Addban")]
        [HttpPost]
        public HttpResponseMessage Addban(BanModel bn)
        {
            BanService.Add(bn);
            return Request.CreateResponse("Ban request send to Admin");
        }

        [Route("api/Admin/EditBan/{id}")]
        [HttpPost]
        public HttpResponseMessage EditBan(BanModel model, int id)
        {
            BanService.Editban(model, id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("api/Supervisor/DeleteSchedule/{id}")]
        [HttpPost]
        public HttpResponseMessage Deleteban(int id)
        {
            BanService.Deleteban(id);
            return Request.CreateResponse("Successfuly Banned Deleted");
        }

        [Route("api/Supervisor/Getappointment/{id}")]
        public HttpResponseMessage Getappointment(int id)
        {
            var data = DoctorAppoinmentService.GetSupervisorAppoinmentofPatient(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/Supervisor/Getappointmentlist")]
        public HttpResponseMessage Getappointmentlist()
        {
            var data = DoctorAppoinmentService.Getappointmentlistofpatient();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/Admin/Editappointment/{id}")]
        [HttpPost]
        public HttpResponseMessage Editappointment(DoctorAppoinmentModel model, int id)
        {
            DoctorAppoinmentService.Editappointment(model, id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("api/Supervisor/Deleteappoinment/{id}")]
        [HttpPost]
        public HttpResponseMessage Deleteappoinment (int id)
        {
            DoctorAppoinmentService.Deleteappointment(id);
            return Request.CreateResponse("Successfuly appointment Deleted");
        }
        [Route("api/Supervisor/Addappointment")]
        [HttpPost]
        public HttpResponseMessage Addappointment(DoctorAppoinmentModel ds)
        {
            DoctorAppoinmentService.Addappointment(ds);
            return Request.CreateResponse("Appointment Successsfully Added");
        }
    }
}
