namespace TeacupProjects.Battleship;

public abstract class Ship
{
    private int _length;
    private Direction orientation = Direction.Vertical;
    private Cell[]? _cells;
    
    public Direction Orientation => orientation;

    public bool CanPlace(Cell cell)
    {
        var cellsBeingConsidered = cell.LinkedCells(orientation).Take(_length).ToList();
        
        var valid = cellsBeingConsidered.Count == _length 
                     && cellsBeingConsidered.All(c => c.ship == null);
        
        cellsBeingConsidered.ForEach(c => c.SetPlacementIndicator(valid));
        return valid;
    }
    
    public bool TryPlace(Cell cell)
    {
        if (!CanPlace(cell)) return false;
        
        _cells = cell.LinkedCells(orientation).Take(_length).ToArray();
        
        foreach (var c in _cells)
        {
            c.SetShip(this);
        }
        
        return true;
    }
    
    public void ToggleOrientation() => orientation = orientation == Direction.Vertical ? Direction.Horizontal : Direction.Vertical;
    
    public enum Direction
    {
        Vertical,
        Horizontal
    }
    
    public class Carrier : Ship
    {
        public Carrier() => _length = 5;
    }
    
    public class Battleship : Ship
    {
        public Battleship() => _length = 4;
    }
    
    public class Cruiser : Ship
    {
        public Cruiser() => _length = 3;
    }

    public class Submarine : Ship
    {
        public Submarine() => _length = 3;
    }
    
    public class Destroyer : Ship
    {
        public Destroyer() => _length = 2;
    }
}