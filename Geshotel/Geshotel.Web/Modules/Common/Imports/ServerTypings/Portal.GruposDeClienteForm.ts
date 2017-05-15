namespace Geshotel.Portal {
    export class GruposDeClienteForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.GruposDeCliente';

    }

    export interface GruposDeClienteForm {
        NombreGrupo: Serenity.StringEditor;
        Huesped: Serenity.BooleanEditor;
        Contratos: Serenity.BooleanEditor;
        Facturar: Serenity.BooleanEditor;
        Agencia: Serenity.BooleanEditor;
        Perfil: Serenity.IntegerEditor;
    }

    [['NombreGrupo', () => Serenity.StringEditor], ['Huesped', () => Serenity.BooleanEditor], ['Contratos', () => Serenity.BooleanEditor], ['Facturar', () => Serenity.BooleanEditor], ['Agencia', () => Serenity.BooleanEditor], ['Perfil', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(GruposDeClienteForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

