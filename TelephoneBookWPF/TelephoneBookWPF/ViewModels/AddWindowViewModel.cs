using Newtonsoft.Json.Serialization;
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
    internal class AddWindowViewModel : ViewModel
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
        #region Добавление Persone
        public ICommand AddCommand { get; }
        private bool CanAddCommandExecute(object parameter) => true;
        private async void OnAddCommandExecuted(object parameter)
        {
            if (Persone.SurName == null || Persone.Name == null || Persone.FatherName == null ||
            Persone.Telephone == null || Persone.Address == null || Persone.Description == null)
            {
                ErrorContent = "Заполните все поля"; return;
            }
            try
            {
                await User._apiRequests.PersoneAdd(Persone, User._tokenResponse.token);
                AddWindow addWindow = (AddWindow)parameter;
                addWindow.Close();
            }
            catch (HttpResponseException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    ErrorContent = "К сожалению у вас нет доступа";
                }
                else
                {
                    ErrorContent = ex.Message;
                }
            }
        }
        #endregion
        #endregion

        public AddWindowViewModel()
        {
            _persone = new Persone();
            AddCommand = new lambdaCommand(OnAddCommandExecuted, CanAddCommandExecute);
        }
    }
}
