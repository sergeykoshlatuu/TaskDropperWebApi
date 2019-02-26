using System.Collections.Generic;
using System.Data;
using ItemWebApi.Models;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using ItemWebApi.Interfaces;
using Dapper;

namespace ItemWebApi.Repositorys
{
    public class TaskDapperRepository : ITaskItemRepository<TaskItem>
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Context"].ConnectionString;

        public TaskDapperRepository(TaskItemContext context)
        {
           
        }
        public IEnumerable<TaskItem> GetAllByEmail(string id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<TaskItem>("SELECT * FROM TaskItems WHERE UserEmail =@id", new { id });
            }
        }

        public TaskItem Get(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<TaskItem>("SELECT * FROM TaskItems WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(TaskItem item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO TaskItems ( UserId,Title,Description,Status,PhotoTask,UserEmail)" +
                    " VALUES( @UserId, @Title, @Description, @Status, @PhotoTask, @UserEmail); SELECT CAST(SCOPE_IDENTITY() as int)";
                int userId = db.Query<int>(sqlQuery, item).First();
                item.Id = userId;
            }
        }

        public void Update(int id,TaskItem item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE TaskItems SET UserId = @UserId, Title = @Title, Description = @Description, Status = @Status, PhotoTask = @PhotoTask, UserEmail = @UserEmail  WHERE Id = @Id";
                db.Execute(sqlQuery, item);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM TaskItems WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}