using RutaCampus.Contratos;
using System;
using System.Collections;
using System.Collections.Generic;

namespace RutaCampus.Common
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T>? Next { get; set; }
        public Node<T>? Back { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }

    internal class DoubleLinkList<T> : IEnumerable<T>, IListOperation<T>
    {
        private Node<T>? Head { get; set; }
        private Node<T>? Last { get; set; }
        private int _count;
        public int Count
        {
            get
            {
                return _count;
            }
        }
        public bool IsEmpty
        {
            get
            {
                return Head is null;
            }
        }

        public T this[int index]
        {
            get => GetNodeAt(index).Value;
            set => GetNodeAt(index).Value = value;
        }

        public DoubleLinkList()
        {
            _count = 0;
        }

        public void Add(T data)
        {
            Node<T> n = new Node<T>(data);
            if (Last is null)
            {
                Head = n;
                Last = n;
            }
            else
            {
                n.Back = Last;
                Last.Next = n;
                Last = n;
            }
            _count++;
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

        public void Insert(int index, T data)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (index == Count)
            {
                Add(data);
                return;
            }

            Node<T> current = GetNodeAt(index);
            Node<T> inserted = new Node<T>(data)
            {
                Back = current.Back,
                Next = current
            };

            if (current.Back is null)
            {
                Head = inserted;
            }
            else
            {
                current.Back.Next = inserted;
            }

            current.Back = inserted;
            _count++;
        }

        public void InsertRange(int index, IEnumerable<T> items)
        {
            ArgumentNullException.ThrowIfNull(items);
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            Lista<T> copia = new Lista<T>(items);
            for (int i = 0; i < copia.Count; i++)
            {
                Insert(index + i, copia[i]);
            }
        }

        public void Delete(int position)
        {
            if (position >= 0 && position < Count)
            {
                RemoveAt(position);
            }
        }

        public T RemoveAt(int position)
        {
            Node<T> node = GetNodeAt(position);
            if (node.Back is null)
            {
                Head = node.Next;
            }
            else
            {
                node.Back.Next = node.Next;
            }

            if (node.Next is null)
            {
                Last = node.Back;
            }
            else
            {
                node.Next.Back = node.Back;
            }

            _count--;
            node.Next = null;
            node.Back = null;
            return node.Value;
        }

        public void RemoveRange(int index, int count)
        {
            ValidarRango(index, count);
            for (int i = 0; i < count; i++)
            {
                RemoveAt(index);
            }
        }

        public bool Remove(T data)
        {
            int position = IndexOf(data);
            if (position < 0)
            {
                return false;
            }

            RemoveAt(position);
            return true;
        }

        public T? ElementAt(int position)
        {
            if (position < 0 || position >= Count)
            {
                return default;
            }

            return GetNodeAt(position).Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int GetPosition(T data)
        {
            Node<T>? current = Head;
            int position = 0;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, data))
                {
                    return position;
                }
                current = current.Next;
                position++;
            }
            throw new ArgumentException("El elemento no se encuentra en la lista.");
        }

        public int IndexOf(T data)
        {
            Node<T>? current = Head;
            int position = 0;
            while (current is not null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, data))
                {
                    return position;
                }

                current = current.Next;
                position++;
            }

            return -1;
        }

        public int LastIndexOf(T data)
        {
            Node<T>? current = Last;
            int position = Count - 1;
            while (current is not null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, data))
                {
                    return position;
                }

                current = current.Back;
                position--;
            }

            return -1;
        }

        public bool Contains(T data)
        {
            return IndexOf(data) >= 0;
        }

        public void Clear()
        {
            Node<T>? current = Head;
            while (current is not null)
            {
                Node<T>? next = current.Next;
                current.Next = null;
                current.Back = null;
                current = next;
            }

            Head = null;
            Last = null;
            _count = 0;
        }

        public void Reverse()
        {
            Node<T>? current = Head;
            while (current is not null)
            {
                Node<T>? next = current.Next;
                current.Next = current.Back;
                current.Back = next;
                current = next;
            }

            (Head, Last) = (Last, Head);
        }

        public void Reverse(int index, int count)
        {
            ValidarRango(index, count);
            int left = index;
            int right = index + count - 1;
            while (left < right)
            {
                Node<T> leftNode = GetNodeAt(left);
                Node<T> rightNode = GetNodeAt(right);
                (leftNode.Value, rightNode.Value) = (rightNode.Value, leftNode.Value);
                left++;
                right--;
            }
        }

        public void Sort()
        {
            Sort(Comparer<T>.Default);
        }

        public void Sort(IComparer<T>? comparer)
        {
            T[] items = ToArray();
            Array.Sort(items, comparer);
            AssignValues(items);
        }

        public void Sort(Comparison<T> comparison)
        {
            ArgumentNullException.ThrowIfNull(comparison);
            T[] items = ToArray();
            Array.Sort(items, comparison);
            AssignValues(items);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ArgumentNullException.ThrowIfNull(array);
            if (arrayIndex < 0 || arrayIndex > array.Length || array.Length - arrayIndex < Count)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }

            Node<T>? current = Head;
            while (current is not null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public T[] ToArray()
        {
            T[] items = new T[Count];
            CopyTo(items, 0);
            return items;
        }

        public IReadOnlyList<T> AsReadOnly()
        {
            return Array.AsReadOnly(ToArray());
        }

        private void AssignValues(T[] items)
        {
            Node<T>? current = Head;
            for (int i = 0; i < items.Length; i++)
            {
                current!.Value = items[i];
                current = current.Next;
            }
        }

        private Node<T> GetNodeAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (index < Count / 2)
            {
                Node<T> current = Head!;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next!;
                }

                return current;
            }

            Node<T> last = Last!;
            for (int i = Count - 1; i > index; i--)
            {
                last = last.Back!;
            }

            return last;
        }

        private void ValidarRango(int index, int count)
        {
            if (index < 0 || count < 0 || index > Count - count)
            {
                throw new ArgumentOutOfRangeException(index < 0 ? nameof(index) : nameof(count));
            }
        }
    }
}

