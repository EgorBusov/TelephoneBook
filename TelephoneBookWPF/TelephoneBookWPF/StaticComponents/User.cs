using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneBookWPF.ApiInteraction;
using TelephoneBookWPF.Models;

namespace TelephoneBookWPF.StaticComponents
{
    public static class User
    {
        public static UserModel _userModel { get; set; }
        public static TokenResponse _tokenResponse { get; set; }
        public static ApiRequests _apiRequests {  get; set; }
    }
}
