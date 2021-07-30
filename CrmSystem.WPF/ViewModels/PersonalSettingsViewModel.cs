using System;
using System.Windows;
using System.Windows.Input;
using CrmSystem.Domain;
using CrmSystem.Domain.Models;
using CrmSystem.WPF.Helpers;
using CrmSystem.WPF.Models.Services;
using CrmSystem.WPF.ViewModels.Services;

namespace CrmSystem.WPF.ViewModels
{
    public class PersonalSettingsViewModel:ObservableObject, IBackable
    {
        private readonly IUnitOfWork _unitOfWork;
        private Employee _editableEmployee;
        private Employee _employee;

        public Employee Employee
        {
            get => _employee;
            set
            {
                _employee = value;
                var temp = _employee.Clone() as Employee;
                temp.Password = string.Empty;

                EditableEmployee = temp;
            }
        }

        public Employee EditableEmployee
        {
            get => _editableEmployee;
            set => base.SetProperty(ref _editableEmployee, value);
        }


        public PersonalSettingsViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            SaveBtnCommand = new RelayCommand(Save);
            BackBtnClickCommand = new RelayCommand(Back);
        }

        private void Save()
        {
            if (string.IsNullOrWhiteSpace(EditableEmployee.Password))
            {
                MessageBox.Show("Password can not be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Employee.Update(EditableEmployee);

            Employee.Password = new Sha256Hash().CreateHash(EditableEmployee.Password);

            _unitOfWork.Save();

            MessageBox.Show("Saved", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            SaveButtonClicked?.Invoke();
        }

        public event Action SaveButtonClicked;

        public ICommand SaveBtnCommand { get; set; }
        public ObservableObject BackVM { get; set; }
        public ICommand BackBtnClickCommand { get; set; }
        public event Action<ObservableObject> BackVmRequested;
        public void Back()
        {
            BackVmRequested?.Invoke(BackVM);
        }
    }
}