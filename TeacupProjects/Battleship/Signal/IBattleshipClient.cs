using Microsoft.AspNetCore.SignalR.Client;

namespace TeacupProjects.Battleship.Signal;

public interface IBattleshipClient : IBattleshipHubClient
{
    string ConnectionId { get; }
    bool IsConnected { get; }
    HubConnection HubConnection { get; }
    Task Start();
    
    void OnMessageReceived(Func<string, string, string, Task> callback);
    void OnPlayerJoined(Func<string, string, Task> callback);
    void OnPlayerWelcomed(Func<string, string, string?, Task> callback);
    void OnPlayerChangedName(Func<string, string, string, Task> callback);
}