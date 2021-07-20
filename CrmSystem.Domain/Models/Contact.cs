using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CrmSystem.Domain.Models
{
    public class Contact:User
    {
        public string Title { get; set; }
        public int? LeadSourceId { get; set; }
        public LeadSource LeadSource { get; set; }
        public int OwnerId { get; set; }
        public Employee Owner { get; set; }
        public string Description { get; set; }
        public RecordDetail CreatedBy { get; set; }
        public RecordDetail ModifiedBy { get; set; }
        public List<ContactNote> Notes { get; set; }
        public List<ContactTask> Tasks { get; set; }
        public List<Contract> Contracts { get; set; }

        public Contact()
        {
            Notes = new List<ContactNote>();
            Tasks = new List<ContactTask>();
            Contracts = new List<Contract>();
        }
        public void Update(Contact user)
        {
            Title = user.Title;
            LeadSource = user.LeadSource;
            Owner = user.Owner;
            Description = user.Description;
            CreatedBy = user.CreatedBy;
            ModifiedBy = user.ModifiedBy;

            base.Update(user);
        }
    }
}