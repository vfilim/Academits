using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ArrayListHomeTask
{
    class ArrayListHome
    {
        static void Main(string[] args)
        {
            List<string> stringsList = new List<string>();
            string inputPath = "input.txt";

            using (StreamReader reader = new StreamReader(inputPath))
            {
                string currentLine;

                while ((currentLine = reader.ReadLine()) != null)
                {
                    stringsList.Add(currentLine);
                }
            }

            List<int> intList = new List<int>();

            int upLimit = 10;

            for (int i = 0; i < upLimit; i++)
            {
                intList.Add(i);
            }

            for (int i = intList.Count() - 1; i > -1; i--)
            {
                if (intList[i] % 2 == 0)
                {
                    intList.RemoveAt(i);
                }
            }

            List<int> numbersList = new List<int> { 1, 5, 2, 1, 3, 5 };

            List<int> uniqueNumbersList = new List<int>();

            for (int i = 0; i < numbersList.Count(); i++)
            {
                if (!uniqueNumbersList.Contains(numbersList[i]))
                {
                    uniqueNumbersList.Add(numbersList[i]);
                }
            }
        }
    }
}
