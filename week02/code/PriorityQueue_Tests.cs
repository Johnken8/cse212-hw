using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace W02CodeQueues
{
    [TestClass]
    public class PriorityQueue_Tests
    {
        [TestMethod]
        public void Test_EnqueueAndDequeue()
        {
            // Arrange
            var queue = new PriorityQueue();
            var item1 = new QueueItem("Item1", 1);
            var item2 = new QueueItem("Item2", 3);
            var item3 = new QueueItem("Item3", 2);

            // Act
            queue.Enqueue(item1);
            queue.Enqueue(item2);
            queue.Enqueue(item3);

            var dequeuedItem = queue.Dequeue();

            // Assert
            Assert.AreEqual("Item2", dequeuedItem.Data);  // Highest priority item
        }

        [TestMethod]
        public void Test_EqualPriorityItems()
        {
            // Arrange
            var queue = new PriorityQueue();
            var item1 = new QueueItem("Item1", 3);
            var item2 = new QueueItem("Item2", 3);
            var item3 = new QueueItem("Item3", 3);

            // Act
            queue.Enqueue(item1);
            queue.Enqueue(item2);
            queue.Enqueue(item3);

            var dequeuedItem = queue.Dequeue(); // Should be item1 (FIFO)
            
            // Assert
            Assert.AreEqual("Item1", dequeuedItem.Data);
        }

        [TestMethod]
        public void Test_EmptyQueue()
        {
            // Arrange
            var queue = new PriorityQueue();

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());
        }
    }
}
