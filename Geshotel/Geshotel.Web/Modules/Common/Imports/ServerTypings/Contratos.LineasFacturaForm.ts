

namespace Geshotel.Contratos {
    export class LineasFacturaForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.LineasFactura';
    }

    export interface LineasFacturaForm {
        HotelId: Serenity.IntegerEditor;
        Fecha: Serenity.DateEditor;
        FacturaId: Serenity.IntegerEditor;
        ReservaId: Serenity.IntegerEditor;
        ContratoId: Serenity.IntegerEditor;
        Descripcion: Serenity.StringEditor;
        Cantidad: Serenity.DecimalEditor;
        Precio: Serenity.DecimalEditor;
        ImpuestoId: Serenity.IntegerEditor;
        PorcImpuesto: Serenity.DecimalEditor;
        ServicioId: Serenity.IntegerEditor;
        UnidadCalculoId: Serenity.IntegerEditor;
        TipoLineaFactura: Serenity.StringEditor;
        PrecioProduccion: Serenity.DecimalEditor;
        PagFactura: Serenity.IntegerEditor;
        Costo: Serenity.DecimalEditor;
        UserId: Serenity.IntegerEditor;
        FechaModificacion: Serenity.DateEditor;
        SwAjuste: Serenity.IntegerEditor;
    }

    [['LineaFacturaId', () => Serenity.IntegerEditor], ['HotelId', () => Serenity.IntegerEditor], ['Fecha', () => Serenity.DateEditor], ['FacturaId', () => Serenity.IntegerEditor], ['ReservaId', () => Serenity.IntegerEditor], ['ContratoId', () => Serenity.IntegerEditor], ['Descripcion', () => Serenity.StringEditor], ['Cantidad', () => Serenity.DecimalEditor], ['Precio', () => Serenity.DecimalEditor], ['ImpuestoId', () => Serenity.IntegerEditor], ['PorcImpuesto', () => Serenity.DecimalEditor], ['ServicioId', () => Serenity.IntegerEditor], ['UnidadCalculoId', () => Serenity.IntegerEditor], ['TipoLineaFactura', () => Serenity.StringEditor], ['PrecioProduccion', () => Serenity.DecimalEditor], ['PagFactura', () => Serenity.IntegerEditor], ['Costo', () => Serenity.DecimalEditor], ['UserId', () => Serenity.IntegerEditor], ['FechaModificacion', () => Serenity.DateEditor], ['SwAjuste', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(LineasFacturaForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}