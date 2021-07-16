using CrmSystem.Domain.Models;
using CrmSystem.WPF.Helpers;

namespace CrmSystem.WPF.ViewModels
{
    public class EmployeeInfoViewModel:ObservableObject
    {
        private BaseEmployee _selectedEmployee;

        public BaseEmployee SelectedEmployee
        {
            get => _selectedEmployee;
            set => base.SetProperty(ref _selectedEmployee, value);
        }
    }
}