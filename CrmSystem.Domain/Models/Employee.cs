namespace CrmSystem.Domain.Models
{
    public enum RoleOption
    {
        Ceo = 1,
        Manager
    }
    public enum ProfileOption
    {
        Administrator = 1,
        Standard
    }

    public class Employee:User
    {
        public string Password { get; set; }
        public RoleOption Role { get; set; }
        public ProfileOption Profile { get; set; }
    }
}