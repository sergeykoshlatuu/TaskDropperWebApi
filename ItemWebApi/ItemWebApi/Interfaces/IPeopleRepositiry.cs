using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemWebApi.Interfaces
{
   public interface IPeopleRepositiry<T> where T : class
        {
           
            string Get(string email,string token);
        string RefreshToken(string oldToken,string email);
        }
}

