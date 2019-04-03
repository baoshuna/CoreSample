using AuthSignalrChat.Models;
using System.Collections.Generic;

namespace AuthSignalrChat.Services
{
    public class UserService : IUserService
    {
        private static readonly List<User> _users = new List<User>
        {
            new User
            {
                Id = "id11",
                UserName = "1@qq.com",
                Password = "123456"
            },
            new User
            {
                Id = "id22",
                UserName = "2@qq.com",
                Password = "123456"
            }
        };
        public List<User> GetUsers()
        {
            return _users;
        }
    }
}
