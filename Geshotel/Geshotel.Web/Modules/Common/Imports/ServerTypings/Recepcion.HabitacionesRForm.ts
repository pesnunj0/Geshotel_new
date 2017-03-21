

namespace Geshotel.Recepcion {
    export class HabitacionesRForm extends Serenity.PrefixedContext {
        static formKey = 'Recepcion.HabitacionesR';
    }

    export interface HabitacionesRForm {
        HabitacionId: Serenity.IntegerEditor;
        TipoBloqueoId: Serenity.IntegerEditor;
        FechaDesde: Serenity.DateEditor;
        FechaHasta: Serenity.DateEditor;
        Observaciones: Serenity.StringEditor;
        ReservaId: Serenity.IntegerEditor;
        UserId: Serenity.IntegerEditor;
        FechaModificacion: Serenity.DateEditor;
    }

    [['HabitacionBloqueoId', () => Serenity.IntegerEditor], ['HabitacionId', () => Serenity.IntegerEditor], ['TipoBloqueoId', () => Serenity.IntegerEditor], ['FechaDesde', () => Serenity.DateEditor], ['FechaHasta', () => Serenity.DateEditor], ['Observaciones', () => Serenity.StringEditor], ['ReservaId', () => Serenity.IntegerEditor], ['UserId', () => Serenity.IntegerEditor], ['FechaModificacion', () => Serenity.DateEditor]].forEach(x => Object.defineProperty(HabitacionesRForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}