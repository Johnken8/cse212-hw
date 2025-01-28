using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueue_Tests
{
    /// Test enqueuing and dequeuing items with different priorities
    /// Defect(s) Found: 
    /// 1. The Dequeue method wasn't properly maintaining FIFO order for items with same priority
    [TestMethod]
    public void Test1_PriorityOrder()
    {
        // Arrange
        PriorityQueue queue = new();
        var item1 = new PriorityItem("First", 1);
        var item2 = new PriorityItem("Second", 2);
        var item3 = new PriorityItem("Third", 1);

        // Act
        queue.Enqueue(item1);
        queue.Enqueue(item2);
        queue.Enqueue(item3);

        var result1 = queue.Dequeue();
        var result2 = queue.Dequeue();
        var result3 = queue.Dequeue();

        // Assert
        Assert.AreEqual("Second", result1.Data); // Highest priority should come out first
        Assert.AreEqual("First", result2.Data);  // For same priority, first in should come out first
        Assert.AreEqual("Third", result3.Data);
    }

    /// Test empty queue behavior
    /// Defect(s) Found:
    /// None - empty queue handling worked correctly
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Test2_EmptyQueue()
    {
        // Arrange
        PriorityQueue queue = new();
        
        // Act & Assert
        queue.Dequeue(); // Should throw InvalidOperationException
    }

    /// Test items with equal priorities maintain FIFO order
    /// Defect(s) Found:
    /// 1. Items with equal priority weren't maintaining their original order
    [TestMethod]
    public void Test3_EqualPriorities()
    {
        // Arrange
        PriorityQueue queue = new();
        var item1 = new PriorityItem("First", 1);
        var item2 = new PriorityItem("Second", 1);
        var item3 = new PriorityItem("Third", 1);

        // Act
        queue.Enqueue(item1);
        queue.Enqueue(item2);
        queue.Enqueue(item3);

        var result1 = queue.Dequeue();
        var result2 = queue.Dequeue();
        var result3 = queue.Dequeue();

        // Assert
        Assert.AreEqual("First", result1.Data);
        Assert.AreEqual("Second", result2.Data);
        Assert.AreEqual("Third", result3.Data);
    }
}