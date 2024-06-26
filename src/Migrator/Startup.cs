using FluentMigrator.Runner;
using FluentMigrator.Runner.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Migrator.Migrations;

namespace Migrator;

public sealed class MigratorStartup
{
    public static IServiceProvider Setup()
    {
        var config = CreateConfiguration();
        var services = new ServiceCollection();

        ConfigureServices(services, config);

        IServiceProvider provider = services.BuildServiceProvider();
        return provider;
    }

    private static IConfiguration CreateConfiguration()
    {
        var currentDirectory = Directory.GetCurrentDirectory();

        var config = new ConfigurationBuilder()
            .SetBasePath(currentDirectory)
            .AddEnvironmentVariables()
            .Build();

        return config;
    }

    private static void ConfigureServices(IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("Postgres");

        services
            .AddSingleton<IConventionSet>(new DefaultConventionSet("engluango", null))
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddPostgres()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(typeof(AddFileTable).Assembly).For.Migrations())
            .AddLogging(lb =>
            {
                lb.AddConfiguration(config);
                lb.AddFluentMigratorConsole();
            });
    }
}