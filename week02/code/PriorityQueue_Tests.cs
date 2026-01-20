using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities and remove one item.
    // Expected Result: The item with the highest priority should be removed first.
    // Defect(s) Found:
    // - The queue removes the first inserted item instead of the item with the highest priority.
    public void TestPriorityQueue_HighestPriorityRemoved()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Add multiple items with the same highest priority.
    // Expected Result: When priorities are equal, the item added first (FIFO) is removed first.
    // Defect(s) Found:
    // - The queue does not follow FIFO order when multiple items share the same priority.
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 10);
        priorityQueue.Enqueue("Second", 10);
        priorityQueue.Enqueue("Third", 5);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("First", result);
    }

    [TestMethod]
    // Scenario: Add items where a lower priority item is added after a higher priority item.
    // Expected Result: The item with the higher priority should still be removed first.
    // Defect(s) Found:
    // - The queue incorrectly prioritizes insertion order over priority.
    public void TestPriorityQueue_LowerPriorityDoesNotOverride()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("High", 10);
        priorityQueue.Enqueue("Low", 1);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Add a single item to the queue and remove it.
    // Expected Result: The single item is returned correctly.
    // Defect(s) Found:
    // - No defects found in this scenario.
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("OnlyItem", 3);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("OnlyItem", result);
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: An InvalidOperationException is thrown with the message "A fila está vazia".
    // Defect(s) Found:
    // - The queue does not throw the correct exception or uses an incorrect error message.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The line is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                              e.GetType(), e.Message)
            );
        }
    }
}
