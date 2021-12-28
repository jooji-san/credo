using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list
{
    class MyList<T>
    {
        public int Count { get; private set; }
        public int Capacity { get; private set; }
        private T[] arr = new T[0];

        private void Copy(T[] newArr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }
        }
        private void Grow(int newCapacity)
        {
            T[] tmp = new T[newCapacity];
            Copy(tmp);
            arr = tmp;
            Capacity = newCapacity;
        }
        public void Add(T item)
        {
            if (Count == Capacity)
            {
                // grow capacity 20 items at a time
                // to reserve space for future potential Adds
                Grow(Capacity + 20);
            }

            arr[Count] = item;
            Count++;
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
        }
        public void Remove(int index)
        {
            if (index > Count - 1 || index < 0) return;

            ShiftLeft(index);
            Count--;
        }
        public T Get(int index)
        {
            if (index > Count - 1 || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            return arr[index];
        }


    }
}
