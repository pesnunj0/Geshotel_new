
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
        ConceptoAceleradorReservasId: Serenity.LookupEditor;
        SumaServicioId: Serenity.LookupEditor;
        RestaServicioId: Serenity.LookupEditor;
        TipoHab: Serenity.LookupEditor;
        TipoPension: Serenity.LookupEditor;
    }

    [['NombreServicio', () => Serenity.StringEditor], ['Abreviatura', () => Serenity.StringEditor], ['TipoServicioId', () => Serenity.LookupEditor], ['TipoUnidadCalculoId', () => Serenity.LookupEditor], ['SwProduccion', () => Serenity.BooleanEditor], ['SwDescuento', () => Serenity.BooleanEditor], ['SwAjustes', () => Serenity.BooleanEditor], ['SwGastos', () => Serenity.BooleanEditor], ['SwPension', () => Serenity.BooleanEditor], ['SwRectificativa', () => Serenity.BooleanEditor], ['ConceptoAceleradorReservasId', () => Serenity.LookupEditor], ['SumaServicioId', () => Serenity.LookupEditor], ['RestaServicioId', () => Serenity.LookupEditor], ['TipoHab', () => Serenity.LookupEditor], ['TipoPension', () => Serenity.LookupEditor]].forEach(x => Object.defineProperty(ServiciosForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

