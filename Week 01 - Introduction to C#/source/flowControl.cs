using System;

namespace Test {
    class TestClass {
        static void Main() {
            Console.WriteLine("Please, enter an integer: ");
            int n = Int32.Parse(Console.ReadLine());
            string response; // Just a declaration, no assignment
            if (n % 2 == 1) {
                response = "What were the odds?";
            } else if (n % 4 == 2) {
                response = "Four of the best, almost...";
            } else {
                response = "Tough luck!";
            }
            Console.WriteLine("n = {0} means: '{1}'", n, response);
        }
    }
}
