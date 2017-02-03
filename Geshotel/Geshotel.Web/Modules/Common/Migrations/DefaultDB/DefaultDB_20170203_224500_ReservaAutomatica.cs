using System;
using FluentMigrator;

namespace Geshotel.Migrations.DefaultDB
{
    [Migration(20170203224500)]
    public class DefaultDB_20170203_224500_ReservaAutomatica : Migration
    {
        public override void Up()
        {
            Alter.Table("cupos")
                .AlterColumn("reserva_automatica").AsBoolean().NotNullable();
        }

        public override void Down()
        {
        }

    }
}