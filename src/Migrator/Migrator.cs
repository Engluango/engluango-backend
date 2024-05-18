using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Migrator;

public class Handler
{
    public string FunctionHandler(byte[] a) 
    {
        var currentDirectory = Directory.GetCurrentDirectory();

        var config = new ConfigurationBuilder()
            .SetBasePath(currentDirectory)
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        return config["config"] ?? "empty";
    }
}