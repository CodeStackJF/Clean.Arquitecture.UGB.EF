using Microsoft.AspNetCore.SignalR;
using UGB.Domain.Interfaces;
namespace UGB.Services.Hubs
{
    //[Authorize]
    public class SignalRMessageHub : Hub
    {
        private readonly ISignalRSessionsRepository signalRSessionsRepository;
        public SignalRMessageHub(ISignalRSessionsRepository _signalRSessionsRepository)
        {
            signalRSessionsRepository = _signalRSessionsRepository;
        }

        public async Task SendMessageToUser(string user, string message)
        {
            Console.WriteLine(user);
            await Clients.User(user).SendAsync("ReceiveMessage", message);
        }

        public override async Task OnConnectedAsync()
        {
            //string userName = Context.User!.GetProperty(ClaimTypes.NameIdentifier);
            string userName = "jairofu";
            await signalRSessionsRepository.Insert(userName, true, Context.ConnectionId);
            await Clients.All.SendAsync("UserConnected", new {Context.ConnectionId, userName});
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            //string userName = Context.User!.GetProperty(ClaimTypes.NameIdentifier);
            string userName = "jairofu";
            await signalRSessionsRepository.Insert(userName, false, Context.ConnectionId);
            await Clients.All.SendAsync("UserDisconnected", new {Context.ConnectionId, userName});
            await base.OnDisconnectedAsync(exception);
        }
    }
}