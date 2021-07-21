using System.Security.AccessControl;
using System.Windows;

namespace CrmSystem.WPF.Helpers
{
    public class AddEditContactViewBehaviors
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
            DependencyProperty.RegisterAttached("EmployeesLoadMethodName", typeof(string), typeof(AddEditContactViewBehaviors), new PropertyMetadata(null, MvvmBehaviors.OnLoadMethodNameChanged));




        public static string GetLeadSourcesLoadMethodName(DependencyObject obj)
        {
            return (string)obj.GetValue(LeadSouLeadSourcesLoadMethodNameProperty);
        }

        public static void SetLeadSourcesLoadMethodName(DependencyObject obj, string value)
        {
            obj.SetValue(LeadSouLeadSourcesLoadMethodNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for LeadSourcesLoadMethodName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LeadSouLeadSourcesLoadMethodNameProperty =
            DependencyProperty.RegisterAttached("LeadSourcesLoadMethodName", typeof(string), typeof(AddEditContactViewBehaviors), new PropertyMetadata(null, MvvmBehaviors.OnLoadMethodNameChanged));




        public static string GetInitialMethodName(DependencyObject obj)
        {
            return (string)obj.GetValue(InitialMethodNameProperty);
        }

        public static void SetInitialMethodName(DependencyObject obj, string value)
        {
            obj.SetValue(InitialMethodNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for InitialMethodName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InitialMethodNameProperty =
            DependencyProperty.RegisterAttached("InitialMethodName", typeof(string), typeof(AddEditContactViewBehaviors), new PropertyMetadata(null, MvvmBehaviors.OnLoadMethodNameChanged));

    }
}