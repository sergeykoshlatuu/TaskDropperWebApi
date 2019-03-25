using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web.Http;
using ItemWebApi.Jwt;
using ItemWebApi.Models;
using Microsoft.IdentityModel.Tokens;

namespace ItemWebApi.Controllers
{
    public class TokenController : ApiController
    {

        private TaskItemContext db;

        public TokenController(TaskItemContext context)
        {
            this.db = context;
        }
        [AllowAnonymous]
        public string Get(string email, string token)
        {
            if (CheckUser(email, token))
            {
                return JwtManager.GenerateToken(email);
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        public bool CheckUser(string email, string token)
       {
            if (email == null || token == null || email == "") return false;

            if (db.People.Where(x => x.Email == email).ToList() != null) return true;

            Person person = new Person { Id = 0, Email = email, Token = token };
            db.People.Add(person);
            db.SaveChanges();
            return true;
           
        }
    }
}