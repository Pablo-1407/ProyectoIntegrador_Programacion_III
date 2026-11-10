using RutaCampus.Contratos;
using System;
using System.Collections;
using System.Collections.Generic;

namespace RutaCampus.Common
{
    internal sealed class PriorityQueue<T> : IPriorityQueueOperation<T> where T : IComparable<T>
    {
        private readonly Lista<T> _items = new Lista<T>();

        public int Count => _items.Count;
        public bool IsEmpty => _items.IsEmpty;
        public int Capacity => _items.Capacity;

        public void Enqueue(T item)
        {
            int inicio = 0;
            int fin = Count;

            while (inicio < fin)
            {
                int medio = inicio + (fin - inicio) / 2;
                if (_items[medio].CompareTo(item) <= 0)
                {
                    inicio = medio + 1;
                }
                else
                {
                    fin = medio;
                }
            }

            _items.Insert(inicio, item);
        }

        public T Dequeue()
        {
            if (!TryDequeue(out T item))
            {
                throw new InvalidOperationException("La cola de prioridad está vacía.");
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

            item = _items.RemoveAt(0);
            return true;
        }

        public T Peek()
        {
            if (!TryPeek(out T item))
            {
                throw new InvalidOperationException("La cola de prioridad está vacía.");
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

            item = _items[0];
            return true;
        }

        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        public int EnsureCapacity(int capacity)
        {
            return _items.EnsureCapacity(capacity);
        }

        public void TrimExcess()
        {
            _items.TrimExcess();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public T[] ToArray()
        {
            return _items.ToArray();
        }

        public void Clear()
        {
            _items.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}