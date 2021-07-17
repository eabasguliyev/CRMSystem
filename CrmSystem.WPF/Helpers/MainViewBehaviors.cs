using System.Security.AccessControl;
using System.Windows;

namespace CrmSystem.WPF.Helpers
{
    public class MainViewBehaviors
    {
        public static string GetInitialSetupMethodName(DependencyObject obj)
        {
            return (string)obj.GetValue(InitialSetupMethodNameProperty);
        }

        public static void SetInitialSetupMethodName(DependencyObject obj, string value)
        {
            obj.SetValue(InitialSetupMethodNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for InitialSetupMethodName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InitialSetupMethodNameProperty =
            DependencyProperty.RegisterAttached("InitialSetupMethodName", typeof(string), typeof(MainViewBehaviors), new PropertyMetadata(null, MvvmBehaviors.OnLoadMethodNameChanged));



        public static string GetViewLoad(DependencyObject obj)
        {
            return (string)obj.GetValue(ViewLoadProperty);
        }

        public static void SetViewLoad(DependencyObject obj, string value)
        {
            obj.SetValue(ViewLoadProperty, value);
        }

        // Using a DependencyProperty as the backing store for ViewLoad.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewLoadProperty =
            DependencyProperty.RegisterAttached("ViewLoad", typeof(string), typeof(MainViewBehaviors), new PropertyMetadata(null, MvvmBehaviors.OnLoadMethodNameChanged));


    }
}