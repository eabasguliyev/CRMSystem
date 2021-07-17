using System;

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
        Standard,
        SuperAdmin
    }

    public abstract class BaseEmployee:User
    {
        public RoleOption Role { get; set; }
        public ProfileOption Profile { get; set; }

        public void Update(BaseEmployee employee)
        {
            Role = employee.Role;
            Profile = employee.Profile;

            base.Update(employee);
        }
    }
}