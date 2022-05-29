using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class DoctorAppoinmentRepo : IRepository<doc_appoinment, int>
    {
        public dpconsultationEntities db; 
        public DoctorAppoinmentRepo(dpconsultationEntities db)
        {
            this.db = db;
        }
        public bool Add(doc_appoinment obj)
        {
            db.doc_appoinment.Add(obj);
            if (db.SaveChanges() != 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var appoin = db.doc_appoinment.FirstOrDefault(x => x.app_id == id);
            db.doc_appoinment.Remove(appoin);
            if (db.SaveChanges() != 0)
            {
                return true;
            }
            return false;
        }

        public bool Edit(doc_appoinment obj)
        {
            var appoin = db.doc_appoinment.FirstOrDefault(x => x.app_id == obj.app_id);
            appoin.app_fee = obj.app_fee;
            if (db.SaveChanges() != 0)
            {
                return true;
            }
            return false;
        }

        public bool EditDelete(doc_appoinment obj)
        {
            throw new NotImplementedException();
        }

        public bool EditStatus(doc_appoinment obj)
        {
            throw new NotImplementedException();
        }

        public doc_appoinment Get(int id)
        {
            return db.doc_appoinment.FirstOrDefault(x => x.schedule_id == id);

        }

        public List<doc_appoinment> Get()
        {
            throw new NotImplementedException();
        }
    }
}
