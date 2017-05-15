

namespace Geshotel.Recepcion.Repositories
{

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Serenity;
    using Serenity.Abstractions;
    using Serenity.ComponentModel;
    using Serenity.Configuration;
    using Serenity.Extensibility;
    using Serenity.Localization;
    using Serenity.Navigation;
    using Serenity.Services;
    using Serenity.Web;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Web.Hosting;
    using ClasesGeshotel.geshotelk;
    using System.Data;

    public class ReservasPreviewRepository
    {
        public ListResponse<ReservasPreviewItem> List(ReservasPreviewListRequest request)
        {
            var result = new ListResponse<ReservasPreviewItem>();
            result.Entities = new List<ReservasPreviewItem>();
            var user = (UserDefinition)Authorization.UserDefinition;
            Int32 userId = user.UserId;
            var x = new GesHotelClase(userId);
            var xx = x.obtieneServiciosReservaCache(request.ReservaId.Value);

            result.Entities = new List<ReservasPreviewItem>();
            if (xx != null)
            {
                int cont = 0;
                // Fill Entities from Dataset
                foreach (DataRow row in xx.ordenarPor("fecha").Table.Rows)
                {
                    result.Entities.Add(new ReservasPreviewItem
                    {
                        Error = row.Field<int>("error"),
                        Key = cont++,
                        ReservaId = request.ReservaId.Value,
                        Fecha = row.Field<DateTime>("fecha"),
                        Descripcion = row.Field<string>("descripcion"),
                        DescTipo = row.Field<string>("desc_tipo"),                      
                        DescUCReserva = row.Field<string>("desc_uc_reserva"),
                        Cantidad = row.Field<decimal>("cantidad"),
                        Precio = row.Field<decimal>("precio"),
                        PrecioProduccion = row.Field<decimal>("precio_produccion"),
                        Importe = row.Field<decimal>("importe")
                    });
                }
            }
            result.TotalCount = result.Entities.Count;
            result.Skip = 0;
            result.Take = 0;
            return result;
        }
    }
}