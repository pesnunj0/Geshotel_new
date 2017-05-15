namespace Geshotel.Contratos {
    export class FacturasForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.Facturas';

    }

    export interface FacturasForm {
        NumeroFactura: Serenity.IntegerEditor;
        SerieId: Serenity.IntegerEditor;
        FechaFactura: Serenity.DateEditor;
        HotelId: Serenity.IntegerEditor;
        ClienteId: Serenity.IntegerEditor;
        FormaPagoId: Serenity.IntegerEditor;
        DireccionFactura: Serenity.StringEditor;
        PoblacionFactura: Serenity.StringEditor;
        Zip: Serenity.StringEditor;
        ProvinciaId: Serenity.IntegerEditor;
        FechaVencimiento: Serenity.DateEditor;
        EstadoFacturaId: Serenity.IntegerEditor;
        RefFra1: Serenity.StringEditor;
        RefFra2: Serenity.StringEditor;
        IdFacturaRectificada: Serenity.IntegerEditor;
        MotivoRectificacion: Serenity.StringEditor;
        UserId: Serenity.IntegerEditor;
        FechaModificacion: Serenity.DateEditor;
    }

    [['NumeroFactura', () => Serenity.IntegerEditor], ['SerieId', () => Serenity.IntegerEditor], ['FechaFactura', () => Serenity.DateEditor], ['HotelId', () => Serenity.IntegerEditor], ['ClienteId', () => Serenity.IntegerEditor], ['FormaPagoId', () => Serenity.IntegerEditor], ['DireccionFactura', () => Serenity.StringEditor], ['PoblacionFactura', () => Serenity.StringEditor], ['Zip', () => Serenity.StringEditor], ['ProvinciaId', () => Serenity.IntegerEditor], ['FechaVencimiento', () => Serenity.DateEditor], ['EstadoFacturaId', () => Serenity.IntegerEditor], ['RefFra1', () => Serenity.StringEditor], ['RefFra2', () => Serenity.StringEditor], ['IdFacturaRectificada', () => Serenity.IntegerEditor], ['MotivoRectificacion', () => Serenity.StringEditor], ['UserId', () => Serenity.IntegerEditor], ['FechaModificacion', () => Serenity.DateEditor]].forEach(x => Object.defineProperty(FacturasForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

