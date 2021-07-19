using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using CrmSystem.Domain;
using CrmSystem.Domain.Models;
using CrmSystem.WPF.Helpers;

namespace CrmSystem.WPF.ViewModels
{
    public class AddEditTaskViewModel:ObservableObject
    {
        private BaseTask _editableTask;
        private BaseTask _task;

        public BaseTask Task
        {
            get => _task;
            set
            {
                _task = value;

                EditableTask = _task.Clone() as BaseTask;
            }
        }

        public BaseTask EditableTask
        {
            get => _editableTask;
            set => SetProperty(ref _editableTask, value);
        }

        private IUnitOfWork _unitOfWork;
        private Employee _selectedOwner;
        private ObservableCollection<Employee> _employees;
        private List<StatusOption> _statuses;
        private List<PriorityOption> _priorities;
        private ObservableCollection<Contact> _contacts;

        public AddEditTaskViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            SaveClickCommand = new RelayCommand(Save);
            SaveAndNewClickCommand = new RelayCommand(SaveAndNew);
            CancelClickCommand = new RelayCommand(Cancel);
        }

        public bool EditMode { get; set; }
        public Employee SelectedOwner
        {
            get => _selectedOwner;
            set => base.SetProperty(ref _selectedOwner, value);
        }

        public ObservableCollection<Employee> Employees
        {
            get => _employees;
            set => base.SetProperty(ref _employees, value);
        }

        public List<StatusOption> Statuses
        {
            get => _statuses;
            set => base.SetProperty(ref _statuses, value);
        }

        public List<PriorityOption> Priorities
        {
            get => _priorities;
            set => base.SetProperty(ref _priorities, value);
        }


        public ICommand SaveClickCommand { get; set; }
        public ICommand SaveAndNewClickCommand { get; set; }
        public ICommand CancelClickCommand { get; set; }

        public event Action SaveOrCancelClicked;


        public ObservableCollection<Contact> Contacts
        {
            get => _contacts;
            set => base.SetProperty(ref _contacts, value);
        }

        private void SaveAndNew()
        {
            SaveChanges();
            ClearUserInputs();
            EditMode = false;
        }

        private void ClearUserInputs()
        {
            EditableTask = new BaseTask();
        }
        public void Save()
        {
            SaveChanges();

            SaveOrCancelClicked?.Invoke();
        }
        private void SaveChanges()
        {
            PrepareTask();

            (Task as ContactTask).Update(EditableTask as ContactTask);

            if (!EditMode)
            {
                if (Task is ContactTask ct)
                {
                    _unitOfWork.ContactTasks.Add(ct);
                }
            }

            _unitOfWork.Save();

            MessageBox.Show("Task saved.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public void Cancel()
        {
            SaveOrCancelClicked?.Invoke();
        }
        private void PrepareTask()
        {
            if (SelectedOwner != null)
                EditableTask.Owner = SelectedOwner;
            

            if (EditMode)
            {
                EditableTask.ModifiedBy = new RecordDetail()
                {
                    Employee = App.LoggedUser,
                    RecordDate = DateTime.Now
                };
            }
            else
            {
                EditableTask.CreatedBy = new RecordDetail()
                {
                    Employee = App.LoggedUser,
                    RecordDate = DateTime.Now
                };
            }
        }
        public void InitialConfiguration()
        {
            if (EditableTask.Owner != null)
                SelectedOwner = EditableTask.Owner;
        }

        public void LoadStatuses()
        {
            Statuses = Enum.GetValues(typeof(StatusOption)).Cast<StatusOption>().ToList();
        }

        public void LoadPriorities()
        {
            Priorities = Enum.GetValues(typeof(PriorityOption)).Cast<PriorityOption>()
                .ToList();
        }
        public void LoadEmployees()
        {
            Employees = new ObservableCollection<Employee>(_unitOfWork.Employees.Find(e => e.Company.Id == App.Company.Id).Select(e => e as Employee));
        }

        public void LoadContacts()
        {
            Contacts = new ObservableCollection<Contact>(_unitOfWork.Contacts.Find(e => e.Company.Id == App.Company.Id).Select(e => e as Contact));
        }

    }
}