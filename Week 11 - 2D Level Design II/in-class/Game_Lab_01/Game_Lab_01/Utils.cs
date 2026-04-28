using System;

namespace Game_Lab_01
{
    public static class Utils
    {
        /* Utility class */

        private static readonly int VOFFSET = 40;

        public static void Log(string message)
        {
            Console.Write("\x1b 7\x1b[{0}E{1}\x1b 8", VOFFSET, message);
        }
    }
}