
namespace Geshotel.Portal {
    export class TiposHabitacionHotelForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.TiposHabitacionHotel';

    }

    export interface TiposHabitacionHotelForm {
        TipoHabitacionId: Serenity.IntegerEditor;
        ServicioId: Serenity.IntegerEditor;
    }

    [['TipoHabitacionId', () => Serenity.IntegerEditor], ['ServicioId', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(TiposHabitacionHotelForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

