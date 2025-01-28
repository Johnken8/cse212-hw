public class TakingTurnsQueue
{
    private readonly PersonQueue queue = new();

    public void AddPerson(Person person)
    {
        queue.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (queue.IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        var person = queue.Dequeue();
        
        // If turns are 0 or less (infinite) or there are still turns left
        if (person.Turns <= 0 || person.Turns > 1)
        {
            if (person.Turns > 0)
            {
                person.Turns--;
            }
            queue.Enqueue(person);
        }
        
        return person;
    }
}