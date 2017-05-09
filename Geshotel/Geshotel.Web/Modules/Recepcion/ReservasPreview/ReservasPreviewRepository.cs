

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
            var ReservaId = Convert.ToInt32(request.ReservaId);
            var user = (UserDefinition)Authorization.UserDefinition;
            Int32 userId = user.UserId;
            // Something is wrong here becouse I do not get ReserveId from request
            ReservaId = 10;
            var x = new GesHotelClase(userId);
            var xx = x.obtieneServiciosReservaCache(ReservaId);
            
            if (xx != null)
            {
                result.Entities = new List<ReservasPreviewItem>();
                var ds = new DataSet();
                ds.Tables.Add(xx.ordenarPor("fecha").Table);
                int cont = 0;
                // Fill Entities from Dataset
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    result.Entities.Add(new ReservasPreviewItem
                    {
                        Error = row.Field<int>("error"),
                        Key = cont++,
                        ReservaId = ReservaId,
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
            return result;
        }
    }
}