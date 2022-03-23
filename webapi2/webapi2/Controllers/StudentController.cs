using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapi2.Models.Database;

namespace webapi2.Controllers
{
    public class StudentController : ApiController
    {
        StudentEntities db = new StudentEntities();
        [Route("api/Studentcreate/Student")]
        [HttpPost]
        public HttpResponseMessage Studentcreate(student st)
        {
            student obj = new student();
            obj.s_name = st.s_name;
            obj.s_dob = st.s_dob;
            obj.dept_id = st.dept_id;
            db.students.Add(obj);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Successfuly Student Added");

        }
        [Route("api/Studentedit/Student/{id}")]
        [HttpPost]
        public HttpResponseMessage Studentedit(student sn, int id)
        {
            var t = db.students.Where(l => l.s_id.Equals(id)).FirstOrDefault();
            if (t != null)
            {
                t.s_name = sn.s_name;
                t.s_dob = sn.s_dob;
                db.Entry(t).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Students detail modified");
        }
        [Route("api/Studentdelete/Student/{id}")]
        [HttpPost]
        public HttpResponseMessage Studentdelete(int id)
        {
            var d = db.students.Where(l => l.s_id.Equals(id)).FirstOrDefault();
            db.students.Remove(d);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Department deleted");
        }
    }
}
