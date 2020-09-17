using System;

namespace ListTask
{
    class Test
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();

            for (int i = 9; i >= 0; i--)
            {
                list.AddFirst(i);
            }

            Console.WriteLine("The list head is " + list.GetFirst());

            Console.ReadKey();
        }
    }
}
