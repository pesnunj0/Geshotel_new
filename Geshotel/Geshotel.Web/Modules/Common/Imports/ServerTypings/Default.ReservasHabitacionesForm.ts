

namespace Geshotel.Default {
    export class ReservasHabitacionesForm extends Serenity.PrefixedContext {
        static formKey = 'Default.ReservasHabitaciones';
    }

    export interface ReservasHabitacionesForm {
        HabitacionId: Serenity.IntegerEditor;
        TipoBloqueoId: Serenity.IntegerEditor;
        FechaDesde: Serenity.DateEditor;
        FechaHasta: Serenity.DateEditor;
        Observaciones: Serenity.StringEditor;
        ReservaId: Serenity.IntegerEditor;
        UserId: Serenity.IntegerEditor;
        FechaModificacion: Serenity.DateEditor;
    }

    [['HabitacionBloqueoId', () => Serenity.IntegerEditor], ['HabitacionId', () => Serenity.IntegerEditor], ['TipoBloqueoId', () => Serenity.IntegerEditor], ['FechaDesde', () => Serenity.DateEditor], ['FechaHasta', () => Serenity.DateEditor], ['Observaciones', () => Serenity.StringEditor], ['ReservaId', () => Serenity.IntegerEditor], ['UserId', () => Serenity.IntegerEditor], ['FechaModificacion', () => Serenity.DateEditor]].forEach(x => Object.defineProperty(ReservasHabitacionesForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}