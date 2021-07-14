using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using CrmSystem.Domain.Models;
using CrmSystem.Domain.Repositories;
using CrmSystem.EntityFramework;
using CrmSystem.EntityFramework.Repositories;
using CrmSystem.WPF.Helpers;

namespace CrmSystem.WPF.ViewModels
{
    public class ContactsViewModel:ObservableObject
    {
        private IContactRepository _repo;
        private ObservableCollection<Contact> _contacts;

        public ObservableCollection<Contact> Contacts
        {
            get => _contacts;
            set => base.SetProperty(ref _contacts, value);
        }

        public ContactsViewModel()
        {
            _repo = new ContactRepository(new CrmSystemContextFactory().Create());
        }

        public void LoadContacts()
        {
            Contacts = new ObservableCollection<Contact>(_repo.GetAll());

            var contactIds = Contacts.Select(c => c.Id);
        }
    }
}