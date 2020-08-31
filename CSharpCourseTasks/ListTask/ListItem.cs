using System;
using System.Collections.Generic;
using System.Text;

namespace ListTask
{
    class ListItem<T>
    {
        private T data;

        private ListItem<T> next;

        public ListItem(T data)
        {
            this.data = data;
        }

        public ListItem(T data, ListItem<T> next)
        {
            this.data = data;
            this.next = next;
        }

        public T GetData()
        {
            return data;
        }

        public void SetData(T newData)
        {
            data = newData;
        }

        public ListItem<T> GetNext()
        {
            return next;
        }

        public void SetNext(ListItem<T> newNext)
        {
            next = newNext;
        }
    }
}
