
namespace Geshotel.Contratos {
    export class LineasForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.Lineas';

    }

    export interface LineasForm {
        ContratoId: Serenity.IntegerEditor;
        HotelId: Serenity.LookupEditor;
        Desde: Serenity.DateEditor;
        Hasta: Serenity.DateEditor;
        ServicioId: Serenity.LookupEditor;
        UnidadCalculoId: Serenity.LookupEditor;
        FrecuenciaId: Serenity.LookupEditor;
        TipoImputacionId: Serenity.LookupEditor;
        Importe: Serenity.DecimalEditor;
        Lunes: Serenity.BooleanEditor;
        Martes: Serenity.BooleanEditor;
        Miercoles: Serenity.BooleanEditor;
        Jueves: Serenity.BooleanEditor;
        Viernes: Serenity.BooleanEditor;
        Sabado: Serenity.BooleanEditor;
        Domingo: Serenity.BooleanEditor;
        PagFactura: Serenity.IntegerEditor;
    }

    [['ContratoId', () => Serenity.IntegerEditor], ['HotelId', () => Serenity.LookupEditor], ['Desde', () => Serenity.DateEditor], ['Hasta', () => Serenity.DateEditor], ['ServicioId', () => Serenity.LookupEditor], ['UnidadCalculoId', () => Serenity.LookupEditor], ['FrecuenciaId', () => Serenity.LookupEditor], ['TipoImputacionId', () => Serenity.LookupEditor], ['Importe', () => Serenity.DecimalEditor], ['Lunes', () => Serenity.BooleanEditor], ['Martes', () => Serenity.BooleanEditor], ['Miercoles', () => Serenity.BooleanEditor], ['Jueves', () => Serenity.BooleanEditor], ['Viernes', () => Serenity.BooleanEditor], ['Sabado', () => Serenity.BooleanEditor], ['Domingo', () => Serenity.BooleanEditor], ['PagFactura', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(LineasForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

