using FluentMigrator;

namespace Migrator.Migrations;

[TimestampedMigration(2023, 9, 17, 16 ,8)]
public sealed class AddFileTable : ForwardOnlyMigration 
{
    public override void Up()
    {
        Create.Table("File")
            .WithColumn("Id").AsGuid().WithDefault(SystemMethods.NewGuid).PrimaryKey()
            .WithColumn("VirtualName").AsString(75).NotNullable()
            .WithColumn("Path").AsString(300).NotNullable()
            .WithColumn("AccessToken").AsString(50).Nullable().Indexed()
            .WithColumn("ToDelete").AsBoolean().NotNullable().Indexed();
    }
}