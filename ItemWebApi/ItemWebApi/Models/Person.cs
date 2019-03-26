using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ItemWebApi.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string ApiToken { get; set; }
        public DateTime TokenLifeTime { get; set; }
    }
}