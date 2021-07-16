using System;
using System.Windows.Input;
using CrmSystem.Domain;
using CrmSystem.Domain.Models;
using CrmSystem.WPF.Helpers;

namespace CrmSystem.WPF.ViewModels
{
    public class CompanySetupViewModel:ObservableObject
    {
        private IUnitOfWork _unitOfWork;
        public Company NewCompany { get; set; }

        public ICommand CreateCompanyCommand { get; set; }

        public CompanySetupViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            NewCompany = new Company();
            CreateCompanyCommand = new RelayCommand(CreateCompany);
        }

        public event Action InitialSetupCompleted;
        private void CreateCompany()
        {
            App.Company = NewCompany;
            
            _unitOfWork.Companies.Add(NewCompany);
            _unitOfWork.Save();

            InitialSetupCompleted?.Invoke();
        }
    }
}