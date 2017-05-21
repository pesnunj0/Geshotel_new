
namespace Geshotel.Portal {
    export class GruposDeServiciosForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.GruposDeServicios';

    }

    export interface GruposDeServiciosForm {
        HotelId: Serenity.IntegerEditor;
        NombreGrupo: Serenity.StringEditor;
        CtaContable: Serenity.StringEditor;
    }

    [['HotelId', () => Serenity.IntegerEditor], ['NombreGrupo', () => Serenity.StringEditor], ['CtaContable', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(GruposDeServiciosForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

