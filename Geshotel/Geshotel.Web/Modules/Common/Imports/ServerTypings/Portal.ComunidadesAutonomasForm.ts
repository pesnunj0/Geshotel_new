namespace Geshotel.Portal {
    export class ComunidadesAutonomasForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.ComunidadesAutonomas';

    }

    export interface ComunidadesAutonomasForm {
        ComunidadAutonoma: Serenity.StringEditor;
        NacionId: Serenity.LookupEditor;
        ComunidadAutonomaIsta: Serenity.StringEditor;
    }

    [['ComunidadAutonoma', () => Serenity.StringEditor], ['NacionId', () => Serenity.LookupEditor], ['ComunidadAutonomaIsta', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(ComunidadesAutonomasForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

