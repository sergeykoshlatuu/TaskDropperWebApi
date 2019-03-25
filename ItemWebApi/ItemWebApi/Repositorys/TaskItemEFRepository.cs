using ItemWebApi.Interfaces;
using ItemWebApi.Jwt;
using ItemWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace ItemWebApi.Repositorys
{
    public class TaskItemEFRepository : ITaskItemRepository<TaskItem>
    {
        private TaskItemContext db;

        public TaskItemEFRepository(TaskItemContext context)
        {
            this.db = context;
        }



        public IEnumerable<TaskItem> GetAllByEmail(string id)
        {
            return db.TaskItems.Where(x => x.UserEmail == id).ToList();
        }

        public TaskItem Get(int id)
        {
            return db.TaskItems.Find(id);
        }

        public void Create(TaskItem task)
        {
            db.TaskItems.Add(task);
            db.SaveChanges();
        }

        public void Update(int id, TaskItem task)
        {
            db.Entry(task).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            TaskItem task = db.TaskItems.Find(id);
            if (task != null)
                db.TaskItems.Remove(task);
            db.SaveChanges();
        }

       
    }

    
}