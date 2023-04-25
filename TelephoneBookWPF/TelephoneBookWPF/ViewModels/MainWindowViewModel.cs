using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Windows;
using System.Windows.Input;
using TelephoneBookWPF.Commands;
using TelephoneBookWPF.Models;
using TelephoneBookWPF.StaticComponents;
using TelephoneBookWPF.ViewModels.Base;
using TelephoneBookWPF.Views;

namespace TelephoneBookWPF.ViewModels
{
    internal class MainWindowViewModel : ViewModel
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
        #region Добавление Persone
        public ICommand AddPersoneCommand { get; }
        private bool CanAddPersoneExecute(object parameter) => true;
        private void OnAddPersoneExecuted(object parameter)
        {
            AddWindow add = new AddWindow();
            add.Show();
        }
        #endregion       
        # region Logout
        public ICommand LogoutCommand { get; }
        private bool CanLogoutExecute(object parameter) => true;
        private void OnlogoutExecuted(object parameter)
        {
            User._tokenResponse = null;
            User._userModel = null;
            MainWindow mainWindow = parameter as MainWindow;
            AuthorizeWindow authorizeWindow = new AuthorizeWindow();
            authorizeWindow.Show();
            mainWindow.Close();
        }
        #endregion
        #region Users
        public ICommand UsersCommand { get; }
        private bool CanUsersExecute(object parameter) => true;
        private void OnUsersExecuted(object parameter)
        {
            UsersWindow usersWindow = new UsersWindow();
            usersWindow.Show();
        }
        #endregion
        #region Изменение Persone
        public ICommand EditCommand { get; }
        private bool CanEditCommandExecute(object parameter) => true;
        private void OnEditCommandExecuted(object parameter)
        {
            if (_selectedItem == null) { return; }
            EditWindow editWindow = new EditWindow(_selectedItem);
            editWindow.Show();
        }
        #endregion
        #region Удаление Persone
        public ICommand DeleteCommand { get; }
        private bool CanDeleteCommandExecute(object parameter) => true;
        private async void OnDeleteCommandExecuted(object parameter)
        {
            try
            {
                if (_selectedItem == null) { return; }
                await User._apiRequests.PersoneDelete(_selectedItem.Id, User._tokenResponse.token);
            }
            catch (HttpResponseException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.Unauthorized) { ErrorContent = "Авторизуйтесь"; }
                else if (ex.Response.StatusCode == HttpStatusCode.Forbidden) { ErrorContent = "К сожалению у вас нет доступа"; }
                else
                {
                    ErrorContent = ex.Message;
                }
            }
        }
        #endregion
        #region Обновление _persones
        public ICommand InitPersonesCommand { get; }
        private bool CanInitPersonesCommandExecute(object parameter) => true;
        private async void OnInitPersonesCommandExecuted(object parameter)
        {
            InitializePersones();
        }       
        #endregion
        #endregion
        public MainWindowViewModel()
        {
            InitializePersones();
            #region Команды
            AddPersoneCommand = new lambdaCommand(OnAddPersoneExecuted, CanAddPersoneExecute);
            LogoutCommand = new lambdaCommand(OnlogoutExecuted, CanLogoutExecute);
            UsersCommand = new lambdaCommand(OnUsersExecuted, CanUsersExecute);
            EditCommand = new lambdaCommand(OnEditCommandExecuted, CanEditCommandExecute);
            DeleteCommand = new lambdaCommand(OnDeleteCommandExecuted, CanDeleteCommandExecute);
            InitPersonesCommand = new lambdaCommand(OnInitPersonesCommandExecuted, CanInitPersonesCommandExecute);
            #endregion
        }

    }
}
