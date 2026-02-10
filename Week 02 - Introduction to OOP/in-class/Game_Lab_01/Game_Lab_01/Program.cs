using System;

namespace Game_Lab_01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int size = GetGridSize();
            GameGrid grid = new GameGrid(size);
            Console.WriteLine(grid);
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