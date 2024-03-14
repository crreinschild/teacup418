using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace TeacupProjects.Battleship.Signal;

public class BattleshipClient : IBattleshipClient, IAsyncDisposable
{
    public BattleshipClient(NavigationManager navigationManager) =>
        HubConnection = new HubConnectionBuilder()
            .WithUrl(navigationManager.ToAbsoluteUri(BattleshipHub.Path))
            .WithAutomaticReconnect()
            .Build();

    public HubConnection HubConnection { get; private set; }
    
    protected bool Started { get; private set; }

    public string ConnectionId { get; private set; }
    
    public async ValueTask DisposeAsync()
    {
        if (HubConnection != null) {
            await HubConnection.DisposeAsync();
        }
    }

    public bool IsConnected => HubConnection.State == HubConnectionState.Connected;
    
    public async Task Start()
    {
        if (!Started)
        {
            await HubConnection.StartAsync();
            ConnectionId = HubConnection.ConnectionId;
            Started = true;
        }
    }
    
    public async Task BroadcastMessage(string roomId, string myId, string message) => await HubConnection.SendAsync(nameof(BroadcastMessage), roomId, myId, message);
    
    public async Task JoinRoom(string roomId, string myId) => await HubConnection.SendAsync(nameof(JoinRoom), roomId, myId);
    
    public async Task WelcomePlayer(string roomId, Player me) => await HubConnection.SendAsync(nameof(WelcomePlayer), roomId, me);

    public async Task DeclareName(string roomId, string myId, string myName) => await HubConnection.SendAsync(nameof(DeclareName), roomId, myId, myName);

    public async Task DeclareReady(string roomId, string myId) => await HubConnection.SendAsync(nameof(DeclareReady), roomId, myId);

    
    public void OnMessageReceived(Func<string, string, string, Task> action)
    {
        if (!Started)
        {
            HubConnection.On(nameof(BroadcastMessage), action);
        }
    }

    public void OnPlayerJoined(Func<string, string, Task> action)
    {
        if (!Started)
        {
            HubConnection.On(nameof(JoinRoom), action);
        }
    }

    public void OnPlayerWelcomed(Func<string, Player, Task> action)
    {
        if (!Started)
        {
            HubConnection.On(nameof(WelcomePlayer), action);
        }
    }

    public void OnPlayerChangedName(Func<string, string, string, Task> action)
    {
        if (!Started)
        {
            HubConnection.On(nameof(DeclareName), action);
        }
    }
    
    public void OnPlayerReady(Func<string, string, Task> action)
    {
        if (!Started)
        {
            HubConnection.On(nameof(DeclareReady), action);
        }
    }
}