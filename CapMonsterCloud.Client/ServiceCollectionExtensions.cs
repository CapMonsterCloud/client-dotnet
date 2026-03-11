using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Zennolab.CapMonsterCloud;

/// <summary>
/// Extension methods for registering CapMonsterCloud services with dependency injection.
/// </summary>
public static class ServiceCollectionExtensions
{
    private static readonly TimeSpan HttpTimeout = TimeSpan.FromSeconds(21);

    /// <summary>
    /// Registers <see cref="ICapMonsterCloudClient"/> with the DI container using <c>IHttpClientFactory</c>.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configure">Action to configure <see cref="ClientOptions"/>.</param>
    /// <returns>An <see cref="IHttpClientBuilder"/> for further HTTP client configuration.</returns>
    public static IHttpClientBuilder AddCapMonsterCloud(
        this IServiceCollection services,
        Action<ClientOptions> configure)
    {
        var options = new ClientOptions();
        configure(options);
        services.AddSingleton(options);

        return services.AddHttpClient<ICapMonsterCloudClient, CapMonsterCloudClient>(client =>
        {
            client.BaseAddress = options.ServiceUri;
            client.Timeout = HttpTimeout;
            var asm = typeof(CapMonsterCloudClient).Assembly.GetName();
            client.DefaultRequestHeaders.UserAgent.TryParseAdd($"{asm.Name}/{asm.Version}");
        });
    }
}
