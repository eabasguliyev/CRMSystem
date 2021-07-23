using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using CrmSystem.Domain;
using CrmSystem.Domain.Models;
using CrmSystem.WPF.Helpers;

namespace CrmSystem.WPF.ViewModels
{
    public class AddEditDealViewModel:ObservableObject
    {
        private readonly IUnitOfWork _unitOfWork;
        private ObservableCollection<Employee> _employees;
        private ObservableCollection<LeadSource> _leadSources;
        private ObservableCollection<Stage> _stages;
        private Contract _editableDeal;
        private Contract _deal;
        private Employee _selectedOwner;
        private LeadSource _selectedLeadSource;
        private Stage _selectedStage;
        private ObservableCollection<Contact> _contacts;

        public AddEditDealViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            SaveClickCommand = new RelayCommand(Save);
            SaveAndNewClickCommand = new RelayCommand(SaveAndNew);
            CancelClickCommand = new RelayCommand(Cancel);
        }

        public Contract Deal
        {
            get => _deal;
            set
            {
                _deal = value;
                EditableDeal = _deal.Clone() as Contract;
            }
        }

        public bool EditMode { get; set; }

        public Contract EditableDeal
        {
            get => _editableDeal;
            set => base.SetProperty(ref _editableDeal, value);
        }


        public ObservableCollection<Employee> Employees
        {
            get => _employees;
            set => base.SetProperty(ref _employees, value);
        }

        public ObservableCollection<LeadSource> LeadSources
        {
            get => _leadSources;
            set => base.SetProperty(ref _leadSources, value);
        }

        public ObservableCollection<Stage> Stages
        {
            get => _stages;
            set => base.SetProperty(ref _stages, value);
        }

        public ObservableCollection<Contact> Contacts
        {
            get => _contacts;
            set => base.SetProperty(ref _contacts, value);
        }

        public Employee SelectedOwner
        {
            get => _selectedOwner;
            set => base.SetProperty(ref _selectedOwner, value);
        }

        public LeadSource SelectedLeadSource
        {
            get => _selectedLeadSource;
            set => base.SetProperty(ref _selectedLeadSource,value);
        }

        public Stage SelectedStage
        {
            get => _selectedStage;
            set => base.SetProperty(ref _selectedStage, value);
        }


        private void PrepareDeal()
        {
            if (EditableDeal.Company == null)
                EditableDeal.Company = App.Company;

            if(!EditMode)
                EditableDeal.StartDate = DateTime.Now;

            if (SelectedOwner != null)
                EditableDeal.Owner = SelectedOwner;

            if (SelectedLeadSource != null)
                EditableDeal.LeadSource = SelectedLeadSource;

            if (SelectedStage != null)
                EditableDeal.Stage = SelectedStage;

            if (EditMode)
            {
                EditableDeal.ModifiedBy = new RecordDetail()
                {
                    Employee = App.LoggedUser,
                    RecordDate = DateTime.Now
                };
            }
            else
            {

                EditableDeal.CreatedBy = new RecordDetail()
                {
                    Employee = App.LoggedUser,
                    RecordDate = DateTime.Now
                };

            }

        }

        public ICommand SaveClickCommand { get; set; }
        public ICommand SaveAndNewClickCommand { get; set; }
        public ICommand CancelClickCommand { get; set; }

        public event Action SaveOrCancelClicked;

        private void SaveAndNew()
        {
            SaveChanges();
            ClearUserInputs();
            EditMode = false;
        }

        private void ClearUserInputs()
        {
            EditableDeal = new Contract();
        }
        public void Save()
        {
            SaveChanges();

            SaveOrCancelClicked?.Invoke();
        }
        private void SaveChanges()
        {
            PrepareDeal();

            Deal.Update(EditableDeal);

            if (!EditMode)
                _unitOfWork.Contracts.Add(Deal);

            _unitOfWork.Save();

            MessageBox.Show("Deal saved.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public void Cancel()
        {
            SaveOrCancelClicked?.Invoke();
        }
        public void InitialConfiguration()
        {
            if (!EditMode)
            {
                SelectedOwner = App.LoggedUser;
                return;
            }

            if (EditableDeal.Owner != null)
                SelectedOwner = EditableDeal.Owner;

            if (EditableDeal.LeadSource != null)
                SelectedLeadSource = EditableDeal.LeadSource;

            if (EditableDeal.Stage != null)
                SelectedStage = EditableDeal.Stage;
        }

        public void LoadEmployees()
        {
            Employees = new ObservableCollection<Employee>(_unitOfWork.Employees.Find(e => e.Company.Id == App.Company.Id).Select(e => e as Employee));
        }

        

        public void LoadLeadSources()
        {
            LeadSources = new ObservableCollection<LeadSource>(_unitOfWork.LeadSources.GetAll());
        }

        public void LoadStages()
        {
            Stages = new ObservableCollection<Stage>(_unitOfWork.Stages.GetAll());
        }

        public void LoadContacts()
        {
            Contacts = new ObservableCollection<Contact>(_unitOfWork.Contacts.Find(e => e.Company.Id == App.Company.Id).Select(e => e as Contact));
        }


        public void ViewLoad()
        {
            LoadEmployees();
            LoadLeadSources();
            LoadStages();
            LoadContacts();
            InitialConfiguration();
        }
    }
}