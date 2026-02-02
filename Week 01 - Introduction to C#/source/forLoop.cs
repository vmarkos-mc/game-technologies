using System;

namespace Test {
    class TestClass {
        static void Main() {
            Console.WriteLine("Please, enter an integer: ");
            int n = Int32.Parse(Console.ReadLine()), a; // You can declare multiple variables in the same line
            for (int i = 0; i < 11; i++) {
                a = i * n;
                Console.WriteLine("{0} x {1} = {2}", i, n, a);
            }
        }
    }
}
