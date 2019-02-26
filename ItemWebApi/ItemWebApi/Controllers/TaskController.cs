using ItemWebApi.Interfaces;
using ItemWebApi.Models;
using ItemWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ItemWebApi.Controllers
{
    public class TaskController : ApiController
    {
        ItemTaskService taskService;

        public TaskController(ITaskItemRepository<TaskItem> taskItemRepository)
        {
            taskService = new ItemTaskService(taskItemRepository);
        }

        [HttpGet]
        // GET api/task/5
        public IEnumerable<TaskItem> GetTaskItem(string id)

        {
            var taskItem = taskService.GetAllByEmail(id);
            return taskItem;
        }

        [HttpPost]
        // POST api/task
        public void CreateTask([FromBody]TaskItem taskItem)
        {
            taskService.Create(taskItem);
            taskService.Save();
        }

        [HttpPut]
        // PUT api/task/5
        public void UpdateTask(int id, [FromBody]TaskItem taskItem)
        {
            taskService.Update(id,taskItem);
            taskService.Save();
        }

        [HttpDelete]
        // DELETE api/task/5
        public void DeleteTask(int id)
        {
            taskService.Delete(id);
            taskService.Save();
        }
    
}
}
