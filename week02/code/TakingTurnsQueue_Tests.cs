using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace W02CodeQueues
{
    [TestClass]
    public class TakingTurnsQueue_Tests
    {
        [TestMethod]
        public void Test_AddPerson()
        {
            // Arrange
            var queue = new TakingTurnsQueue();
            var person = new Person("John", 2);  // Person with 2 turns

            // Act
            queue.AddPerson(person);
            var nextPerson = queue.GetNextPerson();

            // Assert
            Assert.AreEqual(person, nextPerson);
        }

        [TestMethod]
        public void Test_QueueRotation_WithFiniteTurns()
        {
            // Arrange
            var queue = new TakingTurnsQueue();
            var person1 = new Person("John", 2);
            var person2 = new Person("Jane", 1);

            queue.AddPerson(person1);
            queue.AddPerson(person2);

            // Act
            var nextPerson = queue.GetNextPerson(); // Should be person1
            nextPerson = queue.GetNextPerson(); // Should be person2

            // Assert
            Assert.AreEqual(person1.Name, nextPerson.Name);
            nextPerson = queue.GetNextPerson();
            Assert.AreEqual(person2.Name, nextPerson.Name);
        }

        [TestMethod]
        public void Test_QueueRotation_WithInfiniteTurns()
        {
            // Arrange
            var queue = new TakingTurnsQueue();
            var person1 = new Person("John", 2);
            var person2 = new Person("Jane", 0);  // Infinite turns
            queue.AddPerson(person1);
            queue.AddPerson(person2);

            // Act
            var nextPerson = queue.GetNextPerson(); // Should be person1
            nextPerson = queue.GetNextPerson(); // Should be person2
            nextPerson = queue.GetNextPerson(); // Should be person2 again (infinite turns)

            // Assert
            Assert.AreEqual(person1.Name, nextPerson.Name);
            nextPerson = queue.GetNextPerson();
            Assert.AreEqual(person2.Name, nextPerson.Name);
            nextPerson = queue.GetNextPerson();
            Assert.AreEqual(person2.Name, nextPerson.Name);
        }

        [TestMethod]
        public void Test_EmptyQueue()
        {
            // Arrange
            var queue = new TakingTurnsQueue();

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => queue.GetNextPerson());
        }
    }
}
