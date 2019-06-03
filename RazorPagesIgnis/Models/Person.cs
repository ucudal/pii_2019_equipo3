using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesIgnis.Models
{
    public abstract class Person
    {
       public int ID { set; get; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}