using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CrmSystem.Domain;
using CrmSystem.Domain.Models;
using CrmSystem.WPF.Helpers;

namespace CrmSystem.WPF.ViewModels
{

    public class AddEditDealEventArgs : EventArgs
    {
        public bool EditMode { get; set; }
        public Contract Deal { get; set; }
    }

    public class DealsViewModel:ObservableObject
    {
        private readonly IUnitOfWork _unitOfWork;
        private ObservableCollection<Contract> _deals;

        public DealsViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            CreateDealClickCommand = new RelayCommand(CreateDeal);
            EditDealClickCommand = new RelayCommand(EditDeal);
            DealInfoClickCommand = new RelayCommand(NavToDealInfo);
        }

        private void NavToDealInfo()
        {
            DealInfoClicked?.Invoke(SelectedDeal);
        }


        private void EditDeal()
        {
            CreateOrEditDealClicked?.Invoke(this, new AddEditDealEventArgs()
            {
                EditMode = true,
                Deal = SelectedDeal,
            });
        }

        private void CreateDeal()
        {
            CreateOrEditDealClicked?.Invoke(this, new AddEditDealEventArgs()
            {
                EditMode = false,
                Deal = new Contract(),
            });
        }


        public ObservableCollection<Contract> Deals
        {
            get => _deals;
            set => base.SetProperty(ref _deals, value);
        }

        public Contract SelectedDeal { get; set; }


        public ICommand CreateDealClickCommand { get; set; }
        public ICommand EditDealClickCommand { get; set; }
        public ICommand DealInfoClickCommand { get; set; }

        public event Action<Contract> DealInfoClicked;


        public event EventHandler<AddEditDealEventArgs> CreateOrEditDealClicked;

        public void ViewLoad()
        {
            LoadDeals();
        }

        private void LoadDeals()
        {
            Deals = new ObservableCollection<Contract>(
                _unitOfWork.Contracts.Find(c => c.Company.Id == App.Company.Id));
        }
    }
}