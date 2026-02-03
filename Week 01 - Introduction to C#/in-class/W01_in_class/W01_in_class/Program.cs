using System;
using System.Collections.Generic;

namespace InClass
{
    class Test
    {
        /* When writing a Main() function in a C# program, we can 
         * pass command line arguments through the `args` argument of
         * Main().
         * Or we can just ignore it and define Main() as:
         * static void Main()
         */
        static void Main(string[] args)
        {
            // Task 1
            //Console.Write("Enter a: ");
            //double a = Double.Parse(Console.ReadLine());
            //Console.Write("Enter b: ");
            //double b = Double.Parse(Console.ReadLine());
            //double c = MultiplyNumbers(a, b);
            //Console.WriteLine("{0} * {1} = {2}", a, b, c);
            // Task 2
            //List<string> names = new List<string> { "alice", "bob", "charlie", "deborah" };
            //List<string> longNames = GetLongNames(names);
            //foreach (string longName in longNames)
            //{
            //    Console.WriteLine(longName);
            //}
            // Task 3
            Dictionary<string, int> ages = new Dictionary<string, int>();
            ages.Add("alice", 65);
            ages.Add("bob", 56);
            ages.Add("charlie", 60);
            string found = GetUserAge(ages, "alice");
            string notFound = GetUserAge(ages, "deborah");
            Console.WriteLine("Alice's age: {0}\nDeborah's age: {1}", found, notFound);
        }

        static double MultiplyNumbers(double a, double b)
        {
            return a * b;
        }

        // Just an overloaded version
        static int MultiplyNumbers(int a, int b)
        { 
            return a * b;
        }

        static List<string> GetLongNames(List<string> names)
        {
            List<string> result = new List<string>();
            // List.Count corresponds to the number of items present in a list.
            // List.Capacity corresponds to the number of reserved memory slots for the list.
            // List.Count <= List.Capacity
            for (int i = 0; i < names.Count; i++)
            {
                // string.Length corresponds to the length of a string.
                if (names[i].Length > 5)
                {
                    result.Add(names[i]);
                }
            }
            return result;
        }

        static string GetUserAge(Dictionary<string, int> ages, string name)
        {
            // Dictionary.Keys      => dictionary keys
            // Dictionary.Values    => dictionary values
            foreach (string userName in ages.Keys)
            {
                if (userName == name)
                {
                    return userName + " is " + ages[userName] + " years old.";
                }
            }
            return "User not found!";
        }

        // More C#-ic.
        static string GetUserAge2(Dictionary<string, int> ages, string name)
        {
            // ContainsKey is way faster than a loop over all dictionary keys,
            // as it takes advantage of the hash structure of the dictionary.
            if (ages.ContainsKey(name))
            {
                return $"{name} is {ages[name]} years old";
            }
            return "User not found!";
        }
    }
}