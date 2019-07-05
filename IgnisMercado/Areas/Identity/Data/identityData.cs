using System;
/* 
    En esta clase tiene usuarios con los 3 roles posibles ya creados para
    que se pueda ver las funcionalidades de la appweb.
*/
namespace RazorPagesIgnis.Areas.Identity.Data
{
    public static class IdentityData
    {
        public const string AdminUserName = "admin@ignis.com";

        public const string AdminName = "Administrator";

        public const string AdminMail = "admin@ignis.com";

        public static DateTime AdminDOB = new DateTime(1967, 3, 31);

        public const string AdminPassword = "P@55w0rd";

        public const string AdminRoleName = "Administrator";

        public static string[] NonAdminRoleNames = new string[] { "Client", "Technician" };
    }
    public static class Clients
    {
        public static string[] ClientNames = new string [] {
        "Asuntos estudiantiles (UCU)",
        "Biblioteca (UCU)",
        "FIC (UCU)",
        };
        public static string[] ClientMail = new string [] {
        "asuntosestudiantiles@ignis.com",
        "biblioteca@ignis.com",
        "fic@ignis.com",
        };
        public static DateTime[] ClientDOBs = new DateTime [] {
        DateTime.Parse("1998-10-05"),
        DateTime.Parse("1995-07-08"),
        DateTime.Parse("2000-02-01"),
        };
    }
    public static class Technicians
    {   
        public static string[] TechnicianNames = new string [] 
        {
            "Juan Martinez",
            "Jose Rodriguez",
            "Manuel Garcia"        
        };
        public static string[] TechnicianMail = new string [] 
        {
            "jmartinez@ignis.com",
            "jrodriguez@ignis.com",
            "mgarcia@ignis.com"
        };
        public static DateTime[] TechnicianDOBs = new DateTime[]
        {
            DateTime.Parse("1999-01-01"),
            DateTime.Parse("1992-10-12"),
            DateTime.Parse("1974-07-03"),
        };
        public static string[] Specialities = new string[]
        {
            "Fotógrafo",
            "Fotógrafo",
            "Sonidista",
        };
        public static string[] Levels = new string[]
        {
            "Intermedio",
            "Avanzado",
            "Intermedio",
        };
    }
}