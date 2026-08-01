namespace Dockerize.WebApi.Models.Common;

public interface IBaseEntity
{
    int Id { get; set; }
    Guid EntityId { get; set; }
}

public abstract class BaseEntity : IBaseEntity
{
    public int Id { get; set; }
    public Guid EntityId { get; set; }
}