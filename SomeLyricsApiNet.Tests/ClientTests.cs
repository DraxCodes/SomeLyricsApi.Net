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

        [Theory]
        [InlineData("Feel it still")]
        [InlineData("We will rock you")]
        public async Task Client_GetBaseLyrics_UrlShouldNotBeNull(string search)
        {
            var client = new SomeLyricsClient();
            var result = await client.GetBaseLyrics(search);
            Assert.NotNull(result.Links.GeniusUrl);
        }

        [Theory]
        [InlineData("Feel it still")]
        [InlineData("We will rock you")]
        public async Task Client_GetBaseLyrics_ImageUrlShouldNotBeNull(string search)
        {
            var client = new SomeLyricsClient();
            var result = await client.GetBaseLyrics(search);
            Assert.NotNull(result.Thumbnail.Url);
        }

        [Theory]
        [InlineData("Feel it still")]
        [InlineData("We will rock you")]
        public async Task Client_GetBaseLyrics_TitleShouldNotBeNull(string search)
        {
            var client = new SomeLyricsClient();
            var result = await client.GetBaseLyrics(search);
            Assert.NotNull(result.Title);
        }

        [Theory]
        [InlineData("Feel it still")]
        [InlineData("We will rock you")]
        public async Task Client_GetBaseLyrics_AuthorShouldNotBeNull(string search)
        {
            var client = new SomeLyricsClient();
            var result = await client.GetBaseLyrics(search);
            Assert.NotNull(result.Author);
        }

        [Fact]
        public async Task Client_GetBaseLyrics_LyricsShouldReturnString()
        {
            var search = "We will rock you";
            var expected = "[Verse 1]\nBuddy, you're a boy, make a big noise\nPlaying in the street, gonna be a big man someday\nYou got mud on your face, you big disgrace\nKicking your can all over the place, singing\n\n[Chorus]\nWe will, we will rock you\nWe will, we will rock you\n\n[Verse 2]\nBuddy, you're a young man, hard man\nShouting in the street, gonna take on the world someday\nYou got blood on your face, you big disgrace\nWaving your banner all over the place\n\n[Chorus]\nWe will, we will rock you\nSing it out\nWe will, we will rock you\n\n[Verse 3]\nBuddy, you're an old man, poor man\nPleading with your eyes, gonna make you some peace someday\nYou got mud on your face, big disgrace\nSomebody better put you back into your place\n\n[Chorus]\nWe will, we will rock you, sing it\nWe will, we will rock you, everybody\nWe will, we will rock you, hmm\nWe will, we will rock you, alright\n\n[Guitar Solo]";
            var client = new SomeLyricsClient();
            var result = await client.GetBaseLyrics(search);

            Assert.Equal(expected, result.Lyrics);
        }
    }
}
