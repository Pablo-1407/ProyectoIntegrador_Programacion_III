using System.Collections.Generic;

namespace RutaCampus.Contratos
{
    internal interface IPriorityQueueOperation<T> : IEnumerable<T>
    {
        int Count { get; }
        bool IsEmpty { get; }
        int Capacity { get; }
        void Enqueue(T item);
        T Dequeue();
        bool TryDequeue(out T item);
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