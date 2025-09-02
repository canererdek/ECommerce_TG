namespace TG_Ecommerce.SharedKernel.SeedWork;

public class EntityBase<TId> : IEntityBase<TId>
{
    public virtual TId Id { get; protected set; } = default!;
    public virtual DateTime CreatedAt { get; protected set; }
    public virtual DateTime? UpdatedAt { get; protected set; }
    public virtual DateTime? DeletedAt { get; protected set; }
    
    protected EntityBase()
    {
        CreatedAt = DateTime.UtcNow;
    }

    public void SetUpdated()
    {
        UpdatedAt = DateTime.UtcNow;
    }

    public void SoftDelete()
    {
        DeletedAt = DateTime.UtcNow;
    }
}