using System.Windows.Input;
using CrmSystem.EntityFramework;
using CrmSystem.EntityFramework.Repositories;
using CrmSystem.WPF.Helpers;
using CrmSystem.WPF.ViewModels.Services;

namespace CrmSystem.WPF.ViewModels
{
    public class EmployeeLoginViewModel:ObservableObject
    {
        public string Email { get; set; }
        public string Password { get; set; }


        public ICommand LoginCommand { get; set; }

        public EmployeeLoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
        }

        public void Login()
        {
            var repo = new EmployeeRepository(new CrmSystemContextFactory().Create());

            var employee = new EmployeeLogin(repo).Login(Email, Password);

            if (employee == null)
                return;

            // TODO: nav to mainview.
        }

    }
}