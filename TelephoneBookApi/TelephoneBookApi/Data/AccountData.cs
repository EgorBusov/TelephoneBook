using TelephoneBookApi.Authorize;
using TelephoneBookApi.Context;
using TelephoneBookApi.Interfaces;
using TelephoneBookApi.Models;

namespace TelephoneBookApi.Data
{
    public class AccountData : IAccountData
    {
        private readonly TelephoneBookContext _context;
        private readonly IJWT _jwt;
        public AccountData(TelephoneBookContext context, IJWT jwt) 
        {
            _context = context;
            _jwt = jwt;
        }

        public UserModel GetUserByLogPass(UserModel userModel)
        {
            var user = _context.Users.FirstOrDefault(a => a.Username == userModel.Username && 
                                                          a.PasswordHash == _jwt.HashPassword(userModel.Password));
            if (user == null) { return null; }
            UserModel model = new UserModel() { Role = user.Role, Username = user.Username};
            return model;
        }

        public User GetUserByLogin(string login)
        {
            return _context.Users.FirstOrDefault(u => u.Username == login);
        }

        public IEnumerable<UserModel> GetUsers()
        {
            var users = _context.Users.ToList();
            var userModels = new List<UserModel>();
            foreach (var user in users)
            {
                userModels.Add(new UserModel() { Role = user.Role,Username = user.Username});
            }
            return userModels;

        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void RemoveUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public bool CheckUserName(UserModel user)
        {
            var checkUser =  _context.Users.FirstOrDefault(a => a.Username == user.Username);
            if (checkUser != null) { return true; }
            return false;
        }
    }
}
