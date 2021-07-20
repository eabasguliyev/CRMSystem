using System.Windows;

namespace CrmSystem.WPF.Helpers
{
    public class ContactInfoViewBehaviors
    {
        public static string GetLoadNotesMethodName(DependencyObject obj)
        {
            return (string)obj.GetValue(LoadNotesMethodNameProperty);
        }

        public static void SetLoadNotesMethodName(DependencyObject obj, string value)
        {
            obj.SetValue(LoadNotesMethodNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for LoadNotesMethodName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadNotesMethodNameProperty =
            DependencyProperty.RegisterAttached("LoadNotesMethodName", typeof(string), typeof(ContactInfoViewBehaviors), new PropertyMetadata(null, MvvmBehaviors.OnLoadMethodNameChanged));


    }
}