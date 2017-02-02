

namespace Geshotel.Contratos {
    export class ContratosEdadesForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.ContratosEdades';
    }

    export interface ContratosEdadesForm {
        TipoHuespedId: Serenity.IntegerEditor;
        EdadMinima: Serenity.IntegerEditor;
        EdadMaxima: Serenity.IntegerEditor;
        UserId: Serenity.IntegerEditor;
    }

    [['ContratoId', () => Serenity.IntegerEditor], ['TipoHuespedId', () => Serenity.IntegerEditor], ['EdadMinima', () => Serenity.IntegerEditor], ['EdadMaxima', () => Serenity.IntegerEditor], ['UserId', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(ContratosEdadesForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}