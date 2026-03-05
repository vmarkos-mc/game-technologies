using System;

namespace Game_Lab_01
{
    public class WrappingGameGrid : GameGrid
    {
        // Just a boring square grid constructor
        public WrappingGameGrid(int rows) : base(rows) { }

        public override GridPoint GetLeft(GridPoint p)
        {
            return new GridPoint(p.GetX(), (p.GetY() + cols - 1) % cols);
        }

        public override GridPoint GetRight(GridPoint p)
        {
            return new GridPoint(p.GetX(), (p.GetY() + 1) % cols);
        }

        public override GridPoint GetUp(GridPoint p)
        {
            return new GridPoint((p.GetX() + rows - 1) % rows, p.GetY());
        }

        public override GridPoint GetDown(GridPoint p)
        {
            return new GridPoint((p.GetX() + 1) % rows, p.GetY());
        }
    }
}
