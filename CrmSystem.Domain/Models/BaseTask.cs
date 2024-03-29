﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CrmSystem.Domain.Models
{
    public class BaseTask:DomainObject, ICloneable
    {
        public string Subject { get; set; }
        public DateTime DueDate { get; set; }
        public PriorityOption Priority{ get; set; }
        
        public Employee Owner { get; set; }
        public RecordDetail CreatedBy { get; set; }
        public RecordDetail ModifiedBy { get; set; }
        public StatusOption Status { get; set; }
        public string Description { get; set; }
        public ObservableCollection<TaskNote> Notes { get; set; }

        public BaseTask()
        {
            Notes = new ObservableCollection<TaskNote>();
        }
        public object Clone()
        {
            return base.MemberwiseClone() as BaseTask;
        }

        public void Update(BaseTask task)
        {
            Subject = task.Subject;
            DueDate = task.DueDate;
            Owner = task.Owner;
            Description = task.Description;
            CreatedBy = task.CreatedBy;
            Status = task.Status;
            Priority = task.Priority;
            ModifiedBy = task.ModifiedBy;
        }
    }



    public enum StatusOption
    {
        NotStarted = 1,
        Postponed,
        Continues,
        Completed,
        WaitingForEntry
    }

    public enum PriorityOption
    {
        Highest = 1,
        High,
        Normal,
        Low,
        Lowest
    }
}