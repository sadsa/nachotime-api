using System.ComponentModel.DataAnnotations.Schema;

namespace nachotime_data.Models;

public enum WorkflowStatus
{
    NotApproved = 0,
    Approved = 1,
    Rejected = -1,
}

public class Card : EntityBase
{
    public string Title { get; set; } = null!;
    public string Phrase { get; set; } = null!;
    public string Translation { get; set; } = null!;
    public string PlaybackAudioUrl { get; set; } = null!;
    public WorkflowStatus WorkflowStatus { get; set; }
    [Column(TypeName = "jsonb")] public List<Expression> Expressions { get; set; } = new List<Expression>();
}