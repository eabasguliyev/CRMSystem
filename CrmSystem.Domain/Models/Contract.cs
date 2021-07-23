using System;
using System.Collections.Generic;

namespace CrmSystem.Domain.Models
{
    public class Contract:DomainObject, ICloneable
    {
        public string Name { get; set; }
        public Product Product { get; set; }
        public Employee Owner { get; set; }
        public int ContractId { get; set; }
        public Contact Contact { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public Stage Stage { get; set; }
        public decimal Amount { get; set; }
        public decimal ExpectedRevenue { get; set; }
        public int Probability { get; set; }
        public LeadSource LeadSource { get; set; }
        public RecordDetail CreatedBy { get; set; }
        public RecordDetail ModifiedBy { get; set; }
        public string Description { get; set; }
        public Company Company { get; set; }


        public object Clone()
        {
            return base.MemberwiseClone();
        }

        public void Update(Contract contract)
        {
            Name = contract.Name;
            LeadSource = contract.LeadSource;
            Contact = contract.Contact;
            StartDate = contract.StartDate;
            ClosingDate = contract.ClosingDate;
            Amount = contract.Amount;
            Company = contract.Company;
            ExpectedRevenue = contract.ExpectedRevenue;
            Probability = contract.Probability;
            Owner = contract.Owner;
            Description = contract.Description;
            CreatedBy = contract.CreatedBy;
            ModifiedBy = contract.ModifiedBy;
            Stage = contract.Stage;
        }
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