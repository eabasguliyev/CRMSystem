using System;

namespace CrmSystem.Domain.Models
{
    public class RecordDetail
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public DateTime RecordDate { get; set; }
        public int EmployeeId { get; set; }
    }
}