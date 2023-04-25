using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TelephoneBookWPF.Commands;
using TelephoneBookWPF.Models;
using TelephoneBookWPF.StaticComponents;
using TelephoneBookWPF.ViewModels.Base;
using TelephoneBookWPF.Views;

namespace TelephoneBookWPF.ViewModels
{
    class MainWindowDemoViewModel : ViewModel
    {
        #region Свойства и поля
        /// <summary>
        /// Коллекция записей
        /// </summary>
        private IEnumerable<Persone> _persones;
        public IEnumerable<Persone> Persones
        {
            get { return _persones; }
            set
            {

                Set(ref _persones, value);
            }
        }
        private async Task InitializePersones()
        {
            Persones = await User._apiRequests.GetPersones();
        }
        /// <summary>
        /// Выделенный эл-т в listView
        /// </summary>
        private Persone _selectedItem;
        public Persone SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, (Persone)value);
        }
        #endregion
        #region Команды
        #region Login
        public ICommand LoginCommand { get; }
        private bool CanLoginCommandExecute(object parameter) => true;
        private void OnLoginCommandExecuted(object parameter)
        {
            MainWindowDemo mainWindowDemo = (MainWindowDemo)parameter;
            AuthorizeWindow authorize = new AuthorizeWindow();
            authorize.Show();
            mainWindowDemo.Close();
        }
        #endregion
        #endregion

        public MainWindowDemoViewModel()
        {
            InitializePersones();
            LoginCommand = new lambdaCommand(OnLoginCommandExecuted, CanLoginCommandExecute);
        }
    }
}
