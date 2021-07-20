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
        private ObservableCollection<Note> _notes;

        private object _lock = new object();

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


            LoadNotes();
            //AddNewNoteToList(newNote);
        }

        private void AddNewNoteToList(Note newNote)
        {
            Notes.Add(newNote);
            //OnPropertyChanged(nameof(Notes));
        }

        public Contact Contact
        {
            get => _contact;
            set => base.SetProperty(ref _contact, value);
        }

        public ObservableObject BackVM { get; set; }

        public ICommand BackBtnClickCommand { get; set; }
        public ICommand SaveNoteCommand { get; set; }

        public event Action<ObservableObject> BackVmRequested;

        public ObservableCollection<Note> Notes
        {
            get => _notes;
            set => base.SetProperty(ref _notes, value);
        }

        public void Back()
        {
            BackVmRequested?.Invoke(BackVM);
        }

        public void LoadNotes()
        {
            Notes = new ObservableCollection<Note>(_unitOfWork.ContactNotes.Find(cn => cn.Contact.Id == Contact.Id).Select(cn => cn as Note).ToList());
            //BindingOperations.EnableCollectionSynchronization(_notes, _lock);
        }
    }
}