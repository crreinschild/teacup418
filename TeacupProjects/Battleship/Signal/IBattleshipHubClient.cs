namespace TeacupProjects.Battleship.Signal;

public interface IBattleshipHubClient
{
    Task BroadcastMessage(string roomId, string from, string message);
    Task JoinRoom(string roomId, string id);
    Task WelcomePlayer(string roomId, string id, string? name);
    Task DeclareName(string roomId, string id, string name);
}