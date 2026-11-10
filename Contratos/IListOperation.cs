using System.Collections.Generic;

namespace RutaCampus.Contratos
{
    internal interface IListOperation<T> : IReadOnlyList<T>
    {
        new T this[int index] { get; set; }
        bool IsEmpty { get; }
        void Add(T data);
        void AddRange(IEnumerable<T> items);
        void Insert(int index, T data);
        void InsertRange(int index, IEnumerable<T> items);
        void Delete(int position);
        T RemoveAt(int position);
        void RemoveRange(int index, int count);
        bool Remove(T data);
        T? ElementAt(int position);
        int GetPosition(T data);
        int IndexOf(T data);
        int LastIndexOf(T data);
        bool Contains(T data);
        void Clear();
        void Reverse();
        void Reverse(int index, int count);
        void Sort();
        void Sort(IComparer<T>? comparer);
        void Sort(Comparison<T> comparison);
        void CopyTo(T[] array, int arrayIndex);
        T[] ToArray();
        IReadOnlyList<T> AsReadOnly();
    }
}
