using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using ItemWebApi.Interfaces;
using ItemWebApi.Jwt;
using ItemWebApi.Models;
using ItemWebApi.Services;
using Microsoft.IdentityModel.Tokens;

namespace ItemWebApi.Controllers
{
    public class TokenController : ApiController
    {
        TaskItemContext db;

        public TokenController(ITaskItemRepository<TaskItem> taskItemRepository)
        {

           var taskService = new ItemTaskService(taskItemRepository);
            db = taskService.GetContext();
        }

        [AllowAnonymous]
        public string Get(string email, string token)
        {
            if (CheckUserAsync(email, token))
            {
                List<Person> people = db.People.Where(x => x.Email == email).ToList();
                return people[0].ApiToken;

            }
            throw new HttpResponseException(HttpStatusCode.Unauthorized);

        }

        public string RefreshToken(string oldToken)
        {
            List<Person> people = db.People.Where(x => x.Token == oldToken).ToList();
            people[0].ApiToken= JwtManager.GenerateToken(oldToken);
            return people[0].ApiToken;
        }

        public bool CheckUserAsync(string email, string token)
        {
            if (email == null || token == null || email == "") return false;

            List<Person> people = db.People.Where(x => x.Email == email).ToList();
            if (people.Count != 0) return true;
            Person person = new Person();
            person.Email = email;
            person.Token = token;
            person.ApiToken=JwtManager.GenerateToken(email);
            db.People.Add(person);

            db.SaveChanges();
            return true;

        }


    }
}