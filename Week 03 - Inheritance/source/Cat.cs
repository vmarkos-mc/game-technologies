using System;

namespace Animals {
    public class Cat : Animal {
        // All `Animal` fields are here, inherited from the `Animal` class.
        // NOTE: In C# we often prefer "derive" over "inherit" for inheritance.

        // We define a `Cat` constructor by just calling the corresponding `Animal` one,
        // using the keyword `base`. In general, `base` is a pointer
        // to the parent class, while `this` is a pointer to the child class.
        public Cat(string name, int age) : base(name, age) {}

        // Same for the other Animal constructor.
        public Cat(string name, int age, double x, double y) : base(name, age, x, y) {}

        // An example of overriding a parent method.
        public override string Talk() {
            return "Meow!";
        }
    }
}
