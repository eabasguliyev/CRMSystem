using System.Windows;

namespace CrmSystem.WPF.Helpers
{
    public class TasksViewBehaviors
    {
        public static string GetLoadTasksMethodName(DependencyObject obj)
        {
            return (string)obj.GetValue(LoadTasksMethodNameProperty);
        }

        public static void SetLoadTasksMethodName(DependencyObject obj, string value)
        {
            obj.SetValue(LoadTasksMethodNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for LoadEmployeesMethodName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadTasksMethodNameProperty =
            DependencyProperty.RegisterAttached("LoadTasksMethodName", typeof(string), typeof(EmployeesViewBehaviors), new PropertyMetadata(null, MvvmBehaviors.OnLoadMethodNameChanged));


    }
}