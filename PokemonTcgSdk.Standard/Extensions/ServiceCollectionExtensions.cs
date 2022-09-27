namespace PokemonTcgSdk.Standard.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public static class ServiceCollectionExtensions
    {
        public static void AddPokemonSdk(this IServiceCollection services, Action<ServicesProjectOptions> configureOptions)
        {
            services.AddOptions<ServicesProjectOptions>()
                .Configure(configureOptions)
                .Validate(config =>
                {
                    if (string.IsNullOrEmpty(config.ApiKey))
                        return false;
                    return true;
                }, "Api Key Must be defined when registering pokemon sdk in startup");
           // services.AddScoped<IPokemonApiClient, PokemonApiClient>();
        }
    }
}