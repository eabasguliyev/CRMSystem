using System.Collections.Generic;

namespace CrmSystem.Domain.Models
{
    public class Lead : User
    {
        public string Title { get; set; }
        public int? LeadSourceId { get; set; }
        public LeadSource LeadSource { get; set; }
        public int OwnerId { get; set; }
        public Employee Owner { get; set; }
        public string Description { get; set; }
        public RecordDetail CreatedBy { get; set; }
        public RecordDetail ModifiedBy { get; set; }
        public List<LeadNote> Notes { get; set; }
        public List<ContactTask> Tasks { get; set; }

        public void Update(Lead user)
        {
            Title = user.Title;
            LeadSource = user.LeadSource;
            Owner = user.Owner;
            Description = user.Description;
            ModifiedBy = user.ModifiedBy;

            base.Update(user);
        }
    }
}