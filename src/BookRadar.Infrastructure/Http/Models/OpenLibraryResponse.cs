using System.Text.Json.Serialization;

namespace BookRadar.Infrastructure.Http.Models;

public sealed class OpenLibraryResponse
{
    [JsonPropertyName("docs")]
    public List<OpenLibraryDoc> Docs { get; set; } = [];
}

public sealed class OpenLibraryDoc
{
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("first_publish_year")]
    public int? FirstPublishYear { get; set; }

    [JsonPropertyName("publisher")]
    public List<string>? Publisher { get; set; }
}
