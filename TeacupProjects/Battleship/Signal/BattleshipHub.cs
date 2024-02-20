using Microsoft.AspNetCore.SignalR;

namespace TeacupProjects.Battleship.Signal;

public class BattleshipHub : Hub<IBattleshipHubClient>
{
    public static string Path = "/battleship_hub";
    
    public async Task Send(string message) => await Clients.All.Send(message);
    public async Task Join(string id, string connectionId) => await Clients.All.Join(id, connectionId);
    public async Task AcceptJoin(string to, string connectionId) => await Clients.Client(to).AcceptJoin(connectionId);
    public async Task RejectJoin(string to, string message) => await Clients.Client(to).RejectJoin(message);
    
    public override async Task OnConnectedAsync()
    {
        await Clients.Caller.Send($"Welcome to the Battleship Hub {Context?.GetHttpContext()?.Request.Path}!");
        await base.OnConnectedAsync();
    }
}