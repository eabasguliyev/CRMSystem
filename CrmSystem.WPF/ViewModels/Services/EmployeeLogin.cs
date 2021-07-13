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

        public Employee Login(string email, string password)
        {
            return _repo.SingleOrDefault(e => e.Email == email && e.Password == password);
        }
    }
}