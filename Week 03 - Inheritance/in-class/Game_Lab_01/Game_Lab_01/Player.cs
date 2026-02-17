using System;

namespace Game_Lab_01
{
    class Player
    {
        private GridPoint location;

        public Player(int row, int col)
        {
            location = new GridPoint(row, col);
        }

        // Default constructor
        public Player() { }

        // Object method that returns player location
        public GridPoint GetLocation()
        {
            return location;
        }

        // Location Setter
        public void SetLocation(GridPoint location)
        {
            this.location = location;
        }

        // Checks whether the player is at a specific location
        public bool IsAt(int row, int col)
        {
            return location.GetX() == row && location.GetY() == col;
        }

        public override string ToString()
        {
            return "p";
        }
    }
}
