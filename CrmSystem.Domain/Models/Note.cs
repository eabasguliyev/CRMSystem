﻿using System;
using System.Threading.Tasks;

namespace CrmSystem.Domain.Models
{
    public abstract class Note:DomainObject
    {
        public string Text { get; set; }
        public RecordDetail CreatedBy { get; set; }
        public RecordDetail ModifiedBy { get; set; }
    }

    public class TaskNote : Note
    {
        public int TaskId { get; set; }
        public ContactTask Task { get; set; }
    }

    public class ContactNote : Note
    {
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }

    public class ContractNote : Note
    {
        public int ContractId { get; set; }
        public Contract Contract { get; set; }
    }

    public class LeadNote : Note
    {
        public int LeadId { get; set; }
    }
}