using System;
using FluentMigrator;

namespace Geshotel.Migrations.DefaultDB
{
    [Migration(20170326224500)]
    public class DefaultDB_20170326_224500_Guests : Migration
    {
        public override void Up()
        {
            Alter.Table("huespedes")
                .AddColumn("user_id").AsInt32().Nullable()
                .ForeignKey("FK_guest_users", "users", "UserId")
                .AddColumn("fecha_modificacion").AsDateTime().Nullable();


            Alter.Table("reservas_huespedes")
                .AlterColumn("habitacion_id").AsInt16().Nullable()
                .ForeignKey("FK_habitaciones", "habitaciones", "habitacion_id");
        }

        public override void Down()
        {
        }

    }
}