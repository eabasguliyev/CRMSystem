using System;
using System.Windows;
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
            EditBtnCommand = new RelayCommand(Edit);
            CloseTaskBtnCommand = new RelayCommand(CloseTask);
        }

        private void CloseTask()
        {
            var status = MessageBox.Show("Are you sure you want to mark this task as completed?", 
                "Mark as Completed", MessageBoxButton.YesNo,
                MessageBoxImage.Information);

            if (status == MessageBoxResult.No)
                return;


            Task.Status = StatusOption.Completed;
            _unitOfWork.Save();
            Back();
        }

        private void Edit()
        {
            EditButtonClicked?.Invoke(this, new AddEditTaskEventArgs()
            {
                EditMode = true,
                Task = Task,
            });
        }

        public BaseTask Task
        {
            get => _task;
            set => base.SetProperty(ref _task, value);
        }

        public ObservableObject BackVM { get; set; }
        public ICommand BackBtnClickCommand { get; set; }
        public ICommand EditBtnCommand { get; set; }
        public ICommand CloseTaskBtnCommand { get; set; }


        public event Action<ObservableObject> BackVmRequested;
        public event EventHandler<AddEditTaskEventArgs> EditButtonClicked; 

        public void Back()
        {
            BackVmRequested?.Invoke(BackVM);
        }

        
    }
}