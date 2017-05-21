
namespace Geshotel.Contratos {
    export class CuposForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.Cupos';

    }

    export interface CuposForm {
        ClienteId: Serenity.LookupEditor;
        HotelId: Serenity.LookupEditor;
        FechaDesde: Serenity.DateEditor;
        FechaHasta: Serenity.DateEditor;
        TipoHabitacionId: Serenity.LookupEditor;
        Cupo: Serenity.IntegerEditor;
        Garantia: Serenity.DecimalEditor;
        ReservaAutomatica: Serenity.BooleanEditor;
    }

    [['ClienteId', () => Serenity.LookupEditor], ['HotelId', () => Serenity.LookupEditor], ['FechaDesde', () => Serenity.DateEditor], ['FechaHasta', () => Serenity.DateEditor], ['TipoHabitacionId', () => Serenity.LookupEditor], ['Cupo', () => Serenity.IntegerEditor], ['Garantia', () => Serenity.DecimalEditor], ['ReservaAutomatica', () => Serenity.BooleanEditor]].forEach(x => Object.defineProperty(CuposForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

