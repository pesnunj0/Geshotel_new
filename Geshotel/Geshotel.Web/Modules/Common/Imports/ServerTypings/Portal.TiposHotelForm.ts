
namespace Geshotel.Portal {
    export class TiposHotelForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.TiposHotel';

    }

    export interface TiposHotelForm {
        TipoHotel: Serenity.StringEditor;
        Abreviatura: Serenity.StringEditor;
    }

    [['TipoHotel', () => Serenity.StringEditor], ['Abreviatura', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(TiposHotelForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

