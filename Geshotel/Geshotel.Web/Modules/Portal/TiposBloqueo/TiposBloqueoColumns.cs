﻿
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.TiposBloqueo")]
    [BasedOnRow(typeof(Entities.TiposBloqueoRow))]
    public class TiposBloqueoColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 TipoBloqueoId { get; set; }
        [EditLink]
        public String Descriptivo { get; set; }
        public Boolean Editable { get; set; }
    }
}