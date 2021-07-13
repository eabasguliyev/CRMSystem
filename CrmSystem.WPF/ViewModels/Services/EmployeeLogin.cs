using CrmSystem.Domain.Models;

namespace CrmSystem.WPF.ViewModels.Services
{
    public class EmployeeLogin:ILogin<Employee>
    {
        public Employee Login(string email, string password)
        {
            // TODO: search by email and check password.


            return null;
        }
    }
}