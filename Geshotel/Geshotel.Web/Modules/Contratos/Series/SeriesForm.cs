
namespace Geshotel.Contratos.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Contratos.Series")]
    [BasedOnRow(typeof(Entities.SeriesRow))]
    public class SeriesForm
    {
        public Int16 EmpresaId { get; set; }
        public String Descripcion { get; set; }
        public String Abreviatura { get; set; }

        public Boolean Manocorriente { get; set; }
        public Boolean Visible { get; set; }
        public Boolean Factura { get; set; }
        public Boolean Deposito { get; set; }
//        public Int32 ServicioId { get; set; }
//        public Int32 ImpuestoId { get; set; }
//        public Int16 Voxel { get; set; }
    }
}