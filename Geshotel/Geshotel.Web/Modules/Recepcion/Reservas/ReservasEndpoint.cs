
namespace Geshotel.Recepcion.Endpoints
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System.Data;
    using System.Web.Mvc;
    using MyRepository = Repositories.ReservasRepository;
    using MyRow = Entities.ReservasRow;
    // Añadidos
    using Geshotel;
    using System;
    using Serenity.Reporting;
    using Serenity.Web;
    // Fin Añadidos

    [RoutePrefix("Services/Recepcion/Reservas"), Route("{action}")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class ReservasController : ServiceEndpoint
    {
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MyRepository().Create(uow, request);
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MyRepository().Update(uow, request);
        }
 
        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request)
        {
            return new MyRepository().Delete(uow, request);
        }

        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request)
        {
            return new MyRepository().Retrieve(connection, request);
        }

        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request)
        {
            return new MyRepository().List(connection, request);
        }
        public SaveResponse CheckIn(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            var user = (UserDefinition)Authorization.UserDefinition;
            Int32 userId = user.UserId;
            Int32 ReservaId = Convert.ToInt32(request.EntityId);
            Int16 NewStatus = 3;
            var x = ClasesGeshotel.geshotelk.GesHotelClase.CrearClase(userId, "");
            if (x.CambiarEstadoReserva(ReservaId, NewStatus, false))
            // This function returns true if everything went well or false if there was any error
            // Should be good notify if something went wrong. I do not know how
            {
                // I do not know if here I should Retrieve or change MyRow MyRow.Fields.EstadoReservaId
            }

            return new MyRepository().Update(uow, request);
        }
        public FileContentResult ListExcel(IDbConnection connection, ListRequest request)
        {
            var data = List(connection, request).Entities;
            var report = new DynamicDataReport(data, request.IncludeColumns, typeof(Columns.ReservasColumns));
            var bytes = new ReportRepository().Render(report);
            return ExcelContentResult.Create(bytes, "ReservasList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx");
        }
    }
}
