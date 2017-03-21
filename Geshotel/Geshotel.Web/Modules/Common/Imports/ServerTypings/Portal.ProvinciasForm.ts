
namespace Geshotel.Portal {
    export class ProvinciasForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.Provincias';

    }

    export interface ProvinciasForm {
        Provincia: Serenity.StringEditor;
        ComunidadAutonomaId: Serenity.LookupEditor;
        NacionId: Serenity.LookupEditor;
        ProvinciaIsta: Serenity.StringEditor;
        DefectoIsta: Serenity.IntegerEditor;
    }

    [['Provincia', () => Serenity.StringEditor], ['ComunidadAutonomaId', () => Serenity.LookupEditor], ['NacionId', () => Serenity.LookupEditor], ['ProvinciaIsta', () => Serenity.StringEditor], ['DefectoIsta', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(ProvinciasForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

