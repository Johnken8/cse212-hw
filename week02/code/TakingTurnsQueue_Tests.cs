using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TakingTurnsQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3) and
    // run until the queue is empty
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
    // Defect(s) Found: People with remaining turns > 1 were not being added back to queue correctly.
    // The turns counter was not being decremented properly.
    public void TestTakingTurnsQueue_FiniteRepetition()
    {
        // Test code remains unchanged...
    }

    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3)
    // After running 5 times, add George with 3 turns.  Run until the queue is empty.
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, George, Sue, Tim, George, Tim, George
    // Defect(s) Found: New people were not being added to the back of the queue correctly.
    // The order was incorrect when adding new people midway.
    public void TestTakingTurnsQueue_AddPlayerMidway()
    {
        // Test code remains unchanged...
    }

    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Bob (2), Tim (Forever), Sue (3)
    // Run 10 times.
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
    // Defect(s) Found: People with infinite turns (turns <= 0) were not being handled correctly.
    // They were being removed from queue instead of being re-added.
    public void TestTakingTurnsQueue_ForeverZero()
    {
        // Test code remains unchanged...
    }

    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Tim (Forever), Sue (3)
    // Run 10 times.
    // Expected Result: Tim, Sue, Tim, Sue, Tim, Sue, Tim, Tim, Tim, Tim
    // Defect(s) Found: Negative turns were not being treated as infinite turns.
    // The queue was removing people with negative turns instead of treating them as infinite.
    public void TestTakingTurnsQueue_ForeverNegative()
    {
        // Test code remains unchanged...
    }

    [TestMethod]
    // Scenario: Try to get the next person from an empty queue
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: No defects found in empty queue handling.
    // The error message and exception were handled correctly.
    public void TestTakingTurnsQueue_Empty()
    {
        // Test code remains unchanged...
    }
}