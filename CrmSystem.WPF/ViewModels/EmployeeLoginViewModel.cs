using System.Windows.Input;
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

        }

        public void Login()
        {
            var login = new EmployeeLogin();

            var employee = login.Login(Email, Password);

            if (employee == null)
                return;

            // TODO: nav to mainview.
        }

    }
}