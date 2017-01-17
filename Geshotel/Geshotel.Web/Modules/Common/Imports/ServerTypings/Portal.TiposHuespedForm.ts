namespace Geshotel.Portal {
    export class TiposHuespedForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.TiposHuesped';

    }

    export interface TiposHuespedForm {
        Descripcion: Serenity.StringEditor;
        DescCorta: Serenity.StringEditor;
        EmpresaId: Serenity.LookupEditor;
        UcId: Serenity.LookupEditor;
    }

    [['Descripcion', () => Serenity.StringEditor], ['DescCorta', () => Serenity.StringEditor], ['EmpresaId', () => Serenity.LookupEditor], ['UcId', () => Serenity.LookupEditor]].forEach(x => Object.defineProperty(TiposHuespedForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

