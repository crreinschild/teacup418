namespace TeacupProjects.Battleship.Signal;

public interface IBattleshipHubClient
{
    Task Send(string message);
    Task Join(string id, string connectionId);
    Task AcceptJoin(string connectionId);
    Task RejectJoin(string message);
}