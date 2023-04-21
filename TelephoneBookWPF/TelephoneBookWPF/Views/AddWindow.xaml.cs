using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TelephoneBookWPF.Models;
using TelephoneBookWPF.StaticComponents;

namespace TelephoneBookWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Добавление записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void addButton_Click(object sender, RoutedEventArgs e)
        {
            if(textSurName.Text == String.Empty || textName.Text == String.Empty || textFatherName.Text == String.Empty || 
            textTelephone.Text == String.Empty || textAddress.Text == String.Empty || textDescription.Text == String.Empty) 
            {
                error.Content = "Заполните все поля"; return;
            }
            try
            {
                Persone persone = new Persone() { SurName = textSurName.Text, Name = textName.Text, FatherName = textFatherName.Text,
                                                Telephone = textTelephone.Text, Address = textAddress.Text, Description = textDescription.Text};
                await User._apiRequests.PersoneAdd(persone, User._tokenResponse.token);
                Close();
            }
            catch(HttpResponseException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    error.Content = "К сожалению у вас нет доступа";
                }
                else
                {
                    error.Content = ex.Message;
                }
            }
        }
    }
}
