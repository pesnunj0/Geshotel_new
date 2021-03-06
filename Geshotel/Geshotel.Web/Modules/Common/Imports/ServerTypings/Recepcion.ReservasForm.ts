﻿
namespace Geshotel.Recepcion {
    export class ReservasForm extends Serenity.PrefixedContext {
        static formKey = 'Recepcion.Reservas';

    }

    export interface ReservasForm {
        EmpresaId: Serenity.LookupEditor;
        HotelId: Serenity.LookupEditor;
        EstadoReservaId: Serenity.LookupEditor;
        ClienteId: Serenity.LookupEditor;
        ClienteIdFactura: Serenity.LookupEditor;
        NombreReserva: Serenity.StringEditor;
        TipoHabitacionId: Serenity.LookupEditor;
        PensionId: Serenity.LookupEditor;
        Adultos: Serenity.IntegerEditor;
        Child50: Serenity.IntegerEditor;
        ChildFree: Serenity.IntegerEditor;
        Bebes: Serenity.IntegerEditor;
        BonoReferencia: Serenity.StringEditor;
        BonoOnline: Serenity.StringEditor;
        CanalReservaId: Serenity.LookupEditor;
        CodigoOferta: Serenity.StringEditor;
        BloquearTarifa: Serenity.BooleanEditor;
        PermiteDevolucion: Serenity.BooleanEditor;
        Vip: Serenity.BooleanEditor;
        Valor: Serenity.DecimalEditor;
        FechaReserva: Serenity.DateEditor;
        FechaCreacion: Serenity.DateEditor;
        FechaPrevistaLlegada: Serenity.DateTimeEditor;
        FechaPrevistaSalida: Serenity.DateTimeEditor;
        FechaLlegada: Serenity.DateEditor;
        FechaSalida: Serenity.DateEditor;
        ObservacionesLlegada: Serenity.TextAreaEditor;
        ObservacionesSalida: Serenity.TextAreaEditor;
        Observaciones: Serenity.TextAreaEditor;
        ObservacionesCliente: Serenity.TextAreaEditor;
        TipoTarjetaId: Serenity.LookupEditor;
        TarjetaCredito: Serenity.StringEditor;
        Caducidad: Serenity.StringEditor;
        CodSeguridad: Serenity.StringEditor;
        Ficheros: Serenity.MultipleImageUploadEditor;
    }

    [['EmpresaId', () => Serenity.LookupEditor], ['HotelId', () => Serenity.LookupEditor], ['EstadoReservaId', () => Serenity.LookupEditor], ['ClienteId', () => Serenity.LookupEditor], ['ClienteIdFactura', () => Serenity.LookupEditor], ['NombreReserva', () => Serenity.StringEditor], ['TipoHabitacionId', () => Serenity.LookupEditor], ['PensionId', () => Serenity.LookupEditor], ['Adultos', () => Serenity.IntegerEditor], ['Child50', () => Serenity.IntegerEditor], ['ChildFree', () => Serenity.IntegerEditor], ['Bebes', () => Serenity.IntegerEditor], ['BonoReferencia', () => Serenity.StringEditor], ['BonoOnline', () => Serenity.StringEditor], ['CanalReservaId', () => Serenity.LookupEditor], ['CodigoOferta', () => Serenity.StringEditor], ['BloquearTarifa', () => Serenity.BooleanEditor], ['PermiteDevolucion', () => Serenity.BooleanEditor], ['Vip', () => Serenity.BooleanEditor], ['Valor', () => Serenity.DecimalEditor], ['FechaReserva', () => Serenity.DateEditor], ['FechaCreacion', () => Serenity.DateEditor], ['FechaPrevistaLlegada', () => Serenity.DateTimeEditor], ['FechaPrevistaSalida', () => Serenity.DateTimeEditor], ['FechaLlegada', () => Serenity.DateEditor], ['FechaSalida', () => Serenity.DateEditor], ['ObservacionesLlegada', () => Serenity.TextAreaEditor], ['ObservacionesSalida', () => Serenity.TextAreaEditor], ['Observaciones', () => Serenity.TextAreaEditor], ['ObservacionesCliente', () => Serenity.TextAreaEditor], ['TipoTarjetaId', () => Serenity.LookupEditor], ['TarjetaCredito', () => Serenity.StringEditor], ['Caducidad', () => Serenity.StringEditor], ['CodSeguridad', () => Serenity.StringEditor], ['Ficheros', () => Serenity.MultipleImageUploadEditor]].forEach(x => Object.defineProperty(ReservasForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

