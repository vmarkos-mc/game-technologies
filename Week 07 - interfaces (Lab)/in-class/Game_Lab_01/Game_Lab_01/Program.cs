using System;

namespace Game_Lab_01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GameUI UI = GameUI.Instance();
            UI.InitialiseGame();
            UI.Run();
        }
    }
}