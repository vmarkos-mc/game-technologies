using System;

namespace Game_Lab_01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int size = GetGridSize();
            bool wrap = GetWrap();
            GameGrid grid = wrap ? new WrappingGameGrid(size) : new GameGrid(size);
            Console.WriteLine(grid);
            while (true)
            {
                GameGrid.MoveDirection direction = ParseMoveString();
                grid.MakeMove(direction);
                /*
                 * Ideas to produce a grid that does not print over and over again:
                 *  1. Just print many (many) newlines.
                 *      - Major issue: window rescaling.
                 *      - Another major issue: which screen is the biggest one?
                 *  2. Move cursor up by some lines and then print over the existing grid again.
                 *  3. Move cursor to current player position, erase player,
                 *      move cursor to new player position, print player.
                 */
                Console.WriteLine("\x1b[{0}A\r{1}", size, grid);
            }
        }

        public static bool GetWrap()
        {
            Console.Write("Wrap or no wrap (y/n): ");
            return Console.ReadLine().ToLower() == "y"; // So, anything else other than "y" returns false;
        }

        public static GameGrid.MoveDirection ParseMoveString()
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

        public static GameGrid.MoveDirection GetMoveDirection(char moveString)
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

        /*
         * We can think of enums as named integers, i.e., integers that also
         * have a semantic name, as in our case, for grid sizes.
         */
        public enum GridSize
        {
            Small = 15,
            Medium = 20,
            Large = 30
        }

        public static int GetGridSize()
        {
            Console.Write("Please enter grid size (Small=15, Medium=20, Large=30): ");
            int size = Int32.Parse(Console.ReadLine());
            while (!GridSize.IsDefined(typeof(GridSize), size))
            {
                Console.Write("Please enter grid size (Small=15, Medium=20, Large=30): ");
                size = Int32.Parse(Console.ReadLine());
            }
            return size;
        }
    }
}