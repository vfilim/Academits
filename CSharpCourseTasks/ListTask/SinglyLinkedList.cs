using System;
using System.IO;

namespace ListTask
{
    class SinglyLinkedList<T>
    {
        private ListItem<T> head;

        public int Count { get; private set; }

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
            if (index < 0)
            {
                throw new ArgumentException("The index can't be < 0", nameof(index));
            }

            ListItem<T> currentItem = head;

            for (int i = 0; i < index; i++)
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
            if (index == 0)
            {
                return RemoveHead();
            }

            ListItem<T> previousItem = MoveTo(index - 1);

            T removedData = previousItem.Next.Data;

            previousItem.Next = previousItem.Next.Next;

            Count--;

            return removedData;
        }

        public void AddFirst(T data)
        {
            if (Count == 0)
            {
                head = new ListItem<T>(data);
            }

            ListItem<T> newHead = new ListItem<T>(data, head);

            Count++;

            head = newHead;
        }

        public void InsertData(T data, int index)
        {
            if (index < 0)
            {
                throw new ArgumentException("The index can't be < 0", nameof(index));
            }

            if (index == 0)
            {
                ListItem<T> newHead = new ListItem<T>(data, head.Next);

                head = newHead;

                return;
            }

            ListItem<T> previousItem = MoveTo(index - 1);

            ListItem<T> newItem = new ListItem<T>(data, previousItem.Next);

            previousItem.Next = newItem;

            Count++;
        }

        public bool RemoveByData(T data)
        {
            ListItem<T> currentItem = head;
            bool isRemoved = false;

            Func<bool> IsEqual = delegate ()
            {
                if (data == null)
                {
                    if (currentItem.Data == null)
                    {
                        return true;
                    }

                    return false;
                }

                if (data.Equals(currentItem.Data))
                {
                    return true;
                }

                return false;
            };

            for (int i = 0; i < Count; i++)
            {
                if (IsEqual())
                {
                    Remove(i);
                    isRemoved = true;

                    break;
                }

                currentItem = currentItem.Next;
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
            T[] dataArray = new T[Count];

            ListItem<T> currentItem = head;

            for (int i = 0; i < Count; i++)
            {
                dataArray[i] = currentItem.Data;

                currentItem = currentItem.Next;
            }

            currentItem = head;

            for (int i = 0; i < Count; i++)
            {
                currentItem.Data = dataArray[Count - i - 1];

                currentItem = currentItem.Next;
            }
        }

        public SinglyLinkedList<T> GetCopy()
        {
            ListItem<T> currentItem = head;

            SinglyLinkedList<T> listCopy = new SinglyLinkedList<T>();

            for (int i = 0; i < Count; i++)
            {
                listCopy.AddFirst(currentItem.Data);

                currentItem = currentItem.Next;
            }

            listCopy.Reverse();

            return listCopy;
        }
    }
}
