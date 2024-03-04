using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCDownloader.Models
{
    public class File
    {
        [JsonProperty("mp3-128")]
        public string? downloadPath { get; set; }
    }
}
