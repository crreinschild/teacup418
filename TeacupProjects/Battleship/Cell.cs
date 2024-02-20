namespace TeacupProjects.Battleship;

public class Cell
{
    public (int x, int y) coords;
    private bool considered;
    private bool valid;
    public Ship? ship;
    public Cell? e, s;

    public string Classes
    {
        get
        {
            if (considered)
            {
                if (valid)
                    return "cell-valid";
                return "cell-invalid";
            } 
            if (ship != null)
            {
                return "cell-ship";
            }

            return "";
        }
    }

    public void SetPlacementIndicator(bool isValid)
    {
        considered = true;
        valid = isValid;
    }
    
    public void ClearPlacementIndicator()
    {
        considered = false;
        EastCells.ToList().ForEach(c => c.considered = false);
        SouthCells.ToList().ForEach(c => c.considered = false);
    }
    
    public void SetShip(Ship ship) => this.ship = ship;
    
    public IEnumerable<Cell> LinkedCells(Ship.Direction direction) => direction switch 
    {
        Ship.Direction.Horizontal => EastCells,
        Ship.Direction.Vertical => SouthCells,
        _ => throw new ArgumentOutOfRangeException()    
    };

    private IEnumerable<Cell> EastCells
    {
        get
        {
            var next = this;
            while (next != null)
            {
                yield return next;
                next = next.e;
            }
        }
    }
    
    private IEnumerable<Cell> SouthCells
    {
        get
        {
            var next = this;
            while (next != null)
            {
                yield return next;
                next = next.s;
            }
        }
    }
}