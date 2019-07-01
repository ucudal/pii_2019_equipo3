using System;

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

        public static string[] NonAdminRoleNames = new string[] { "Cliente", "Técnico" };
        public const string TechUserName = "Manuel_García";

        public const string TechName = "Manuel García";

        public const string TechMail = "tech@ignis.com";

        public static DateTime TechDOB = new DateTime(1999, 2, 12);

        public const string TechPassword = "P@55w0rd";

        public const string TechRoleName = "Técnico";
        
        public const string ClientUserName = "Juan_Rodriguez";

        public const string ClientName = "Juan Rodriguez";

        public const string ClientMail = "client@ignis.com";

        public static DateTime ClientDOB = new DateTime(1977, 12, 22);

        public const string ClientPassword = "P@55w0rd";

        public const string ClientRoleName = "Cliente";

    }
}