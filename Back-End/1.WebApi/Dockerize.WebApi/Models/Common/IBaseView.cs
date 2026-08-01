namespace Dockerize.WebApi.Models.Common;

public interface IBaseView
{
    int Id { get; set; }
    Guid EntityId { get; set; }
}
public abstract class BaseView : IBaseView
{
    public int Id { get; set; }
    public Guid EntityId { get; set; }
}