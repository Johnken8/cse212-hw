using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class TakingTurnsQueue_Tests
{
    /// Defect(s) Found:
    /// 1. The GetNextPerson method wasn't correctly handling the turn decrementing logic
    /// 2. The queue wasn't properly re-enqueueing people with turns remaining
    /// 3. People with infinite turns (Turns <= 0) weren't being properly handled
    [TestMethod]
    public void Test1_AddPerson()
    {
        // Test adding a single person to the queue
        // Arrange
        TakingTurnsQueue queue = new();
        Person person1 = new("Bob", 3);
        queue.AddPerson(person1);
        // Act
        Person result = queue.GetNextPerson();
        // Assert
        Assert.AreEqual("Bob", result.Name);
    }

    /// Defect(s) Found:
    /// 1. When a person with finite turns was dequeued, their turns weren't being decremented properly
    /// 2. People weren't being re-added to the queue correctly when they still had turns remaining
    [TestMethod]
    public void Test2_TakingTurns()
    {
        // Test taking turns in the queue
        // Arrange
        TakingTurnsQueue queue = new();
        Person person1 = new("Bob", 2);
        Person person2 = new("Tim", 1);
        queue.AddPerson(person1);
        queue.AddPerson(person2);
        // Act
        Person result1 = queue.GetNextPerson();    // Bob  (2 turns)
        Person result2 = queue.GetNextPerson();    // Tim  (1 turn)
        Person result3 = queue.GetNextPerson();    // Bob  (1 turn)
        // Assert
        Assert.AreEqual("Bob", result1.Name);
        Assert.AreEqual("Tim", result2.Name);
        Assert.AreEqual("Bob", result3.Name);
    }

    /// Defect(s) Found:
    /// 1. The queue wasn't handling infinite turns correctly
    /// 2. Infinite-turn people weren't staying in the queue
    [TestMethod]
    public void Test3_InfiniteTurns()
    {
        // Test handling of infinite turns
        // Arrange
        TakingTurnsQueue queue = new();
        Person person1 = new("Bob", 0);  // Infinite turns
        queue.AddPerson(person1);
        // Act
        Person result1 = queue.GetNextPerson();
        Person result2 = queue.GetNextPerson();
        // Assert
        Assert.AreEqual("Bob", result1.Name);
        Assert.AreEqual("Bob", result2.Name);
    }

    /// Defect(s) Found:
    /// None - empty queue handling worked correctly
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Test4_EmptyQueue()
    {
        // Test empty queue behavior
        // Arrange
        TakingTurnsQueue queue = new();
        // Act & Assert
        queue.GetNextPerson(); // Should throw InvalidOperationException
    }
}