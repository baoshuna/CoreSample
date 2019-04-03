using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSignalrChat.Hubs
{
    [Authorize]
    public class UserChatHub : Hub
    {
        public async Task SendToUser(string sendTo, string message)
        {
            await Clients.User(sendTo).SendAsync("ReceiveDirectMessage", $"{Context.UserIdentifier}:{message}---{DateTime.Now}");
        }
    }
}
