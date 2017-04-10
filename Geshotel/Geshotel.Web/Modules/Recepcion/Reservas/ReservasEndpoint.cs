
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
            return new MyRepository().Create(request);
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MyRepository().Update(request);
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

        public ChangeReservationStatusResponse ChangeReservationStatus(ChangeReservationStatusRequest request)
        {
            request.CheckNotNull();

            Check.NotNull(request.ReservaId, nameof(request.ReservaId));

            var x = ClasesGeshotel.geshotelk.GesHotelClase.CrearClase(Convert.ToInt32(Authorization.UserId), "");
            if (!x.CambiarEstadoReserva(request.ReservaId.Value, request.NewStatusId.Value, false))
                throw new ValidationError("Sorry, can't change Status To the Reservation!");

            new MyRepository().Update(new SaveRequest<MyRow>
            {
                EntityId = request.ReservaId,
                Entity = new MyRow
                {
                    EstadoReservaId = (int)ReservationStatus.CheckedIn
                }
            });

            return new ChangeReservationStatusResponse();
        }
        public CheckInResponse CheckIn(CheckInRequest request)
        {
            request.CheckNotNull();

            Check.NotNull(request.ReservaId, nameof(request.ReservaId));

            var x = ClasesGeshotel.geshotelk.GesHotelClase.CrearClase(Convert.ToInt32(Authorization.UserId), "");
            if (!x.CambiarEstadoReserva(request.ReservaId.Value, 3, false))
                throw new ValidationError("Sorry, can't check in!");

            new MyRepository().Update( new SaveRequest<MyRow>
            {
                EntityId = request.ReservaId,
                Entity = new MyRow
                {
                    EstadoReservaId = (int)ReservationStatus.CheckedIn
                }
            });

            return new CheckInResponse();
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
