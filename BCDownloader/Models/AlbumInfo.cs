using Newtonsoft.Json;

namespace BCDownloader.Models
{
    public record AlbumInfo(
        [JsonProperty("artist")]
        string? Artist,
        [JsonProperty("album_release_date")]
        string? ReleaseDate,
        [JsonProperty("trackinfo")]
        Trackinfo[]? TrackInfo);
}
