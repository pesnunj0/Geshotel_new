namespace Geshotel.Recepcion {
    export class ReservasContratosForm extends Serenity.PrefixedContext {
        static formKey = 'Recepcion.ReservasContratos';

    }

    export interface ReservasContratosForm {
        ReservaId: Serenity.IntegerEditor;
        ContratoId: Serenity.IntegerEditor;
        Directo: Serenity.IntegerEditor;
    }

    [['ReservaId', () => Serenity.IntegerEditor], ['ContratoId', () => Serenity.IntegerEditor], ['Directo', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(ReservasContratosForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

