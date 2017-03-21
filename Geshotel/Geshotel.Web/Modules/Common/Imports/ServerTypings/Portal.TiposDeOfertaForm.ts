
namespace Geshotel.Portal {
    export class TiposDeOfertaForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.TiposDeOferta';

    }

    export interface TiposDeOfertaForm {
        Oferta: Serenity.StringEditor;
        PermitirMMayorQueN: Serenity.IntegerEditor;
        Rejilla: Serenity.IntegerEditor;
        Observaciones: Serenity.StringEditor;
        OrdenAplicacion: Serenity.IntegerEditor;
    }

    [['Oferta', () => Serenity.StringEditor], ['PermitirMMayorQueN', () => Serenity.IntegerEditor], ['Rejilla', () => Serenity.IntegerEditor], ['Observaciones', () => Serenity.StringEditor], ['OrdenAplicacion', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(TiposDeOfertaForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

