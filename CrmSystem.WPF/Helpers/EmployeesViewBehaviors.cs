using System.Windows;

namespace CrmSystem.WPF.Helpers
{
    public class EmployeesViewBehaviors
    {


        public static string GetLoadEmployeesMethodName(DependencyObject obj)
        {
            return (string)obj.GetValue(LoadEmployeesMethodNameProperty);
        }

        public static void SetLoadEmployeesMethodName(DependencyObject obj, string value)
        {
            obj.SetValue(LoadEmployeesMethodNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for LoadEmployeesMethodName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadEmployeesMethodNameProperty =
            DependencyProperty.RegisterAttached("LoadEmployeesMethodName", typeof(string), typeof(EmployeesViewBehaviors), new PropertyMetadata(null, MvvmBehaviors.OnLoadMethodNameChanged));


    }
}