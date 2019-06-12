using Newtonsoft.Json;

namespace SomeLyricsApiNet.Models
{
    public class Lyric
    {
        [JsonProperty("title")] public string Title { get; set; }
        [JsonProperty("author")] public string Author { get; set; }
        [JsonProperty("lyrics")] public string Lyrics { get; set; }
        [JsonProperty("thumbnail")] public Thumbnail Thumbnail { get; set; }
        [JsonProperty("links")] public Links Links { get; set; }
    }

    public class Thumbnail
    {
        [JsonProperty("genius")] public string Url { get; set; }
    }

    public class Links
    {
        [JsonProperty("genius")] public string GeniusUrl { get; set; }
    }

}
