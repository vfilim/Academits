using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ArrayListTask
{
    class MyArrayList<T> : IList<T>
    {
        public T[] Elements { get; set; }

        private int Capacity { get; set; }

        public int Count { get; set; }

        public bool IsReadOnly { get; private set; }

        public MyArrayList()
        {
            Capacity = 0;
            Count = 0;

            Elements = new T[Capacity];
        }

        public MyArrayList(T[] array)
        {
            Capacity = array.Length;

            Elements = new T[Capacity];

            array.CopyTo(Elements, 0);
        }

        public T this[int index]
        {
            get
            {
                return Elements[index];
            }

            set
            {
                Elements[index] = value;
            }
        }

        public int IndexOf(T element)
        {
            return Array.IndexOf(Elements, element);
        }

        public void Insert(int index, T element)
        {

        }

        public void RemoveAt(int index)
        {

        }

        public void Add(T element)
        {

        }

        public void Clear()
        {

        }

        public bool Contains(T element)
        {
            return
        }

        public void CopyTo(T[] array, int index)
        {

        }

        public bool Remove(T element)
        {
            return
        }
        public IEnumerator<T> GetEnumerator()
        {
            return;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return
        }
    }
}
