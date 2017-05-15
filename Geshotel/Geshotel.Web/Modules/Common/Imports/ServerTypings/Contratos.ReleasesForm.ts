namespace Geshotel.Contratos {
    export class ReleasesForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.Releases';

    }

    export interface ReleasesForm {
        ClienteId: Serenity.LookupEditor;
        HotelId: Serenity.LookupEditor;
        FechaDesde: Serenity.DateEditor;
        FechaHasta: Serenity.DateEditor;
        Observaciones: Serenity.StringEditor;
        Dias: Serenity.IntegerEditor;
    }

    [['ClienteId', () => Serenity.LookupEditor], ['HotelId', () => Serenity.LookupEditor], ['FechaDesde', () => Serenity.DateEditor], ['FechaHasta', () => Serenity.DateEditor], ['Observaciones', () => Serenity.StringEditor], ['Dias', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(ReleasesForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

