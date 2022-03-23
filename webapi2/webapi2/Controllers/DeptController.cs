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
    public class DeptController : ApiController
    {
        StudentEntities db = new StudentEntities();
        [Route("api/Deptcreate/create")]
        [HttpPost]
        public HttpResponseMessage Deptcreate(dept dt)
        {
            dept obj = new dept();
            obj.dept_name = dt.dept_name;
            db.depts.Add(obj);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Department Added");
        }
        [Route("api/Deptedit/Dept/{id}")]
        [HttpPost]
        public HttpResponseMessage Deptedit(dept sn, int id)
        {
            var t = db.depts.Where(l => l.dept_id.Equals(id)).FirstOrDefault();
            if (t != null)
            {
                t.dept_name = sn.dept_name;
                db.Entry(t).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Department detail modified");
        }
        [Route("api/Deptdelete/Dept/{id}")]
        [HttpPost]
        public HttpResponseMessage Deptdelete(int id)
        {
            var d = db.depts.Where(l => l.dept_id.Equals(id)).FirstOrDefault();
            db.depts.Remove(d);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Department deleted");
        }




    }
}
