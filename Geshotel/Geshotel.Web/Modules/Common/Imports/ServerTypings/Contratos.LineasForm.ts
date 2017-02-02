

namespace Geshotel.Contratos {
    export class LineasForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.Lineas';
    }

    export interface LineasForm {
        ContratoId: Serenity.IntegerEditor;
        Oferta: Serenity.BooleanEditor;
        Desde: Serenity.DateEditor;
        Hasta: Serenity.DateEditor;
        ServicioId: Serenity.IntegerEditor;
        UnidadCalculoId: Serenity.IntegerEditor;
        FrecuenciaId: Serenity.IntegerEditor;
        TipoImputacionId: Serenity.IntegerEditor;
        Importe: Serenity.DecimalEditor;
        N: Serenity.IntegerEditor;
        TipoOfertaId: Serenity.IntegerEditor;
        M: Serenity.DecimalEditor;
        AmbitoOfertaId: Serenity.IntegerEditor;
        Lunes: Serenity.BooleanEditor;
        Martes: Serenity.BooleanEditor;
        Miercoles: Serenity.BooleanEditor;
        Jueves: Serenity.BooleanEditor;
        Viernes: Serenity.BooleanEditor;
        Sabado: Serenity.BooleanEditor;
        Domingo: Serenity.BooleanEditor;
        PagFactura: Serenity.IntegerEditor;
        UserId: Serenity.IntegerEditor;
        FechaModificacion: Serenity.DateEditor;
    }

    [['LineaContratoId', () => Serenity.IntegerEditor], ['ContratoId', () => Serenity.IntegerEditor], ['Oferta', () => Serenity.BooleanEditor], ['Desde', () => Serenity.DateEditor], ['Hasta', () => Serenity.DateEditor], ['ServicioId', () => Serenity.IntegerEditor], ['UnidadCalculoId', () => Serenity.IntegerEditor], ['FrecuenciaId', () => Serenity.IntegerEditor], ['TipoImputacionId', () => Serenity.IntegerEditor], ['Importe', () => Serenity.DecimalEditor], ['N', () => Serenity.IntegerEditor], ['TipoOfertaId', () => Serenity.IntegerEditor], ['M', () => Serenity.DecimalEditor], ['AmbitoOfertaId', () => Serenity.IntegerEditor], ['Lunes', () => Serenity.BooleanEditor], ['Martes', () => Serenity.BooleanEditor], ['Miercoles', () => Serenity.BooleanEditor], ['Jueves', () => Serenity.BooleanEditor], ['Viernes', () => Serenity.BooleanEditor], ['Sabado', () => Serenity.BooleanEditor], ['Domingo', () => Serenity.BooleanEditor], ['PagFactura', () => Serenity.IntegerEditor], ['UserId', () => Serenity.IntegerEditor], ['FechaModificacion', () => Serenity.DateEditor]].forEach(x => Object.defineProperty(LineasForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}