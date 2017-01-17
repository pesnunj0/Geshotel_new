
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.Servicios")]
    [BasedOnRow(typeof(Entities.ServiciosRow))]
    public class ServiciosForm
    {
        public String NombreServicio { get; set; }
        public String Abreviatura { get; set; }
        public Int16 TipoServicioId { get; set; }
        public Int16 TipoUnidadCalculoId { get; set; }
        public Boolean SwProduccion { get; set; }
        public Boolean SwDescuento { get; set; }
        public Boolean SwAjustes { get; set; }
        public Boolean SwGastos { get; set; }
        public Boolean SwPension { get; set; }
        public Boolean SwRectificativa { get; set; }
        public Int16 ConceptoAceleradorReservasId { get; set; }
//        public Double Costo { get; set; }
        public Int32 SumaServicioId { get; set; }
        public Int32 RestaServicioId { get; set; }
//        public Int16 UserId { get; set; }
//        public DateTime FechaModificacion { get; set; }
        public Int16 TipoHab { get; set; }
        public Int16 TipoPension { get; set; }
    }
}