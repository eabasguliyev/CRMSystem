using System;
using System.Windows;
using System.Windows.Input;
using CrmSystem.Domain.Models;
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
            switch (App.LoggedUser.Profile)
            {
                case ProfileOption.Administrator:
                case ProfileOption.SuperAdmin:
                {
                    UsersButtonClicked?.Invoke();
                    break;
                }
                case ProfileOption.Standard:
                {
                    MessageBox.Show("You don't have required permission. Contact with IT department.",
                        "Authorization error", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
            }
        }
    }
}