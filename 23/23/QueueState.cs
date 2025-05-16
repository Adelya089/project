using System;

namespace QueueVisualization.Model
{
    [Serializable] // Важно для сериализации
    public class QueueState
    {
        public int[] Array { get; set; }
        public int Head { get; set; }
        public int Tail { get; set; }
        public int Capacity { get; set; }
        public int Count { get; set; }
    }
}