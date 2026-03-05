using System;
using System.Collections.Generic;

namespace Animals {
    public class AnimalStructures {
        public static void Main(string[] args) {
            Animal alice = new Animal("Alice", 8);
            Cat bob = new Cat("Bob", 7);
            Dog charlie = new Dog("Charlie", 6);
            List<Animal> animals = new List<Animal> {alice, bob, charlie};
            animals.ForEach(Console.WriteLine);
        }
    }
}
