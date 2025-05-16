using System;
using System.Collections.Generic;
using System.Linq;

namespace QueueVisualization.Model
{
    public class Queue
    {
        private int[] _array;
        private int _head;
        private int _tail;
        private int _capacity;

        public int Capacity
        {
            get { return _capacity; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Capacity), "Capacity must be greater than zero.");
                }
                _capacity = value;
                _array = new int[_capacity];
                _head = 0;
                _tail = 0;
            }
        }
        public Queue(int capacity)
        {
            Capacity = capacity;
        }


        public int Head => _head;
        public int Tail => _tail;


        public int Count { get; private set; } = 0;

        public bool IsEmpty => Count == 0;
        public bool IsFull => Count == Capacity;

        public event EventHandler QueueChanged;

        private void OnQueueChanged()
        {
            QueueChanged?.Invoke(this, EventArgs.Empty);
        }


        public void Enqueue(int value)
        {
            if (IsFull)
            {
                throw new InvalidOperationException("Queue is full.");
            }

            _array[_tail] = value;
            _tail = (_tail + 1) % Capacity; // Цикличность
            Count++;
            OnQueueChanged();
        }


        public int Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            int value = _array[_head];
            _head = (_head + 1) % Capacity;  // Цикличность
            Count--;
            OnQueueChanged();
            return value;
        }

        public void Clear()
        {
            _head = 0;
            _tail = 0;
            Count = 0;
            Array.Clear(_array, 0, _array.Length);
            OnQueueChanged();
        }


        public QueueState GetState()
        {
            return new QueueState
            {
                Array = _array.ToArray(), // Создаем копию массива, чтобы не было прямых ссылок
                Head = _head,
                Tail = _tail,
                Capacity = Capacity,
                Count = Count
            };
        }

        public void SetState(QueueState state)
        {
            if (state.Array.Length != Capacity)
            {
                throw new ArgumentException("Несовместимый размер массива состояния.");
            }

            Array.Copy(state.Array, _array, state.Array.Length);
            _head = state.Head;
            _tail = state.Tail;
            Count = state.Count;
            OnQueueChanged();
        }

        public int[] GetArrayCopy()
        {
            return _array.ToArray(); // Возвращаем копию, чтобы избежать прямого доступа к внутреннему массиву
        }
    }
}