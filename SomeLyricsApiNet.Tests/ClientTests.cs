using System;
using System.Threading.Tasks;
using SomeLyricsApiNet.Models;
using Xunit;

namespace SomeLyricsApiNet.Tests
{
    public class ClientTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("blah blah blah")]
        [InlineData("Can't possibly be a song!")]
        public void Client_GetBaseLyricsAsync_ThrowExceptionOnBadSearch(string search)
        {
            var client = new SomeLyricsClient();
            var ex = Record.ExceptionAsync(async () => await client.GetBaseLyrics(search));
            Assert.NotNull(ex);
        }

        [Theory]
        [InlineData("Feel it still")]
        [InlineData("We will rock you")]
        public async Task Client_GetBaseLyricsAsync_ShouldReturnLyricModelOnSuccess(string search)
        {
            var client = new SomeLyricsClient();
            var result = await client.GetBaseLyrics(search);
            Assert.IsType<Lyric>(result);
        }

        [Theory]
        [InlineData("Feel it still")]
        [InlineData("We will rock you")]
        public async Task Client_GetBaseLyrics_LyricsShouldNotBeNull(string search)
        {
            var client = new SomeLyricsClient();
            var result = await client.GetBaseLyrics(search);
            Assert.NotNull(result.Lyrics);
        }
    }
}
