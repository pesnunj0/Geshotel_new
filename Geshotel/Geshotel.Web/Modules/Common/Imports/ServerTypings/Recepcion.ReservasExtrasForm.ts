namespace Geshotel.Recepcion {
    export class ReservasExtrasForm extends Serenity.PrefixedContext {
        static formKey = 'Recepcion.ReservasExtras';

    }

    export interface ReservasExtrasForm {
        ReservaId: Serenity.IntegerEditor;
        ServicioId: Serenity.LookupEditor;
        UnidadCalculoId: Serenity.LookupEditor;
        FechaDesde: Serenity.DateEditor;
        FechaHasta: Serenity.DateEditor;
        Cantidad: Serenity.DecimalEditor;
        FlagContrato: Serenity.IntegerEditor;
        PrecioServicio: Serenity.DecimalEditor;
        ServicioExtra: Serenity.IntegerEditor;
    }

    [['ReservaId', () => Serenity.IntegerEditor], ['ServicioId', () => Serenity.LookupEditor], ['UnidadCalculoId', () => Serenity.LookupEditor], ['FechaDesde', () => Serenity.DateEditor], ['FechaHasta', () => Serenity.DateEditor], ['Cantidad', () => Serenity.DecimalEditor], ['FlagContrato', () => Serenity.IntegerEditor], ['PrecioServicio', () => Serenity.DecimalEditor], ['ServicioExtra', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(ReservasExtrasForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

