using System;
using System.Data.Entity.Infrastructure;
using System.Windows.Input;
using CrmSystem.WPF.Helpers;

namespace CrmSystem.WPF.ViewModels
{
    public class SettingsViewModel:ObservableObject
    {
        public ICommand UsersClickCommand { get; set; }

        public SettingsViewModel()
        {
            UsersClickCommand = new RelayCommand(UsersButtonClick);
        }

        public event Action UsersButtonClicked;
        private void UsersButtonClick()
        {
            UsersButtonClicked?.Invoke();
        }
    }
}