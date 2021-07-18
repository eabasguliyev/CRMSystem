using System.Windows;

namespace CrmSystem.WPF.Helpers
{
    public class AddEditTaskViewBehaviors
    {
        public static string GetEmployeesLoadMethodName(DependencyObject obj)
        {
            return (string)obj.GetValue(EmployeesLoadMethodNameProperty);
        }

        public static void SetEmployeesLoadMethodName(DependencyObject obj, string value)
        {
            obj.SetValue(EmployeesLoadMethodNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for LoadMethodName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EmployeesLoadMethodNameProperty =
            DependencyProperty.RegisterAttached("EmployeesLoadMethodName", typeof(string), typeof(AddEditTaskViewBehaviors), new PropertyMetadata(null, MvvmBehaviors.OnLoadMethodNameChanged));



        public static string GetLoadStatusesMethodName(DependencyObject obj)
        {
            return (string)obj.GetValue(LoadStatusesMethodNameProperty);
        }

        public static void SetLoadStatusesMethodName(DependencyObject obj, string value)
        {
            obj.SetValue(LoadStatusesMethodNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for LoadStatusesMethodName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadStatusesMethodNameProperty =
            DependencyProperty.RegisterAttached("LoadStatusesMethodName", typeof(string), typeof(AddEditTaskViewBehaviors), new PropertyMetadata(null, MvvmBehaviors.OnLoadMethodNameChanged));



        public static string GetLoadPrioritiesMethodName(DependencyObject obj)
        {
            return (string)obj.GetValue(LoadPrioritiesMethodNameProperty);
        }

        public static void SetLoadPrioritiesMethodName(DependencyObject obj, string value)
        {
            obj.SetValue(LoadPrioritiesMethodNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for LoadStatusesMethodName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadPrioritiesMethodNameProperty =
            DependencyProperty.RegisterAttached("LoadPrioritiesMethodName", typeof(string), typeof(AddEditTaskViewBehaviors), new PropertyMetadata(null, MvvmBehaviors.OnLoadMethodNameChanged));

        public static string GetLoadContactsMethodName(DependencyObject obj)
        {
            return (string)obj.GetValue(LoadContactsMethodNameProperty);
        }

        public static void SetLoadContactsMethodName(DependencyObject obj, string value)
        {
            obj.SetValue(LoadContactsMethodNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for LoadStatusesMethodName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadContactsMethodNameProperty =
            DependencyProperty.RegisterAttached("LoadContactsMethodName", typeof(string), typeof(AddEditTaskViewBehaviors), new PropertyMetadata(null, MvvmBehaviors.OnLoadMethodNameChanged));



    }
}