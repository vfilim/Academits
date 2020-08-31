using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;

namespace ListTask
{
    class SinglyLinkedList<T>
    {
        private ListItem<T> head;

        private int count;

        public SinglyLinkedList(ListItem<T> head)
        {
            this.head = head;

            count = 1;

            for (ListItem<T> i = head; i.GetNext() != null; i = i.GetNext())
            {
                count++;
            }
        }

        public int GetCount()
        {
            return count;
        }

        public T GetHeadData()
        {
            return head.GetData();
        }

        public T GetItemData(int index)
        {
            ListItem<T> iterator = head;

            for (int count = 0; count < index; count++)
            {
                iterator = iterator.GetNext();
            }

            return iterator.GetData();
        }

        public T SetItemData(T newData, int index)
        {
            ListItem<T> iterator = head;

            for (int count = 0; count < index; count++)
            {
                iterator = iterator.GetNext();
            }

            T oldData = iterator.GetData();

            iterator.SetData(newData);

            return oldData;
        }

        public T RemoveItem(int index)
        {
            ListItem<T> iterator = head;

            for (int count = 0; count < index - 1; count++)
            {
                iterator = iterator.GetNext();
            }

            T removedItemData = iterator.GetNext().GetData();

            iterator.SetNext(iterator.GetNext().GetNext());

            count--;

            return removedItemData;
        }

        public void AddHeadData(T data)
        {
            ListItem<T> newHead = new ListItem<T>(data, head);

            count++;

            head = newHead;
        }

        public void InsertData(T data, int index)
        {
            ListItem<T> iterator = head;

            for (int count = 0; count < index - 1; count++)
            {
                iterator = iterator.GetNext();
            }

            ListItem<T> newItem = new ListItem<T>(data, iterator.GetNext());

            iterator.SetNext(newItem);

            count++;
        }

        public bool RemoveItemOnData(T data)
        {
            ListItem<T> iterator = head;
            bool isRemoved = false;
            int index = 0;

            while (isRemoved)
            {
                if (data.Equals(iterator.GetData()))
                {
                    RemoveItem(index);
                    isRemoved = true;

                    count--;
                }

                iterator = iterator.GetNext();
                index++;
            }


            return isRemoved;
        }

        public T RemoveHead()
        {
            T headDataCopy = head.GetData();

            head = head.GetNext();

            count--;

            return headDataCopy;
        }

        /*public void Reverse()
        {
            ListItem<T>[] itemArray = new ListItem<T>[count];

            ListItem<T> iterator = head;

            for (int i = 0; i > count; i++)
            {
                itemArray[i] = iterator;

                iterator = iterator.GetNext();
            }

            iterator = head;

            for (int i = count - 1; i > -1; i--)
            {
                iterator.SetData(itemArray[i].GetData());
                iterator.SetNext(itemArray[i - 1]);

                iterator.
            }
        }*/
    }
}
