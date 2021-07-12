using System;

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
    }

    public class ContactNote : Note
    {
        public int ContactId { get; set; }
    }
}