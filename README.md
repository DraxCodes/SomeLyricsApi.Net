# SomeLyricsApi.Net
SomeLyricsApi.Net a .Net standard wrapper for the Some-Random-Api Lyrics Wrapper.

This is just a random project for Day 4 of our Discords challenge series.

## How to setup.

```cs
//You can choose to either use DI via the extension method provided or simply new up a static SomeLyricsClient
//Using a static client would be like, Please note that this is the intended use of the wrapper but it should work fine.
public static SomeLyricsClient lyricsClient = new SomeLyricsClient();

//The correct way to use this wrapper is with a Dependency Injection setup. I provide an extension method via for Microsofts Dependency Injection.
//You can use that like so... (Note in this example I am making the setup of the DI container I static method to call at the start of my program)
public static class Container
{
  public static IServiceProvider SetupServiceProvider()
    => new ServiceCollection()
          .UseSomeLyricsApi()
          .BuildServiceProvider();
}

//The other way would be to simply add the Interface and Concrete client to your DI container. Like so...
public static class Container
{
  public static IServiceProvider SetupServiceProvider()
    => new ServiceCollection()
          .AddSingleton<ISomeLyricsClient, SomeLyricsClient>()
          .BuildServiceProvider();
}
```

## How to use

Currently the only method of getting lyrics is the base lyrics getter method. You can use it like so:

```cs
//With a static client
var search = await lyricsClient.GetBaseLyricsAsync("Search Here");
//Do something with the search like..
Console.WriteLine(search.Lyrics);
```

Using it with DI, you would ideally use constructor injection like so...

```cs
public class LyricsService
{
  private readonly ISomeLyricsClient _client;
  
  public LyricsService(ISomeLyricsClient client)
  {
    _client = client;
  }
  
  public async Task<string> GetLyrics(string search)
  {
    var result = await _client.GetLyricsAsync(search);
    return results.Lyrics;
  }
}
```

## Unit Tests

The Majority of the code is unit tested [Here](https://github.com/DraxCodes/SomeLyricsApi.Net/blob/master/SomeLyricsApiNet.Tests/ClientTests.cs)

Please note that it will throw WebExceptions on bad search results as shown here..

```cs
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
```

This means you can handle the exception as you see fit.

