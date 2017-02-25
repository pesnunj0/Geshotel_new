
namespace Geshotel.Recepcion {
    export class ReservasServiciosForm extends Serenity.PrefixedContext {
        static formKey = 'Recepcion.ReservasServicios';

    }

    export interface ReservasServiciosForm {
        ReservaId: Serenity.IntegerEditor;
        ServicioId: Serenity.IntegerEditor;
        UnidadCalculoId: Serenity.IntegerEditor;
        FechaDesde: Serenity.DateEditor;
        FechaHasta: Serenity.DateEditor;
        Cantidad: Serenity.DecimalEditor;
        UserId: Serenity.IntegerEditor;
        FechaModificacion: Serenity.DateEditor;
        FlagContrato: Serenity.IntegerEditor;
        PrecioServicio: Serenity.DecimalEditor;
        ServicioExtra: Serenity.IntegerEditor;
    }

    [['ReservaId', () => Serenity.IntegerEditor], ['ServicioId', () => Serenity.IntegerEditor], ['UnidadCalculoId', () => Serenity.IntegerEditor], ['FechaDesde', () => Serenity.DateEditor], ['FechaHasta', () => Serenity.DateEditor], ['Cantidad', () => Serenity.DecimalEditor], ['UserId', () => Serenity.IntegerEditor], ['FechaModificacion', () => Serenity.DateEditor], ['FlagContrato', () => Serenity.IntegerEditor], ['PrecioServicio', () => Serenity.DecimalEditor], ['ServicioExtra', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(ReservasServiciosForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

