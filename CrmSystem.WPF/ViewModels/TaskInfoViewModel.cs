using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using CrmSystem.Domain;
using CrmSystem.WPF.Helpers;
using CrmSystem.Domain.Models;
using CrmSystem.WPF.ViewModels.Services;


namespace CrmSystem.WPF.ViewModels
{
    
    public class TaskInfoViewModel:ObservableObject, IBackable
    {
        private readonly IUnitOfWork _unitOfWork;
        private BaseTask _task;
        private string _text;

        public TaskInfoViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            BackBtnClickCommand = new RelayCommand(Back);
            EditBtnCommand = new RelayCommand(Edit);
            CloseTaskBtnCommand = new RelayCommand(CloseTask);
            SaveNoteCommand = new RelayCommand(SaveNote);
        }

       
        public BaseTask Task
        {
            get => _task;
            set
            {
                base.SetProperty(ref _task, value);

                if (_task is ContactTask ct)
                {
                    _unitOfWork.ContactTasks.GetNotes(ct.Id);
                    OnPropertyChanged(nameof(Notes));
                }
            }
        }

        public ObservableCollection<Note> Notes
        {
            get => new ObservableCollection<Note>(Task.Notes);
        }

        public string Text
        {
            get => _text;
            set => base.SetProperty(ref _text, value);
        }

        public ObservableObject BackVM { get; set; }
        public ICommand BackBtnClickCommand { get; set; }
        public ICommand EditBtnCommand { get; set; }
        public ICommand CloseTaskBtnCommand { get; set; }
        public ICommand SaveNoteCommand  { get; set; }

        public event Action<ObservableObject> BackVmRequested;
        public event EventHandler<AddEditTaskEventArgs> EditButtonClicked;



        private void SaveNote()
        {
            if (string.IsNullOrWhiteSpace(Text))
                return;

            Task.Notes.Add(new TaskNote()
            {
                CreatedBy = new RecordDetail()
                {
                    Employee = App.LoggedUser,
                    RecordDate =  DateTime.Now
                },
                Text = Text,
                Task = Task as ContactTask
            });

            _unitOfWork.Save();
            Text = string.Empty;
        }

        private void CloseTask()
        {
            var status = MessageBox.Show("Are you sure you want to mark this task as completed?",
                "Mark as Completed", MessageBoxButton.YesNo,
                MessageBoxImage.Information);

            if (status == MessageBoxResult.No)
                return;


            Task.Status = StatusOption.Completed;
            _unitOfWork.Save();
            Back();
        }

        private void Edit()
        {
            EditButtonClicked?.Invoke(this, new AddEditTaskEventArgs()
            {
                EditMode = true,
                Task = Task,
            });
        }

        public void Back()
        {
            BackVmRequested?.Invoke(BackVM);
        }

        public void ViewLoad()
        {

        }
    }
}