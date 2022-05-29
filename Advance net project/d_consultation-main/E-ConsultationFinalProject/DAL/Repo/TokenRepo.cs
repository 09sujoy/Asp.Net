using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class TokenRepo : IRepository<Token, string>, IAuth<Token>
    {
       public dpconsultationEntities db;
        public TokenRepo(dpconsultationEntities db)
        {
            this.db = db;
        }

        public bool Add(Token obj)
        {
            db.Tokens.Add(obj);
            if(db.SaveChanges() != 0)
            {
                return true;
            }
            return false;
        }

        public Token Authenticate(string uname, string upass)
        {
            var data = db.users.FirstOrDefault(x => x.u_name == uname && x.u_password == upass);
            Token t = null;
            if(data != null)
            {
                t = new Token()
                {
                    accesstoken = Guid.NewGuid().ToString(),
                    createdat = DateTime.Now,
                    expireat = null,
                    u_id = data.u_id

                };
              if (this.Add(t)) return t;

            }
            return null;
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Token obj)
        {
            throw new NotImplementedException();
        }

        public bool EditDelete(Token obj)
        {
            throw new NotImplementedException();
        }

        public bool EditStatus(Token obj)
        {
            throw new NotImplementedException();
        }

        public Token Get(string key)
        {
            return db.Tokens.FirstOrDefault(x => x.accesstoken == key && (x.user.u_status == "Active" || x.user.u_status == "Requested"));
        }

        public List<Token> Get()
        {
            throw new NotImplementedException();
        }
    }
}
