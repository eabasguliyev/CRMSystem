namespace CrmSystem.Domain.Models
{
    public class ContactTask : BaseTask
    {
        public int ContactId { get; set; }
        public Contact Contact { get; set; }

        public void Update(BaseTask task)
        {
            Contact = (task as ContactTask).Contact;
            //ContactId = (task as ContactTask).ContactId;
            base.Update(task);
        }
    }
}