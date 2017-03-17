namespace Geshotel.Portal {
    export class EmpresasForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.Empresas';

    }

    export interface EmpresasForm {
        Empresa: Serenity.StringEditor;
        EmpresaContable: Serenity.StringEditor;
        Direccion: Serenity.StringEditor;
        Poblacion: Serenity.StringEditor;
        Zip: Serenity.StringEditor;
        ProvinciaId: Serenity.LookupEditor;
        Telefono: Serenity.StringEditor;
        Fax: Serenity.StringEditor;
        Cif: Serenity.StringEditor;
        RutaFicheros: Serenity.StringEditor;
    }

    [['Empresa', () => Serenity.StringEditor], ['EmpresaContable', () => Serenity.StringEditor], ['Direccion', () => Serenity.StringEditor], ['Poblacion', () => Serenity.StringEditor], ['Zip', () => Serenity.StringEditor], ['ProvinciaId', () => Serenity.LookupEditor], ['Telefono', () => Serenity.StringEditor], ['Fax', () => Serenity.StringEditor], ['Cif', () => Serenity.StringEditor], ['RutaFicheros', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(EmpresasForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

