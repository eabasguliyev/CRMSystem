using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;
using CrmSystem.Domain;
using CrmSystem.Domain.Models;
using CrmSystem.WPF.Helpers;

namespace CrmSystem.WPF.ViewModels
{
    public class EmployeesViewModel:ObservableObject
    {
        private IUnitOfWork _unitOfWork;
        private ObservableCollection<BaseEmployee> _employees;

        private AddEmployeeViewModel _addUserView;


        private ObservableObject _currentViewModel;

        public ObservableCollection<BaseEmployee> Employees
        {
            get => _employees;
            set => base.SetProperty(ref _employees, value);
        }

        public ObservableObject CurrentViewModel
        {
            get => _currentViewModel;
            set => base.SetProperty(ref _currentViewModel, value);
        }


        public ICommand AddUserClickCommand { get; set; }

        public EmployeesViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _addUserView = new AddEmployeeViewModel(unitOfWork);
            _addUserView.AddUserOrCancelOperation += NavToEmployeesView;

            AddUserClickCommand = new RelayCommand(AddUserClick);
        }

        private void NavToEmployeesView(object sender, AddEmployeeEventArgs e)
        {
            CurrentViewModel = null;

            if(e.Added)
                LoadEmployees();
        }

        private void AddUserClick()
        {
            CurrentViewModel = _addUserView;
        }


        public void LoadEmployees()
        {
            var employees = new List<BaseEmployee>();

            employees.AddRange(_unitOfWork.Employees.Find(e => e.Company.Id == App.Company.Id));
            employees.AddRange(_unitOfWork.RequestedEmployees.Find(e => e.Company.Id == App.Company.Id));

            Employees = new ObservableCollection<BaseEmployee>(employees);
        }
    }
}