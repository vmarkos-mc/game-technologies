using System;
using System.Runtime.CompilerServices;

namespace Game_Lab_01
{
    public class GameUI
    {
        // More on the singleton pattern:
        // https://refactoring.guru/design-patterns/singleton
        private Game game;
        private bool wrap;
        private int size;
        // We implement the Singleton Design Pattern, so we
        // declare a private reference to ourselves.
        private static GameUI uiInstance;

        private GameUI()
        {
            // Empty for now, so just reserving memory
        }

        // This is the actual singleton constructor
        public static GameUI Instance()
        {
            // If there is no instance initialised, create one
            if (uiInstance == null) { uiInstance = new GameUI(); }
            // Then, return the private UI instance.
            return uiInstance;
        }

        public void InitialiseGame()
        {
            GetGridSize();
            GetWrap();
            game = new Game(size, wrap);
        }

        public void Run()
        {
            Console.WriteLine(game);
            while (!game.IsOver())
            {
                GameGrid.MoveDirection direction = ParseMoveString();
                game.MakeMove(direction);
                Console.WriteLine("\x1b[{0}A\r{1}", size, game);
                Console.Write("\x1b[{0}A{1}", size, .GetInventory());
            }
            Console.WriteLine("You won in {0} moves!", game.GetNumberOfMoves());
            while (Console.ReadKey().KeyChar != 'q') { Console.Write("\rPress 'q' to exit!"); }
        }

        public void GetWrap()
        {
            Console.Write("Wrap or no wrap (y/n): ");
            wrap = Console.ReadLine().ToLower() == "y"; // So, anything else other than "y" returns false;
        }

        /*
         * We can think of enums as named integers, i.e., integers that also
         * have a semantic name, as in our case, for grid sizes.
         */
        private enum GridSize
        {
            Small = 15,
            Medium = 20,
            Large = 30
        }

        public void GetGridSize()
        {
            Console.Write("Please enter grid size (Small=15, Medium=20, Large=30): ");
            size = Int32.Parse(Console.ReadLine());
            while (!GridSize.IsDefined(typeof(GridSize), size))
            {
                Console.Write("Please enter grid size (Small=15, Medium=20, Large=30): ");
                size = Int32.Parse(Console.ReadLine());
            }
        }

        public GameGrid.MoveDirection ParseMoveString()
        {
            // This assignment is just a hack to stop the compiler complaining.
            GameGrid.MoveDirection direction = GameGrid.MoveDirection.Down;
            bool validDirection = false;
            while (!validDirection)
            {
                //Console.Write("Next move (wasd): ");
                // string moveString = Console.ReadLine();
                //char moveString = (char) Console.Read(); // Works but leads to some UI bugs
                // ConsoleKeyInfo stores information about the last key pressed by user.
                // key.KeyChar corresponds to the character of that key (if it does exist).
                ConsoleKeyInfo key = Console.ReadKey();
                char moveChar = key.KeyChar;
                try
                {
                    direction = GetMoveDirection(moveChar);
                    validDirection = true;
                }
                catch (ArgumentOutOfRangeException)
                {
                    // Just ignore it
                }
            }
            return direction;
        }

        private GameGrid.MoveDirection GetMoveDirection(char moveString)
        {
            switch (moveString)
            {
                case 'w':
                    return GameGrid.MoveDirection.Up; // No need for break here, since we return.
                case 'a':
                    return GameGrid.MoveDirection.Left;
                case 's':
                    return GameGrid.MoveDirection.Down;
                case 'd':
                    return GameGrid.MoveDirection.Right;
                default:
                    throw new ArgumentOutOfRangeException("Invalid move option. Valid ones: 'w', 'a', 's', 'd'.");
            }
        }
    }
}
