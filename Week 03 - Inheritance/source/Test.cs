using System;

namespace Animals {
    class Test {
        public static void Main(string[] args) {
            Animal alice = new Animal("Alice", 8, 0.0, 1.0);
            Cat bob = new Cat("Bob", 7);
            Dog charlie = new Dog("Charlie", 5);
            Console.WriteLine("{0}\n{1}", alice, bob);
            Console.WriteLine("Alice says: {0}\nBob says: {1}\nCharlie says: {2}", alice.Talk(), bob.Talk(), charlie.Talk());
        }
    }
}
