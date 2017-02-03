namespace Geshotel.Contratos {
    export class ContratosForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.Contratos';

    }

    export interface ContratosForm {
        HotelId: Serenity.LookupEditor;
        ClienteId: Serenity.LookupEditor;
        FechaContrato: Serenity.DateEditor;
        FechaDesde: Serenity.DateEditor;
        FechaHasta: Serenity.DateEditor;
        NumeroContratoCliente: Serenity.StringEditor;
        UserId: Serenity.IntegerEditor;
        FechaModificacion: Serenity.DateEditor;
        TemporadaId: Serenity.IntegerEditor;
        ImpuestoIncluido: Serenity.BooleanEditor;
        MercadoId: Serenity.IntegerEditor;
    }

    [['HotelId', () => Serenity.LookupEditor], ['ClienteId', () => Serenity.LookupEditor], ['FechaContrato', () => Serenity.DateEditor], ['FechaDesde', () => Serenity.DateEditor], ['FechaHasta', () => Serenity.DateEditor], ['NumeroContratoCliente', () => Serenity.StringEditor], ['UserId', () => Serenity.IntegerEditor], ['FechaModificacion', () => Serenity.DateEditor], ['TemporadaId', () => Serenity.IntegerEditor], ['ImpuestoIncluido', () => Serenity.BooleanEditor], ['MercadoId', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(ContratosForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

