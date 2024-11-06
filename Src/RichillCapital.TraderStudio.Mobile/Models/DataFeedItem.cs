namespace RichillCapital.TraderStudio.Mobile.Models;

public sealed record DataFeedItem
{
    public required string Name { get; init; }
    public required string Provider { get; init; }
    public required string Status { get; init; }
    public required Dictionary<string, object> Arguments { get; init; }
    public required DateTimeOffset CreatedTimeUtc { get; init; }
}
