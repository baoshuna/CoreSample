using AuthSignalrChat.Models;
using System.Collections.Generic;

namespace AuthSignalrChat.Services
{
    public interface IUserService
    {
        List<User> GetUsers();
    }
}
