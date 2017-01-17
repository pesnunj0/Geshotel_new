namespace Geshotel.Portal {
    export class UnidadesCalculoForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.UnidadesCalculo';

    }

    export interface UnidadesCalculoForm {
        Uc: Serenity.StringEditor;
        DescripcionUnidadCalculo: Serenity.StringEditor;
        TipoUnidadCalculoId: Serenity.IntegerEditor;
        Pax: Serenity.IntegerEditor;
        ServicioId: Serenity.IntegerEditor;
        UserId: Serenity.IntegerEditor;
        FechaModificacion: Serenity.DateEditor;
    }

    [['Uc', () => Serenity.StringEditor], ['DescripcionUnidadCalculo', () => Serenity.StringEditor], ['TipoUnidadCalculoId', () => Serenity.IntegerEditor], ['Pax', () => Serenity.IntegerEditor], ['ServicioId', () => Serenity.IntegerEditor], ['UserId', () => Serenity.IntegerEditor], ['FechaModificacion', () => Serenity.DateEditor]].forEach(x => Object.defineProperty(UnidadesCalculoForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

