using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesIgnis.Models
{
    public abstract class Person
    {
        public Person(string name, int age, string mail, string password)
        {
            this.Name = name;
            this.Age = age;
            this.Mail = mail;
            this.Password = password;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}