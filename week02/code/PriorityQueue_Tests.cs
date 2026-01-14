using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a priority queue and add the following people with priorities: John (1), Jane (3), James (2)
    // Expected Result: Jane, James, John
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var john = new PriorityItem("John", 1);
        var jane = new PriorityItem("Jane", 3);
        var james = new PriorityItem("James", 2);

        PriorityItem[] expectedResult = {jane, james, john};

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(john.Value, john.Priority);
        priorityQueue.Enqueue(jane.Value, jane.Priority);
        priorityQueue.Enqueue(james.Value, james.Priority);

        for (int i = 0; i < expectedResult.Length; i++)
        {
            var item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, item);
        }
    }
    [TestMethod]
    // Scenario: Create a priority queue and prompt the following people with priorities: John (2), Jane (3), James (1), Jonah (3)
    // Expected Result: Jane, Jonah, John, James
    // Defect(s) Found: The for loop in Dequeue did not correctly iterate through all items in the queue to find the highest priority item.
    public void TestPriorityQueue_2()
    {
       var john = new PriorityItem("John", 2);
        var jane = new PriorityItem("Jane", 3);
        var james = new PriorityItem("James", 1);
        var jonah = new PriorityItem("Jonah", 3);

        PriorityItem[] expectedResult = {jane, jonah, john, james};

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(john.Value, john.Priority);
        priorityQueue.Enqueue(jane.Value, jane.Priority);
        priorityQueue.Enqueue(james.Value, james.Priority);
        priorityQueue.Enqueue(jonah.Value, jonah.Priority);

        for (int i = 0; i < expectedResult.Length; i++)
        {
            var item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, item);
        }
    }

    [TestMethod]
    // Scenario: Create an empty priority queue and attempt to dequeue an item.
    // Expected Result: Jane, James, John
    // Defect(s) Found: The RemoveAt method was missing in Dequeue, so the item with the highest priority was not being removed from the queue.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}