namespace nachotime_data.Models;

public class Expression : EntityBase
{
    public bool IsKnown { get; set; }
    public string? Translation { get; set; }
    public string? Definition { get; set; }
    public int CardId { get; set; }
    public Card Card { get; set; }
}