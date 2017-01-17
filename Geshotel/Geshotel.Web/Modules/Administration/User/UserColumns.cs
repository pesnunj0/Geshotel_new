
namespace Geshotel.Administration.Columns
{
    using Serenity.ComponentModel;
    using System;
    using System.Collections.Generic;

    [ColumnsScript("Administration.User")]
    [BasedOnRow(typeof(Entities.UserRow))]
    public class UserColumns
    {
        [EditLink, AlignRight, Width(55)]
        public String UserId { get; set; }
        [EditLink, Width(150)]
        public String Username { get; set; }
        [Width(150)]
        public String DisplayName { get; set; }
        [Width(250), EmpresasListFormatter]
        public List<Int16> EmpresasList { get; set; }
        [Width(250)]
        public String Email { get; set; }
        [Width(100)]
        public String Source { get; set; }
    }
}
