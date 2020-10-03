using System;
using System.Collections.Generic;
using System.Linq;

namespace Lambdas
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Person>();

            list.Add(new Person("Peter", 23));
            list.Add(new Person("Alice", 26));
            list.Add(new Person("John", 24));
            list.Add(new Person("Elizabeth", 28));
            list.Add(new Person("Mary", 30));
            list.Add(new Person("Andrew", 32));
            list.Add(new Person("John", 32));
            list.Add(new Person("Mike", 15));
            list.Add(new Person("Michele", 17));
            list.Add(new Person("Peter", 47));
            list.Add(new Person("Mary", 60));
            list.Add(new Person("Alice", 12));
            list.Add(new Person("Andrew", 13));

            var uniqueNamesList = list
                .Select(x => x.Name)
                .Distinct();

            Console.Write("Unique names are: ");

            int uniqueNamesListCount = uniqueNamesList.ToList().Count;

            foreach (var e in uniqueNamesList.Take(uniqueNamesListCount - 1))
            {
                Console.Write(e + ", ");
            }

            Console.WriteLine(uniqueNamesList.Skip(uniqueNamesListCount - 1).First() + ".");

            var teensAverageAge = list
                .Where(x => x.Age < 18)
                .Select(x => x.Age)
                .Average();

            Console.WriteLine("The average age of people 18 and less year old is " + teensAverageAge);

            var dictionary = list
                .GroupBy(x => x.Name)
                .ToDictionary(x => x.Key, x => x.ToList());

            Console.WriteLine("Groups of people by name and their average age:");

            foreach (var n in dictionary)
            {
                Console.WriteLine(n.Key);

                double average = n.Value
                    .Select(x => x.Age)
                    .Average();

                Console.WriteLine(average);
            }

            var selectedAgePeopleList = list
                .Where(x => x.Age > 20 && x.Age < 45)
                .OrderBy(x => x.Age)
                .Select(x => x.Name);

            Console.WriteLine("The list of people 20-45 year old in ascendant order:");

            foreach (var e in selectedAgePeopleList)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }
    }
}
