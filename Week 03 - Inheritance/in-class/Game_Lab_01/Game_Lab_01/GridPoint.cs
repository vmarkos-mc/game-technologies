using System;

namespace Game_Lab_01
{
    // Since we need this class only within our namespace, we define this as `internal`
    public class GridPoint
    {
        private int x;
        private int y;

        public GridPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        // No setters is just like x and y are constants.
    }
}
