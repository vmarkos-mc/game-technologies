using System;

namespace Animals {
    class StrangeTest {
        public static void Main(string[] args) {
            Cat alice = new Cat("Alice", 8);
            Animal bob = new Cat("Bob", 7);
            // What will this print?
            Console.WriteLine("{0}\n{1}", alice.Talk(), bob.Talk());
        }
    }
}
