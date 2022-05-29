using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{


    public class ConsultationRepo : IRepository<patient, int>
    {
        dpconsultationEntities db;
        public ConsultationRepo(dpconsultationEntities db)
        {
            this.db = db;
        }
        public bool Add(patient obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(patient obj)
        {

            var patient = db.patients.FirstOrDefault(x => x.u_id == obj.p_id);
            patient.p_sickness_reason = obj.p_sickness_reason;
            patient.p_diagnostics_info = obj.p_diagnostics_info;
            patient.u_id = obj.u_id;
            patient.app_id = obj.app_id;
            patient.isdeleted = obj.isdeleted;
            patient.status = "accept";
           

            if (db.SaveChanges() != 0)
            {
                return true;
            }
            return false;




        }

        public bool EditDelete(patient obj)
        {
            /*
             var data = db.patients.FirstOrDefault(x => x.p_id == obj.p_id);
             data.isdeleted = obj.isdeleted;
             if (db.SaveChanges() != 0)
             {
                 return true;
             }
             return false;

             */

            throw new NotImplementedException();

        }

        public bool EditStatus(patient obj)
        {

            var p = db.patients.FirstOrDefault(x => x.p_id == obj.p_id);
       

           
            p.status = obj.status;



            if (db.SaveChanges() != 0)
            {
                return true;
            }
            return false;
        }




     







        public patient Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<patient> Get()
        {
            return db.patients.ToList();
        }
    }

}
