

namespace Geshotel.Portal {
    export class EstadosFacturasForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.EstadosFacturas';
    }

    export interface EstadosFacturasForm {
        Descripcion: Serenity.StringEditor;
        EsError: Serenity.IntegerEditor;
    }

    [['EstadoFacturaId', () => Serenity.IntegerEditor], ['Descripcion', () => Serenity.StringEditor], ['EsError', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(EstadosFacturasForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}