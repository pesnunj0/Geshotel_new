namespace Geshotel.Contratos {
    export class OfertasForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.Ofertas';

    }

    export interface OfertasForm {
        Texto: Serenity.StringEditor;
        ContratoId: Serenity.IntegerEditor;
        FechaDesde: Serenity.DateEditor;
        FechaHasta: Serenity.DateEditor;
        TipoAplicacionOfertaId: Serenity.LookupEditor;
        AplicableAuto: Serenity.BooleanEditor;
        FechaReservaDesde: Serenity.DateEditor;
        FechaReservaHasta: Serenity.DateEditor;
        EstanciaMinimaDias: Serenity.IntegerEditor;
        EstanciaMaximaDias: Serenity.IntegerEditor;
        DiasDeAntelacion: Serenity.IntegerEditor;
        TipoServicioId: Serenity.LookupEditor;
        ServicioId: Serenity.LookupEditor;
        UnidadCalculoId: Serenity.LookupEditor;
        ServicioLigadoId: Serenity.LookupEditor;
        CupoOferta: Serenity.IntegerEditor;
        Precio: Serenity.DecimalEditor;
        N: Serenity.DecimalEditor;
        TipoOfertaId: Serenity.LookupEditor;
        M: Serenity.DecimalEditor;
        AmbitoOfertaId: Serenity.LookupEditor;
        ImpuestoIncluido: Serenity.BooleanEditor;
        TipoImputacionId: Serenity.LookupEditor;
        OrdenAplicacion: Serenity.IntegerEditor;
    }

    [['Texto', () => Serenity.StringEditor], ['ContratoId', () => Serenity.IntegerEditor], ['FechaDesde', () => Serenity.DateEditor], ['FechaHasta', () => Serenity.DateEditor], ['TipoAplicacionOfertaId', () => Serenity.LookupEditor], ['AplicableAuto', () => Serenity.BooleanEditor], ['FechaReservaDesde', () => Serenity.DateEditor], ['FechaReservaHasta', () => Serenity.DateEditor], ['EstanciaMinimaDias', () => Serenity.IntegerEditor], ['EstanciaMaximaDias', () => Serenity.IntegerEditor], ['DiasDeAntelacion', () => Serenity.IntegerEditor], ['TipoServicioId', () => Serenity.LookupEditor], ['ServicioId', () => Serenity.LookupEditor], ['UnidadCalculoId', () => Serenity.LookupEditor], ['ServicioLigadoId', () => Serenity.LookupEditor], ['CupoOferta', () => Serenity.IntegerEditor], ['Precio', () => Serenity.DecimalEditor], ['N', () => Serenity.DecimalEditor], ['TipoOfertaId', () => Serenity.LookupEditor], ['M', () => Serenity.DecimalEditor], ['AmbitoOfertaId', () => Serenity.LookupEditor], ['ImpuestoIncluido', () => Serenity.BooleanEditor], ['TipoImputacionId', () => Serenity.LookupEditor], ['OrdenAplicacion', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(OfertasForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

