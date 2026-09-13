namespace Ordering.Domain.Abstractions;
public abstract class Entity<TId> : IEntity<TId>
{
    protected Entity(TId id)
    {
        Id = id;
    }
    public TId Id { get; private init; }
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
}
