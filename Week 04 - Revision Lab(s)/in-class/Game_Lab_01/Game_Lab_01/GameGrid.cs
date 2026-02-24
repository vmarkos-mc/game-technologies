using System;

namespace Game_Lab_01
{
	public class GameGrid
	{
		// By default, each game grid has two dimensions.
		internal int rows; // We need those to be visible to child classes
        internal int cols;
		private Player player; // This declares an object of the class Player

		// General purpose grid constructor.
		public GameGrid(int rows, int cols)
		{
			this.rows = rows;
			this.cols = cols;
			player = new Player(this.rows - 1, 0);
		}

		// Just a shorthand to create square game grids.
		public GameGrid(int rows) : this(rows, rows) { }

        // Get neighbours
        public virtual GridPoint GetLeft(GridPoint p)
        {
            // If we are already at the leftmost part, then we just return ourselves.
            if (p.GetY() == 0) return p;
            // If we are not at the lefmost part of the grid, then just return a point that is one column left.
            return new GridPoint(p.GetX(), p.GetY() - 1);
        }

        public virtual GridPoint GetRight(GridPoint p)
        {
            if (p.GetY() == cols - 1) return p;
            return new GridPoint(p.GetX(), p.GetY() + 1);
        }

        public virtual GridPoint GetUp(GridPoint p)
		{
			if (p.GetX() == 0) return p;
			return new GridPoint(p.GetX() - 1, p.GetY());
		}

        public virtual GridPoint GetDown(GridPoint p)
		{
			if (p.GetX() == rows - 1) return p;
			return new GridPoint(p.GetX() + 1, p.GetY());
		}

        // Move related utilities

        // Makes a move, if allowed, or throw an exception
        public void MakeMove(MoveDirection direction)
        {
            // Get player's current location
            GridPoint playerLocation = player.GetLocation();
            GridPoint newPlayerLocation; // Just an object declaration
            switch (direction)
            {
                case MoveDirection.Left: // if
                    newPlayerLocation = GetLeft(playerLocation);
                    break;
                case MoveDirection.Right: // else if
                    newPlayerLocation = GetRight(playerLocation);
                    break;
                case MoveDirection.Up: // else if
                    newPlayerLocation = GetUp(playerLocation);
                    break;
                case MoveDirection.Down: // else if
                    newPlayerLocation = GetDown(playerLocation);
                    break;
                default: // else
                    throw new ArgumentOutOfRangeException("Invalid move option."); // In case we have been provided with an irrelevant value.
            }
            player.SetLocation(newPlayerLocation);
        }

        // Local definition of possible move directions
        public enum MoveDirection
        {
            Left, Right, Up, Down // 0, 1, 2, 3, respectively
        }

        public override string ToString()
        {
			string gridString = ""; // or string gridString = string.Empty;
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					if (player.IsAt(i, j))
					{
						gridString += $"{player} ";
					} else
					{
                        gridString += "* "; // You might want to *not* print the empty character for j == cols - 1
                    }
				}
				gridString += "\n";
			}
			return gridString;
        }
	}
}