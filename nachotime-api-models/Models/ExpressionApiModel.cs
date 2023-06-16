namespace nachotime_api_models.Models;

public class ExpressionApiModel
{
    public Guid Id { get; set; }
    public bool IsKnown { get; set; }
    public string? Translation { get; set; }
    public string? Definition { get; set; }
}