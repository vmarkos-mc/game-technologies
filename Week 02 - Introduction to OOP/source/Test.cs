using System;

namespace Animals {
    class Test {
        public static void Main(string[] args) {
            Animal alice = new Animal("Alice", 8, 0.0, 1.0);
            Animal bob = new Animal("Bob", 7);
            Console.WriteLine("{0}\n{1}", alice, bob);
        }
    }
}
