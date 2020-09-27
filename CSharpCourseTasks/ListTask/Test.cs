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

            Console.WriteLine("The elements count is " + list.Count);

            Console.WriteLine("The list head is " + list.GetFirst());

            Console.WriteLine("Let's change third element to 20, it was " + list.SetData(20, 2));
            Console.WriteLine("Now it is " + list.GetData(2));

            list.InsertData(40, 4);
            Console.WriteLine("We inserted element 40 on index 4, now it is " + list.GetData(4) + ", the next element is " + list.GetData(5));

            Console.WriteLine("Let's remove the element on index 5, it was " + list.Remove(5) + ", now it is " + list.GetData(5));

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list.GetData(i));
            }

            Console.WriteLine("Let's remove the element 6. Is it successfully deleted? " + list.RemoveByData(6));

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list.GetData(i));
            }

            Console.WriteLine("What's about the element 12? " + list.RemoveByData(12));

            Console.WriteLine("Let's reverse the list and print it");
            list.Reverse();

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list.GetData(i));
            }

            var stringsList = new SinglyLinkedList<string>();

            stringsList.AddFirst("last");
            stringsList.AddFirst(null);
            stringsList.AddFirst("second");
            stringsList.AddFirst("first");

            stringsList.SetData(null, 1);

            stringsList.RemoveByData(null);

            for (int i = 0; i < stringsList.Count; i++)
            {
                Console.WriteLine(stringsList.GetData(i));
            }

            var listCopy = list.GetCopy();

            Console.WriteLine("Let's print numbers list copy");

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(listCopy.GetData(i));
            }

            Console.ReadKey();
        }
    }
}
