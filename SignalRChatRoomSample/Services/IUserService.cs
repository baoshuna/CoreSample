using SignalRChatRoomSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChatRoomSample.Services
{
    public interface IUserService
    {
        List<User> GetUsers();
    }
}
