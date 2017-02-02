﻿
namespace Geshotel.Contratos.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;
    using Geshotel.Portal.Entities;

    [ConnectionKey("Default"), DisplayName("Contratos"), InstanceName("Contratos"), TwoLevelCached]
    [ReadPermission("Contratos:General")]
    [ModifyPermission("Contratos:General")]
    public sealed class ContratosRow : Row, IIdRow, INameRow
    {
        [DisplayName("Contrato Id"), Column("contrato_id"), Identity]
        public Int32? ContratoId
        {
            get { return Fields.ContratoId[this]; }
            set { Fields.ContratoId[this] = value; }
        }

        [DisplayName("Hotel"), Column("hotel_id"), NotNull, ForeignKey("hoteles", "hotel_id"), LeftJoin("jHotel"), TextualField("Hotel")]
        [LookupEditor(typeof(HotelesRow))]
        public Int16? HotelId
        {
            get { return Fields.HotelId[this]; }
            set { Fields.HotelId[this] = value; }
        }

        [DisplayName("Cliente"), Column("cliente_id"), NotNull, ForeignKey("clientes", "cliente_id"), LeftJoin("jCliente"), TextualField("Cliente")]
        [LookupEditor(typeof(ClientesRow))]
        public Int32? ClienteId
        {
            get { return Fields.ClienteId[this]; }
            set { Fields.ClienteId[this] = value; }
        }

        [DisplayName("Fecha Contrato"), Column("fecha_contrato"), NotNull]
        public DateTime? FechaContrato
        {
            get { return Fields.FechaContrato[this]; }
            set { Fields.FechaContrato[this] = value; }
        }

        [DisplayName("Fecha Desde"), Column("fecha_desde"), NotNull]
        public DateTime? FechaDesde
        {
            get { return Fields.FechaDesde[this]; }
            set { Fields.FechaDesde[this] = value; }
        }

        [DisplayName("Fecha Hasta"), Column("fecha_hasta"), NotNull]
        public DateTime? FechaHasta
        {
            get { return Fields.FechaHasta[this]; }
            set { Fields.FechaHasta[this] = value; }
        }

        [DisplayName("Numero Contrato TTOO"), Column("numero_contrato_cliente"), Size(40), QuickSearch]
        public String NumeroContratoCliente
        {
            get { return Fields.NumeroContratoCliente[this]; }
            set { Fields.NumeroContratoCliente[this] = value; }
        }

        [DisplayName("Usuario"), Column("user_id")]
        public Int16? UserId
        {
            get { return Fields.UserId[this]; }
            set { Fields.UserId[this] = value; }
        }

        [DisplayName("Fecha Modificacion"), Column("fecha_modificacion")]
        public DateTime? FechaModificacion
        {
            get { return Fields.FechaModificacion[this]; }
            set { Fields.FechaModificacion[this] = value; }
        }

        [DisplayName("Temporada"), Column("temporada_id")]
        public Int16? TemporadaId
        {
            get { return Fields.TemporadaId[this]; }
            set { Fields.TemporadaId[this] = value; }
        }

        [DisplayName("Impuesto Incluido"), Column("impuesto_incluido")]
        public Boolean? ImpuestoIncluido
        {
            get { return Fields.ImpuestoIncluido[this]; }
            set { Fields.ImpuestoIncluido[this] = value; }
        }

        [DisplayName("Mercado"), Column("mercado_id")]
        public Int16? MercadoId
        {
            get { return Fields.MercadoId[this]; }
            set { Fields.MercadoId[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.ContratoId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.NumeroContratoCliente; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public ContratosRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field ContratoId;
            public Int16Field HotelId;
            public Int32Field ClienteId;
            public DateTimeField FechaContrato;
            public DateTimeField FechaDesde;
            public DateTimeField FechaHasta;
            public StringField NumeroContratoCliente;
            public Int16Field UserId;
            public DateTimeField FechaModificacion;
            public Int16Field TemporadaId;
            public BooleanField ImpuestoIncluido;
            public Int16Field MercadoId;


            public RowFields()
                : base("[dbo].[contratos]")
            {
                LocalTextPrefix = "Contratos.Contratos";
            }
        }
    }
}
