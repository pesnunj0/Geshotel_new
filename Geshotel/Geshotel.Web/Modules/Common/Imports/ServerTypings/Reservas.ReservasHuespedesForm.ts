

namespace Geshotel.Reservas {
    export class ReservasHuespedesForm extends Serenity.PrefixedContext {
        static formKey = 'Reservas.ReservasHuespedes';
    }

    export interface ReservasHuespedesForm {
        ReservaId: Serenity.IntegerEditor;
        ClienteId: Serenity.IntegerEditor;
        FechaLlegada: Serenity.DateEditor;
        FechaSalida: Serenity.DateEditor;
        HabitacionId: Serenity.IntegerEditor;
        TipoHuespedId: Serenity.IntegerEditor;
        Edad: Serenity.IntegerEditor;
    }

    [['ReservasHuespedesId', () => Serenity.IntegerEditor], ['ReservaId', () => Serenity.IntegerEditor], ['ClienteId', () => Serenity.IntegerEditor], ['FechaLlegada', () => Serenity.DateEditor], ['FechaSalida', () => Serenity.DateEditor], ['HabitacionId', () => Serenity.IntegerEditor], ['TipoHuespedId', () => Serenity.IntegerEditor], ['Edad', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(ReservasHuespedesForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}