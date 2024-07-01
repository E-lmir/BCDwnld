using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCDownloader.Models
{
    public class Trackinfo
    {
        [JsonProperty("file")]
        public File? File { get; set; }
        public byte[]? Data { get; set; }
        [JsonProperty("artist")]
        public string? Artist { get; set; }
        [JsonProperty("title")]
        public string? Title { get; set; }
        [JsonProperty("title_link")]
        public string? TitleLink { get; set; }
    }
}
