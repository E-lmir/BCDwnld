using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BCDownloader.Models
{
    public class AlbumInfo
    {
        public long art_id { get; set; }
        public Package[] packages { get; set; }
        public string artist { get; set; }
        public Play_Cap_Data play_cap_data { get; set; }
        public string album_release_date { get; set; }
        [JsonProperty("trackinfo")]
        public Trackinfo[] TrackInfo { get; set; }
    }

    public class Play_Cap_Data
    {
        public bool streaming_limits_enabled { get; set; }
        public long streaming_limit { get; set; }
    }

    public class Package
    {
        public long id { get; set; }
        public string url { get; set; }
        public string url_for_app { get; set; }
        public long type_id { get; set; }
        public string type_name { get; set; }
        public string title { get; set; }
        public object description { get; set; }
        public object desc_pt1 { get; set; }
        public object desc_pt2 { get; set; }
        public long new_desc_format { get; set; }
        public long grid_index { get; set; }
        public object _private { get; set; }
        public object subscriber_only { get; set; }
        public float price { get; set; }
        public object is_set_price { get; set; }
        public object is_live_ticket { get; set; }
        public object live_event_over { get; set; }
        public object live_event_id { get; set; }
        public object live_event_title { get; set; }
        public object live_event_url { get; set; }
        public object live_event_gcal_url { get; set; }
        public object live_event_ical_url { get; set; }
        public object live_event_replays_enabled { get; set; }
        public object live_event_image_color_one { get; set; }
        public object live_event_image_color_two { get; set; }
        public string sku { get; set; }
        public object upc { get; set; }
        public long band_id { get; set; }
        public long selling_band_id { get; set; }
        public string label { get; set; }
        public string currency { get; set; }
        public object country { get; set; }
        public object tax_rate { get; set; }
        public object options_title { get; set; }
        public object options { get; set; }
        public Origin[] origins { get; set; }
        public Art[] arts { get; set; }
        public object album_art { get; set; }
        public long album_art_id { get; set; }
        public object shipping_exception_mode { get; set; }
        public string download_type { get; set; }
        public long download_id { get; set; }
        public object download_is_preorder { get; set; }
        public string download_release_date { get; set; }
        public string download_title { get; set; }
        public string download_url { get; set; }
        public bool download_has_audio { get; set; }
        public long download_track_count { get; set; }
        public long download_art_id { get; set; }
        public string download_artist { get; set; }
        public long fulfillment_days { get; set; }
        public object release_date { get; set; }
        public string new_date { get; set; }
        public object edition_size { get; set; }
        public object quantity_sold { get; set; }
        public long quantity_available { get; set; }
        public long quantity_limits { get; set; }
        public bool quantity_warning { get; set; }
        public long album_id { get; set; }
        public string album_title { get; set; }
        public object album_artist { get; set; }
        public object album_private { get; set; }
        public string album_publish_date { get; set; }
        public string album_release_date { get; set; }
        public bool subscriber_only_published { get; set; }
        public object featured_date { get; set; }
        public long certified_seller { get; set; }
        public bool limited_checkout { get; set; }
        public object associated_license_id { get; set; }
        public object live_event_scheduled_start_date { get; set; }
        public object live_event_scheduled_end_date { get; set; }
        public object live_event_start_date { get; set; }
        public object live_event_end_date { get; set; }
        public object live_event_timezone { get; set; }
        public object live_event_type { get; set; }
        public object listening_party_duration { get; set; }
        public bool is_cardable { get; set; }
    }

    public class Origin
    {
        public long id { get; set; }
        public object quantity { get; set; }
        public object quantity_sold { get; set; }
        public long quantity_available { get; set; }
        public long package_id { get; set; }
        public long option_id { get; set; }
    }

    public class Art
    {
        public long id { get; set; }
        public string file_name { get; set; }
        public long index { get; set; }
        public long image_id { get; set; }
        public long width { get; set; }
        public long height { get; set; }
        public long crc { get; set; }
    }

    public class Trackinfo
    {
        [JsonProperty("file")]
        public File File { get; set; }
        public object artist { get; set; }
        public string title { get; set; }
        public bool unreleased_track { get; set; }
        public string title_link { get; set; }
        public bool has_lyrics { get; set; }
        public float duration { get; set; }
        public object lyrics { get; set; }
        public long sizeof_lyrics { get; set; }
        public object video_source_type { get; set; }
        public object video_source_id { get; set; }
        public object video_mobile_url { get; set; }
        public object video_poster_url { get; set; }
        public object video_id { get; set; }
        public object video_caption { get; set; }
        public object video_featured { get; set; }
        public object alt_link { get; set; }
    }

    public class File
    {
        [JsonProperty("mp3-128")]
        public string downloadPath { get; set; }
    }
}
