

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

        private class MySaveHandler : SaveRequestHandler<MyRow> {
            protected override void AfterSave()
            {
                base.AfterSave();

                var user = (UserDefinition)Authorization.UserDefinition;
                Int32 userId = user.UserId;
                var kk= Request.Entity.BonoReferencia.ToString();
                Int32 ReservaId = Convert.ToInt32(Request.Entity.ReservaId);
                var x = new GesHotelClase(userId);
                var res = new GesHotelClase.MetaReserva();
                var hus = new GesHotelClase.MetaHuesped();

                // Filling fields for MetaReserva

                res.bloquear_tarifa = Convert.ToBoolean(Request.Entity.BloquearTarifa);
                res.bono_online = Request.Entity.BonoOnline.ToString();
                res.bono_referencia = Request.Entity.BonoReferencia.ToString();
                res.codigo_oferta = Request.Entity.CodigoOferta.ToString();
                res.canal_reserva_id = Convert.ToInt16(Request.Entity.CanalReservaId);
                res.cliente_id = Convert.ToInt32(Request.Entity.ClienteId);
                res.cliente_id_factura = Convert.ToInt32(Request.Entity.ClienteIdFactura);
                res.permite_devolucion = Convert.ToBoolean(Request.Entity.PermiteDevolucion);
                res.vip = Convert.ToBoolean(Request.Entity.Vip);
                res.hotel_id = Convert.ToInt16(Request.Entity.HotelId);
                res.habitacion_servicio_id = Convert.ToInt16(Request.Entity.TipoHabitacionId);
                res.pension_servicio_id = Convert.ToInt16(Request.Entity.PensionId);
                res.numero_habitaciones = 1; // Por ahora a piñón 1 habitación por reserva
                res.observaciones = Request.Entity.Observaciones.ToString();
                // Fechas
                res.fecha_reserva = Convert.ToDateTime(Request.Entity.FechaReserva).Date;
                res.fecha_prevista_llegada = Convert.ToDateTime(Request.Entity.FechaPrevistaLlegada);
                res.fecha_prevista_salida = Convert.ToDateTime(Request.Entity.FechaPrevistaSalida);
                // Datos de tarjeta credito
                res.tipo_tarjeta_id = Convert.ToInt16(Request.Entity.TipoTarjetaId);
                res.tarjeta_credito = Request.Entity.TarjetaCredito.ToString();
                res.caducidad = Request.Entity.Caducidad.ToString();
                res.cod_seguridad = Request.Entity.CodSeguridad.ToString();
                // *************************
                // Unidades de Calculo
                // *************************
                var ucs = new List<GesHotelClase.UCS>
                {
                    new GesHotelClase.UCS() {unidad_calculo_id=2,cantidad = Convert.ToInt32(Request.Entity.Adultos) },
                    new GesHotelClase.UCS() {unidad_calculo_id=3,cantidad = Convert.ToInt32(Request.Entity.Child50) },
                    new GesHotelClase.UCS() {unidad_calculo_id=4,cantidad = Convert.ToInt32(Request.Entity.ChildFree) },
                    new GesHotelClase.UCS() {unidad_calculo_id=5,cantidad = Convert.ToInt32(Request.Entity.Bebes) }
                };

                res.unidades_calculos = ucs;
                // Here I call My function to validate Reservation and calculate Price
                // The function is as follow
                // var isok = x.obtieneServiciosReserva(res, false, ReservaId);
                // if (!isok) 
                //     throw new ValidationError("Reservation with Errors. Please Check the contract!");

            }
        }
        private class MyDeleteHandler : DeleteRequestHandler<MyRow> { }
        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow> { }
        private class MyListHandler : ListRequestHandler<MyRow> { }
    }
}