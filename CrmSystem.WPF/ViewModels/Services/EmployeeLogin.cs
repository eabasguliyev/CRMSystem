using System.Linq;
using CrmSystem.Domain.Models;
using CrmSystem.Domain.Repositories;

namespace CrmSystem.WPF.ViewModels.Services
{
    public class EmployeeLogin:ILogin<Employee>
    {
        private IEmployeeRepository _repo;

        public EmployeeLogin(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public LoginStateOption Login(string email, string password, out Employee employee)
        {
            var user = _repo.SingleOrDefault(e => e.Email == email);

            employee = user as Employee;

            if (employee == null)
                return LoginStateOption.WrongEmail;

            return employee.Password != password ? 
                LoginStateOption.WrongPassword : LoginStateOption.Success;
        }
    }
}