using System;
using System.Windows.Input;
using CrmSystem.Domain.Models;
using CrmSystem.WPF.Helpers;

namespace CrmSystem.WPF.ViewModels
{
    public class EmployeInfoEventArgs : EventArgs
    {
        public BaseEmployee Employee { get; set; }
    }

public class EmployeeInfoViewModel:ObservableObject
    {
        private BaseEmployee _selectedEmployee;

        public BaseEmployee SelectedEmployee
        {
            get => _selectedEmployee;
            set => base.SetProperty(ref _selectedEmployee, value);
        }

        public ICommand EditButtonClickCommand { get; set; }

        public EmployeeInfoViewModel()
        {
            EditButtonClickCommand = new RelayCommand(EditButtonClick);
        }

        public event EventHandler<EmployeInfoEventArgs> EditButtonClicked;

        private void EditButtonClick()
        {
            EditButtonClicked?.Invoke(this, new EmployeInfoEventArgs()
            {
                Employee = SelectedEmployee
            });
        }
    }
}