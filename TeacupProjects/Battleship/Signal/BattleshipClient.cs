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
    
    public async Task Send(string message) => await HubConnection.SendAsync(nameof(Send), message);
    
    public async Task Join(string id, string connectionId) => await HubConnection.SendAsync(nameof(Join), id, connectionId);
    
    public async Task AcceptJoin(string connectionId) => await HubConnection.SendAsync(nameof(AcceptJoin), connectionId);

    public async Task RejectJoin(string message) => await HubConnection.SendAsync(nameof(RejectJoin), message);

    public void OnSend(Func<string, Task> action)
    {
        if (!Started)
        {
            HubConnection.On(nameof(Send), action);
        }
    }

    public void OnJoin(Func<string, string, Task> action)
    {
        if (!Started)
        {
            HubConnection.On(nameof(Join), action);
        }
    }

    public void OnAcceptJoin(Func<string, Task> connectionId)
    {
        if (!Started)
        {
            HubConnection.On(nameof(AcceptJoin), connectionId);
        }
    }

    public void OnRejectJoin(Func<string, Task> message)
    {
        if (!Started)
        {
            HubConnection.On(nameof(RejectJoin), message);
        }
    }
}