namespace Geshotel.Portal {
    export class NacionesForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.Naciones';

    }

    export interface NacionesForm {
        Nacion: Serenity.StringEditor;
        DescCorta: Serenity.StringEditor;
        MonedaId: Serenity.LookupEditor;
        IdiomaId: Serenity.LookupEditor;
        NumeroIne: Serenity.IntegerEditor;
        PaisIsta: Serenity.StringEditor;
        Defecto: Serenity.IntegerEditor;
        NombreReal: Serenity.StringEditor;
        IdiomaMails: Serenity.StringEditor;
    }

    [['Nacion', () => Serenity.StringEditor], ['DescCorta', () => Serenity.StringEditor], ['MonedaId', () => Serenity.LookupEditor], ['IdiomaId', () => Serenity.LookupEditor], ['NumeroIne', () => Serenity.IntegerEditor], ['PaisIsta', () => Serenity.StringEditor], ['Defecto', () => Serenity.IntegerEditor], ['NombreReal', () => Serenity.StringEditor], ['IdiomaMails', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(NacionesForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

