
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.Servicios")]
    [BasedOnRow(typeof(Entities.ServiciosRow))]
    public class ServiciosColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 ServicioId { get; set; }
        [EditLink,Width(150)]
        public String NombreServicio { get; set; }
        [Width(100)]
        public String Abreviatura { get; set; }
        [Width(100)]
        public String TipoServicioNombreTipoServicio { get; set; }
        [Width(90)]
        public String Tipo_UC { get; set; }
        [Width (60),AlignCenter]
        public Boolean SwProduccion { get; set; }
        [Width(60),AlignCenter]
        public Boolean SwDescuento { get; set; }
        [Width(60),AlignCenter]
        public Boolean SwAjustes { get; set; }
        [Width(60),AlignCenter]
        public Boolean SwGastos { get; set; }
        [Width(60),AlignCenter]
        public Boolean SwPension { get; set; }
        [Width(80),AlignCenter]
        public Boolean SwRectificativa { get; set; }
        [Width(110)]
        public String Concepto { get; set; }
//        public Double Costo { get; set; }
        [Width(120)]
        public String Suma { get; set; }
        [Width(120)]
        public String Resta { get; set; }
//        public Int16 UserId { get; set; }
//        public DateTime FechaModificacion { get; set; }
        [Width(110)]
        public String NombreTipoHab { get; set; }
        [Width(110)]
        public String NombreTipoPension { get; set; }
    }
}