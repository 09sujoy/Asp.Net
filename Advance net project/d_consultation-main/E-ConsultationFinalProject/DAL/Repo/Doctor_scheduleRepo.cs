using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class Doctor_scheduleRepo : IRepository<doctor_schedule, int>
    {
        dpconsultationEntities db;
        public Doctor_scheduleRepo(dpconsultationEntities db)
        {
            this.db = db;
        }
        public bool Add(doctor_schedule obj)
        {
            db.doctor_schedule.Add(obj);
            if (db.SaveChanges() != 0)
            {
                return true;
            }
            return false;

        }

        public bool Delete(int id)
        {
            var schedule = db.doctor_schedule.FirstOrDefault(x => x.schedule_id == id);
            db.doctor_schedule.Remove(schedule);
            if (db.SaveChanges() != 0)
            {
                return true;
            }
            return false;
        }

        public bool Edit(doctor_schedule obj)
        {

            var ds = db.doctor_schedule.FirstOrDefault(x => x.schedule_id == obj.schedule_id);
            if (db.SaveChanges() != 0)
            {
                return true;
            }
            return false;
        }

        public bool EditDelete(doctor_schedule obj)
        {
            throw new NotImplementedException();
        }

        public bool EditStatus(doctor_schedule obj)
        {
            throw new NotImplementedException();
        }

        public doctor_schedule Get(int id)
        {
            return db.doctor_schedule.FirstOrDefault(x => x.schedule_id == id);
        }

        public List<doctor_schedule> Get()
        {
            return db.doctor_schedule.ToList() ;
        }
    }
}
