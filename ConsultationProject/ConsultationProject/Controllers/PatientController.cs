using ConsultationProject.Models.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsultationProject.Controllers
{
    public class PatientController : Controller
    {
        econsultationEntities db = new econsultationEntities();
        [AllowAnonymous]
        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AppointmentList()
        {
            econsultationEntities db = new econsultationEntities();
            appointment obj = new appointment();


            return View(db.appointments.ToList());
        }
        public ActionResult Request_sent (int id)
        {
            var drValue = db.appointments.Where(l => l.ap_id.Equals(id)).FirstOrDefault();

            drValue.ap_status = "Request sent";
            db.Entry(drValue).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AppointmentList");
        }
        public ActionResult Cancel_request (int id)
        {
            var drValue = db.appointments.Where(l => l.ap_id.Equals(id)).FirstOrDefault();

            drValue.ap_status = "Request";
            db.Entry(drValue).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AppointmentList");
        }
        public ActionResult schedule()
        {
            econsultationEntities db = new econsultationEntities(); 
            

            return View(db.doctor_schedule.ToList());
        }
    }
}