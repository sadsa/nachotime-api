namespace nachotime_api_models.Models;

public enum WorkflowStatus
{
    NotApproved = 0,
    Approved = 1,
    Rejected = -1,
}

public class CardApiModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Phrase { get; set; } = null!;
    public string Translation { get; set; } = null!;
    public string PlaybackAudioUrl { get; set; } = null!;
    public WorkflowStatus WorkflowStatus { get; set; }
    public List<ExpressionApiModel> Expressions { get; set; } = null!;
    public DateTimeOffset CreatedDate { get; set; }
}