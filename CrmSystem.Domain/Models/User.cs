using System;

namespace CrmSystem.Domain.Models
{
    public abstract class User:DomainObject, ICloneable
    {
        private byte[] _image;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + ' ' + LastName;
        public string Email { get; set; }

        public byte[] Image
        {
            get => _image;
            set
            {
                _image = value;
                base.OnPropertyChanged();
            }
        }

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
            Image = user.Image;
            Phone = user.Phone;
            Mobile = user.Mobile;
            Birthdate = user.Birthdate;
            CreationDate = user.CreationDate;
            Company = user.Company;
            AddressInfo?.Update(user.AddressInfo);
        }
    }
}