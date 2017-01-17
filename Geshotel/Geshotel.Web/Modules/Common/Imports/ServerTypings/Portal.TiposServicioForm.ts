namespace Geshotel.Portal {
    export class TiposServicioForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.TiposServicio';

    }

    export interface TiposServicioForm {
        NombreTipoServicio: Serenity.StringEditor;
    }

    [['NombreTipoServicio', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(TiposServicioForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

