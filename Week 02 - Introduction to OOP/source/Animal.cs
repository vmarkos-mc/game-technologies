using System;

namespace Animals {
    public class Animal {
        // Class attributes
        private string name;
        private int age;
        private double x;
        private double y;

        // Constructor
        public Animal(string name, int age, double x, double y) {
            this.name = name;
            this.age = age;
            this.x = x;
            this.y = y;
        }

        // Inline constructor definition
        public Animal(string name, int age) : this(name, age, 0.0, 0.0) { }

        // Default constructor
        public Animal() {}

        // Simple class method to move animals around
        public void MoveBy(double dx, double dy) {
            x += dx;
            y += dy;
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
            this.age = age;
        }

        // Overriding Base ToString() method
        public override string ToString() {
            return String.Format("Name: {0}, Age: {1}, Location: ({2}, {3})", name, age, x, y);
        }
    }
}
