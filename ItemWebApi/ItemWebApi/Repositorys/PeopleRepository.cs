using ItemWebApi.Interfaces;
using ItemWebApi.Jwt;
using ItemWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemWebApi.Repositorys
{
    public class PeopleRepository : IPeopleRepositiry<Person>
        {
            private TaskItemContext db;

            public PeopleRepository(TaskItemContext context)
            {
                this.db = context;
            }

        public string Get(string email, string token)
        {
            if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(token)) return null;

            List<Person> people = db.People.Where(x => x.Email == email).ToList();

            if (people.Count != 0)
            {
                if (people[0].TokenLifeTime < DateTime.Now)
                {
                    people[0].ApiToken = JwtManager.GenerateToken(email);
                    people[0].TokenLifeTime = DateTime.Now.AddMinutes(20);
                }
                return people[0].ApiToken;
            }

            Person person = new Person();
            person.Email = email;
            person.Token = token;
            person.ApiToken = JwtManager.GenerateToken(email);
            person.TokenLifeTime = DateTime.Now.AddMinutes(20);
            db.People.Add(person);

            db.SaveChanges();
            return person.ApiToken;
        }

        public string RefreshToken(string oldToken,string email)
        {
            List<Person> people = db.People.Where(x => x.Email == email).ToList();
            if (people.Count != 0)
            {
                people[0].ApiToken = JwtManager.GenerateToken(email);
                people[0].TokenLifeTime = DateTime.Now.AddMinutes(20);
                return people[0].ApiToken;
            }
            return oldToken;
        }
    }

}
