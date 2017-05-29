using System;
using FluentMigrator;
// ************************************************************************************************
// Añadir el campo ficheros a Reservas y contratos
// Añadir el fichero GalleryImages a Huespedes
// ************************************************************************************************
namespace Geshotel.Migrations.DefaultDB
{
    [Migration(20170528224500)]
    public class DefaultDB_20170528_224500_PreviewServicios : Migration
    { 
        public override void Up()
        {
            Alter.Table("Huespedes")
               .AddColumn("GalleryImages").AsString(int.MaxValue).Nullable();
            Alter.Table("Contratos")
               .AddColumn("ficheros").AsString(int.MaxValue).Nullable();
            Alter.Table("Reservas")
               .AddColumn("ficheros").AsString(int.MaxValue).Nullable();
        }
        public override void Down()
        {
        }

    }
}