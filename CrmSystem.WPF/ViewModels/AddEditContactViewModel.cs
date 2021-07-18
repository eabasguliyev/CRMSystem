using System;
using System.Collections.ObjectModel;
using System.Linq;
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
        private Contact _editableContact;
        public bool EditMode { get; set; }

        public Contact Contact
        {
            get => _contact;
            set
            {
                _contact = value;

                EditableContact = _contact.Clone() as Contact;
            }
        }

        public Contact EditableContact
        {
            get => _editableContact;
            set => base.SetProperty(ref _editableContact, value);
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
            EditableContact = new Contact()
            {
                AddressInfo = new AddressInformation()
            };
        }

        public void LoadEmployees()
        {
            Employees = new ObservableCollection<Employee>(_unitOfWork.Employees.Find(e => e.Company.Id == App.Company.Id).Select(e => e as Employee));
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

            Contact.Update(EditableContact);

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
                EditableContact.Owner = SelectedOwner;

            if (SelectedLeadSource != null)
                EditableContact.LeadSource = SelectedLeadSource;

            if (EditableContact.Company == null)
                EditableContact.Company = App.Company;

            if (EditMode)
            {
                EditableContact.ModifiedBy = new RecordDetail()
                {
                    Employee = App.LoggedUser,
                    RecordDate = DateTime.Now
                };
            }
            else
            {

                EditableContact.CreatedBy = new RecordDetail()
                {
                    Employee = App.LoggedUser,
                    RecordDate = DateTime.Now
                };

            }
        }

        public void InitialConfiguration()
        {
            if (EditableContact.Owner != null)
                SelectedOwner = EditableContact.Owner;

            if (EditableContact.LeadSource != null)
                SelectedLeadSource = EditableContact.LeadSource;
        }
    }
}