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
        UserId: Serenity.LookupEditor;
        FechaModificacion: Serenity.DateEditor;
        TemporadaId: Serenity.LookupEditor;
        ImpuestoIncluido: Serenity.BooleanEditor;
        MercadoId: Serenity.LookupEditor;
    }

    [['HotelId', () => Serenity.LookupEditor], ['ClienteId', () => Serenity.LookupEditor], ['FechaContrato', () => Serenity.DateEditor], ['FechaDesde', () => Serenity.DateEditor], ['FechaHasta', () => Serenity.DateEditor], ['NumeroContratoCliente', () => Serenity.StringEditor], ['UserId', () => Serenity.LookupEditor], ['FechaModificacion', () => Serenity.DateEditor], ['TemporadaId', () => Serenity.LookupEditor], ['ImpuestoIncluido', () => Serenity.BooleanEditor], ['MercadoId', () => Serenity.LookupEditor]].forEach(x => Object.defineProperty(ContratosForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

