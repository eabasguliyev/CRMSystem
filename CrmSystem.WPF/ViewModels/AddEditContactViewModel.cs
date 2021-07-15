using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using CrmSystem.Domain;
using CrmSystem.Domain.Models;
using CrmSystem.EntityFramework;
using CrmSystem.EntityFramework.Repositories;
using CrmSystem.WPF.Helpers;

namespace CrmSystem.WPF.ViewModels
{
    public class AddEditContactViewModel:ObservableObject
    {
        private IUnitOfWork _unitOfWork;

        private Contact _contact;
        
        private ObservableCollection<Employee> _employees;
        private ObservableCollection<LeadSource> _leadSources;
        private LeadSource _selectedLeadSource;
        private Employee _selectedOwner;
        public bool EditMode { get; set; }

        public Contact Contact
        {
            get => _contact;
            set => base.SetProperty(ref _contact, value);
        }

        public ObservableCollection<Employee> Employees
        {
            get => _employees;
            set => base.SetProperty(ref _employees, value);
        }

        public ObservableCollection<LeadSource> LeadSources
        {
            get => _leadSources;
            set => base.SetProperty(ref _leadSources, value);
        }

        public ICommand SaveClickCommand { get; set; }
        public ICommand SaveAndNewClickCommand { get; set; }
        public ICommand CancelClickCommand { get; set; }
        public Employee Employee { get; set; }

        public event Action SaveOrCancelClicked;

        public LeadSource SelectedLeadSource
        {
            get => _selectedLeadSource;
            set => base.SetProperty(ref _selectedLeadSource, value);
        }

        public Employee SelectedOwner
        {
            get => _selectedOwner;
            set => base.SetProperty(ref _selectedOwner, value);
        }

        public AddEditContactViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            SaveClickCommand = new RelayCommand(Save);
            CancelClickCommand = new RelayCommand(Cancel);
            SaveAndNewClickCommand = new RelayCommand(SaveAndNew);
        }

        private void SaveAndNew()
        {
            SaveChanges();
            ClearUserInputs();
            EditMode = false;
        }

        private void ClearUserInputs()
        {
            Contact = new Contact()
            {
                AddressInfo = new AddressInformation()
            };
        }

        public void LoadEmployees()
        {
            Employees = new ObservableCollection<Employee>(_unitOfWork.Employees.GetAll());
        }

        public void LoadLeadSources()
        {
            LeadSources = new ObservableCollection<LeadSource>(_unitOfWork.LeadSources.GetAll());
        }

        public void Save()
        {
            SaveChanges();
            
            SaveOrCancelClicked?.Invoke();
        }

        private void SaveChanges()
        {
            PrepareContact();

            if (!EditMode)
                _unitOfWork.Contacts.Add(Contact);

            _unitOfWork.Save();

            MessageBox.Show("Contact saved.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void Cancel()
        {
            SaveOrCancelClicked?.Invoke();
        }

        private void PrepareContact()
        {
            if (SelectedOwner != null)
                Contact.Owner = SelectedOwner;

            if (SelectedLeadSource != null)
                Contact.LeadSource = SelectedLeadSource;

            if (EditMode)
            {
                Contact.ModifiedBy = new RecordDetail()
                {
                    Employee = Employee,
                    RecordDate = DateTime.Now
                };
            }
            else
            {

                Contact.CreatedBy = new RecordDetail()
                {
                    Employee = Employee,
                    RecordDate = DateTime.Now
                };

            }
        }

        public void InitialConfiguration()
        {
            if (Contact.Owner != null)
                SelectedOwner = Contact.Owner;

            if (Contact.LeadSource != null)
                SelectedLeadSource = Contact.LeadSource;
        }
    }
}