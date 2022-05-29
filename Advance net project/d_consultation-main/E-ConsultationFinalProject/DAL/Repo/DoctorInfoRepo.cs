using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class DoctorInfoRepo : IRepository<doctor_info, int>
    {
        dpconsultationEntities db;
        public DoctorInfoRepo(dpconsultationEntities db)
        {
            this.db = db;
        }
        public bool Add(doctor_info obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(doctor_info dr)
        {
            var d = db.doctor_info.FirstOrDefault(x => x.did == dr.did);

            d.d_govid = dr.d_govid;
            d.d_degree = dr.d_degree;
            d.d_speciality = dr.d_speciality;


            if (db.SaveChanges() != 0)
            {
                this.EditStatus(d);
                return true;
            }
            return false;
        }

        public bool EditDelete(doctor_info obj)
        {
            throw new NotImplementedException();
        }

        public bool EditStatus(doctor_info obj)
        {
            var d = db.users.FirstOrDefault(x => x.u_id == obj.u_id);
            d.u_status = "Requested";

            if (db.SaveChanges() != 0)
            {

                return true;
            }


            return false;
        }

        public doctor_info Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<doctor_info> Get()
        {
            return db.doctor_info.ToList();
        }
    }
}
