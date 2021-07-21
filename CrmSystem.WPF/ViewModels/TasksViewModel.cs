using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Windows.Input;
using CrmSystem.Domain;
using CrmSystem.Domain.Models;
using CrmSystem.WPF.Helpers;

namespace CrmSystem.WPF.ViewModels
{
    public class AddEditTaskEventArgs : EventArgs
    {
        public bool EditMode { get; set; }
        public BaseTask Task { get; set; }
    }

    public class TasksViewModel:ObservableObject
    {
        private readonly IUnitOfWork _unitOfWork;
        private BaseTask _selectedTask;
        private ObservableCollection<BaseTask> _tasks;

        public TasksViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            CreateTaskClickCommand = new RelayCommand(CreateTaskClick);
            EditTaskClickCommand = new RelayCommand(EditTaskClicked);
            TaskInfoClickCommand = new RelayCommand(TaskInfoClick);
        }


        private void TaskInfoClick()
        {
            TaskInfoClicked?.Invoke(this, SelectedTask);
        }

        private void CreateTaskClick()
        {
            CreateTasksClicked?.Invoke(this, new AddEditTaskEventArgs()
            {
                EditMode = false,
                Task = new ContactTask()
            });
        }

        private void EditTaskClicked()
        {
            CreateTasksClicked?.Invoke(this, new AddEditTaskEventArgs()
            {
                EditMode = true,
                Task = SelectedTask
            });
        }

        public BaseTask SelectedTask
        {
            get => _selectedTask;
            set => base.SetProperty(ref _selectedTask, value);
        }

        public ICommand CreateTaskClickCommand { get; set; }
        public ICommand EditTaskClickCommand { get; set; }
        public ICommand TaskInfoClickCommand { get; set; }

        public event EventHandler<AddEditTaskEventArgs> CreateTasksClicked;
        public event EventHandler<BaseTask> TaskInfoClicked;

        public ObservableCollection<BaseTask> Tasks
        {
            get => _tasks;
            set => base.SetProperty(ref _tasks, value);
        }


        private void LoadTasks()
        {
            Expression<Func<ContactTask, bool>> predicate = null;

            switch (App.LoggedUser.Profile)
            {
                case ProfileOption.Administrator:
                case ProfileOption.SuperAdmin:
                {
                    predicate = (ct) => ct.Contact.Company.Id == App.Company.Id;
                    break;
                }
                case ProfileOption.Standard:
                {
                    predicate = (ct) => ct.Contact.Company.Id == App.Company.Id && ct.Owner.Id == App.LoggedUser.Id;
                    break;
                }
            }

            Tasks = new ObservableCollection<BaseTask>(_unitOfWork.ContactTasks.Find(predicate));
        }

        public void ViewLoad()
        {
            LoadTasks();
        }
    }
}