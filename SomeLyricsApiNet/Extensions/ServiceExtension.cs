using Microsoft.Extensions.DependencyInjection;
using SomeLyricsApiNet.Abstractions;

namespace SomeLyricsApiNet.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection UseSomeLyricsApi(this IServiceCollection services)
        {
            services.AddSingleton<ISomeLyricsClient, SomeLyricsClient>();
            return services;
        }
    }
}
