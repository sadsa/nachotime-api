namespace nachotime_data.Models;

public abstract class EntityBase
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
}
