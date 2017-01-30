using System;
using FluentMigrator;

namespace Geshotel.Migrations.DefaultDB
{
    [Migration(20170130120000)]
    public class DefaultDB_20170130_120000_Contratos : Migration
    {
        public override void Up()
        {

            Create.Table("formas_pago_empresa")
                .WithColumn("forma_pago_id").AsInt16().NotNullable().PrimaryKey()
                .ForeignKey("FK_formas_pago_empresa_foma_pago_id", "formas_de_pago", "forma_pago_id")
                .WithColumn("empresa_id").AsInt16().NotNullable().PrimaryKey()
                .ForeignKey("FK_formas_pago_empresa_empresa_id", "empresas", "empresa_id")
                .WithColumn("cta_contable").AsString(15).Nullable()
                .WithColumn("dpto_contable").AsString(5).Nullable();

            Create.Table("formas_pago_hotel")
                .WithColumn("forma_pago_id").AsInt16().NotNullable().PrimaryKey()
                .ForeignKey("FK_formas_pago_hotel_foma_pago_id", "formas_de_pago", "forma_pago_id")
                .WithColumn("hotel_id").AsInt16().NotNullable().PrimaryKey()
                .ForeignKey("FK_formas_pago_hotel_hotel_id", "hoteles", "hotel_id")
                .WithColumn("cta_contable").AsString(15).Nullable()
                .WithColumn("dpto_contable").AsString(5).Nullable();

            Create.Table("ficheros_contratos")
                .WithColumn("fichero_id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("contrato_id").AsInt32().NotNullable()
                .ForeignKey("FK_ficheros_contratos_contrato_id", "contratos", "contrato_id")
                .WithColumn("titulo").AsString(100).NotNullable()
                .WithColumn("url").AsString(255).NotNullable()
                .WithColumn("user_id").AsInt16()
                .WithColumn("fecha_modificacion").AsDateTime();

            Create.Table("releases")
                .WithColumn("release_id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("cliente_id").AsInt32().NotNullable()
                .ForeignKey("FK_releases_cliente_id", "clientes", "cliente_id")
                .WithColumn("hotel_id").AsInt16().NotNullable()
                .ForeignKey("FK_releases_hotel_id", "hoteles", "hotel_id")
                .WithColumn("fecha_desde").AsDate().NotNullable()
                .WithColumn("fecha_hasta").AsDate().NotNullable()
                .WithColumn("observaciones").AsString(100).Nullable()
                .WithColumn("dias").AsInt16().Nullable()
                .WithColumn("user_id").AsInt16().Nullable()
                .WithColumn("fecha_modificacion").AsDate().Nullable();
        }
        public override void Down()
        {
        }

    }
}