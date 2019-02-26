using ItemWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ItemWebApi.Interfaces
{
    public interface ITaskItemRepository<T> where T : class
    {
        IEnumerable<T> GetAllByEmail(string id);
        T Get(int id);
        void Create(T item);
        void Update(int id,T item);
        void Delete(int id);
    }

    
}