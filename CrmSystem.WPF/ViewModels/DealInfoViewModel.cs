using CrmSystem.Domain;
using CrmSystem.Domain.Models;
using CrmSystem.WPF.Helpers;

namespace CrmSystem.WPF.ViewModels
{
    public class DealInfoViewModel:ObservableObject
    {
        private readonly IUnitOfWork _unitOfWork;
        private Contract _deal;

        public DealInfoViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Contract Deal
        {
            get => _deal;
            set => base.SetProperty(ref _deal, value);
        }
    }
}