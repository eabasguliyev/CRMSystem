﻿using System;
using System.Windows.Input;

namespace CrmSystem.WPF.Helpers
{
    public class RelayCommand:ICommand
    {
        private Action _execute;
        private Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute), "Execute method can not be null");
            
            _canExecute = canExecute;
        }


        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }

        public event EventHandler CanExecuteChanged;
    }

    public class RelayCommand<TEntity> : ICommand where TEntity:class
    {
        private Action<TEntity> _execute;
        private Func<TEntity, bool> _canExecute;

        public RelayCommand(Action<TEntity> execute, Func<TEntity, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute), "Execute method can not be null");

            _canExecute = canExecute;
        }


        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter as TEntity) ?? true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter as TEntity);
        }

        public event EventHandler CanExecuteChanged;
    }
}