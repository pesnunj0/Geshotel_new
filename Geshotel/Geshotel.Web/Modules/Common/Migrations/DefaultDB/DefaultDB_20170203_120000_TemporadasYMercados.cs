using System;
using FluentMigrator;

namespace Geshotel.Migrations.DefaultDB
{
    [Migration(20170203120000)]
    public class DefaultDB_20170203_120000_TemporadasYMercados : Migration
    {
        public override void Up()
        {

            Create.Table("temporadas")
                .WithColumn("temporada_id").AsInt16().NotNullable().PrimaryKey()
                .WithColumn("temporada").AsString(25).NotNullable()
                .WithColumn("empresa_id").AsInt16().NotNullable().PrimaryKey()
                .ForeignKey("FK_temporadas_empresa_empresa_id", "empresas", "empresa_id")
                .WithColumn("ano").AsInt16().Nullable()
                .WithColumn("fecha_desde").AsDate()
                .WithColumn("fecha_hasta").AsDate();

            Create.Table("mercados")
                .WithColumn("mercado_id").AsInt16().NotNullable().PrimaryKey()
                .WithColumn("mercado").AsString(25)
                .WithColumn("empresa_id").AsInt16().NotNullable().PrimaryKey()
                .ForeignKey("FK_mercados_empresa_empresa_id", "empresas", "empresa_id");
          }
        public override void Down()
        {
        }

    }
}