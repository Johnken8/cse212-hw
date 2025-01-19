using System;
using System.Collections.Generic;

namespace W02CodeQueues
{
    public class TakingTurnsQueue
    {
        private Queue<Person> queue = new Queue<Person>();

        public void AddPerson(Person person)
        {
            queue.Enqueue(person);
        }

        public Person GetNextPerson()
        {
            if (queue.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            var person = queue.Dequeue();
            if (person.Turns > 0)
            {
                person.Turns--;
                if (person.Turns > 0 || person.Turns == 0)
                {
                    queue.Enqueue(person);  // Person gets back in the queue if they have turns left.
                }
            }
            else
            {
                queue.Enqueue(person);  // Person with infinite turns stays in the queue.
            }
            return person;
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Turns { get; set; }

        public Person(string name, int turns)
        {
            Name = name;
            Turns = turns;
        }
    }
}
