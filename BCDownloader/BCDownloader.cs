using BCDownloader.Models;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace BCDownloader
{
    public class BCDownloader (HttpClient client)
    {
        private readonly HttpClient _client = client;

        public async Task<AlbumInfo?> GetAlbumInfoAsync(string url)
        {
            var document = await GetDocumentAsync(url);
            var albumInfo = GetAlbumInfo(document);
            albumInfo.CoverData = await GetCoverData(document);

            if (albumInfo?.TrackInfo is not null)
            {
                var trackInfo = albumInfo.TrackInfo.ToList();
                albumInfo.TrackInfo.Clear();

                await Parallel.ForEachAsync(trackInfo, async (trackInfo, ct) =>
                {
                    if (trackInfo.File?.DownloadPath is not null)
                    {
                        var response = await _client.GetAsync(trackInfo.File.DownloadPath);
                        trackInfo.Artist ??= albumInfo.Artist;
                        trackInfo.Data = await response.Content.ReadAsByteArrayAsync();
                        albumInfo.TrackInfo.Add(trackInfo);
                    }
                });

                return albumInfo;
            }

            return null;
        }

        private async Task<byte[]> GetCoverData(string document)
        {            
            var doc = new HtmlDocument();
            doc.LoadHtml(document);
            var url = doc.DocumentNode.SelectSingleNode("//*[@id=\"tralbumArt\"]/a/img").GetAttributeValue("src", "");
            
            var response = await _client.GetAsync(url);

            return await response.Content.ReadAsByteArrayAsync();
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
