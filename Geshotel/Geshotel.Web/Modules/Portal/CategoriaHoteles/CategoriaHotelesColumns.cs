
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.CategoriaHoteles")]
    [BasedOnRow(typeof(Entities.CategoriaHotelesRow))]
    public class CategoriaHotelesColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 CategoriaId { get; set; }
        [EditLink]
        public String Abreviatura { get; set; }
        public String Categoria { get; set; }
    }
}