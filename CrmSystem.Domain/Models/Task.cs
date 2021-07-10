using System;

namespace CrmSystem.Domain.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime DueDate { get; set; }
        public PriorityOption Priority{ get; set; }
        public Contact Contact { get; set; }
        public Employee Owner { get; set; }
        public RecordDetail CreatedBy { get; set; }
        public RecordDetail ModifiedBy { get; set; }
        public StatusOption Status { get; set; }
        public string Description { get; set; }
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