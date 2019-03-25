using ItemWebApi.Interfaces;
using ItemWebApi.Models;
using ItemWebApi.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;
using ItemWebApi.Jwt.Filters;


namespace ItemWebApi.Controllers
{
    public class TaskController : ApiController
    {
        ItemTaskService taskService;
       

        public TaskController(ITaskItemRepository<TaskItem> taskItemRepository)
        {

            taskService = new ItemTaskService(taskItemRepository);
           
        }

        [JwtAuthentication]
        // GET api/task/5
        public IEnumerable<TaskItem> GetTaskItem(string id)
        {
                var taskItem = taskService.GetAllByEmail(id);
                return taskItem;
        }

        [JwtAuthentication]
        [HttpPost]
        // POST api/task
        public void CreateTask([FromBody]TaskItem taskItem)
        {
            taskService.Create(taskItem);
            taskService.Save();
        }

        [JwtAuthentication]
        [HttpPut]
        // PUT api/task/5
        public void UpdateTask(int id, [FromBody]TaskItem taskItem)
        {
            taskService.Update(id,taskItem);
            taskService.Save();
        }

        [JwtAuthentication]
        [HttpDelete]
        // DELETE api/task/5
        public void DeleteTask(int id)
        {
            taskService.Delete(id);
            taskService.Save();
        }
    
}
}
