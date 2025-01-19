using System;
using System.Collections.Generic;
using System.Linq;

namespace W02CodeQueues
{
    public class PriorityQueue
    {
        private List<QueueItem> queue = new List<QueueItem>();

        public void Enqueue(QueueItem item)
        {
            queue.Add(item);
        }

        public QueueItem Dequeue()
        {
            if (queue.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            var highestPriorityItem = queue.OrderByDescending(item => item.Priority)
                                           .ThenBy(item => queue.IndexOf(item))
                                           .FirstOrDefault();

            queue.Remove(highestPriorityItem);
            return highestPriorityItem;
        }
    }

    public class QueueItem
    {
        public string Data { get; set; }
        public int Priority { get; set; }

        public QueueItem(string data, int priority)
        {
            Data = data;
            Priority = priority;
        }
    }
}
