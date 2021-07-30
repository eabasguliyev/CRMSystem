using System.ComponentModel;
using System.Runtime.CompilerServices;
using CrmSystem.Domain.Annotations;

namespace CrmSystem.Domain.Models
{
    //public class BindableBase : INotifyPropertyChanged
    //{
    //    public void SetProperty<T>(ref T target, T value, [CallerMemberName] string propertyName = null)
    //    {
    //        if (object.Equals(target, value))
    //            return;

    //        target = value;

    //        OnPropertyChanged(propertyName);
    //    }

    //    public event PropertyChangedEventHandler PropertyChanged;

    //    [NotifyPropertyChangedInvocator]
    //    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    }
    //}

    public class DomainObject:INotifyPropertyChanged
    {
        public int Id { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}