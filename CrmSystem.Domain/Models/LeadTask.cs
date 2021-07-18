namespace CrmSystem.Domain.Models
{
    public class LeadTask : BaseTask
    {
        public int LeadId { get; set; }
        public Lead Lead { get; set; }
    }
}