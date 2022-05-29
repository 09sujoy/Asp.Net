using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IAuth<T>
    {
        T Authenticate(string uname, string upass);
    }
}
