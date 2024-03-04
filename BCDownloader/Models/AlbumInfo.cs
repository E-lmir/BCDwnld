using Newtonsoft.Json;

namespace BCDownloader.Models
{
    public class AlbumInfo
    {
        public long art_id { get; set; }
        public Package[]? packages { get; set; }
        public string? artist { get; set; }
        public string? album_release_date { get; set; }
        [JsonProperty("trackinfo")]
        public Trackinfo[]? TrackInfo { get; set; }
    }
}
