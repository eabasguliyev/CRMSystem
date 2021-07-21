using System.Windows;

namespace CrmSystem.WPF.Helpers.Behaviors
{
    public static class MvvmBehaviors
    {
        public static void OnLoadMethodNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is FrameworkElement uiElement))
                return;

            uiElement.Loaded += (sender, args) =>
            {
                var viewModel = uiElement.DataContext;

                if (viewModel == null)
                    return;

                var methodInfo = viewModel.GetType().GetMethod(e.NewValue.ToString());

                if (methodInfo == null)
                    return;

                methodInfo.Invoke(viewModel, null);
            };
        }

        public static void OnClosingMethodNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is Window window))
                return;

            window.Closing += (sender, args) =>
            {
                var viewModel = window.DataContext;

                if (viewModel == null)
                    return;

                var methodInfo = viewModel.GetType().GetMethod(e.NewValue.ToString());

                if (methodInfo == null)
                    return;

                methodInfo.Invoke(viewModel, null);
            };
        }
    }
}