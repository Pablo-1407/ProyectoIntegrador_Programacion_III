using RutaCampus.Contratos;
using System;
using System.Collections;
using System.Collections.Generic;

namespace RutaCampus.Common
{
    internal class Pila<T> : IStackOperation<T>
    {
        private T[] _items;

        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;
        public int Capacity => _items.Length;

        public Pila() : this(0)
        {
        }

        public Pila(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            _items = capacity == 0 ? Array.Empty<T>() : new T[capacity];
        }

        public void Push(T item)
        {
            EnsureCapacity(Count + 1);
            _items[Count++] = item;
        }

        public void PushRange(IEnumerable<T> items)
        {
            ArgumentNullException.ThrowIfNull(items);
            T[] values = ReferenceEquals(items, this) ? ToArray() : items is T[] array ? (T[])array.Clone() : new Lista<T>(items).ToArray();
            EnsureCapacity(Count + values.Length);
            for (int i = values.Length - 1; i >= 0; i--)
            {
                Push(values[i]);
            }
        }

        public T Pop()
        {
            if (!TryPop(out T item))
            {
                throw new InvalidOperationException("La pila está vacía.");
            }

            return item;
        }

        public bool TryPop(out T item)
        {
            if (IsEmpty)
            {
                item = default!;
                return false;
            }

            int index = --Count;
            item = _items[index];
            _items[index] = default!;
            return true;
        }

        public T Peek()
        {
            if (!TryPeek(out T item))
            {
                throw new InvalidOperationException("La pila está vacía.");
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

            item = _items[Count - 1];
            return true;
        }

        public bool Contains(T item)
        {
            return Array.IndexOf(_items, item, 0, Count) >= 0;
        }

        public T[] ToArray()
        {
            T[] result = new T[Count];
            for (int i = 0; i < Count; i++)
            {
                result[i] = _items[Count - i - 1];
            }

            return result;
        }

        public void Clear()
        {
            Array.Clear(_items, 0, Count);
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int EnsureCapacity(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            if (capacity <= _items.Length)
            {
                return _items.Length;
            }

            int nuevaCapacidad = _items.Length == 0 ? 4 : checked(_items.Length * 2);
            if (nuevaCapacidad < capacity)
            {
                nuevaCapacidad = capacity;
            }

            Array.Resize(ref _items, nuevaCapacidad);
            return nuevaCapacidad;
        }

        public void TrimExcess()
        {
            if (Count < _items.Length)
            {
                Array.Resize(ref _items, Count);
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ArgumentNullException.ThrowIfNull(array);
            if (arrayIndex < 0 || arrayIndex > array.Length || array.Length - arrayIndex < Count)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }

            for (int i = 0; i < Count; i++)
            {
                array[arrayIndex + i] = _items[Count - i - 1];
            }
        }
    }
}
