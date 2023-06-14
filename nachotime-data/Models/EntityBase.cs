namespace nachotime_data.Models;

public abstract class EntityBase
{
    public int Id { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
}
