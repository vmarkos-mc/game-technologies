using System;

namespace Game_Lab_01
{
    public class Game
    {
        private bool isGameOver;
        private int numberOfMoves;
        private GameGrid grid;

        public Game(int size, bool wrap)
        {
            grid = wrap ? new WrappingGameGrid(size) : new GameGrid(size);
            isGameOver = false;
            numberOfMoves = 0;
        }

        public void MakeMove(GameGrid.MoveDirection direction)
        {
            isGameOver = grid.MakeMove(direction);
            numberOfMoves++;
        }

        // This is actually a getter
        public bool IsOver() { return isGameOver; }

        // We use just a getter, so we essentially make `numberOfMoves` read-only
        public int GetNumberOfMoves() { return numberOfMoves; }

        public override string ToString()
        {
            return grid.ToString();
        }
    }
}
