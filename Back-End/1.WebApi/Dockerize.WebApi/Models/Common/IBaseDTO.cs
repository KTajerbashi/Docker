namespace Dockerize.WebApi.Models.Common;
public interface IBaseDTO
{
    int Id { get; set; }
    Guid EntityId { get; set; }
}
public abstract class BaseDTO : IBaseDTO
{
    public int Id { get; set; }
    public Guid EntityId { get; set; }
}


