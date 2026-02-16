using System;

namespace Animals {
    public class Dog : Animal {
        public Dog(string name, int age) : base(name, age) {}
        public Dog(string name, int age, double x, double y) : base(name, age, x, y) {}

        public override string Talk() {
            return "Woof!";
        }
    }
}
