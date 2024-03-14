using System.Runtime.Serialization;

namespace TeacupProjects.Battleship;

public class Player()
{
    public string id;
    public string? name;
    public bool isReady;
    public bool isInGame;
    public Board theirBoard;
}