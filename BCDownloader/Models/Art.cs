using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCDownloader.Models
{
    public class Art
    {
        public long id { get; set; }
        public string? file_name { get; set; }
        public long index { get; set; }
        public long image_id { get; set; }
        public long width { get; set; }
        public long height { get; set; }
        public long crc { get; set; }
    }
}
