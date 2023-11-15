using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using SignalR_chat_api.Models;
using System.Xml.Schema;

namespace SignalR_chat_api.Hubs
{
    public class AdminandClientsChatHub : Hub
    {

        private readonly UserManager<AppUser> _userManager;

        CatchManager um = new CatchManager(new EFCatchRepository());

        Context c = new Context();

        static List<string> clients = new List<string>();

        public AdminandClientsChatHub(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task SendMessage(Catch sohbet)
        {
            await Clients.All.SendAsync("receiveMessage", sohbet.CatchDetails);
        }

        public override async Task OnConnectedAsync()
        {
            clients.Add(Context.ConnectionId);
            await Clients.All.SendAsync("clients", clients);
            await Clients.All.SendAsync("userJoined", Context.ConnectionId);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clients.Remove(Context.ConnectionId);
            await Clients.All.SendAsync("clients", clients);
            await Clients.All.SendAsync("userLeaved", Context.ConnectionId);
        }

    }
}
