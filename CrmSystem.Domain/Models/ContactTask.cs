namespace CrmSystem.Domain.Models
{
    public class ContactTask : BaseTask
    {
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}