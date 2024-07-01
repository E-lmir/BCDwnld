using Newtonsoft.Json;

namespace BCDownloader.Models
{
    public class AlbumInfo
    {
        [JsonProperty("artist")]
        public string? Artist { get; set; }
        [JsonProperty("album_release_date")]
        public string? ReleaseDate { get; set; }
        [JsonProperty("trackinfo")]
        public Trackinfo[]? TrackInfo { get; set; }
    }
}
