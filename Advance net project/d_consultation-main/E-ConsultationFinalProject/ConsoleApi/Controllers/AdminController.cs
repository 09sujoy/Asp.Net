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
    [AdminAccess]
    public class AdminController : ApiController
    {
      
        [Route("api/Admin/Get")]
        public HttpResponseMessage Get()
        {
            var data = AllUserService.Get();
           if(data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "User Empty");
        }
        [Route("api/Admin/SearchUser")]
        [HttpPost]
        public HttpResponseMessage SearchUser(userModel model)
        {
            var data = AllUserService.SearchUser(model);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Admin/Add")]
        [HttpPost]
        public HttpResponseMessage Add(userModel u)
        {
            AllUserService.Add(u);
            return Request.CreateResponse("User Successsfully Added");
        }

        [Route("api/Admin/EditUser/{id}")]
        [HttpPost]
        public HttpResponseMessage EditUser(userModel u, int id)
        {
            AllUserService.EditUser(u, id);
            return Request.CreateResponse("Successfuly User Information Edited");
        }

        [Route("api/Admin/GetDoctor")]
        public HttpResponseMessage GetDoctor()
        {
            var data = DoctorInfoService.Get();
            
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/Admin/DoctorInfoEdit/{id}")]
        [HttpPost]
        public HttpResponseMessage DoctorInfoEdit(DoctorInfoModel model,int id)
        {
            DoctorInfoService.Edit(model, id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("api/Admin/GetRequestedDoctor")]
        public HttpResponseMessage GetRequestedDoctor()
        {
            var data = DoctorInfoService.GetRequestedDoctor();
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse("User Empty");
        }

        [Route("api/Admin/UStatusChange/{id}")]
        [HttpPost]
        public HttpResponseMessage UStatusChange(userModel u, int id)
        {
            AllUserService.EditUserStatus(u, id);
            return Request.CreateResponse("Successfuly Status Changed");
        }

        [Route("api/Admin/GetBanRequest")]
      
        public HttpResponseMessage GetBanRequest()
        {
            var data = BanService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

       
       

        [Route("api/Admin/DeleteUser/{id}")]
        [HttpPost]
        public HttpResponseMessage DeleteUser(int id)
        {
            AllUserService.EditDelete(id);
            return Request.CreateResponse("Successfuly User Deleted");
        }

        

        [Route("api/Admin/CheckConsultation")]
        [HttpGet]
        public HttpResponseMessage CheckConsultation()
        {
            var data = PatientService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/Admin/DeleteConsultation/{id}")]
        [HttpPost]
        public HttpResponseMessage DeleteConsultation(int id)
        {
             PatientService.DeletePatientCon(id);

            return Request.CreateResponse("Successfuly Consultation Removed");
            
        }

    }
}
