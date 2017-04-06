

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
                Int32 ReservaId = Convert.ToInt32(fld.ReservaId);

                var x = new GesHotelClase(userId);
                var res = new GesHotelClase.MetaReserva();
                var hus = new GesHotelClase.MetaHuesped();
                
                // Filling fields for MetaReserva

                res.bloquear_tarifa = Convert.ToBoolean(fld.BloquearTarifa);
                res.bono_online = fld.BonoOnline.ToString();
                res.bono_referencia = fld.BonoReferencia.ToString();
                res.codigo_oferta = fld.CodigoOferta.ToString();
                res.canal_reserva_id = Convert.ToInt16(fld.CanalReservaId);
                res.cliente_id = Convert.ToInt32(fld.ClienteId);
                res.cliente_id_factura = Convert.ToInt32(fld.ClienteIdFactura);
                res.permite_devolucion = Convert.ToBoolean(fld.PermiteDevolucion);
                res.vip = Convert.ToBoolean(fld.Vip);
                res.hotel_id = Convert.ToInt16(fld.HotelId);
                res.habitacion_servicio_id = Convert.ToInt16(fld.TipoHabitacionId);
                res.pension_servicio_id = Convert.ToInt16(fld.PensionId);
                res.numero_habitaciones = 1; // Por ahora a piñón 1 habitación por reserva
                res.observaciones = fld.Observaciones.ToString();
                // Fechas
                res.fecha_reserva = Convert.ToDateTime(fld.FechaReserva).Date;
                res.fecha_prevista_llegada = Convert.ToDateTime(fld.FechaPrevistaLlegada);
                res.fecha_prevista_salida = Convert.ToDateTime(fld.FechaPrevistaSalida);
                // Datos de tarjeta credito
                res.tipo_tarjeta_id = Convert.ToInt16(fld.TipoTarjetaId);
                res.tarjeta_credito = fld.TarjetaCredito.ToString();
                res.caducidad = fld.Caducidad.ToString();
                res.cod_seguridad = fld.CodSeguridad.ToString();
                // *************************
                // Unidades de Calculo
                // *************************
                var ucs = new List<GesHotelClase.UCS>
                {
                    new GesHotelClase.UCS() {unidad_calculo_id=2,cantidad = Convert.ToInt32(fld.Adultos) },
                    new GesHotelClase.UCS() {unidad_calculo_id=3,cantidad = Convert.ToInt32(fld.Child50) },
                    new GesHotelClase.UCS() {unidad_calculo_id=4,cantidad = Convert.ToInt32(fld.ChildFree) },
                    new GesHotelClase.UCS() {unidad_calculo_id=5,cantidad = Convert.ToInt32(fld.Bebes) }
                };

                res.unidades_calculos = ucs;

                x.obtieneServiciosReserva(res,false,ReservaId);

            }
        }
        private class MyDeleteHandler : DeleteRequestHandler<MyRow> { }
        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow> { }
        private class MyListHandler : ListRequestHandler<MyRow> { }
    }
}