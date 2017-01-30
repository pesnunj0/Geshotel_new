using FluentMigrator;
using FluentMigrator.Builders.Create.Table;
using System;

namespace Geshotel.Migrations.DefaultDB
{

    [Migration(20141103140000)]
    public class DefaultDB_20141103_140000_Initial : AutoReversingMigration
    {
        public override void Up()
        {
            IfDatabase("MySql")
                .Execute.EmbeddedScript("Geshotel.Modules.Common.Migrations.CommonFilesDB.CommonFilesDB_Initial_Script_MySql.sql");
            IfDatabase("SqlServer", "SqlServer2000", "SqlServerCe")
                .Execute.EmbeddedScript("Geshotel.Modules.Common.Migrations.CommonFilesDB.CommonFilesDB_Initial_Script_SQL_Server.sql");
            IfDatabase("Postgres")
                .Execute.EmbeddedScript("Geshotel.Modules.Common.Migrations.CommonFilesDB.CommonFilesDB_Initial_Script_PostgreSQL.sql");

            this.CreateTableWithId32("Users", "UserId", s => s
                .WithColumn("Username").AsString(100).NotNullable()
                .WithColumn("DisplayName").AsString(100).NotNullable()
                .WithColumn("Email").AsString(100).Nullable()
                .WithColumn("Source").AsString(4).NotNullable()
                .WithColumn("PasswordHash").AsString(86).NotNullable()
                .WithColumn("PasswordSalt").AsString(10).NotNullable()
                .WithColumn("LastDirectoryUpdate").AsDateTime().Nullable()
                .WithColumn("UserImage").AsString(100).Nullable()
                .WithColumn("InsertDate").AsDateTime().NotNullable()
                .WithColumn("InsertUserId").AsInt32().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("IsActive").AsInt16().NotNullable().WithDefaultValue(1));

            Insert.IntoTable("Users").Row(new
            {
                Username = "admin",
                DisplayName = "admin",
                Email = "admin@geshotel.com",
                Source = "site",
                PasswordHash = "rfqpSPYs0ekFlPyvIRTXsdhE/qrTHFF+kKsAUla7pFkXL4BgLGlTe89GDX5DBysenMDj8AqbIZPybqvusyCjwQ",
                PasswordSalt = "hJf_F",
                InsertDate = new DateTime(2014, 1, 1),
                InsertUserId = 1,
                IsActive = 1
            });

            this.CreateTableWithId32("Languages", "Id", s => s
                .WithColumn("LanguageId").AsString(10).NotNullable()
                .WithColumn("LanguageName").AsString(50).NotNullable());

            Insert.IntoTable("Languages").Row(new
            {
                LanguageId = "es",
                LanguageName = "Spanish"
            });

            Insert.IntoTable("Languages").Row(new
            {
                LanguageId = "en",
                LanguageName = "English"
            });

            Insert.IntoTable("Languages").Row(new
            {
                LanguageId = "fr",
                LanguageName = "Français"
            });

            Insert.IntoTable("Languages").Row(new
            {
                LanguageId = "de",
                LanguageName = "Deutsch"
            });

            Insert.IntoTable("Languages").Row(new
            {
                LanguageId = "nl",
                LanguageName = "Nederlands"
            });

            Insert.IntoTable("Languages").Row(new
            {
                LanguageId = "da",
                LanguageName = "Dansk"
            });

            Insert.IntoTable("Languages").Row(new
            {
                LanguageId = "pt",
                LanguageName = "Português"
            });

            Insert.IntoTable("Languages").Row(new
            {
                LanguageId = "sw",
                LanguageName = "Swenska"
            });

            Insert.IntoTable("Languages").Row(new
            {
                LanguageId = "it",
                LanguageName = "Italiano"
            });


            Insert.IntoTable("Languages").Row(new
            {
                LanguageId = "ru",
                LanguageName = "Russian"
            });
 

            Insert.IntoTable("Languages").Row(new
            {
                LanguageId = "zh-CN",
                LanguageName = "Chinese (Simplified)"
            });

            Insert.IntoTable("Languages").Row(new
            {
                LanguageId = "no",
                LanguageName = "Norsk"
            });

            Insert.IntoTable("Languages").Row(new
            {
                LanguageId = "fi",
                LanguageName = "Päät"
            });

            Insert.IntoTable("Languages").Row(new
            {
                LanguageId = "ro",
                LanguageName = "Românesc"
            });

            Insert.IntoTable("Languages").Row(new
            {
                LanguageId = "lb",
                LanguageName = "Lëtzebuerger"
            });

            Insert.IntoTable("Languages").Row(new
            {
                LanguageId = "el",
                LanguageName = "Greek"
            });

            Insert.IntoTable("Languages").Row(new
            {
                LanguageId = "po",
                LanguageName = "Polska"
            });

            Insert.IntoTable("Languages").Row(new
            {
                LanguageId = "ro",
                LanguageName = "Românesc"
            });

            Insert.IntoTable("Languages").Row(new
            {
                LanguageId = "jp",
                LanguageName = "Japanesse"
            });

        }
    }
}