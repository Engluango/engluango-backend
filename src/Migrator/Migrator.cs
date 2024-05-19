using System;
using System.IO;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Migrator;

public class Handler
{
    public string FunctionHandler(byte[] a) 
    {
        var serviceProvider = MigratorStartup.Setup();
        var migrationRunner = serviceProvider.GetRequiredService<IMigrationRunner>();

        Console.WriteLine("DEBUG");
        migrationRunner.MigrateUp();

        return "Successful migration";
    }
}