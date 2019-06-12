using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SomeLyricsApiNet.Abstractions;
using SomeLyricsApiNet.Models;

namespace SomeLyricsApiNet
{
    public class SomeLyricsClient : ISomeLyricsClient
    {
        public async Task<Lyric> GetBaseLyrics(string song)
        {
            try
            {
                var url = new Uri($"https://some-random-api.ml/lyrics?title={song}");
                using (var client = new WebClient())
                {
                    var baseJson = await client.DownloadStringTaskAsync(url);
                    return JsonConvert.DeserializeObject<Lyric>(baseJson);
                }
            }
            catch (WebException e)
            {
                throw new WebException("Song Not found. Sorry!", e.InnerException);
            }
        }
    }
}
