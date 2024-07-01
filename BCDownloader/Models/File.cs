using Newtonsoft.Json;

namespace BCDownloader.Models
{
    public class File
    {
        [JsonProperty("mp3-128")]
        public string? DownloadPath { get; set; }
    }
}
