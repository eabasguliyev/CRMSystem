using System;

namespace CrmSystem.Domain.Models
{
    public class Contract:DomainObject
    {
        public string Name { get; set; }
        public Product Product { get; set; }
        public Employee Owner { get; set; }
        public int ContractId { get; set; }
        public Contact Contact { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public Stage Stage { get; set; }
        public decimal Amount { get; set; }
        public decimal ExpectedRevenue { get; set; }
        public RecordDetail CreatedBy { get; set; }
        public RecordDetail ModifiedBy { get; set; }
        public string Description { get; set; }

        public Company Company { get; set; }
    }

    public class Stage : DomainObject
    {
        public string Name { get; set; }
    }
    public enum SaleType
    {
        Cash = 1,
        Credit
    }
}