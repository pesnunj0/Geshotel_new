
namespace Geshotel.Portal {
    export class ImpuestosForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.Impuestos';

    }

    export interface ImpuestosForm {
        EmpresaId: Serenity.LookupEditor;
        Impuesto: Serenity.StringEditor;
        Porcentaje: Serenity.DecimalEditor;
        CtaContable: Serenity.StringEditor;
        ActivoGeshotel: Serenity.BooleanEditor;
        UserId: Serenity.LookupEditor;
        FechaActualizacion: Serenity.DateEditor;
    }

    [['EmpresaId', () => Serenity.LookupEditor], ['Impuesto', () => Serenity.StringEditor], ['Porcentaje', () => Serenity.DecimalEditor], ['CtaContable', () => Serenity.StringEditor], ['ActivoGeshotel', () => Serenity.BooleanEditor], ['UserId', () => Serenity.LookupEditor], ['FechaActualizacion', () => Serenity.DateEditor]].forEach(x => Object.defineProperty(ImpuestosForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

