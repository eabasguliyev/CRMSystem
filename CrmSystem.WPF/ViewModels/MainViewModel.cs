using System;
using System.Windows.Input;
using CrmSystem.Domain;
using CrmSystem.Domain.Models;
using CrmSystem.WPF.Helpers;

namespace CrmSystem.WPF.ViewModels
{
    public class MainViewModel:ObservableObject
    {
        // view models

        private ContactsViewModel _contactsViewModel;
        private AddEditContactViewModel _addEditContactViewModel;
        private SettingsViewModel _settingsViewModel;
        private CompanySetupViewModel _companySetupViewModel;
        private EmployeesViewModel _employeesViewModel;
        private TasksViewModel _tasksViewModel;
        private AddEditTaskViewModel _addEditTaskViewModel;
        private ContactInfoViewModel _contactInfoViewModel;
        private TaskInfoViewModel _taskInfoViewModel;

        public Employee LoggedUser => App.LoggedUser;

        private IUnitOfWork _unitOfWork;

        private ObservableObject _currentViewModel;

        public MainViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _contactsViewModel = new ContactsViewModel(_unitOfWork);
            _contactsViewModel.CreateContactClicked += NavToAddEditContact;
            _contactsViewModel.ContactInfoClicked += NavToContactInfo;
            
            _addEditContactViewModel = new AddEditContactViewModel(_unitOfWork);
            _addEditContactViewModel.SaveOrCancelClicked += NavToContacts;

            _settingsViewModel = new SettingsViewModel();
            _settingsViewModel.UsersButtonClicked += NavToEmployeesView;
            _companySetupViewModel = new CompanySetupViewModel(_unitOfWork);
            _companySetupViewModel.InitialSetupCompleted += OnInitialSetupCompleted;

            _employeesViewModel = new EmployeesViewModel(_unitOfWork);

            _tasksViewModel = new TasksViewModel(_unitOfWork);
            _tasksViewModel.CreateTasksClicked += NavToAddEditTask;
            _tasksViewModel.TaskInfoClicked += NavToTaskInfo;

            _addEditTaskViewModel = new AddEditTaskViewModel(_unitOfWork);
            _addEditTaskViewModel.SaveOrCancelClicked += NavToTasks;

            _contactInfoViewModel = new ContactInfoViewModel(_unitOfWork);
            _contactInfoViewModel.BackVmRequested += NavToPreviousVm;

            _taskInfoViewModel = new TaskInfoViewModel(_unitOfWork);
            _taskInfoViewModel.BackVmRequested += NavToPreviousVm;
            _taskInfoViewModel.EditButtonClicked += NavToAddEditTask;

            ContactsClickCommand = new RelayCommand(NavToContacts);
            SettingsClickCommand = new RelayCommand(NavToSettings);
            LogoutClickCommand = new RelayCommand(Logout);
            TasksClickCommand = new RelayCommand(NavToTasks);
        }

        private void NavToTaskInfo(object? sender, BaseTask e)
        {
            _taskInfoViewModel.Task = e;
            _taskInfoViewModel.BackVM = CurrentViewModel;
            CurrentViewModel = _taskInfoViewModel;
        }

        private void NavToPreviousVm(ObservableObject vm)
        {
            CurrentViewModel = vm;
        }

        private void NavToContactInfo(Contact contact)
        {
            _contactInfoViewModel.Contact = contact;
            _contactInfoViewModel.BackVM = CurrentViewModel;
            CurrentViewModel = _contactInfoViewModel;
        }

        private void NavToAddEditTask(object? sender, AddEditTaskEventArgs e)
        {
            _addEditTaskViewModel.Task = e.Task;
            _addEditTaskViewModel.EditMode = e.EditMode;

            CurrentViewModel = _addEditTaskViewModel;
        }

        private void NavToTasks()
        {
            CurrentViewModel = _tasksViewModel;
        }

        private void Logout()
        {
            App.LoggedUser = null;
            App.Company = null;

            CurrentViewModel = null;
            LogoutEvent?.Invoke();
        }

        private void NavToEmployeesView()
        {
            CurrentViewModel = _employeesViewModel;
        }

        private void OnInitialSetupCompleted()
        {
            CurrentViewModel = null;
        }

        private void NavToSettings()
        {
            CurrentViewModel = _settingsViewModel;
        }

        private void NavToAddEditContact(object? sender, AddEditContactEventArgs e)
        {
            _addEditContactViewModel.EditMode = e.EditMode;

            _addEditContactViewModel.Contact = e.Contact;


            CurrentViewModel = _addEditContactViewModel;
        }
        public ICommand ContactsClickCommand { get; set; }
        public ICommand SettingsClickCommand { get; set; }
        public ICommand LogoutClickCommand { get; set; }
        public ICommand TasksClickCommand { get; set; }

        public event Action LogoutEvent;
        public ObservableObject CurrentViewModel
        {
            get => _currentViewModel;
            set => base.SetProperty(ref _currentViewModel, value);
        }
        private void NavToContacts()
        {
            CurrentViewModel = _contactsViewModel;
        }

        public void InitialSetup()
        {
            if (App.Company == null)
            {
                CurrentViewModel = _companySetupViewModel;
            }
        }

        public void ViewLoad()
        {
            InitialSetup();
        }
    }
}