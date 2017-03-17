namespace Geshotel.Recepcion {
    export class ReservasOfertasForm extends Serenity.PrefixedContext {
        static formKey = 'Recepcion.ReservasOfertas';

    }

    export interface ReservasOfertasForm {
        ReservaId: Serenity.IntegerEditor;
        OfertaId: Serenity.IntegerEditor;
        Tipo: Serenity.StringEditor;
        Activa: Serenity.IntegerEditor;
        OfertaUsada: Serenity.IntegerEditor;
    }

    [['ReservaId', () => Serenity.IntegerEditor], ['OfertaId', () => Serenity.IntegerEditor], ['Tipo', () => Serenity.StringEditor], ['Activa', () => Serenity.IntegerEditor], ['OfertaUsada', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(ReservasOfertasForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

