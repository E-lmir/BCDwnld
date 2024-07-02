using Newtonsoft.Json;

namespace BCDownloader.Models
{
    public record File(
        [JsonProperty("mp3-128")]
        string? DownloadPath);
}
