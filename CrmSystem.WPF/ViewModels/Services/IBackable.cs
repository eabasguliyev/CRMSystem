using System;
using System.Windows.Input;
using CrmSystem.WPF.Helpers;

namespace CrmSystem.WPF.ViewModels.Services
{
    public interface IBackable
    { 
        ObservableObject BackVM { get; set; }
        ICommand BackBtnClickCommand { get; set; }

        event Action<ObservableObject> BackVmRequested;
        void Back();
    }
}