using System.Windows;

namespace CrmSystem.WPF.Helpers.Behaviors
{
    public class EditEmployeeViewBehaviors
    {

        public static string GetViewLoadMethodName(DependencyObject obj)
        {
            return (string)obj.GetValue(ViewLoadMethodNameProperty);
        }

        public static void SetViewLoadMethodName(DependencyObject obj, string value)
        {
            obj.SetValue(ViewLoadMethodNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for ViewLoadMethodName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewLoadMethodNameProperty =
            DependencyProperty.RegisterAttached("ViewLoadMethodName", typeof(string), typeof(EditEmployeeViewBehaviors), new PropertyMetadata(null, MvvmBehaviors.OnLoadMethodNameChanged));

    }
}