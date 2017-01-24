
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.GruposDeServicios")]
    [BasedOnRow(typeof(Entities.GruposDeServiciosRow))]
    public class GruposDeServiciosColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 GrupoServicioId { get; set; }
        [EditLink]
        public String NombreGrupo { get; set; }
        public String CtaContable { get; set; }
    }
}