using Serenity.Data;


namespace Geshotel.Portal.Entities
{
    public interface ITenantRow
    {
        Int16Field HotelIdField { get; }
        Int16Field EmpresaIdField { get; }
    }
}