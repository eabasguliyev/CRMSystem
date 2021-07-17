using System;

namespace CrmSystem.Domain.Models
{
    public abstract class User:DomainObject, ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + ' ' + LastName;
        public string Email { get; set; }
        public string ImageLink { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public DateTime? Birthdate { get; set; }
        public DateTime? CreationDate { get; set; }
        public AddressInformation AddressInfo { get; set; }
        public Company Company { get; set; }

        public User()
        {
            AddressInfo = new AddressInformation();
        }
        public virtual object Clone()
        {
            var clone = base.MemberwiseClone() as User;

            clone.AddressInfo = AddressInfo?.Clone() as AddressInformation;

            return clone;
        }

        public void Update(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            ImageLink = user.ImageLink;
            Phone = user.Phone;
            Mobile = user.Mobile;
            Birthdate = user.Birthdate;
            CreationDate = user.CreationDate;
            AddressInfo?.Update(user.AddressInfo);
        }
    }
}