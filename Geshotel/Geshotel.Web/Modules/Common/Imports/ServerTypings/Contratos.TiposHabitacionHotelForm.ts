

namespace Geshotel.Contratos {
    export class TiposHabitacionHotelForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.TiposHabitacionHotel';
    }

    export interface TiposHabitacionHotelForm {
        HotelId: Serenity.IntegerEditor;
        TipoHabitacionId: Serenity.IntegerEditor;
        ServicioId: Serenity.IntegerEditor;
    }

    [['TipoHabitacionHotelId', () => Serenity.IntegerEditor], ['HotelId', () => Serenity.IntegerEditor], ['TipoHabitacionId', () => Serenity.IntegerEditor], ['ServicioId', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(TiposHabitacionHotelForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}