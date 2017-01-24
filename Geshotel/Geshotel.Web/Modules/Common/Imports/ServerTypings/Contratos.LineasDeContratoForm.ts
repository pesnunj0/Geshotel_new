namespace Geshotel.Contratos {
    export class LineasDeContratoForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.LineasDeContrato';

    }

    export interface LineasDeContratoForm {
        ContratoId: Serenity.IntegerEditor;
        Oferta: Serenity.IntegerEditor;
        Desde: Serenity.DateEditor;
        Hasta: Serenity.DateEditor;
        ServicioId: Serenity.LookupEditor;
        UnidadCalculoId: Serenity.IntegerEditor;
        FrecuenciaId: Serenity.IntegerEditor;
        TipoImputacionId: Serenity.IntegerEditor;
        Importe: Serenity.DecimalEditor;
        N: Serenity.IntegerEditor;
        TipoOfertaId: Serenity.IntegerEditor;
        M: Serenity.DecimalEditor;
        AmbitoOfertaId: Serenity.IntegerEditor;
        Lunes: Serenity.IntegerEditor;
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

    [['ContratoId', () => Serenity.IntegerEditor], ['Oferta', () => Serenity.IntegerEditor], ['Desde', () => Serenity.DateEditor], ['Hasta', () => Serenity.DateEditor], ['ServicioId', () => Serenity.LookupEditor], ['UnidadCalculoId', () => Serenity.IntegerEditor], ['FrecuenciaId', () => Serenity.IntegerEditor], ['TipoImputacionId', () => Serenity.IntegerEditor], ['Importe', () => Serenity.DecimalEditor], ['N', () => Serenity.IntegerEditor], ['TipoOfertaId', () => Serenity.IntegerEditor], ['M', () => Serenity.DecimalEditor], ['AmbitoOfertaId', () => Serenity.IntegerEditor], ['Lunes', () => Serenity.IntegerEditor], ['Martes', () => Serenity.BooleanEditor], ['Miercoles', () => Serenity.BooleanEditor], ['Jueves', () => Serenity.BooleanEditor], ['Viernes', () => Serenity.BooleanEditor], ['Sabado', () => Serenity.BooleanEditor], ['Domingo', () => Serenity.BooleanEditor], ['PagFactura', () => Serenity.IntegerEditor], ['UserId', () => Serenity.IntegerEditor], ['FechaModificacion', () => Serenity.DateEditor]].forEach(x => Object.defineProperty(LineasDeContratoForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

