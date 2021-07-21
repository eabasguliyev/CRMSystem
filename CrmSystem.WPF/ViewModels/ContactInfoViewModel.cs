using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using CrmSystem.Domain;
using CrmSystem.Domain.Models;
using CrmSystem.WPF.Helpers;
using CrmSystem.WPF.ViewModels.Services;

namespace CrmSystem.WPF.ViewModels
{
    public class ContactInfoViewModel:ObservableObject, IBackable
    {
        private readonly IUnitOfWork _unitOfWork;
        private Contact _contact;

        private object _lock = new object();
        private ObservableCollection<Note> _notes;

        public ContactInfoViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
            BackBtnClickCommand = new RelayCommand(Back);
            SaveNoteCommand = new RelayCommand<string>(SaveNote);
        }

        private void SaveNote(string note)
        {
            var newNote = new ContactNote()
            {
                Contact = Contact,
                CreatedBy = new RecordDetail()
                {
                    Employee = App.LoggedUser,
                    RecordDate = DateTime.Now
                },
                Text = note
            };

            Contact.Notes.Add(newNote);

            _unitOfWork.Save();
        }

        public Contact Contact
        {
            get => _contact;
            set
            {
                base.SetProperty(ref _contact, value);

                _unitOfWork.Contacts.GetNotes(_contact.Id);
                OnPropertyChanged("Notes");
            }
        }

        public ObservableObject BackVM { get; set; }

        public ICommand BackBtnClickCommand { get; set; }
        public ICommand SaveNoteCommand { get; set; }

        public event Action<ObservableObject> BackVmRequested;


        // birbasha olaraq getterini Contact.Notes etdim ishlemedi.
        

        public void Back()
        {
            BackVmRequested?.Invoke(BackVM);
        }

        public void LoadNotes()
        {
            
            //BindingOperations.EnableCollectionSynchronization(_notes, _lock);
        }

        public void ViewLoad()
        {

            //LoadNotes();
        }
    }
}