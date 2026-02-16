using System;

namespace Animals {
    public class Animal {
        // Class attributes
        // Typically, all attributes (fields) are by default private.
        private string name;
        private int age;
        private double x;
        private double y;

        // Constructor
        public Animal(string name, int age, double x, double y) {
            // `this.name` refers to the class attribute.
            // `name` is just the constructor's argument.
            // In the same way for the other arguments.
            this.name = name;
            // this.age = age;
            // Since we have a non-trivial setter for age:
            SetAge(age);
            this.x = x;
            this.y = y;
        }

        // Inline constructor definition
        public Animal(string name, int age) : this(name, age, 0.0, 0.0) { }
        /*
        This syntax goes as follows:
            * public <ClassName> (arguments) : call to another constructor { <empty> }
            * the call to another constructor is made as follows:
                - this -> points to the class itself, so, essentially, this makes the call to the constructor
                - by passing the arguments we want, the compiler understands which constructor we refer to.

        Alternative (more verbose, harder to maintain):

        ```csharp
        public Animal(string name, int age) {
            this.name = name;
            this.age = age;
            x = 0.0; // this.x = 0.0;
            y = 0.0; // this.y = 0.0;
        }
        ```
        */

        // Default constructor
        public Animal() {}

        // Simple class method to move animals around
        public void MoveBy(double dx, double dy) {
            x += dx; // x = x + dx;
            y += dy; // y = y + dy;
        }
        
        /*
         * This is a brand new instance method that defines what it means
         * for an animal to "talk", by returning a generic string.
         * The virtual keyword, in practice, allows us to override this 
         * method in child classes, if needed.
         */
        public virtual string Talk() {
            return "Talk!";
        }

        // Getters and setters for some fields
        public string GetName() {
            return name;
        }

        public void SetName(string name) {
            this.name = name;
        }

        public int GetAge() {
            return age;
        }

        public void SetAge(int age) {
            if (age < 0)
            {
                Console.WriteLine("Age should be a non-negative integer, not {0}", age);
                // Here, we should raise an exception.
                return;
            }
            this.age = age;
        }

        // Overriding Base ToString() method
        public override string ToString() {
            // String.Format is an example of a static class method, i.e.,
            // a function that is included in the String class but is not dependent
            // on a specific object (class instance) but on the class itself.
            // Juxtapose with Python's "string".format(...), which is a object method.
            return String.Format("Name: {0}, Age: {1}, Location: ({2}, {3})", name, age, x, y);
        }
    }
}
