namespace TeacupProjects.Battleship;

public class Board
{
    public Cell[,] cells;
    
    public Board()
    {
        cells = new Cell[10,10];
            
        int? previousRow = null;
        for (var i = 9; i >= 0; i--)
        {
            int? previousColumn = null;
            for (var j = 9; j >= 0; j--)
            {
                cells[i, j] = new Cell()
                {
                    coords = (j, i),
                    e = previousColumn.HasValue ? cells[i, previousColumn.Value] : null,
                    s = previousRow.HasValue ? cells[previousRow.Value, j] : null
                };
                previousColumn = j;
            }
            previousRow = i;
        }
    }
}