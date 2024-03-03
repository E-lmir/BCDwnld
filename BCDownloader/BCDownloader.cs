using BCDownloader.Models;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace BCDownloader
{
    ////*[@class="track-title"]
    public static class BCDownloader
    {
        public static HttpClient client = new();
        public static async Task<string> GetDocumentAsync(string url)
        {
            var response = await client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
        public static IEnumerable<string> GetTrackList(string document)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(document);
            var track = doc.DocumentNode.SelectNodes("//*[@class=\"track-title\"]").Select(x => x.GetDirectInnerText()).ToList();
            return track;
        }

        public static async Task<AlbumInfo?> GetAlbumInfoAsync(string document)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(document);
            var albumInfo = await Task.Run(() => JsonConvert.DeserializeObject<AlbumInfo>(doc.DocumentNode
                .SelectNodes("//script")
                .Where(x => x.Attributes.Contains("data-tralbum"))
                .FirstOrDefault()
                ?.GetAttributeValue("data-tralbum", "1")
                .Replace("&quot;", "\"") ?? string.Empty));

            return albumInfo;
        }

        public static async Task<byte[]> GetFileDataAsync(string url)
        {
            var response = await client.GetAsync(url);
            return await response.Content.ReadAsByteArrayAsync();
        }

        public static async Task GetFileAsync(string url)
        {
            var albumInfo = await GetAlbumInfoAsync(url);
            foreach (var trackInfo in albumInfo?.TrackInfo)
            {

            }
        }
    }
}
