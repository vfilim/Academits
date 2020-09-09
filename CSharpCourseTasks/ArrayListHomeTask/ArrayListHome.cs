using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

namespace ArrayListHomeTask
{
    class ArrayListHome
    {
        static void Main(string[] args)
        {
            List<string> stringsList = new List<string>();
            string inputPath = "input.txt";

            try
            {
                using (StreamReader reader = new StreamReader(inputPath))
                {
                    string currentLine;

                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        stringsList.Add(currentLine);
                        Console.WriteLine(currentLine);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("{0} is not found!", inputPath);
            }

            List<int> intList = new List<int>() { 6, 24, 63, 22, 34, 7, 15, 66 };

            for (int i = intList.Count - 1; i >= 0; i--)
            {
                if (intList[i] % 2 == 0)
                {
                    intList.RemoveAt(i);
                }
            }

            Console.WriteLine("The first list uneven numbers are:");

            foreach (int i in intList)
            {
                Console.WriteLine(i);
            }

            List<int> numbersList = new List<int> { 1, 5, 2, 1, 3, 5 };

            int startCapacity = 20;

            List<int> uniqueNumbersList = new List<int>(startCapacity);

            foreach (int i in numbersList)
            {
                if (!uniqueNumbersList.Contains(i))
                {
                    uniqueNumbersList.Add(i);
                }
            }

            Console.WriteLine("The second list unique numbers are:");

            foreach (int i in uniqueNumbersList)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
