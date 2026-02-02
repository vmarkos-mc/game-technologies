using System;

namespace Test {
    class TestClass {
        static void Main() {
            Console.WriteLine("Please, enter an integer: ");
            int n = Int32.Parse(Console.ReadLine());
            string response;
            int d = 2;
            if (n < 2) // You can omit {, } for single line blocks
                response = "not";
            else {
                while (n % d != 0) {
                    d++;
                }
            }
            // The so-called ternary operator: condition ? true-case : false-case
            // Much like Python's inline if statement.
            response = d == n ? "" : " not";
            Console.WriteLine("{0} is{1} prime!", n, response);
        }
    }
}
