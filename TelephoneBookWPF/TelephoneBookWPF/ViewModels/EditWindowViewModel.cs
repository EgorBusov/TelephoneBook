using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Windows.Input;
using TelephoneBookWPF.Commands;
using TelephoneBookWPF.Models;
using TelephoneBookWPF.StaticComponents;
using TelephoneBookWPF.ViewModels.Base;
using TelephoneBookWPF.Views;

namespace TelephoneBookWPF.ViewModels
{
    internal class EditWindowViewModel : ViewModel
    {
        #region Поля и свойства
        private Persone _persone;
        public Persone Persone
        {
            get { return _persone; }
            set { Set(ref _persone, value); }
        }
        #endregion
        #region Команды
        #region Изменение Persone
        public ICommand EditCommand { get; }
        private bool CanEditCommandExecute(object parameter) => true;
        private async void OnEditCommandExecuted(object parameter)
        {
            if (Persone.SurName == null || Persone.Name == null || Persone.FatherName == null ||
            Persone.Telephone == null || Persone.Address == null || Persone.Description == null)
            {
                ErrorContent = "Заполните все поля"; return;
            }
            try
            {
                await User._apiRequests.PersoneEdit(_persone, User._tokenResponse.token);
                EditWindow editWindow = (EditWindow)parameter;
                editWindow.Close();
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
        #endregion
        public EditWindowViewModel(Persone persone)
        {
            _persone = persone;
            EditCommand = new lambdaCommand(OnEditCommandExecuted, CanEditCommandExecute);
        }
    }
}
