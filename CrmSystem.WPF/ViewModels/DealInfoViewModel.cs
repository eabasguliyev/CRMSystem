using System;
using System.Windows;
using System.Windows.Input;
using CrmSystem.Domain;
using CrmSystem.Domain.Models;
using CrmSystem.WPF.Helpers;
using CrmSystem.WPF.ViewModels.Services;

namespace CrmSystem.WPF.ViewModels
{
    public class DealInfoViewModel:ObservableObject, IBackable
    {
        private readonly IUnitOfWork _unitOfWork;
        private Contract _deal;

        public DealInfoViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            BackBtnClickCommand = new RelayCommand(Back);
            RemoveClickCommand = new RelayCommand(Remove);
            EditClickCommand = new RelayCommand(Edit);
        }

        private void Edit()
        {
            EditButtonClicked?.Invoke(this, new AddEditDealEventArgs()
            {
                Deal = Deal,
                EditMode = true
            });
        }

        private void Remove()
        {
            _unitOfWork.Contracts.Remove(Deal);
            _unitOfWork.Save();

            MessageBox.Show("Deal removed", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            RemoveButtonClicked?.Invoke();
        }

        public Contract Deal
        {
            get => _deal;
            set => base.SetProperty(ref _deal, value);
        }

        public ObservableObject BackVM { get; set; }
        public ICommand BackBtnClickCommand { get; set; }
        public event Action<ObservableObject> BackVmRequested;

        public ICommand RemoveClickCommand { get; set; }
        public ICommand EditClickCommand { get; set; }

        public event Action RemoveButtonClicked;
        public event EventHandler<AddEditDealEventArgs> EditButtonClicked;

        public void Back()
        {
            BackVmRequested?.Invoke(BackVM);
        }
    }
}