namespace Geshotel.Contratos {
    export class LineasForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.Lineas';

    }

    export interface LineasForm {
        ContratoId: Serenity.IntegerEditor;
        Oferta: Serenity.BooleanEditor;
        Desde: Serenity.DateEditor;
        Hasta: Serenity.DateEditor;
        ServicioId: Serenity.LookupEditor;
        UnidadCalculoId: Serenity.LookupEditor;
        FrecuenciaId: Serenity.LookupEditor;
        TipoImputacionId: Serenity.LookupEditor;
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
        UserId: Serenity.LookupEditor;
        FechaModificacion: Serenity.DateEditor;
    }

    [['ContratoId', () => Serenity.IntegerEditor], ['Oferta', () => Serenity.BooleanEditor], ['Desde', () => Serenity.DateEditor], ['Hasta', () => Serenity.DateEditor], ['ServicioId', () => Serenity.LookupEditor], ['UnidadCalculoId', () => Serenity.LookupEditor], ['FrecuenciaId', () => Serenity.LookupEditor], ['TipoImputacionId', () => Serenity.LookupEditor], ['Importe', () => Serenity.DecimalEditor], ['N', () => Serenity.IntegerEditor], ['TipoOfertaId', () => Serenity.IntegerEditor], ['M', () => Serenity.DecimalEditor], ['AmbitoOfertaId', () => Serenity.IntegerEditor], ['Lunes', () => Serenity.BooleanEditor], ['Martes', () => Serenity.BooleanEditor], ['Miercoles', () => Serenity.BooleanEditor], ['Jueves', () => Serenity.BooleanEditor], ['Viernes', () => Serenity.BooleanEditor], ['Sabado', () => Serenity.BooleanEditor], ['Domingo', () => Serenity.BooleanEditor], ['PagFactura', () => Serenity.IntegerEditor], ['UserId', () => Serenity.LookupEditor], ['FechaModificacion', () => Serenity.DateEditor]].forEach(x => Object.defineProperty(LineasForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

