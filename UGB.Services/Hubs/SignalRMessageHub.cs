using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using UGB.Domain.Interfaces;
using UGB.Services.Helper;
namespace UGB.Services.Hubs
{
    [Authorize]
    public class SignalRMessageHub : Hub
    {
        private readonly ISignalRSessionsRepository signalRSessionsRepository;
        public SignalRMessageHub(ISignalRSessionsRepository _signalRSessionsRepository)
        {
            signalRSessionsRepository = _signalRSessionsRepository;
        }

        public async Task SendMessageToUser(string user, string message)
        {
            await Clients.User(user).SendAsync("ReceiveMessage", message);
        }

        public override async Task OnConnectedAsync()
        {
            string userName = Context.User!.GetProperty(ClaimTypes.NameIdentifier);
            await signalRSessionsRepository.Insert(userName, true, Context.ConnectionId);
            await Clients.All.SendAsync("UserConnected", new {Context.ConnectionId, userName});
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            string userName = Context.User!.GetProperty(ClaimTypes.NameIdentifier);
            await signalRSessionsRepository.Insert(userName, false, Context.ConnectionId);
            await Clients.All.SendAsync("UserDisconnected", new {Context.ConnectionId, userName});
            await base.OnDisconnectedAsync(exception);
        }
    }
}