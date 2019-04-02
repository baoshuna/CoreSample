using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChatRoomSample.Hubs
{
    public class NameUserIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            // 这里拿到了一个连接上下文
            // 可以通过这个连接上下文选择用什么做标识来判定用户
            // 是cookie还是user还是queryString
            var x = connection.User?.Identity?.Name;

            // return connection.GetHttpContext().Request.Query["userid"];

            return connection.User?.FindFirst("UserName")?.Value;
        }
    }
}
