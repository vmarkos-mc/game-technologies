using System;

namespace Animals {
    class Test {
        public static void Main(string[] args) {
            Animal alice = new Animal("Alice", 8, 0.0, 1.0);
            Cat bob = new Cat("Bob", 7);
            // Animal charlie = new Animal();
            Console.WriteLine("{0}\n{1}", alice, bob);
            Console.WriteLine("Alice says: {0}\nBob says: {1}", alice.Talk(), bob.Talk());
        }
    }
}
