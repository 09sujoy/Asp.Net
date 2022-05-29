using econsult.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace econsult.Controllers
{
    public class PatientController : Controller
    {
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

        
    }
}