using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class BanRepo : IRepository<ban, int>
    {
        dpconsultationEntities db;
        public BanRepo(dpconsultationEntities db)
        {
            this.db = db;
        }
        public bool Add(ban obj)
        {
            db.bans.Add(obj);
            if (db.SaveChanges() != 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var ban = db.bans.FirstOrDefault(x => x.ban_id == id);
            db.bans.Remove(ban);
            if (db.SaveChanges() != 0)
            {
                return true;
            }
            return false;
        }

        public bool Edit(ban obj)
        {
            var bs = db.bans.FirstOrDefault(x => x.ban_id == obj.ban_id);
            bs.ban_reason = obj.ban_reason;
            bs.ban_duration = obj.ban_duration;
            bs.ban_time = obj.ban_time;

            if (db.SaveChanges() != 0)
            {
                return true;
            }
            return false;
        }

        public bool EditDelete(ban obj)
        {
            throw new NotImplementedException();
        }

        public bool EditStatus(ban obj)
        {
            throw new NotImplementedException();
        }

        public ban Get(int id)
        {
            return db.bans.FirstOrDefault(x => x.ban_id == id);
        }

        public List<ban> Get()
        {
            return db.bans.ToList();
        }
    }
}
