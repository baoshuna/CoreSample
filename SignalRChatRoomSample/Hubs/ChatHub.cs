using Microsoft.AspNetCore.SignalR;
using SignalRChatRoomSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChatRoomSample.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message + "---" + DateTime.Now.ToString());
        }

        //public Task SendMessageToGroup(string user, string message)
        //{
        //    var group = new List<string>{ "group1", "group2" };
        //    return Clients.Groups(group).SendAsync("ReceiveMessage", message + "---" + DateTime.Now.ToString());
        //}

        //public override async Task OnConnectedAsync()
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", "Admin", "Hello World From Hub" + "---" + DateTime.Now.ToString());
        //    await Groups.AddToGroupAsync(Context.ConnectionId, "group1");
        //    await base.OnConnectedAsync();
        //}

        //public override async Task OnDisconnectedAsync(Exception exception)
        //{
        //    await Groups.RemoveFromGroupAsync(Context.ConnectionId, "group1");
        //    await base.OnDisconnectedAsync(exception);
        //}
    }
}
