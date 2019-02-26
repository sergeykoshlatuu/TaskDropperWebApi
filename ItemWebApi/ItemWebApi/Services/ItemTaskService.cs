using ItemWebApi.Interfaces;
using ItemWebApi.Models;
using ItemWebApi.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemWebApi.Services
{
    public class ItemTaskService : IDisposable
    {
        private TaskItemContext db = new TaskItemContext();
        private ITaskItemRepository<TaskItem> _taskItemRepository;

         public ItemTaskService(ITaskItemRepository<TaskItem> taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }


        public IEnumerable<TaskItem> GetAllByEmail(string id)
        {
            return _taskItemRepository.GetAllByEmail(id);
        }

        public TaskItem Get(int id)
        {
            return _taskItemRepository.Get(id);
        }
        public void Create(TaskItem item)
        {
            _taskItemRepository.Create(item);
        }
        public void Update(int id, TaskItem item)
        {
            _taskItemRepository.Update(id, item);
        }
        public void Delete(int id)
        {
            _taskItemRepository.Delete(id);
        }

        public void Save()
        {
            db.SaveChanges();
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