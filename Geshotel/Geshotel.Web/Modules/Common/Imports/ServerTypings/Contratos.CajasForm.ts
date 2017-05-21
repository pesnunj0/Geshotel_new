
namespace Geshotel.Contratos {
    export class CajasForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.Cajas';

    }

    export interface CajasForm {
        HotelId: Serenity.LookupEditor;
        NombreCaja: Serenity.StringEditor;
        DescCorta: Serenity.StringEditor;
        CierreDia: Serenity.BooleanEditor;
    }

    [['HotelId', () => Serenity.LookupEditor], ['NombreCaja', () => Serenity.StringEditor], ['DescCorta', () => Serenity.StringEditor], ['CierreDia', () => Serenity.BooleanEditor]].forEach(x => Object.defineProperty(CajasForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

