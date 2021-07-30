using System;
using System.Windows;
using System.Windows.Input;
using CrmSystem.Domain;
using CrmSystem.Domain.Models;
using CrmSystem.WPF.Helpers;
using CrmSystem.WPF.ViewModels.Services;

namespace CrmSystem.WPF.ViewModels
{
    public class CompanySettingViewModel:ObservableObject, IBackable
    {
        private readonly IUnitOfWork _unitOfWork;
        private Company _editableCompany;
        private Company _company;

        public CompanySettingViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            SaveBtnCommand = new RelayCommand(Save);
            BackBtnClickCommand = new RelayCommand(Back);

        }

        private void Save()
        {
            Company.Update(EditableCompany);

            _unitOfWork.Save();

            MessageBox.Show("Saved", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            SaveButtonClicked?.Invoke();
        }

        public event Action SaveButtonClicked;

        public Company Company
        {
            get => _company;
            set
            {
                _company = value;

                EditableCompany = _company.Clone() as Company;
            }
        }

        public Company EditableCompany
        {
            get => _editableCompany;
            set => base.SetProperty(ref _editableCompany, value);
        }

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