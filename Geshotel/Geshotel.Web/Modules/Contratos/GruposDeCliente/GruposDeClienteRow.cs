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

    [ConnectionKey("Geshotel"), DisplayName("grupos_de_cliente"), InstanceName("grupos_de_cliente"), TwoLevelCached]
    [ReadPermission("Contratos:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Contratos.GruposDeCliente")]
    public sealed class GruposDeClienteRow : Row, IIdRow, INameRow
    {
        [DisplayName("Grupo Cliente Id"), Column("grupo_cliente_id"), Identity]
        public Int16? GrupoClienteId
        {
            get { return Fields.GrupoClienteId[this]; }
            set { Fields.GrupoClienteId[this] = value; }
        }

        [DisplayName("Nombre Grupo"), Column("nombre_grupo"), Size(30), NotNull, QuickSearch]
        public String NombreGrupo
        {
            get { return Fields.NombreGrupo[this]; }
            set { Fields.NombreGrupo[this] = value; }
        }


        [DisplayName("Huesped"), Column("huesped"), NotNull]
        public Boolean? Huesped
        {
            get { return Fields.Huesped[this]; }
            set { Fields.Huesped[this] = value; }
        }

        [DisplayName("Contratos"), Column("contratos"), NotNull]
        public Boolean? Contratos
        {
            get { return Fields.Contratos[this]; }
            set { Fields.Contratos[this] = value; }
        }

        [DisplayName("Facturar"), Column("facturar"), NotNull]
        public Boolean? Facturar
        {
            get { return Fields.Facturar[this]; }
            set { Fields.Facturar[this] = value; }
        }

        [DisplayName("Agencia"), Column("agencia"), NotNull]
        public Boolean? Agencia
        {
            get { return Fields.Agencia[this]; }
            set { Fields.Agencia[this] = value; }
        }

        [DisplayName("Perfil"), Column("perfil")]
        public Int16? Perfil
        {
            get { return Fields.Perfil[this]; }
            set { Fields.Perfil[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.GrupoClienteId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.NombreGrupo; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public GruposDeClienteRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field GrupoClienteId;
            public StringField NombreGrupo;
            public BooleanField Huesped;
            public BooleanField Contratos;
            public BooleanField Facturar;
            public BooleanField Agencia;
            public Int16Field Perfil;

            public RowFields()
                : base("grupos_de_cliente")
            {
                LocalTextPrefix = "Contratos.GruposDeCliente";
            }
        }
    }
}
