using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRChatRoomSample.Hubs;
using SignalRChatRoomSample.Models;

namespace SignalRChatRoomSample.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IHubContext<ChatHub> _hubContext;

        //public HomeController(IHubContext<ChatHub> hubContext)
        //{
        //    _hubContext = hubContext;
        //}
        public IActionResult Send()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Send([FromServices]IHubContext<ChatHub> hubContext, string user,string message)
        {
            hubContext.Clients.All.SendAsync("ReceiveMessage", user, message + "---" + DateTime.Now.ToString());
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
