using System;

namespace Game_Lab_01
{
	public class GameGrid
	{
		// By default, each game grid has two dimensions.
		private int rows;
		private int cols;

		// General purpose grid constructor.
		public GameGrid(int rows, int cols)
		{
			this.rows = rows;
			this.cols = cols;
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
					gridString += "* ";
				}
				gridString += "\n";
			}
			return gridString;
        }
	}
}