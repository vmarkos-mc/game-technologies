using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Animals {
    public class Dog : Animal {
        public Dog(string name, int age) : base(name, age) {}
        public Dog(string name, int age, double x, double y) : base(name, age, x, y) {}

        public override string Talk() {
            return "Woof!";
        }

        public override string ToString()
        {
            return String.Format("Dog: {0}, Age: {1}", base.GetName(), base.GetAge());
        }
    }
}
