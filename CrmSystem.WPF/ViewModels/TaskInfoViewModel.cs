using System;
using System.Windows.Input;
using CrmSystem.Domain;
using CrmSystem.WPF.Helpers;
using CrmSystem.Domain.Models;
using CrmSystem.WPF.ViewModels.Services;


namespace CrmSystem.WPF.ViewModels
{
    public class TaskInfoViewModel:ObservableObject, IBackable
    {
        private readonly IUnitOfWork _unitOfWork;
        private BaseTask _task;

        public TaskInfoViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            BackBtnClickCommand = new RelayCommand(Back);
        }

        public BaseTask Task
        {
            get => _task;
            set => base.SetProperty(ref _task, value);
        }

        public ObservableObject BackVM { get; set; }
        public ICommand BackBtnClickCommand { get; set; }
        public event Action<ObservableObject> BackVmRequested;
        public void Back()
        {
            BackVmRequested?.Invoke(BackVM);
        }
    }
}