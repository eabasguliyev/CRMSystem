using System;
using System.Windows.Input;
using CrmSystem.Domain.Models;
using CrmSystem.WPF.Helpers;

namespace CrmSystem.WPF.ViewModels
{
    public class MainViewModel:ObservableObject
    {
        // view models

        private ContactsViewModel _contactsViewModel;

        
        
        private ObservableObject _currentViewModel;

        public MainViewModel()
        {
            _contactsViewModel = new ContactsViewModel();

            ContactsClickCommand = new RelayCommand(NavToContacts);
        }

        public Employee Employee { get; set; }

        public ICommand ContactsClickCommand { get; set; }

        public ObservableObject CurrentViewModel
        {
            get => _currentViewModel;
            set => base.SetProperty(ref _currentViewModel, value);
        }


        private void NavToContacts()
        {
            CurrentViewModel = _contactsViewModel;
        }
    }
}