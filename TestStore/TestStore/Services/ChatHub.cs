using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using TestStore.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace TestStore.Services
{
    [Authorize]
    public class ChatHub : Hub
    {   

        public async Task Send(string message)
        {
            //var user = Context.User;
            //var userName = user.Identity.Name;
            await Clients.All.SendAsync("Send", message);
        }
    }
}
