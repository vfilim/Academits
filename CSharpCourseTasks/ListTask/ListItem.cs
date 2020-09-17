using System;
using System.Collections.Generic;
using System.Text;

namespace ListTask
{
    class ListItem<T>
    {
        public T Data { get; set; }

        public ListItem<T> Next { get; set; }

        public ListItem(T data)
        {
            this.Data = data;
        }

        public ListItem(T data, ListItem<T> next)
        {
            this.Data = data;
            this.Next = next;
        }
    }
}
