using System;
using System.Collections.Generic;
using System.Text;
using WpfApplication.Interfaces;

namespace WpfApplication.UserApp
{
    class UsersApplication : IUsers
    {
        private DataUsers _dataUsers;
        public void Add(User user)
        {
            _dataUsers.Users.Add(user);
            _dataUsers.SaveChanges();
        }
    }
}
