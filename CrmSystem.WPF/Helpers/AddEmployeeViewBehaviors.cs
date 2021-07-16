using System.Windows;

namespace CrmSystem.WPF.Helpers
{
    public class AddEmployeeViewBehaviors
    {

        public static string GetLoadRolesMethodName(DependencyObject obj)
        {
            return (string)obj.GetValue(LoadRolesMethodNameProperty);
        }

        public static void SetLoadRolesMethodName(DependencyObject obj, string value)
        {
            obj.SetValue(LoadRolesMethodNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for LoadRoleMethodName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadRolesMethodNameProperty =
            DependencyProperty.RegisterAttached("LoadRolesMethodName", typeof(string), typeof(AddEmployeeViewBehaviors), new PropertyMetadata(null, MvvmBehaviors.OnLoadMethodNameChanged));


        public static string GetLoadProfilesMethodName(DependencyObject obj)
        {
            return (string)obj.GetValue(LoadProfilesMethodNameProperty);
        }

        public static void SetLoadProfilesMethodName(DependencyObject obj, string value)
        {
            obj.SetValue(LoadProfilesMethodNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for LoadProfilesMethodName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadProfilesMethodNameProperty =
            DependencyProperty.RegisterAttached("LoadProfilesMethodName", typeof(string), typeof(AddEmployeeViewBehaviors), new PropertyMetadata(null, MvvmBehaviors.OnLoadMethodNameChanged));


    }
}