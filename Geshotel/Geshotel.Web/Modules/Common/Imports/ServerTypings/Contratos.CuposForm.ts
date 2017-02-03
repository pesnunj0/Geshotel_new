namespace Geshotel.Contratos {
    export class CuposForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.Cupos';

    }

    export interface CuposForm {
        ClienteId: Serenity.IntegerEditor;
        HotelId: Serenity.IntegerEditor;
        FechaDesde: Serenity.DateEditor;
        FechaHasta: Serenity.DateEditor;
        TipoHabitacionId: Serenity.IntegerEditor;
        Garantia: Serenity.DecimalEditor;
        ReservaAutomatica: Serenity.StringEditor;
        UserId: Serenity.IntegerEditor;
        FechaModificacion: Serenity.DateEditor;
    }

    [['ClienteId', () => Serenity.IntegerEditor], ['HotelId', () => Serenity.IntegerEditor], ['FechaDesde', () => Serenity.DateEditor], ['FechaHasta', () => Serenity.DateEditor], ['TipoHabitacionId', () => Serenity.IntegerEditor], ['Garantia', () => Serenity.DecimalEditor], ['ReservaAutomatica', () => Serenity.StringEditor], ['UserId', () => Serenity.IntegerEditor], ['FechaModificacion', () => Serenity.DateEditor]].forEach(x => Object.defineProperty(CuposForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

