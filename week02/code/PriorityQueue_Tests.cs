using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add multiple items with different priorities and verify highest priority is removed first
    // Expected Result: Items should be dequeued in order of priority (highest first)
    // Defect(s) Found: The Dequeue method was not properly removing items from the queue
    // and was not correctly identifying the highest priority item
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Second", 3);
        priorityQueue.Enqueue("Third", 2);

        Assert.AreEqual("Second", priorityQueue.Dequeue(), "Should return highest priority (3)");
        Assert.AreEqual("Third", priorityQueue.Dequeue(), "Should return next highest priority (2)");
        Assert.AreEqual("First", priorityQueue.Dequeue(), "Should return lowest priority (1)");
    }

    [TestMethod]
    // Scenario: Add multiple items with same priority and verify FIFO order is maintained
    // Expected Result: Items with same priority should be dequeued in the order they were added
    // Defect(s) Found: The queue was not maintaining FIFO order for items with equal priority
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 2);
        priorityQueue.Enqueue("Second", 2);
        priorityQueue.Enqueue("Third", 2);

        Assert.AreEqual("First", priorityQueue.Dequeue(), "Should return first item added with priority 2");
        Assert.AreEqual("Second", priorityQueue.Dequeue(), "Should return second item added with priority 2");
        Assert.AreEqual("Third", priorityQueue.Dequeue(), "Should return third item added with priority 2");
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue
    // Expected Result: Should throw InvalidOperationException with appropriate message
    // Defect(s) Found: Empty queue check was correct but item was not being removed from queue
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Should have thrown an exception");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Mix of different priorities with some equal priorities
    // Expected Result: Should dequeue highest priority first, maintaining FIFO for equal priorities
    // Defect(s) Found: The loop in Dequeue method was not checking all items in the queue
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low1", 1);
        priorityQueue.Enqueue("High1", 3);
        priorityQueue.Enqueue("Mid1", 2);
        priorityQueue.Enqueue("High2", 3);
        priorityQueue.Enqueue("Mid2", 2);

        Assert.AreEqual("High1", priorityQueue.Dequeue(), "Should return first item with highest priority");
        Assert.AreEqual("High2", priorityQueue.Dequeue(), "Should return second item with highest priority");
        Assert.AreEqual("Mid1", priorityQueue.Dequeue(), "Should return first medium priority item");
        Assert.AreEqual("Mid2", priorityQueue.Dequeue(), "Should return second medium priority item");
        Assert.AreEqual("Low1", priorityQueue.Dequeue(), "Should return lowest priority item");
    }
}