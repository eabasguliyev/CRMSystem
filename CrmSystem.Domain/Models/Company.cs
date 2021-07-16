using System.Collections.Generic;

namespace CrmSystem.Domain.Models
{
    public class Company:DomainObject
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public List<Contact> Contacts { get; set; }
        public List<Employee> Employees { get; set; }
        public List<LeadSource> LeadSources { get; set; }
        public List<Product> Products { get; set; }
        public List<Contract> Contracts { get; set; }

        public Company()
        {
            Contacts = new List<Contact>();
            Employees = new List<Employee>();
            LeadSources = new List<LeadSource>();
            Products = new List<Product>();
            Contracts = new List<Contract>();
        }
    }
}