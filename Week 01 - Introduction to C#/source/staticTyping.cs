using System;

namespace Test {
    class TestClass {
        static void Main() {
            // Python: x = 5; x = "High" (Valid)
            // C#:
            int score = 100; 
            string grade = "A";
            var autoType = 10.5; // Compiler 'guesses' double, but it's fixed!
            Console.WriteLine("Score: {0}\nGrade: {1}\nAutoType: {2}", score, grade, autoType);
        }
    }
}
