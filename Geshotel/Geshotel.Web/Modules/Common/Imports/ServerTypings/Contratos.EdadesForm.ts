namespace Geshotel.Contratos {
    export class EdadesForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.Edades';

    }

    export interface EdadesForm {
        HotelId: Serenity.LookupEditor;
        ClienteId: Serenity.LookupEditor;
        FechaDesde: Serenity.DateEditor;
        FechaHasta: Serenity.DateEditor;
        TipoHuespedId: Serenity.LookupEditor;
        EdadMinima: Serenity.IntegerEditor;
        EdadMaxima: Serenity.IntegerEditor;
    }

    [['HotelId', () => Serenity.LookupEditor], ['ClienteId', () => Serenity.LookupEditor], ['FechaDesde', () => Serenity.DateEditor], ['FechaHasta', () => Serenity.DateEditor], ['TipoHuespedId', () => Serenity.LookupEditor], ['EdadMinima', () => Serenity.IntegerEditor], ['EdadMaxima', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(EdadesForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

