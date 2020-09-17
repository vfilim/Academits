using System.Collections.Generic;
using System.IO;
using System;
using System.Data.SqlTypes;

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
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("{0} is not found!", inputPath);
            }

            foreach (string e in stringsList)
            {
                Console.WriteLine(e);
            }

            List<int> intList = new List<int> { 6, 24, 63, 22, 34, 7, 15, 66 };

            for (int i = intList.Count - 1; i >= 0; i--)
            {
                if (intList[i] % 2 == 0)
                {
                    intList.RemoveAt(i);
                }
            }

            Console.WriteLine("The first list uneven numbers are:");

            foreach (int n in intList)
            {
                Console.WriteLine(n);
            }

            List<int> numbersList = new List<int> { 1, 5, 2, 1, 3, 5 };

            List<int> uniqueNumbersList = new List<int>(numbersList.Count);

            foreach (int e in numbersList)
            {
                if (!uniqueNumbersList.Contains(e))
                {
                    uniqueNumbersList.Add(e);
                }
            }

            Console.WriteLine("The second list unique numbers are:");

            foreach (int e in uniqueNumbersList)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }
    }
}
