using ItemWebApi.Interfaces;
using ItemWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemWebApi.Services
{
    public class PeopleService : IDisposable
    {
        private TaskItemContext db = new TaskItemContext();
        private IPeopleRepositiry<Person> _peopleRepositiry;

        public PeopleService(IPeopleRepositiry<Person> peopleRepositiry)
        {
            _peopleRepositiry = peopleRepositiry;
        }


       

        public string Get(string email,string token)
        {
            return _peopleRepositiry.Get(email,token);
        }
        public string RefreshToken(string oldToken,string email)
        {
           return _peopleRepositiry.RefreshToken(oldToken,email);
        }
        

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}