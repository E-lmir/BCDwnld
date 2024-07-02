using Newtonsoft.Json;

namespace BCDownloader.Models
{
    public record Trackinfo
    {
        [JsonProperty("file")]
        public File? File { get; init; }
        [JsonProperty("Data")]
        public byte[]? Data { get; set; }
        [JsonProperty("artist")]
        public string? Artist { get; set; }
        [JsonProperty("title")]
        public string? Title { get; init; }
        [JsonProperty("title_link")]
        public string? TitleLink { get; init; }
    }
}
