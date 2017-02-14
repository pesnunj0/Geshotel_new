
namespace Geshotel.Contratos {
    export class OfertasForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.Ofertas';

    }

    export interface OfertasForm {
        ContratoId: Serenity.IntegerEditor;
        Texto: Serenity.StringEditor;
        AplicableAuto: Serenity.BooleanEditor;
        ImpuestoIncluido: Serenity.BooleanEditor;
        FechaDesde: Serenity.DateEditor;
        FechaHasta: Serenity.DateEditor;
        TipoAplicacionOfertaId: Serenity.LookupEditor;
        OrdenAplicacion: Serenity.IntegerEditor;
        FechaReservaDesde: Serenity.DateEditor;
        FechaReservaHasta: Serenity.DateEditor;
        EstanciaMinimaDias: Serenity.IntegerEditor;
        EstanciaMaximaDias: Serenity.IntegerEditor;
        DiasDeAntelacion: Serenity.IntegerEditor;
        CupoOferta: Serenity.IntegerEditor;
        TipoServicioId: Serenity.LookupEditor;
        ServicioId: Serenity.LookupEditor;
        UnidadCalculoId: Serenity.LookupEditor;
        ServicioLigadoId: Serenity.LookupEditor;
        TipoImputacionId: Serenity.LookupEditor;
        AmbitoOfertaId: Serenity.LookupEditor;
        TipoOfertaId: Serenity.LookupEditor;
        N: Serenity.IntegerEditor;
        M: Serenity.DecimalEditor;
    }

    [['ContratoId', () => Serenity.IntegerEditor], ['Texto', () => Serenity.StringEditor], ['AplicableAuto', () => Serenity.BooleanEditor], ['ImpuestoIncluido', () => Serenity.BooleanEditor], ['FechaDesde', () => Serenity.DateEditor], ['FechaHasta', () => Serenity.DateEditor], ['TipoAplicacionOfertaId', () => Serenity.LookupEditor], ['OrdenAplicacion', () => Serenity.IntegerEditor], ['FechaReservaDesde', () => Serenity.DateEditor], ['FechaReservaHasta', () => Serenity.DateEditor], ['EstanciaMinimaDias', () => Serenity.IntegerEditor], ['EstanciaMaximaDias', () => Serenity.IntegerEditor], ['DiasDeAntelacion', () => Serenity.IntegerEditor], ['CupoOferta', () => Serenity.IntegerEditor], ['TipoServicioId', () => Serenity.LookupEditor], ['ServicioId', () => Serenity.LookupEditor], ['UnidadCalculoId', () => Serenity.LookupEditor], ['ServicioLigadoId', () => Serenity.LookupEditor], ['TipoImputacionId', () => Serenity.LookupEditor], ['AmbitoOfertaId', () => Serenity.LookupEditor], ['TipoOfertaId', () => Serenity.LookupEditor], ['N', () => Serenity.IntegerEditor], ['M', () => Serenity.DecimalEditor]].forEach(x => Object.defineProperty(OfertasForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

