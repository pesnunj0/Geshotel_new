
namespace Geshotel.Portal {
    export class TiposHabitacionHotelForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.TiposHabitacionHotel';

    }

    export interface TiposHabitacionHotelForm {
        HotelId: Serenity.LookupEditor;
        TipoHabitacionId: Serenity.LookupEditor;
        ServicioId: Serenity.LookupEditor;
    }

    [['HotelId', () => Serenity.LookupEditor], ['TipoHabitacionId', () => Serenity.LookupEditor], ['ServicioId', () => Serenity.LookupEditor]].forEach(x => Object.defineProperty(TiposHabitacionHotelForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

