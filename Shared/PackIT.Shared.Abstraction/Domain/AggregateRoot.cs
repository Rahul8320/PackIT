namespace PackIT.Shared.Abstraction.Domain;

public abstract class AggregateRoot<T>
{
    public T Id { get; protected set; } = default!;
    public int Version { get; protected set; }
    public IEnumerable<IDomainEvent> Events => _events;

    private readonly List<IDomainEvent> _events = [];
    private bool _versionIncremented;

    protected void AddEvent(IDomainEvent @event)
    {
        if (_events.Count == 0 && !_versionIncremented)
        {
            Version++;
            _versionIncremented = true;

            _events.Add(@event); // TODO: clarification needed!
        }
    }

    public void ClearEvents() => _events.Clear();

    protected void IncrementVersion()
    {
        if (_versionIncremented)
        {
            return;
        }

        Version++;
        _versionIncremented = true;
    }
}
