using System;
using System.Collections.Generic;

namespace Test {
    class TestClass {
        static void Main() {
            List<int> numbers = new List<int> { 1, 2, 3};
            numbers.Add(5);
            
            Dictionary<string, int> ages = new Dictionary<string, int>();
            ages.Add("Alice", 65);
            ages.Add("Bob", 56);
        }
    }
}
