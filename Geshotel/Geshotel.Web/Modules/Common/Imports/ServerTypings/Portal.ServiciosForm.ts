namespace Geshotel.Portal {
    export class ServiciosForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.Servicios';

    }

    export interface ServiciosForm {
        NombreServicio: Serenity.StringEditor;
        Abreviatura: Serenity.StringEditor;
        TipoServicioId: Serenity.LookupEditor;
        TipoUnidadCalculoId: Serenity.LookupEditor;
        SwProduccion: Serenity.BooleanEditor;
        SwDescuento: Serenity.BooleanEditor;
        SwAjustes: Serenity.BooleanEditor;
        SwGastos: Serenity.BooleanEditor;
        SwPension: Serenity.BooleanEditor;
        SwRectificativa: Serenity.BooleanEditor;
        ConceptoAceleradorReservasId: Serenity.IntegerEditor;
        SumaServicioId: Serenity.IntegerEditor;
        RestaServicioId: Serenity.IntegerEditor;
        TipoHab: Serenity.IntegerEditor;
        TipoPension: Serenity.IntegerEditor;
    }

    [['NombreServicio', () => Serenity.StringEditor], ['Abreviatura', () => Serenity.StringEditor], ['TipoServicioId', () => Serenity.LookupEditor], ['TipoUnidadCalculoId', () => Serenity.LookupEditor], ['SwProduccion', () => Serenity.BooleanEditor], ['SwDescuento', () => Serenity.BooleanEditor], ['SwAjustes', () => Serenity.BooleanEditor], ['SwGastos', () => Serenity.BooleanEditor], ['SwPension', () => Serenity.BooleanEditor], ['SwRectificativa', () => Serenity.BooleanEditor], ['ConceptoAceleradorReservasId', () => Serenity.IntegerEditor], ['SumaServicioId', () => Serenity.IntegerEditor], ['RestaServicioId', () => Serenity.IntegerEditor], ['TipoHab', () => Serenity.IntegerEditor], ['TipoPension', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(ServiciosForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

