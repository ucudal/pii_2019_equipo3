<<<<<<< HEAD
using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesIgnis.Models
{
    public abstract class Person
    {
        public Person(string nombre, int edad, string mail, string contraseña)
        {
            this.Nombre = nombre;
            this.Edad = edad;
            this.Mail = mail;
            this.Contraseña = contraseña;
        }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Mail { get; set; }
        public string Contraseña { get; set; }
    }
=======
using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesIgnis.Models
{
    public abstract class Person
    {
        public Person(string nombre, int edad, string mail, string contraseña)
        {
            this.Nombre = nombre;
            this.Edad = edad;
            this.Mail = mail;
            this.Contraseña = contraseña;
        }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Mail { get; set; }
        public string Contraseña { get; set; }
    }
>>>>>>> master
}