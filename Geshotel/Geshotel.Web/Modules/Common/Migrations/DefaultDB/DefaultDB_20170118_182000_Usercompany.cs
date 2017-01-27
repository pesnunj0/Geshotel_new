using System;
using FluentMigrator;

namespace Geshotel.Migrations.DefaultDB
{
    [Migration(20170118182000)]
    public class DefaultDB_20170118_182000_Usercompany : Migration
    {
 
        public override void Up()
        {
            Alter.Table("users")
                .AddColumn("EmpresaId").AsInt16().Nullable()
                .AddColumn("HotelId").AsInt16().Nullable();
            // -------------------
            // Creamos el indice
            // --------------------
            Create.Index().OnTable("users").OnColumn("EmpresaId");
            Create.Index().OnTable("users").OnColumn("HotelId");
            Update.Table("Users").Set(new { EmpresaID = "1" }).AllRows();
            Update.Table("Users").Set(new { HotelID = "1" }).AllRows();
            // ------------------------------------
            // Creamos los Roles para el proyecto
            // ------------------------------------
            Insert.IntoTable("roles").Row(new
            {
                RoleName = "Recepcionista"
            });
            Insert.IntoTable("roles").Row(new
            {
                RoleName = "Jefe de Recepción"
            });
            Insert.IntoTable("roles").Row(new
            {
                RoleName = "Director de Hotel"
            });
            Insert.IntoTable("roles").Row(new
            {
                RoleName = "Administración y Central Reservas"
            });

            Insert.IntoTable("roles").Row(new
            {
                RoleName = "Admin"
            });

            //
            // Borramos la tabla Languages y la volvemos a crear para cargar los idiomas propios
            //
            Delete.Table("Languages");

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
        public override void Down()
        {
            
        }

    }
}