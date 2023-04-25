﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using TelephoneBookWPF.Commands.Base;

namespace TelephoneBookWPF.Commands
{
    public class lambdaCommand : Command
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;
        public lambdaCommand(Action<object> Execute, Func<object,bool> CanExecute = null) 
        {
            _execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _canExecute = CanExecute;
        }
        public override bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true; 

        public override void Execute(object? parameter) => _execute(parameter);
    }
}
