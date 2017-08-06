/*****************************************************************************************************
 * ReservasExtrasRepository.cs
 * Filtramos por FlagContrato = 2
 * Rutina ApplyFilters
 * Javier Nuñez
 * Mayo 2017
 * ***************************************************************************************************/


namespace Geshotel.Recepcion.Repositories
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Data;
    using MyRow = Entities.ReservasServiciosRow;
    using ClasesGeshotel.geshotelk;

    public class ReservasExtrasRepository
    {
        private static MyRow.RowFields fld { get { return MyRow.Fields; } }

        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MySaveHandler().Process(uow, request, SaveRequestType.Create);
        }

        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MySaveHandler().Process(uow, request, SaveRequestType.Update);
        }

        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request)
        {
            return new MyDeleteHandler().Process(uow, request);
        }

        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request)
        {
            return new MyRetrieveHandler().Process(connection, request);
        }

        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request)
        {
            return new MyListHandler().Process(connection, request);
        }

        private class MySaveHandler : SaveRequestHandler<MyRow>
        {
            protected override void SetInternalFields()
            {
                // Antes de salvar ponemos fecha_desde y fecha_hasta
                // Verificamos que no tengan errores
                base.SetInternalFields();
                var user = (UserDefinition)Authorization.UserDefinition;
                Int32 userId = user.UserId;
                Int32 ReservaId = (int)Row.ReservaId;
                Row.FlagContrato = 0;
                Row.ServicioExtra = 1;         
            }
 
            protected override void AfterSave()
            {
                base.AfterSave();
                BatchGenerationUpdater.OnCommit(this.UnitOfWork, fld.GenerationKey);
                var user = (UserDefinition)Authorization.UserDefinition;
                Int32 userId = user.UserId;
                var x = new GesHotelClase(userId);
                x.crearLineasFacturas((int)Row.ReservaId,(int)Row.ServicioId,(int)Row.UnidadCalculoId,(float)Row.Cantidad,Row.FechaDesde,Row.FechaHasta,(int)Row.ServicioReservaId);
            }
        }
        private class MyDeleteHandler : DeleteRequestHandler<MyRow> { }
        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow> { }
        private class MyListHandler : ListRequestHandler<MyRow>
        {
            protected override void ApplyFilters(SqlQuery query)
            {
                base.ApplyFilters(query);

                query.Where(
                     fld.FlagContrato == 0 && fld.ServicioExtra == 1
                       .ToString()
                        );

            }
        }
    }
}