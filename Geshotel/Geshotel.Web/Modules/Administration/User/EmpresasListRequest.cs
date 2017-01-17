

namespace Geshotel.Administration
{
    using Serenity.Services;
    using System.Collections.Generic;

    public class EmpresasListRequest : ListRequest
    {
        public List<int> Empresas { get; set;}
    }
}