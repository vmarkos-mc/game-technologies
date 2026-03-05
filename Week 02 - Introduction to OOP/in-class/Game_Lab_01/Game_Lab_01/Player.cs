using System;

namespace Game_Lab_01
{
    class Player
    {
        private int row;
        private int col;

        public Player(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        // Default constructor
        public Player() { }

        // Object method that returns player location
        public int[] Location()
        {
            return new int[] { row, col };
        }

        // Checks whether the player is at a specific location
        public bool IsAt(int row, int col)
        {
            return this.row == row && this.col == col;
        }

        public override string ToString()
        {
            return "p";
        }
    }
}
