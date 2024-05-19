using FluentMigrator;

namespace Migrator.Migrations;

[TimestampedMigration(2023, 9, 17, 16 ,8)]
public sealed class AddFileTable : ForwardOnlyMigration 
{
    private const string CreateExtension = @"
        SET search_path to engluango;
        CREATE EXTENSION IF NOT EXISTS ""uuid-ossp"";";
    
    public override void Up()
    {
        Execute.Sql(CreateExtension);
    }
}