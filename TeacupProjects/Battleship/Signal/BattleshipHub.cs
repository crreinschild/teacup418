using System.Numerics;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.SignalR;

namespace TeacupProjects.Battleship.Signal;

public class BattleshipHub : Hub<IBattleshipHubClient>
{
    public static string Path = "/battleship_hub";
    
    public async Task BroadcastMessage(string roomId, string myId, string message) => await Clients.OthersInGroup(roomId).BroadcastMessage(roomId, myId, message);

    public async Task JoinRoom(string roomId, string myId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
        await Clients.OthersInGroup(roomId).JoinRoom(roomId, myId);
    } 
    public async Task WelcomePlayer(string roomId, string myId, string? myName) => await Clients.OthersInGroup(roomId).WelcomePlayer(roomId, myId, myName);
    public async Task DeclareName(string roomId, string myId, string myName) => await Clients.Group(roomId).DeclareName(roomId, myId, myName);
}