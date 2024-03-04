using BCDownloader.Models;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System.Collections.Concurrent;

namespace BCDownloader
{
    public class BCDownloader
    {
        public static HttpClient client = new();

        public static async Task<IEnumerable<Trackinfo>> GetTracksAsync(string url)
        {
            var document = await GetDocumentAsync(url);
            var albumInfo = GetAlbumInfo(document);

            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = 1000,
                CancellationToken = default
            };

            if (albumInfo?.TrackInfo != null)
            {
                var data = new ConcurrentBag<Trackinfo>();

                await Parallel.ForEachAsync(albumInfo.TrackInfo.ToList(), options, async (trackInfo, ct) =>
                {
                    var response = await client.GetAsync(trackInfo.File?.downloadPath);
                    trackInfo.Data = await response.Content.ReadAsByteArrayAsync();
                    data.Add(trackInfo);
                });

                return data;
            }

            return null;
        }

        private static async Task<string> GetDocumentAsync(string url)
        {
            var response = await client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        public static IEnumerable<string> GetTrackList(string document)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(document);
            var track = doc.DocumentNode.SelectNodes("//*[@class=\"track-title\"]").Select(x => x.GetDirectInnerText());
            return track;
        }

        private static AlbumInfo? GetAlbumInfo(string document)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(document);
            var albumInfo = JsonConvert.DeserializeObject<AlbumInfo>(doc.DocumentNode
                .SelectNodes("//script")
                .Where(x => x.Attributes.Contains("data-tralbum"))
                .FirstOrDefault()
                ?.GetAttributeValue("data-tralbum", "1")
                .Replace("&quot;", "\"") ?? string.Empty);

            return albumInfo;
        }

        public static async Task<byte[]> GetFileDataAsync(string url)
        {
            var response = await client.GetAsync(url);
            return await response.Content.ReadAsByteArrayAsync();
        }

        public static async Task<byte[]> GetFileAsync(Trackinfo info)
        {
            var response = await client.GetAsync(info.File.downloadPath);
            return await response.Content.ReadAsByteArrayAsync();
        }
    }
}
