using BCDownloader.Models;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System.Collections.Concurrent;

namespace BCDownloader
{
    public class BCDownloader
    {
        private static HttpClient _client = new();

        public async Task<IEnumerable<Trackinfo>?> GetTracksInfoAsync(string url)
        {
            var document = await GetDocumentAsync(url);
            var albumInfo = GetAlbumInfo(document);

            if (albumInfo?.TrackInfo is not null)
            {
                var data = new ConcurrentBag<Trackinfo>();

                await Parallel.ForEachAsync(albumInfo.TrackInfo.ToList(), async (trackInfo, ct) =>
                {
                    if (trackInfo.File?.DownloadPath is not null)
                    {
                        var response = await _client.GetAsync(trackInfo.File.DownloadPath);
                        trackInfo.Artist ??= albumInfo.Artist;
                        trackInfo.Data = await response.Content.ReadAsByteArrayAsync();
                        data.Add(trackInfo);
                    }
                });

                return data;
            }

            return null;
        }

        private async Task<string> GetDocumentAsync(string url)
        {
            var response = await _client.GetAsync(url);

            return await response.Content.ReadAsStringAsync();
        }

        private AlbumInfo? GetAlbumInfo(string document)
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
    }
}
