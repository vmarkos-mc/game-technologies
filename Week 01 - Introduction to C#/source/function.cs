using System;

namespace Test {
    class TestClass {
        static void Main() {
            Console.WriteLine("Please, enter an integer: ");
            int n = Int32.Parse(Console.ReadLine());
            int d = DivSum(n);
            Console.WriteLine("Divisor sum of {0} = {1}.", n, d);
        }

        static int DivSum(int n) {
            int s = 0;
            for (int i = 1; i <= n; i++) {
                if (n % i == 0)
                    s += i;
            }
            return s;
        }
    }
}
