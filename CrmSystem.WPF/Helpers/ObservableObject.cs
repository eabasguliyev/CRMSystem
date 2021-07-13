using System.ComponentModel;
using System.Runtime.CompilerServices;
using CrmSystem.WPF.Annotations;

namespace CrmSystem.WPF.Helpers
{
    public class ObservableObject:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetProperty<T>(ref T target, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(target, value))
                return;

            target = value;

            OnPropertyChanged(propertyName);
        }
    }
}