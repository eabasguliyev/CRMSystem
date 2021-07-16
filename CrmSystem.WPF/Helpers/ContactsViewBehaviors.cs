using System.Security.AccessControl;
using System.Windows;

namespace CrmSystem.WPF.Helpers
{
    public class ContactsViewBehaviors
    {


        public static string GetLoadedMethodName(DependencyObject obj)
        {
            return (string)obj.GetValue(LoadedMethodNameProperty);
        }

        public static void SetLoadedMethodName(DependencyObject obj, string value)
        {
            obj.SetValue(LoadedMethodNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for LoadMethodName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadedMethodNameProperty =
            DependencyProperty.RegisterAttached("LoadedMethodName", typeof(string), typeof(ContactsViewBehaviors), new PropertyMetadata(null, MvvmBehaviors.OnLoadMethodNameChanged));

    }
}