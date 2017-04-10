

namespace Geshotel.Recepcion.Repositories
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using MyRow = Entities.ReservasRow;
    using ClasesGeshotel.geshotelk;

    public class ReservasRepository
    {
        private static MyRow.RowFields fld { get { return MyRow.Fields; } }

        public SaveResponse Create(SaveRequest<MyRow> request)
        {
            using (var connection = SqlConnections.NewByKey("Default"))
            using (var uow = new UnitOfWork(connection))
            {
                var result = new MySaveHandler().Process(uow, request, SaveRequestType.Create);
                uow.Commit();
                CargaMetaReserva(request);
                return result;
            }
        }
 
        private tablaServicios CargaMetaReserva(SaveRequest<MyRow> request)
        {
            var user = (UserDefinition)Authorization.UserDefinition;
            Int32 userId = user.UserId;
            var kk = request.Entity.BonoReferencia.ToString();
            Int32 ReservaId = Convert.ToInt32(request.Entity.ReservaId);
            var x = new GesHotelClase(userId);
            var res = new GesHotelClase.MetaReserva();
            var hus = new GesHotelClase.MetaHuesped();

            // Filling fields for MetaReserva

            res.bloquear_tarifa = Convert.ToBoolean(request.Entity.BloquearTarifa);
            if (request.Entity.BonoOnline != null)
                res.bono_online = request.Entity.BonoOnline.ToString();
            res.bono_referencia = request.Entity.BonoReferencia.ToString();
            if (request.Entity.CodigoOferta != null)
                res.codigo_oferta = request.Entity.CodigoOferta.ToString();
            if (request.Entity.CanalReservaId != null)
                res.canal_reserva_id = Convert.ToInt16(request.Entity.CanalReservaId);
            res.cliente_id = Convert.ToInt32(request.Entity.ClienteId);
            if (request.Entity.ClienteIdFactura != null)
                res.cliente_id_factura = Convert.ToInt32(request.Entity.ClienteIdFactura);
            res.permite_devolucion = Convert.ToBoolean(request.Entity.PermiteDevolucion);
            res.vip = Convert.ToBoolean(request.Entity.Vip);
            res.hotel_id = Convert.ToInt16(request.Entity.HotelId);
            res.habitacion_servicio_id = Convert.ToInt16(request.Entity.TipoHabitacionId);
            res.pension_servicio_id = Convert.ToInt16(request.Entity.PensionId);
            res.numero_habitaciones = 1; // Por ahora a piñón 1 habitación por reserva
            if (res.observaciones != null)
                res.observaciones = request.Entity.Observaciones.ToString();
            // Fechas
            res.fecha_reserva = Convert.ToDateTime(request.Entity.FechaReserva).Date;
            res.fecha_prevista_llegada = Convert.ToDateTime(request.Entity.FechaPrevistaLlegada);
            res.fecha_prevista_salida = Convert.ToDateTime(request.Entity.FechaPrevistaSalida);
            // Datos de tarjeta credito
            if (request.Entity.TipoTarjetaId != null)
                res.tipo_tarjeta_id = Convert.ToInt16(request.Entity.TipoTarjetaId);
            if (request.Entity.TarjetaCredito != null)
                res.tarjeta_credito = request.Entity.TarjetaCredito.ToString();
            if (request.Entity.Caducidad != null)
                res.caducidad = request.Entity.Caducidad.ToString();
            if (request.Entity.CodSeguridad != null)
                res.cod_seguridad = request.Entity.CodSeguridad.ToString();
            // *************************
            // Unidades de Calculo
            // *************************
            var ucs = new List<GesHotelClase.UCS>
                {
                    new GesHotelClase.UCS() {unidad_calculo_id=2,cantidad = Convert.ToInt32(request.Entity.Adultos) },
                    new GesHotelClase.UCS() {unidad_calculo_id=3,cantidad = Convert.ToInt32(request.Entity.Child50) },
                    new GesHotelClase.UCS() {unidad_calculo_id=4,cantidad = Convert.ToInt32(request.Entity.ChildFree) },
                    new GesHotelClase.UCS() {unidad_calculo_id=5,cantidad = Convert.ToInt32(request.Entity.Bebes) }
                };

            res.unidades_calculos = ucs;
            //Here I call My function to validate Reservation and calculate Price
            //The function is as follow
            return x.obtieneServiciosReserva(res, false, ReservaId);
            //if (!isok)
            //    throw new ValidationError("Reservation with Errors. Please Check the contract!");
        }

        public SaveResponse Update( SaveRequest<MyRow> request)

        {
            using (var connection = SqlConnections.NewByKey("Default"))
            using (var uow = new UnitOfWork(connection))
            {
                var result = new MySaveHandler().Process(uow, request, SaveRequestType.Update);
                uow.Commit();
                CargaMetaReserva(request);

                return result;
            }
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

        private class MySaveHandler : SaveRequestHandler<MyRow> { }
        private class MyDeleteHandler : DeleteRequestHandler<MyRow> { }
        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow> { }
        private class MyListHandler : ListRequestHandler<MyRow>
        {
            protected override void ApplySortBy(SqlQuery query, SortBy sortBy)
            {    
                base.ApplySortBy(query, sortBy);
                query.OrderBy("fecha_prevista_llegada",true);
            }
        }
    }
}