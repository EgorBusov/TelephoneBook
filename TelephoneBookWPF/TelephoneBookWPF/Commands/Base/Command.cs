﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TelephoneBookWPF.Commands.Base
{
    public abstract class Command : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        /// <summary>
        /// Возможность выполнения команды
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public abstract bool CanExecute(object? parameter);// прописываются условия при которых может выполнится
        /// <summary>
        /// Логикавыполнения команды
        /// </summary>
        /// <param name="parameter"></param>
        /// <exception cref="NotImplementedException"></exception>
        public abstract void Execute(object? parameter);
    }
}
