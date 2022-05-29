using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    
    public class PrescriptionRepo : IRepository<prescription, int>
    {
        public dpconsultationEntities db;
        public PrescriptionRepo(dpconsultationEntities db)
        {
            this.db = db;
        }
        public bool Add(prescription obj)
        {
            db.prescriptions.Add(obj);
            if (db.SaveChanges() != 0)
            {
                return true;
            }
            return false;

        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(prescription obj)
        {
            throw new NotImplementedException();
        }

        public bool EditDelete(prescription obj)
        {
            throw new NotImplementedException();
        }

        public bool EditStatus(prescription obj)
        {
            throw new NotImplementedException();
        }

        public prescription Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<prescription> Get()
        {
            return db.prescriptions.ToList();
        }
    }
}
