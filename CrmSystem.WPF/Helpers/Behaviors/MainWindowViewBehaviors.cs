using System.Security.AccessControl;
using System.Windows;

namespace CrmSystem.WPF.Helpers.Behaviors
{
    public class MainWindowViewBehaviors
    {


        public static string GetOnClosingMethodName(DependencyObject obj)
        {
            return (string)obj.GetValue(OnClosingMethodNameProperty);
        }

        public static void SetOnClosingMethodName(DependencyObject obj, string value)
        {
            obj.SetValue(OnClosingMethodNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for OnClosingMethodName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OnClosingMethodNameProperty =
            DependencyProperty.RegisterAttached("OnClosingMethodName", typeof(string), typeof(MainWindowViewBehaviors), new PropertyMetadata(null, MvvmBehaviors.OnClosingMethodNameChanged));


    }
}