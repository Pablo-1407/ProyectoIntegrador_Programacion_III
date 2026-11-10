using RutaCampus.Contratos;
using System;
using System.Collections;
using System.Collections.Generic;

namespace RutaCampus.Common
{
    public class Lista<T> : IListOperation<T>
    {
        private T[] _items;
        private int _count;

        public int Count => _count;
        public bool IsEmpty => _count == 0;
        public int Capacity => _items.Length;

        public T this[int index]
        {
            get
            {
                ValidarIndice(index);
                return _items[index];
            }
            set
            {
                ValidarIndice(index);
                _items[index] = value;
            }
        }

        public Lista() : this(0)
        {
        }

        public Lista(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            _items = capacity == 0 ? Array.Empty<T>() : new T[capacity];
        }

        public Lista(IEnumerable<T> items) : this()
        {
            AddRange(items);
        }

        public void Add(T data)
        {
            EnsureCapacity(_count + 1);
            _items[_count++] = data;
        }

        public void AddRange(IEnumerable<T> items)
        {
            ArgumentNullException.ThrowIfNull(items);

            if (ReferenceEquals(items, this))
            {
                items = ToArray();
            }

            foreach (T item in items)
            {
                Add(item);
            }
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            EnsureCapacity(_count + 1);
            Array.Copy(_items, index, _items, index + 1, _count - index);
            _items[index] = item;
            _count++;
        }

        public void InsertRange(int index, IEnumerable<T> items)
        {
            ArgumentNullException.ThrowIfNull(items);
            if (index < 0 || index > _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            T[] nuevosItems = items is T[] array ? (T[])array.Clone() : new Lista<T>(items).ToArray();
            if (nuevosItems.Length == 0)
            {
                return;
            }

            EnsureCapacity(_count + nuevosItems.Length);
            Array.Copy(_items, index, _items, index + nuevosItems.Length, _count - index);
            Array.Copy(nuevosItems, 0, _items, index, nuevosItems.Length);
            _count += nuevosItems.Length;
        }

        public void Delete(int position)
        {
            ValidarIndice(position);
            RemoveAt(position);
        }

        public T RemoveAt(int index)
        {
            ValidarIndice(index);
            T removed = _items[index];
            _count--;
            Array.Copy(_items, index + 1, _items, index, _count - index);
            _items[_count] = default!;
            return removed;
        }

        public void RemoveRange(int index, int count)
        {
            if (index < 0 || count < 0 || index > _count - count)
            {
                throw new ArgumentOutOfRangeException(index < 0 ? nameof(index) : nameof(count));
            }

            if (count == 0)
            {
                return;
            }

            _count -= count;
            Array.Copy(_items, index + count, _items, index, _count - index);
            Array.Clear(_items, _count, count);
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index < 0)
            {
                return false;
            }

            RemoveAt(index);
            return true;
        }

        public T ElementAt(int position)
        {
            ValidarIndice(position);
            return _items[position];
        }

        public int GetPosition(T data)
        {
            int index = IndexOf(data);
            return index >= 0
                ? index
                : throw new ArgumentException("El elemento no se encuentra en la lista.", nameof(data));
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(_items, item, 0, _count);
        }

        public int LastIndexOf(T item)
        {
            return Array.LastIndexOf(_items, item, _count - 1, _count);
        }

        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }

        public void Clear()
        {
            Array.Clear(_items, 0, _count);
            _count = 0;
        }

        public void Reverse()
        {
            Array.Reverse(_items, 0, _count);
        }

        public void Reverse(int index, int count)
        {
            ValidarRango(index, count);
            Array.Reverse(_items, index, count);
        }

        public void Sort()
        {
            Sort(Comparer<T>.Default);
        }

        public void Sort(IComparer<T>? comparer)
        {
            Array.Sort(_items, 0, _count, comparer);
        }

        public void Sort(Comparison<T> comparison)
        {
            ArgumentNullException.ThrowIfNull(comparison);
            Array.Sort(_items, 0, _count, Comparer<T>.Create(comparison));
        }

        public T[] ToArray()
        {
            T[] result = new T[_count];
            Array.Copy(_items, result, _count);
            return result;
        }

        public IReadOnlyList<T> AsReadOnly()
        {
            return Array.AsReadOnly(ToArray());
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
            if (_count == _items.Length)
            {
                return;
            }

            Array.Resize(ref _items, _count);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ArgumentNullException.ThrowIfNull(array);
            if (arrayIndex < 0 || arrayIndex > array.Length || array.Length - arrayIndex < _count)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }

            Array.Copy(_items, 0, array, arrayIndex, _count);
        }

        private void ValidarRango(int index, int count)
        {
            if (index < 0 || count < 0 || index > _count - count)
            {
                throw new ArgumentOutOfRangeException(index < 0 ? nameof(index) : nameof(count));
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void ValidarIndice(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }
    }
}
