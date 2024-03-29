﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
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

        private string _text;

        public ContactInfoViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
            BackBtnClickCommand = new RelayCommand(Back);
            SaveNoteCommand = new RelayCommand(SaveNote);
            EditBtnClickCommand = new RelayCommand(Edit);
            RemoveClickCommand = new RelayCommand(Remove);
        }


        private void Remove()
        {
            _unitOfWork.Contacts.Remove(Contact);
            _unitOfWork.Save();

            MessageBox.Show("Contact removed", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            RemoveButtonClicked?.Invoke();
        }

        private void Edit()
        {
            EditButtonClicked?.Invoke(this, new AddEditContactEventArgs()
            {
                EditMode = true,
                Contact = Contact
            });
        }

        private void SaveNote()
        {
            if (string.IsNullOrWhiteSpace(Text))
                return;

            var newNote = new ContactNote()
            {
                Contact = Contact,
                CreatedBy = new RecordDetail()
                {
                    Employee = App.LoggedUser,
                    RecordDate = DateTime.Now
                },
                Text = Text
            };

            Contact.Notes.Add(newNote);

            _unitOfWork.Save();

            Text = String.Empty;
        }

        public string Text
        {
            get => _text;
            set => base.SetProperty(ref _text, value);
        }

        public Contact Contact
        {
            get => _contact;
            set
            {
                base.SetProperty(ref _contact, value);

                _unitOfWork.Contacts.GetNotes(_contact.Id);
                OnPropertyChanged(nameof(Notes));
            }
        }

        public ObservableObject BackVM { get; set; }

        public ICommand BackBtnClickCommand { get; set; }
        public ICommand SaveNoteCommand { get; set; }
        public ICommand EditBtnClickCommand { get; set; }
        public ICommand RemoveClickCommand { get; set; }


        public event Action<ObservableObject> BackVmRequested;
        public event EventHandler<AddEditContactEventArgs> EditButtonClicked;
        public event Action RemoveButtonClicked;


        public ObservableCollection<Note> Notes => new ObservableCollection<Note>(Contact.Notes);


        public void Back()
        {
            BackVmRequested?.Invoke(BackVM);
        }
        

        public void ViewLoad()
        {
            //LoadNotes();
        }
    }
}