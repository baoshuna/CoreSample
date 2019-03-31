using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChatRoomSample.Models
{
    public interface IChat
    {
        Task SendMsg(string message);
    }
}
