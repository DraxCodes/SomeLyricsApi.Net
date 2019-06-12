using System.Threading.Tasks;
using SomeLyricsApiNet.Models;

namespace SomeLyricsApiNet.Abstractions
{
    public interface ISomeLyricsClient
    {
        Task<Lyric> GetBaseLyricsAsync(string song);
    }
}