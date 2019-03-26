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
using ItemWebApi.Jwt.Filters;
using ItemWebApi.Models;
using ItemWebApi.Services;
using Microsoft.IdentityModel.Tokens;

namespace ItemWebApi.Controllers
{
    public class TokenController : ApiController
    {
        PeopleService peopleService;

        public TokenController(IPeopleRepositiry<Person> peopleRepositiry)
        {
            peopleService = new PeopleService(peopleRepositiry);
        }

        [AllowAnonymous]
        public string Get(string email, string token)
        {
           return peopleService.Get(email, token);
        }

        [JwtAuthentication]
        [HttpGet]
        public string RefreshToken(string oldToken,string email)
        {
            return peopleService.RefreshToken(oldToken,email);
        }

    }
}