using RutaCampus.Contratos;
using System;
using System.Collections.Generic;
using System.Collections;

namespace RutaCampus.Common
{
    internal class Queue<T> : IQueueOperation<T>
    {
        private readonly Lista<T> elements = new Lista<T>();
        public int Count => elements.Count;
        public bool IsEmpty => elements.Count == 0;
        public int Capacity => elements.Capacity;

        public void Enqueue(T item)
        {
            elements.Add(item);
        }

        public T Dequeue()
        {
            if (!TryDequeue(out T item))
            {
                throw new InvalidOperationException("La cola está vacía.");
            }

            return item;
        }

        public bool TryDequeue(out T item)
        {
            if (IsEmpty)
            {
                item = default!;
                return false;
            }

            item = elements[0];
            elements.RemoveAt(0);
            return true;
        }

        public T Peek()
        {
            if (!TryPeek(out T item))
            {
                throw new InvalidOperationException("La cola está vacía.");
            }

            return item;
        }

        public bool TryPeek(out T item)
        {
            if (IsEmpty)
            {
                item = default!;
                return false;
            }

            item = elements[0];
            return true;
        }

        public bool Contains(T item)
        {
            return elements.Contains(item);
        }

        public T[] ToArray()
        {
            return elements.ToArray();
        }

        public void Clear()
        {
            elements.Clear();
        }

        public int EnsureCapacity(int capacity)
        {
            return elements.EnsureCapacity(capacity);
        }

        public void TrimExcess()
        {
            elements.TrimExcess();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            elements.CopyTo(array, arrayIndex);
        }

        public void EnqueueRange(IEnumerable<T> items)
        {
            ArgumentNullException.ThrowIfNull(items);
            elements.AddRange(ReferenceEquals(items, this) ? ToArray() : items);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
