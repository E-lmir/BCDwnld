using Newtonsoft.Json;

namespace BCDownloader.Models
{
    public record Trackinfo (
        [JsonProperty("file")]
        File? File,
        [JsonProperty("Data")]
        byte[]? Data,
        [JsonProperty("artist")]
        string? Artist,
        [JsonProperty("title")]
        string? Title,
        [JsonProperty("title_link")]
        string? TitleLink);
}
