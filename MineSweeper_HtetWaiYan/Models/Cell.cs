namespace MineSweeper_HtetWaiYan.Models
{
    public class Cell
    {
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public bool IsMine { get; set; } = false;
        public bool IsRevealed { get; set; } = false;
        public int AdjacentMines { get; set; }
    }
}
