﻿/*********************************************************************************************************
 * Para evitar deadlocks entre Serenity y Geshotel, en vez de utilizar MySavehandler etc
 * He cambiado la llamada en Create y Update para que despues de la llamada a MySavehandler, es decir, cuando
 * la reserva ya ha sido grabada, pueda llamar a la funcion de geshotel ObtieneServiviosReserva
 * En MySaveHandler he añadido que iguale fecha_llegada y fecha_salida a fecha_prevista_llegada y 
 * fecha_prevista_salida (esta estupidez la hago para poder hacer busqueda de reservas solo por fechas
 * ********************************************************************************************************/

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
        private static bool LlamaCargaMetaReserva = false;


        public SaveResponse Create(SaveRequest<MyRow> request)
        {
            LlamaCargaMetaReserva = true;
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
            Int32 ReservaId = Convert.ToInt32(request.Entity.ReservaId);
            var x = new GesHotelClase(userId);
            var res = new GesHotelClase.MetaReserva();
            var hus = new GesHotelClase.MetaHuesped();
            
            if (LlamaCargaMetaReserva)

            // Filling fields for MetaReserva
            res.nombre_reserva = Convert.ToString(request.Entity.NombreReserva);
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
            res.pension_id = Convert.ToInt16(request.Entity.PensionId);
            res.tipo_habitacion_id = Convert.ToInt16(request.Entity.TipoHabitacionId);
            res.adultos = Convert.ToInt16(request.Entity.Adultos);
            res.child_50 = Convert.ToInt16(request.Entity.Child50);
            res.child_free = Convert.ToInt16(request.Entity.ChildFree);
            res.bebes = Convert.ToInt16(request.Entity.Bebes);
            res.numero_habitaciones = 1; // Por ahora a piñón 1 habitación por reserva
            if (res.observaciones != null)
                res.observaciones = request.Entity.Observaciones.ToString();
            // Fechas
            res.fecha_creacion = Convert.ToDateTime(request.Entity.FechaCreacion);
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
            if (request.Entity.Ficheros != null)
                res.ficheros = request.Entity.Ficheros.ToString();
            // *************************
            // Unidades de Calculo
            // *************************
            var ucs = new GesHotelClase.UCS[4];

            int i = 0;
            if (Convert.ToInt32(request.Entity.Adultos)>0)
            {
                ucs[i] = new GesHotelClase.UCS();
                ucs[i].cantidad = Convert.ToInt32(request.Entity.Adultos);
                ucs[i].unidad_calculo_id = 2;
                i++;
            }
            if (Convert.ToInt32(request.Entity.Child50) >= 0)
            {
                ucs[i] = new GesHotelClase.UCS();
                ucs[i].cantidad = Convert.ToInt32(request.Entity.Child50);
                ucs[i].unidad_calculo_id = 3;
                i++;
            }
            
            if (Convert.ToInt32(request.Entity.ChildFree) >= 0)
            {
                ucs[i] = new GesHotelClase.UCS();
                ucs[i].cantidad = Convert.ToInt32(request.Entity.ChildFree);
                ucs[i].unidad_calculo_id = 4;
                i++;
            }
            if (Convert.ToInt32(request.Entity.Bebes) >= 0)
            {
                ucs[i] = new GesHotelClase.UCS();
                ucs[i].cantidad = Convert.ToInt32(request.Entity.Bebes);
                ucs[i].unidad_calculo_id = 5;
                i++;
            }

            //var ucs = new List<GesHotelClase.UCS>
            //    {
            //        new GesHotelClase.UCS() {unidad_calculo_id=2,cantidad = Convert.ToInt32(request.Entity.Adultos) },
            //        new GesHotelClase.UCS() {unidad_calculo_id=3,cantidad = Convert.ToInt32(request.Entity.Child50) },
            //        new GesHotelClase.UCS() {unidad_calculo_id=4,cantidad = Convert.ToInt32(request.Entity.ChildFree) },
            //        new GesHotelClase.UCS() {unidad_calculo_id=5,cantidad = Convert.ToInt32(request.Entity.Bebes) }
            //    };

            res.unidades_calculos = ucs;
            res.estado_reserva_id = Convert.ToInt16(request.Entity.EstadoReservaId);
            //Here I call My function to validate Reservation and calculate Price
            //The function is as follow
            var result = x.obtieneServiciosReserva(res, true, ReservaId);
            //if (result.errornum !=0)
            //    throw new ValidationError("Reservation with Errors. Please Check the contract! " + result.errortxt );
            return result;
        }

        public SaveResponse Update(SaveRequest<MyRow> request)
        {           
            using (var connection = SqlConnections.NewByKey("Default"))
            using (var uow = new UnitOfWork(connection))
            {
                var result = new MySaveHandler().Process(uow, request, SaveRequestType.Update);
                uow.Commit();
                if (LlamaCargaMetaReserva)
                //if (request.Entity.EstadoReservaId <2) // En estado 0 (Con Errores o Pendiente de entrar)
                    CargaMetaReserva(request);          // Genero MetaReserva y Recargo 
                if (request.Entity.EstadoReservaId>2 & request.Entity.EstadoReservaId<5) // Menos estado Anulada o No Show Regenero Lineas de Factura
                {
                    var user = (UserDefinition)Authorization.UserDefinition;
                    Int32 userId = user.UserId;
                    Int32 ReservaId = Convert.ToInt32(request.Entity.ReservaId);
                    var x = new GesHotelClase(userId);
                    x.regenerarLineasFacturasReserva(ReservaId);
                }                   
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

        private class MySaveHandler : SaveRequestHandler<MyRow>
        {
            
            protected override void SetInternalFields()
            {
                
                base.SetInternalFields();
                // ****************************************************************************************
                // Si hay cambio en alguno de los campos importantes entonces Llamamos a CargaMetaReserva
                // Evitamos llamarla siempre
                // ****************************************************************************************
                if (Old != null)
                {
                    if (Old.PensionId != Row.PensionId || Old.TipoHabitacionId != Row.TipoHabitacionId || Old.Adultos != Row.Adultos || Old.Bebes != Row.Bebes || Old.Child50 != Row.Child50 || Old.ChildFree != Row.ChildFree || Old.ClienteId != Row.ClienteId)
                        LlamaCargaMetaReserva = true;
                }
                if (Row.EstadoReservaId < 3)
                {
                    Row.FechaLlegada = Row.FechaPrevistaLlegada;
                    Row.FechaSalida = Row.FechaPrevistaSalida;
                }
            }
        }
        private class MyDeleteHandler : DeleteRequestHandler<MyRow> { }
        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow> { }
        private class MyListHandler : ListRequestHandler<MyRow>
        {
            protected override void ApplySort(SqlQuery query)
            {
                
                base.ApplySort(query);

                // if you do this here, users can't sort by other columns, as fechaprevista... will always be sorted first
                // query.OrderByFirst("fecha_prevista_llegada", true);
            }
        }
    }
}