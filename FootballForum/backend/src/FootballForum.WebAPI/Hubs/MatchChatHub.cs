using FootballForum.WebAPI.Models;
using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;

namespace FootballForum.WebAPI.Hubs
{
    public class MatchChatHub : Hub
    {
        public async Task JoinMatch(string matchId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, matchId);
        }

        public async Task LeaveMatch(string matchId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, matchId);
        }

        public async Task SendMessage(string matchId, string user, string message)
        {
            var chatMessage = new ChatMessage
            {
                User = user,
                Message = message,
                Timestamp = DateTime.UtcNow
            };

            await Clients.Group(matchId).SendAsync("ReceiveMessage", chatMessage);
        }
    }
}
