using System.Collections.ObjectModel;
using CrmSystem.Domain;
using CrmSystem.Domain.Models;
using CrmSystem.WPF.Helpers;

namespace CrmSystem.WPF.ViewModels
{
    public class DealsViewModel:ObservableObject
    {
        private readonly IUnitOfWork _unitOfWork;
        private ObservableCollection<Contract> _contracts;

        public DealsViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public ObservableCollection<Contract> Contracts
        {
            get => _contracts;
            set => base.SetProperty(ref _contracts, value);
        }

        public Contract SelectedDeal { get; set; }

        public void ViewLoad()
        {
            LoadContracts();
        }

        private void LoadContracts()
        {
            Contracts = new ObservableCollection<Contract>(
                _unitOfWork.Contracts.Find(c => c.Company.Id == App.Company.Id));
        }
    }
}