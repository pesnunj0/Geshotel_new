﻿
namespace Geshotel.Contratos.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Contratos.TiposHabitacionHotel")]
    [BasedOnRow(typeof(Entities.TiposHabitacionHotelRow))]
    public class TiposHabitacionHotelColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 TipoHabitacionHotelId { get; set; }
        [Width(150), QuickFilter, Hidden]
        public String Empresa { get; set; }
        [Width(150), QuickFilter, QuickFilterOption("CascadeFrom", "EmpresaId"), QuickFilterOption("multiple", true)]
        public String HotelName { get; set; }
        [EditLink]
        public String TipoHabitacionName { get; set; }
        public String ServicioName { get; set; }
    }
}