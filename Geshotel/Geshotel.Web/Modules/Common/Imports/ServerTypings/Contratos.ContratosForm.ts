

namespace Geshotel.Contratos {
    export class ContratosForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.Contratos';
    }

    export interface ContratosForm {
        HotelId: Serenity.IntegerEditor;
        ClienteId: Serenity.IntegerEditor;
        FechaContrato: Serenity.DateEditor;
        FechaDesde: Serenity.DateEditor;
        FechaHasta: Serenity.DateEditor;
        ContratoIdOriginal: Serenity.IntegerEditor;
        ContratoIdSiguiente: Serenity.IntegerEditor;
        NumeroContratoCliente: Serenity.StringEditor;
        UserId: Serenity.IntegerEditor;
        FechaModificacion: Serenity.DateEditor;
        TemporadaId: Serenity.IntegerEditor;
        ImpuestoIncluido: Serenity.BooleanEditor;
        MercadoId: Serenity.IntegerEditor;
        ClienteIdPadre: Serenity.IntegerEditor;
    }

    [['ContratoId', () => Serenity.IntegerEditor], ['HotelId', () => Serenity.IntegerEditor], ['ClienteId', () => Serenity.IntegerEditor], ['FechaContrato', () => Serenity.DateEditor], ['FechaDesde', () => Serenity.DateEditor], ['FechaHasta', () => Serenity.DateEditor], ['ContratoIdOriginal', () => Serenity.IntegerEditor], ['ContratoIdSiguiente', () => Serenity.IntegerEditor], ['NumeroContratoCliente', () => Serenity.StringEditor], ['UserId', () => Serenity.IntegerEditor], ['FechaModificacion', () => Serenity.DateEditor], ['TemporadaId', () => Serenity.IntegerEditor], ['ImpuestoIncluido', () => Serenity.BooleanEditor], ['MercadoId', () => Serenity.IntegerEditor], ['ClienteIdPadre', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(ContratosForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}