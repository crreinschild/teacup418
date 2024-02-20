using Microsoft.AspNetCore.SignalR.Client;

namespace TeacupProjects.Battleship.Signal;

public interface IBattleshipClient : IBattleshipHubClient
{
    string ConnectionId { get; }
    bool IsConnected { get; }
    HubConnection HubConnection { get; }
    Task Start();
    
    void OnSend(Func<string, Task> callback);
    void OnJoin(Func<string, string, Task> callback);
    void OnAcceptJoin(Func<string, Task> callback);
    void OnRejectJoin(Func<string, Task> callback);
}