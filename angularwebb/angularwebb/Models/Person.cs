using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace angularwebb.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
    }
}