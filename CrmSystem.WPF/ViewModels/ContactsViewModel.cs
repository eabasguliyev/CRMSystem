using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using CrmSystem.Domain;
using CrmSystem.Domain.Models;
using CrmSystem.Domain.Repositories;
using CrmSystem.EntityFramework;
using CrmSystem.EntityFramework.Repositories;
using CrmSystem.WPF.Helpers;

namespace CrmSystem.WPF.ViewModels
{
    public class AddEditContactEventArgs : EventArgs
    {
        public bool EditMode { get; set; }
        public Contact Contact { get; set; }
    }

    public class ContactsViewModel:ObservableObject
    {
        private ObservableCollection<Contact> _contacts;

        private IUnitOfWork _unitOfWork;
        public ObservableCollection<Contact> Contacts
        {
            get => _contacts;
            set => base.SetProperty(ref _contacts, value);
        }

        public ContactsViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            CreateContactClickCommand = new RelayCommand(CreateContactClick);
            EditContactClickCommand = new RelayCommand(EditContactClick);
            ContactInfoClickCommand = new RelayCommand(ContactInfoClick);
        }

        private void ContactInfoClick()
        {
            ContactInfoClicked?.Invoke(SelectedContact);
        }

        public ICommand CreateContactClickCommand { get; set; }
        public ICommand EditContactClickCommand { get; set; }
        public ICommand ContactInfoClickCommand { get; set; }

        public event EventHandler<AddEditContactEventArgs> CreateContactClicked;
        public event Action<Contact> ContactInfoClicked;

        public Contact SelectedContact { get; set; }

        public void LoadContacts()
        {
            Contacts = new ObservableCollection<Contact>(_unitOfWork.Contacts.Find(c => c.Company.Id == App.Company.Id));
        }

        public void CreateContactClick()
        {
            CreateContactClicked?.Invoke(this, new AddEditContactEventArgs()
            {
                EditMode = false,
                Contact = new Contact()
            });
        }

        public void EditContactClick()
        {
            CreateContactClicked?.Invoke(this, new AddEditContactEventArgs()
            {
                EditMode = true,
                Contact = SelectedContact
            });
        }

    }
}