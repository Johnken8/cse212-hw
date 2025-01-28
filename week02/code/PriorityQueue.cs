public class PriorityQueue
{
    private readonly List<PriorityItem> items = new();

    public void Enqueue(PriorityItem item)
    {
        items.Add(item);
    }

    public PriorityItem Dequeue()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        int maxPriority = items.Max(x => x.Priority);
        var firstHighestPriorityItem = items.First(x => x.Priority == maxPriority);
        
        items.Remove(firstHighestPriorityItem);
        return firstHighestPriorityItem;
    }
}

public class PriorityItem
{
    public string Data { get; set; }
    public int Priority { get; set; }

    public PriorityItem(string data, int priority)
    {
        Data = data;
        Priority = priority;
    }
}