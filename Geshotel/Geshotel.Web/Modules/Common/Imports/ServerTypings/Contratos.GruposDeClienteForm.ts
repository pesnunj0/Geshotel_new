

namespace Geshotel.Contratos {
    export class GruposDeClienteForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.GruposDeCliente';
    }

    export interface GruposDeClienteForm {
        NombreGrupo: Serenity.StringEditor;
        EmpresaId: Serenity.IntegerEditor;
        CtaContable: Serenity.StringEditor;
        UserId: Serenity.IntegerEditor;
        FechaModificacion: Serenity.DateEditor;
        Huesped: Serenity.IntegerEditor;
        Contratos: Serenity.IntegerEditor;
        Facturar: Serenity.IntegerEditor;
        Agencia: Serenity.IntegerEditor;
        Perfil: Serenity.IntegerEditor;
    }

    [['GrupoClienteId', () => Serenity.IntegerEditor], ['NombreGrupo', () => Serenity.StringEditor], ['EmpresaId', () => Serenity.IntegerEditor], ['CtaContable', () => Serenity.StringEditor], ['UserId', () => Serenity.IntegerEditor], ['FechaModificacion', () => Serenity.DateEditor], ['Huesped', () => Serenity.IntegerEditor], ['Contratos', () => Serenity.IntegerEditor], ['Facturar', () => Serenity.IntegerEditor], ['Agencia', () => Serenity.IntegerEditor], ['Perfil', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(GruposDeClienteForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}