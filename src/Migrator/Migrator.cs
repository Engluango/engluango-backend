using System;
using System.IO;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Migrator;

public class Handler
{
    public string FunctionHandler(byte[] a) 
    {
        var serviceProvider = MigratorStartup.Setup();
        var migrationRunner = serviceProvider.GetRequiredService<IMigrationRunner>();

        migrationRunner.MigrateUp();

        return "Successful migration";
    }
}