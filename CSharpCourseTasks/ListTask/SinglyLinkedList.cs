using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.IO;

namespace ListTask
{
    class SinglyLinkedList<T>
    {
        private ListItem<T> head;

        private int Count { get; set; }

        public SinglyLinkedList() 
        {
            Count = 0;
        }

        public SinglyLinkedList(T head)
        {
            this.head = new ListItem<T>(head);

            Count = 1;
        }

        public T GetFirst()
        {
            return head.Data;
        }

        private ListItem<T> MoveTo(int index)
        {
            ListItem<T> currentItem = head;

            for (int count = 0; count < index; count++)
            {
                currentItem = currentItem.Next;
            }

            return currentItem;
        }

        public T GetData(int index)
        {
            return MoveTo(index).Data;
        }

        public T SetData(T newData, int index)
        {
            ListItem<T> item = MoveTo(index);

            T oldData = item.Data;

            item.Data = newData;

            return oldData;
        }

        public T Remove(int index)
        {
            ListItem<T> previousItem = MoveTo(index - 1);

            T removedData = previousItem.Next.Data;

            previousItem.Next = previousItem.Next.Next;

            Count--;

            return removedData;
        }

        public void AddFirst(T data)
        {
            ListItem<T> newHead = new ListItem<T>(data, head);

            Count++;

            head = newHead;
        }

        public void InsertData(T data, int index)
        {
            ListItem<T> previousItem = MoveTo(index - 1);

            ListItem<T> newItem = new ListItem<T>(data, previousItem.Next);

            previousItem.Next = newItem;

            Count++;
        }

        public bool RemoveByData(T data)
        {
            ListItem<T> currentItem = head;
            bool isRemoved = false;
            int index = 0;

            while (!isRemoved)
            {
                if (data.Equals(currentItem.Data))
                {
                    Remove(index);
                    isRemoved = true;

                    Count--;
                }

                currentItem = currentItem.Next;
                index++;
            }

            return isRemoved;
        }

        public T RemoveHead()
        {
            if (Count == 0)
            {
                throw new IOException("The list is empty!");
            }

            T headCopy = head.Data;

            head = head.Next;

            Count--;

            return headCopy;
        }

        public void Reverse()
        {
            ListItem<T>[] itemArray = new ListItem<T>[Count];

            ListItem<T> currentItem = head;

            for (int i = 0; i < Count; i++)
            {
                itemArray[i] = currentItem;

                currentItem = currentItem.Next;
            }

            currentItem = head;

            for (int i = 0; i < Count; i++)
            {
                currentItem.Data = itemArray[Count - i].Data;
                currentItem.Next = itemArray[Count - i - 1];
            }
        }

        public void CopyTo(SinglyLinkedList<T> list)
        {

        }
    }
}
