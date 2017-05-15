namespace Geshotel.Recepcion {
    export class HabitacionesBloqueosForm extends Serenity.PrefixedContext {
        static formKey = 'Recepcion.HabitacionesBloqueos';

    }

    export interface HabitacionesBloqueosForm {
        HabitacionId: Serenity.LookupEditor;
        TipoBloqueoId: Serenity.LookupEditor;
        FechaDesde: Serenity.DateEditor;
        FechaHasta: Serenity.DateEditor;
        Observaciones: Serenity.TextAreaEditor;
        ReservaId: Serenity.IntegerEditor;
    }

    [['HabitacionId', () => Serenity.LookupEditor], ['TipoBloqueoId', () => Serenity.LookupEditor], ['FechaDesde', () => Serenity.DateEditor], ['FechaHasta', () => Serenity.DateEditor], ['Observaciones', () => Serenity.TextAreaEditor], ['ReservaId', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(HabitacionesBloqueosForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

