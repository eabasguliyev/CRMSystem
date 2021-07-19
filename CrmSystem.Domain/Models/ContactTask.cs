namespace CrmSystem.Domain.Models
{
    public class ContactTask : BaseTask
    {
        public int ContactId { get; set; }
        public Contact Contact { get; set; }

        public void Update(ContactTask task)
        {
            Contact = task.Contact;
            //ContactId = (task as ContactTask).ContactId;
            base.Update(task);
        }
    }
}