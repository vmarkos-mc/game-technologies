using System;

namespace Game_Lab_01
{
	public class GameGrid
	{
		// By default, each game grid has two dimensions.
		private int rows;
		private int cols;
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