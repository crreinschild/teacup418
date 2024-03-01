namespace TeacupProjects.Battleship;

public record Player()
{
    public string id;
    public string? name;
    public bool isReady;
    public bool isInGame;
    public Board theirBoard;
}