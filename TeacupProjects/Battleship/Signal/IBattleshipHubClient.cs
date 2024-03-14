namespace TeacupProjects.Battleship.Signal;

public interface IBattleshipHubClient
{
    Task BroadcastMessage(string roomId, string from, string message);
    Task JoinRoom(string roomId, string id);
    Task WelcomePlayer(string roomId, Player me);
    Task DeclareName(string roomId, string id, string name);
    Task DeclareReady(string roomId, string id);
}