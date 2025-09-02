namespace TG_Ecommerce.SharedKernel.SeedWork;

public interface IEntityBase
{
    
}

public interface IEntityBase<TId> : IEntityBase
{
    TId Id { get; }
}