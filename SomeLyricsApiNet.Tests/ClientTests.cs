using System;
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
        public void Client_GetBaseLyricsAsync_ThrowExceptionOnBadSearch(string url)
        {
            var client = new SomeLyricsClient();
            var ex = Record.ExceptionAsync(async () => await client.GetBaseLyrics(url));
            Assert.NotNull(ex);
        }
    }
}
