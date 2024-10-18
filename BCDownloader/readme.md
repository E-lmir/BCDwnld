## Allow download albums and tracks from [BandCamp](https://bandcamp.com/).
## Usage:
~~~
var client = new HttpClient();
var downloader = new BCDownloader(client);
var album = await downloader.GetTracksInfoAsync("https://nirvana.bandcamp.com/album/bleach");
if (album is not null)
{
  foreach (var track in album.TrackInfo)
  {
    var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), track.Title+".mp3");
    System.IO.File.WriteAllBytes(path, track.Data);
  }
}
~~~
