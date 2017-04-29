

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
            var ReservaId = Convert.ToInt32(request.ReservaId);
            var user = (UserDefinition)Authorization.UserDefinition;
            Int32 userId = user.UserId;

            var x = new GesHotelClase(userId);
            var xx = x.obtieneServiciosReservaCache(ReservaId);

            if (xx != null)
            {
                var ds = new DataSet();
                ds.Tables.Add(xx.ordenarPor("fecha").Table);
                string json = JsonConvert.SerializeObject(ds);
            }


            return result;

        }
    }
}