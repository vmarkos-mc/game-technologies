using System;
using System.Collections.Generic;

namespace Game_Lab_01
{
	public class GameGrid
	{
        // Class constants
        // FIXME: Create a configuration file!
        private readonly Dictionary<Ingredient.IngredientType, int> ingredientsDistribution = new Dictionary<Ingredient.IngredientType, int>
        {
            { Ingredient.IngredientType.Spanaki, 3 },
            { Ingredient.IngredientType.Vrouva, 4 },
            { Ingredient.IngredientType.Feta, 3},
            { Ingredient.IngredientType.Seskoulo, 6 },
            { Ingredient.IngredientType.Anithos, 10 },
            { Ingredient.IngredientType.Prasso, 4 },
            { Ingredient.IngredientType.Fyllo, 1 },
        };
		// By default, each game grid has two dimensions.
		internal int rows; // We need those to be visible to child classes
        internal int cols;
		private Player player; // This declares an object of the class Player
        // HashSet is like Python's set.
        private HashSet<GridPoint> visited = new HashSet<GridPoint>();
        private Dictionary<GridPoint, Artefact> relics = new Dictionary<GridPoint, Artefact>();

		// General purpose grid constructor.
		public GameGrid(int rows, int cols, Player player)
		{
			this.rows = rows;
			this.cols = cols;
			this.player = player;
            relics = GetRandomArtefacts();
		}
           
        // Just a shorthand to create square game grids.
		public GameGrid(int rows, Player player) : this(rows, rows, player) { }

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


        private Dictionary<GridPoint, Artefact> GetRandomArtefacts()
        {
            Dictionary<GridPoint, Artefact> artefacts = new Dictionary<GridPoint, Artefact>();
            // This is not uniformly random, so we should use something like reservoir sampling here.
            GridPoint point;
            foreach (KeyValuePair<Ingredient.IngredientType, int> pair in ingredientsDistribution)
            {
                for (int i = 0; i < pair.Value; i++)
                {
                    point = GetRandomGridPoint();
                    while (artefacts.ContainsKey(point))
                        point = GetRandomGridPoint();
                    Ingredient ingredient = new Ingredient(point, pair.Key);
                    artefacts[point] = ingredient;
                }
            }
            return artefacts;
        }

        private GridPoint GetRandomGridPoint()
        {
            Random rng = new Random(); // This is a (pseudo)random number generator
            int x = rng.Next(0, rows); // Random.Next() returns the next random number.
            int y = rng.Next(0, cols);
            GridPoint point = new GridPoint(x, y);
            return point;
        }

        // Move related utilities

        // Makes a move, if allowed, or throw an exception
        public bool MakeMove(MoveDirection direction)
        {
            // Get player's current location
            GridPoint playerLocation = player.GetLocation();
            // `Add()` adds an element to a set only if it is not already there
            visited.Add(playerLocation);
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
            // If there is a relic there, collect it.
            // TODO: Use .CollectRelic return value to inform player about whether the relic has been collected or not
            if (relics.ContainsKey(newPlayerLocation))
            {
                //Console.WriteLine("Collecting: {0}", relics[newPlayerLocation]);
                player.CollectRelic(relics[newPlayerLocation]);
                //Console.WriteLine("Collected: {0}", relics[newPlayerLocation]);
            }
            if (player.GetRelicsCollected() == relics.Count()) return true;
            return false;
            // Debugging
            // Console.WriteLine("Relics Collected: {0}", player.GetRelicsCollected());
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
					} else if (visited.Contains(new GridPoint(i, j)))
                    {
                        gridString += ". "; // This means we have visited this cell
                    }
                    else
                    {
                        gridString += "* "; // You might want to *not* print the empty character for j == cols - 1
                    }
				}
                if (i < rows - 1) gridString += "\n";
			}
			return gridString;
        }
	}
}