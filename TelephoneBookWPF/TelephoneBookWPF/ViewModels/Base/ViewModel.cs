using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TelephoneBookWPF.ViewModels.Base
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        #region Текст ошибки
        protected string _errorContent;
        /// <summary>
        /// Текст ошибки
        /// </summary>
        public string ErrorContent
        {
            get { return _errorContent; }
            set
            {
                Set(ref _errorContent, value);
            }
        }
        #endregion
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string proprtyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(proprtyname));
        }
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if(Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
