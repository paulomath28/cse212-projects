/// <summary>
/// This queue is circular. When people are added using AddPerson, they are placed
/// at the back of the queue (following FIFO rules). When GetNextPerson is called,
/// the next person in the queue is removed, returned, and then placed back at the
/// end of the queue if they still have turns remaining. 
/// 
/// Each person remains in the queue until their turns are exhausted. When a person
/// is added, a turns parameter specifies how many turns they have. If the turns
/// value is 0 or less, the person has an infinite number of turns and will remain
/// in the queue indefinitely. If a person runs out of turns, they are not added
/// back into the queue.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    /// <summary>
    /// Gets the number of people currently in the queue.
    /// </summary>
    public int Length => _people.Length;

    /// <summary>
    /// Adds a new person to the back of the queue with the specified name and number of turns.
    /// </summary>
    /// <param name="name">The name of the person.</param>
    /// <param name="turns">
    /// The number of turns the person has. A value of 0 or less indicates
    /// an infinite number of turns.
    /// </param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Removes and returns the next person in the queue.
    /// The person is added back to the end of the queue if they still have turns remaining
    /// or if they have an infinite number of turns (turns less than or equal to 0).
    /// 
    /// If the queue is empty, an InvalidOperationException is thrown.
    /// </summary>
    /// <returns>The next person in the queue.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when attempting to get a person from an empty queue.
    /// </exception>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        // Infinite turns
        if (person.Turns <= 0)
        {
            _people.Enqueue(person);
        }
        // Finite turns greater than one
        else if (person.Turns > 1)
        {
            person.Turns--;
            _people.Enqueue(person);
        }
        // If Turns == 1, this was the last turn and the person is not re-enqueued

        return person;
    }

    /// <summary>
    /// Returns a string representation of the queue.
    /// </summary>
    /// <returns>A string representing the current state of the queue.</returns>
    public override string ToString()
    {
        return _people.ToString();
    }
}
