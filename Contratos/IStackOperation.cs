using System.Collections.Generic;

namespace RutaCampus.Contratos
{
    internal interface IStackOperation<T> : IEnumerable<T>
    {
        int Count { get; }
        bool IsEmpty { get; }
        int Capacity { get; }
        void Push(T item);
        void PushRange(IEnumerable<T> items);
        T Pop();
        bool TryPop(out T item);
        T Peek();
        bool TryPeek(out T item);
        bool Contains(T item);
        int EnsureCapacity(int capacity);
        void TrimExcess();
        void CopyTo(T[] array, int arrayIndex);
        T[] ToArray();
        void Clear();
    }
}
